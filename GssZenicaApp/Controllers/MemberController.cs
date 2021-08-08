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
    public class MemberController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MemberController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var members = await _unitOfWork.MemberRepository.GetAllMembers();
            var membersViewModel = _mapper.Map<IEnumerable<ListMemberViewModel>>(members);
            return View(membersViewModel);
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var memberAdd = new AddMemberViewModel();
            memberAdd = await PopulateDropdowns(memberAdd);
            return View(memberAdd);
        }
        public async Task<AddMemberViewModel> PopulateDropdowns(AddMemberViewModel memberAdd)
        {
            memberAdd.GenderList = new SelectList(await _unitOfWork.MemberRepository.GetAllGenders(), "Id", "Name");
            memberAdd.BloodTypeList = new SelectList(await _unitOfWork.MemberRepository.GetAllBloodTypes(), "Id", "Label");
            memberAdd.CityList = new SelectList(await _unitOfWork.MemberRepository.GetAllCities(), "Id", "Name");
            memberAdd.MemberTypeList = new SelectList(await _unitOfWork.MemberRepository.GetAllMemberTypes(), "Id", "Name");
            memberAdd.MemberPositionList = new SelectList(await _unitOfWork.MemberRepository.GetAllMemberPositions(), "Id", "Name");
            return memberAdd;
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddMemberViewModel model)
        {
            if (ModelState.IsValid)
            {
                var skillId = await CreateMembersSkill();
                CreateMember(skillId, model);
                if (await _unitOfWork.Complete())
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Create");
        }
        public async Task<int> CreateMembersSkill()
        {
            var skill = new Skill();
            _unitOfWork.SkillRepository.AddSkill(skill);
            await _unitOfWork.Complete();
            return skill.Id;
        }
        public void CreateMember(int skillId, AddMemberViewModel model)
        {
            var memberAdd = _mapper.Map<Member>(model);
            memberAdd.SkillId = skillId;
            _unitOfWork.MemberRepository.AddMember(memberAdd);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var member = await _unitOfWork.MemberRepository.GetMember(id);
            var memberEdit = _mapper.Map<EditMemberViewModel>(member);
            memberEdit = (EditMemberViewModel)await PopulateDropdowns(memberEdit);
            return View(memberEdit);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditMemberViewModel model)
        {
            if (ModelState.IsValid)
            {
                var memberEdit = await _unitOfWork.MemberRepository.GetMember(model.Id);
                _mapper.Map(model, memberEdit);
                _unitOfWork.MemberRepository.UpdateMember(memberEdit);
                if (await _unitOfWork.Complete())
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Edit", model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var member = await _unitOfWork.MemberRepository.GetMember(id);
            var skill = await _unitOfWork.SkillRepository.GetSkill(member.SkillId);
            _unitOfWork.SkillRepository.DeleteSkill(skill.Id);
            _unitOfWork.MemberRepository.DeleteMember(id);
            await _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeActivate(int id)
        {
            var memberDeActivate = await _unitOfWork.MemberRepository.GetMember(id);
            memberDeActivate.IsActive = !memberDeActivate.IsActive;
            _unitOfWork.MemberRepository.UpdateMember(memberDeActivate);
            await _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
    }
}
