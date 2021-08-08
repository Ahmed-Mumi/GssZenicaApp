using AutoMapper;
using GssZenicaApp.Interfaces;
using GssZenicaApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GssZenicaApp.Controllers
{
    public class SkillController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SkillController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var skills = await _unitOfWork.SkillRepository.GetAllSkills();
            var skillsViewModel = _mapper.Map<IEnumerable<ListSkillViewModel>>(skills);
            return View(skillsViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var skill = await _unitOfWork.SkillRepository.GetSkill(id);
            var skillEdit = _mapper.Map<EditSkillViewModel>(skill);
            skillEdit = await PopulateDropdowns(skillEdit);
            return View(skillEdit);
        }
        public async Task<EditSkillViewModel> PopulateDropdowns(EditSkillViewModel skillEdit)
        {
            skillEdit.SkiingCategoryList = new SelectList(await _unitOfWork.SkillRepository.GetAllSkiingCategories(), "Id", "Label");
            skillEdit.DivingCategoryList = new SelectList(await _unitOfWork.SkillRepository.GetAllDivingCategories(), "Id", "Label");
            skillEdit.GuideCategoryList = new SelectList(await _unitOfWork.SkillRepository.GetAllGuideCategories(), "Id", "Label");
            skillEdit.SarCategoryList = new SelectList(await _unitOfWork.SkillRepository.GetAllSarCategories(), "Id", "Label");
            return skillEdit;
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditSkillViewModel model)
        {
            if (ModelState.IsValid)
            {
                var skillEdit = await _unitOfWork.SkillRepository.GetSkill(model.Id);
                _mapper.Map(model, skillEdit);
                _unitOfWork.SkillRepository.UpdateSkill(skillEdit);
                if (await _unitOfWork.Complete())
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Edit", model);
        }
    }
}
