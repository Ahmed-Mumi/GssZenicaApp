using AutoMapper;
using GssZenicaApp.Interfaces;
using GssZenicaApp.Models;
using GssZenicaApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GssZenicaApp.Controllers
{
    public class ReportController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReportController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var reports = await _unitOfWork.ReportRepository.GetAllReports();
            var reportsViewModel = _mapper.Map<IEnumerable<ListReportViewModel>>(reports);
            return View(reportsViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Create(int stationActivityId)
        {
            var reportAdd = new AddReportViewModel
            {
                MemberList = new SelectList(await _unitOfWork.MemberRepository.GetAllMembers(), "Id", "FullName"),
                StationActivityId = stationActivityId
            };
            return View(reportAdd);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddReportViewModel model)
        {
            if (ModelState.IsValid)
            {
                var reportAdd = _mapper.Map<Report>(model);
                _unitOfWork.ReportRepository.AddReport(reportAdd);
                if (await _unitOfWork.Complete())
                {
                    await AddReportIdToStationActivity(model.StationActivityId, reportAdd.Id);
                    return RedirectToAction("Index", "StationActivity");
                }
            }
            return RedirectToAction("Create");
        }
        public async Task AddReportIdToStationActivity(int stationActivityId, int reportId)
        {
            var stationActivity = await _unitOfWork.StationActivityRepository.GetStationActivity(stationActivityId);
            stationActivity.ReportId = reportId;
            _unitOfWork.StationActivityRepository.UpdateStationActivity(stationActivity);
            await _unitOfWork.Complete();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var report = await _unitOfWork.ReportRepository.GetReport(id);
            var reportEdit = _mapper.Map<EditReportViewModel>(report);
            reportEdit.MemberList = new SelectList(await _unitOfWork.MemberRepository.GetAllMembers(), "Id", "FullName");
            return View(reportEdit);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditReportViewModel model)
        {
            if (ModelState.IsValid)
            {
                var reportEdit = await _unitOfWork.ReportRepository.GetReport(model.Id);
                _mapper.Map(model, reportEdit);
                _unitOfWork.ReportRepository.UpdateReport(reportEdit);
                if (await _unitOfWork.Complete())
                {
                    return RedirectToAction("Index", "StationActivity");
                }
            }
            return RedirectToAction("Edit", model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            _unitOfWork.ReportRepository.DeleteReport(id);
            await _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
    }
}
