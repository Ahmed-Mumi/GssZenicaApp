using AutoMapper;
using GssZenicaApp.Interfaces;
using GssZenicaApp.Models;
using GssZenicaApp.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Reporting.NETCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GssZenicaApp.Controllers
{
    public class BorrowedController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BorrowedController(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllActiveBorrows()
        {
            var borrowedList = await _unitOfWork.BorrowedRepository.GetAllActiveBorrows();
            var borrowedListViewModel = _mapper.Map<IEnumerable<ListBorrowedViewModel>>(borrowedList);
            return View("ActiveBorrows", borrowedListViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllInactiveBorrows()
        {
            var borrowedList = await _unitOfWork.BorrowedRepository.GetAllInactiveBorrows();
            var borrowedListViewModel = _mapper.Map<IEnumerable<ListBorrowedViewModel>>(borrowedList);
            return View("InactiveBorrows", borrowedListViewModel);
        }

        public async Task<IActionResult> ReturnEquipment(int id)
        {
            var borrow = await _unitOfWork.BorrowedRepository.GetBorrow(id);
            UpdateBorrow(borrow);
            await IncreaseLiveQuantityStock(borrow.EquipmentCategoryId, borrow.Quantity);
            await _unitOfWork.Complete();
            return RedirectToAction("GetAllActiveBorrows");
        }

        public void UpdateBorrow(Borrowed borrow)
        {
            borrow.IsActive = false;
            borrow.DateOfReturn = DateTime.Now;
            _unitOfWork.BorrowedRepository.UpdateBorrow(borrow);
        }
        public async Task IncreaseLiveQuantityStock(int equipmentCategoryId, int quantity)
        {
            var stock = await _unitOfWork.StockRepository.GetStockByEquipmentCategoryId(equipmentCategoryId);
            stock.LiveQuantity += quantity;
            _unitOfWork.StockRepository.UpdateStock(stock);
        }
        [HttpGet]
        public async Task<IActionResult> GetEquipmentCategories(int? memberId)
        {
            var equipmentCategories = await _unitOfWork.EquipmentCategoryRepository.GetAllEquipmentCategories();
            var equipmentCategoryViewModel = new BorrowedViewModel()
            {
                EquipmentCategoryList = _mapper.Map<IEnumerable<ListEquipmentCategoryViewModel>>(equipmentCategories),
                MemberList = new SelectList(await _unitOfWork.MemberRepository.GetAllMembers(), "Id", "FullName"),
                MemberId = memberId != null ? memberId.Value : 0
            };
            return View("BorrowEquipmentCategory", equipmentCategoryViewModel);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(int equipmentCategoryId, int memberId, int quantity)
        {
            if (ModelState.IsValid)
            {
                await BorrowEquipment(equipmentCategoryId, memberId, quantity);
                await DecreaseLiveQuantityStock(equipmentCategoryId, quantity);
                if (await _unitOfWork.Complete())
                {
                    return RedirectToAction("GetEquipmentCategories", "Borrowed", new { memberId = memberId });
                }
            }
            return RedirectToAction("Create");
        }
        public async Task BorrowEquipment(int equipmentCategoryId, int memberId, int quantity)
        {
            int lastIdNumber = await _unitOfWork.BorrowedRepository.GetLastBorrowId() + 1;
            var borrowedAdd = new Borrowed()
            {
                BorrowNumber = "Z-" + lastIdNumber.ToString(),
                DateOfBorrow = DateTime.Now,
                MemberId = memberId,
                EquipmentCategoryId = equipmentCategoryId,
                Quantity = quantity,
                IsActive = true,
                DateOfNecessaryReturn = DateTime.Now.AddDays(2)
            };
            _unitOfWork.BorrowedRepository.AddBorrow(borrowedAdd);
        }
        public async Task DecreaseLiveQuantityStock(int equipmentCategoryId, int quantity)
        {
            var stock = await _unitOfWork.StockRepository.GetStockByEquipmentCategoryId(equipmentCategoryId);
            stock.LiveQuantity -= quantity;
            _unitOfWork.StockRepository.UpdateStock(stock);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.BorrowedRepository.DeleteBorrow(id);
            await _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> PrintBorrowed(int memberId)
        {
            var report = new LocalReport();
            report = await GetBorrowInformations(memberId, report);
            report = await GetMembersBorrowsTabel(memberId, report);
            var pdf = report.Render("PDF");
            return File(pdf, "application/pdf", "report.pdf");
        }
        public async Task<LocalReport> GetMembersBorrowsTabel(int memberId, LocalReport report)
        {
            var memberBorrows = _mapper.Map<IEnumerable<ListBorrowedViewModel>>
                (await _unitOfWork.BorrowedRepository.GetMembersActiveBorrows(memberId));
            report.DataSources.Add(new ReportDataSource("dsBorrowed", memberBorrows));
            return report;
        }
        public async Task<LocalReport> GetBorrowInformations(int memberId, LocalReport report)
        {
            var borrowInfoToPrint = new BorrowInfoToPrintViewModel
            {
                UserName = "Ahmed", //biće od logiranog korisnika
                MemberName = await _unitOfWork.MemberRepository.GetMemberName(memberId),
                DateOfReport = DateTime.Now
            };
            report.ReportPath = $"{this._webHostEnvironment.WebRootPath}\\Reports\\rprtBorrow.rdlc";
            report.SetParameters(PopulateParameters(borrowInfoToPrint));
            return report;
        }
        public ReportParameter[] PopulateParameters(BorrowInfoToPrintViewModel borrowInfoToPrintViewModel)
        {
            var dateOfReport = borrowInfoToPrintViewModel.DateOfReport.ToString("dd/MM/yyyy");
            var parameters = new[] { new ReportParameter("DateOfReport", dateOfReport),
                                     new ReportParameter("MemberName", borrowInfoToPrintViewModel.MemberName),
                                     new ReportParameter("UserName", borrowInfoToPrintViewModel.UserName) };
            return parameters;
        }
    }
}
