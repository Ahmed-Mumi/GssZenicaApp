using AutoMapper;
using GssZenicaApp.Helpers;
using GssZenicaApp.Interfaces;
using GssZenicaApp.Models;
using GssZenicaApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GssZenicaApp.Controllers
{
    public class MembershipFeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MembershipFeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var membershipFees = await _unitOfWork.MembershipFeeRepository.GetAllMembershipFees();
            var membershipFeesViewModel = _mapper.Map<IEnumerable<ListMembershipFeeViewModel>>(membershipFees);
            return View(membershipFeesViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var membershipFeeAdd = new AddMembershipFeeViewModel
            {
                MemberList = new SelectList(await _unitOfWork.MemberRepository.GetAllMembers(), "Id", "FullName"),
                MembershipFeeCategoryList = new SelectList(await _unitOfWork.MembershipFeeCategoryRepository
                    .GetAllMembershipFeeCategories(), "Id", "Name"),
            };
            return View(membershipFeeAdd);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddMembershipFeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var membershipFeeAdd = _mapper.Map<MembershipFee>(model);
                _unitOfWork.MembershipFeeRepository.AddMembershipFee(membershipFeeAdd);
                if (await _unitOfWork.Complete())
                {
                    return Json(new
                    {
                        isValid = true,
                        view = "#view-allFees",
                        html = RenderRazorViewHelper.RenderRazorViewToString(this, "_ViewAll", await GetMembershipFees())
                    });
                }
            }
            return Json(new { isValid = false, html = RenderRazorViewHelper.RenderRazorViewToString(this, "Create", model) });
        }
        public async Task<IActionResult> Delete(int id)
        {
            _unitOfWork.MembershipFeeRepository.DeleteMembershipFee(id);
            await _unitOfWork.Complete();
            return Json(new { view = "#view-allFees", html = RenderRazorViewHelper.RenderRazorViewToString(this, "_ViewAll", await GetMembershipFees()) });
        }
        public async Task<IEnumerable<ListMembershipFeeViewModel>> GetMembershipFees()
        {
            var membershipFees = await _unitOfWork.MembershipFeeRepository.GetAllMembershipFees();
            return _mapper.Map<IEnumerable<ListMembershipFeeViewModel>>(membershipFees);
        }
    }
}
