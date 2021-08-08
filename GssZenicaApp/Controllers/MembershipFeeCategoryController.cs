using AutoMapper;
using GssZenicaApp.Helpers;
using GssZenicaApp.Interfaces;
using GssZenicaApp.Models;
using GssZenicaApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GssZenicaApp.Controllers
{
    public class MembershipFeeCategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MembershipFeeCategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var membershipFeeCategories = await _unitOfWork.MembershipFeeCategoryRepository.GetAllMembershipFeeCategories();
            var membershipFeeCategoriesViewModel = _mapper.Map<IEnumerable<ListMembershipFeeCategoryViewModel>>(membershipFeeCategories);
            return View(membershipFeeCategoriesViewModel);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new AddMembershipFeeCategoryViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddMembershipFeeCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var membershipFeeCategoryAdd = _mapper.Map<MembershipFeeCategory>(model);
                _unitOfWork.MembershipFeeCategoryRepository.AddMembershipFeeCategory(membershipFeeCategoryAdd);
                if (await _unitOfWork.Complete())
                {
                    return Json(new
                    {
                        isValid = true,
                        view = "#view-all",
                        html = RenderRazorViewHelper.RenderRazorViewToString(this, "_ViewAll", await GetMembershipFeeCategories())
                    });
                }
            }
            return Json(new { isValid = false, html = RenderRazorViewHelper.RenderRazorViewToString(this, "Create", model) });
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var membershipFeeCategory = await _unitOfWork.MembershipFeeCategoryRepository.GetMembershipFeeCategory(id);
            var membershipFeeCategoryEdit = _mapper.Map<EditMembershipFeeCategoryViewModel>(membershipFeeCategory);
            return View(membershipFeeCategoryEdit);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditMembershipFeeCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var membershipFeeCategoryEdit = await _unitOfWork.MembershipFeeCategoryRepository.GetMembershipFeeCategory(model.Id);
                _mapper.Map(model, membershipFeeCategoryEdit);
                _unitOfWork.MembershipFeeCategoryRepository.UpdateMembershipFeeCategory(membershipFeeCategoryEdit);
                if (await _unitOfWork.Complete())
                {
                    return Json(new
                    {
                        isValid = true,
                        view = "#view-all",
                        html = RenderRazorViewHelper.RenderRazorViewToString(this, "_ViewAll", await GetMembershipFeeCategories())
                    });
                }
            }
            return Json(new { isValid = false, html = RenderRazorViewHelper.RenderRazorViewToString(this, "Edit", model) });
        }
        public async Task<IActionResult> Delete(int id)
        {
            _unitOfWork.MembershipFeeCategoryRepository.DeleteMembershipFeeCategory(id);
            await _unitOfWork.Complete();
            return Json(new
            {
                view = "#view-all",
                html = RenderRazorViewHelper.RenderRazorViewToString(this, "_ViewAll", await GetMembershipFeeCategories())
            });
        }
        public async Task<IEnumerable<ListMembershipFeeCategoryViewModel>> GetMembershipFeeCategories()
        {
            var membershipFeeCategories = await _unitOfWork.MembershipFeeCategoryRepository.GetAllMembershipFeeCategories();
            return _mapper.Map<IEnumerable<ListMembershipFeeCategoryViewModel>>(membershipFeeCategories);
        }
    }
}
