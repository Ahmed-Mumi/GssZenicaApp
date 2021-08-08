using AutoMapper;
using GssZenicaApp.Helpers;
using GssZenicaApp.Interfaces;
using GssZenicaApp.Models;
using GssZenicaApp.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GssZenicaApp.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EquipmentController(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var equipments = await _unitOfWork.EquipmentRepository.GetAllEquipments();
            var equipmentsViewModel = _mapper.Map<IEnumerable<ListEquipmentViewModel>>(equipments);
            return View(equipmentsViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var equipmentAdd = new AddEquipmentViewModel
            {
                MemberList = new SelectList(await _unitOfWork.MemberRepository.GetAllMembers(), "Id", "FullName"),
                EquipmentCategoryList = new SelectList(await _unitOfWork.EquipmentRepository.GetAllEquipmentCategory(), "Id", "Name")
            };
            return View(equipmentAdd);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddEquipmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    model.ReceiptImage = await FileUploadHelper.UploadFileGetDocumentName
                        (_webHostEnvironment.WebRootPath, model.ReceiptImage, model.ImageFile, FileUploadHelper.EquipmentReceipt);
                }
                var equipmentAdd = _mapper.Map<Equipment>(model);
                _unitOfWork.EquipmentRepository.AddEquipment(equipmentAdd);
                await IncreaseStockQuantity(equipmentAdd.EquipmentCategoryId, model.Quantity);
                if (await _unitOfWork.Complete())
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Create");
        }
        public async Task IncreaseStockQuantity(int equipmentCategoryId, int quantity)
        {
            var stock = await _unitOfWork.StockRepository.GetStockByEquipmentCategoryId(equipmentCategoryId);
            stock.LiveQuantity += quantity;
            stock.TotalQuantity += quantity;
            _unitOfWork.StockRepository.UpdateStock(stock);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var equipment = await _unitOfWork.EquipmentRepository.GetEquipment(id);
            var equipmentEdit = _mapper.Map<EditEquipmentViewModel>(equipment);
            equipmentEdit.MemberList = new SelectList(await _unitOfWork.MemberRepository.GetAllMembers(), "Id", "FullName");
            equipmentEdit.EquipmentCategoryList = new SelectList(await _unitOfWork.EquipmentRepository.GetAllEquipmentCategory(), "Id", "Name");
            return View(equipmentEdit);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditEquipmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var equipmentEdit = await _unitOfWork.EquipmentRepository.GetEquipment(model.Id);
                if (model.ImageFile != null)
                {
                    equipmentEdit.ReceiptImage = await FileUploadHelper.UploadFileGetDocumentName
                        (_webHostEnvironment.WebRootPath, equipmentEdit.ReceiptImage, model.ImageFile, FileUploadHelper.EquipmentReceipt);
                }
                _mapper.Map(model, equipmentEdit);
                _unitOfWork.EquipmentRepository.UpdateEquipment(equipmentEdit);
                await DecreaseStockQuantity(equipmentEdit.EquipmentCategoryId, model.OldQuantity);
                await IncreaseStockQuantity(equipmentEdit.EquipmentCategoryId, model.Quantity);
                if (await _unitOfWork.Complete())
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Edit", model);
        }
        public async Task DecreaseStockQuantity(int equipmentCategoryId, int oldQuantity)
        {
            var stock = await _unitOfWork.StockRepository.GetStockByEquipmentCategoryId(equipmentCategoryId);
            stock.LiveQuantity -= oldQuantity;
            stock.TotalQuantity -= oldQuantity;
            _unitOfWork.StockRepository.UpdateStock(stock);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var receiptEquipmentDelete = await _unitOfWork.EquipmentRepository.GetEquipment(id);
            if (!String.IsNullOrEmpty(receiptEquipmentDelete.ReceiptImage))
            {
                FileUploadHelper.RemoveFileHelper(_webHostEnvironment.WebRootPath,
                    receiptEquipmentDelete.ReceiptImage, FileUploadHelper.EquipmentReceipt);
            }
            _unitOfWork.EquipmentRepository.DeleteEquipment(id);
            await _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
    }
}
