using AutoMapper;
using GssZenicaApp.Interfaces;
using GssZenicaApp.Models;
using GssZenicaApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GssZenicaApp.Controllers
{
    public class StationActivityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StationActivityController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var stationActivities = await _unitOfWork.StationActivityRepository.GetAllStationActivities();
            var stationActivitiesViewModel = _mapper.Map<IEnumerable<ListStationActivityViewModel>>(stationActivities);
            return View(stationActivitiesViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var members = _mapper.Map<IEnumerable<ListMemberViewModel>>(await _unitOfWork.MemberRepository.GetAllMembers());
            var stationActivityAdd = new AddStationActivityViewModel
            {
                MemberList = members.ToList(),
                DateOfActivity = DateTime.Now
            };
            return View(stationActivityAdd);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddStationActivityViewModel model)
        {
            if (ModelState.IsValid)
            {
                var stationActivityAdd = _mapper.Map<StationActivity>(model);
                _unitOfWork.StationActivityRepository.AddStationActivity(stationActivityAdd);
                await _unitOfWork.Complete();
                foreach (var member in model.MemberList)
                {
                    if (member.IsChecked)
                    {
                        await MemberActivity(stationActivityAdd.Id, member.Id);
                    }
                }
                await _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }
        public async Task MemberActivity(int stationActivityId, int memberId)
        {
            AddMemberToActivity(stationActivityId, memberId);
            await IncreaseMemberPresence(memberId);
        }
        public void AddMemberToActivity(int stationActivityId, int memberId)
        {
            var activityMember = new ActivityMember
            {
                StationActivityId = stationActivityId,
                MemberId = memberId
            };
            _unitOfWork.ActivityMemberRepository.AddActivityMember(activityMember);
        }
        public async Task IncreaseMemberPresence(int memberId)
        {
            var memberPresence = await _unitOfWork.MemberRepository.GetMember(memberId);
            memberPresence.PresenceCounter++;
            _unitOfWork.MemberRepository.UpdateMember(memberPresence);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var stationActivity = await _unitOfWork.StationActivityRepository.GetStationActivity(id);
            var stationActivityEdit = _mapper.Map<EditStationActivityViewModel>(stationActivity);
            var allMembers = _mapper.Map<IEnumerable<ListMemberViewModel>>(await _unitOfWork.MemberRepository.GetAllMembers());
            var stationActivityMembers = await _unitOfWork.ActivityMemberRepository.GetActivityMembersById(stationActivity.Id);
            stationActivityEdit.MemberList = GetCheckedMembers(allMembers, stationActivityMembers);
            return View(stationActivityEdit);
        }
        public List<ListMemberViewModel> GetCheckedMembers(IEnumerable<ListMemberViewModel> allMembers, IEnumerable<ActivityMember> stationActivityMembers)
        {
            foreach (var member in allMembers)
            {
                foreach (var activityMember in stationActivityMembers)
                {
                    if (member.Id == activityMember.MemberId)
                    {
                        member.IsChecked = true;
                    }
                }
            }
            return allMembers.ToList();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditStationActivityViewModel model)
        {
            if (ModelState.IsValid)
            {
                var stationActivityEdit = await _unitOfWork.StationActivityRepository.GetStationActivity(model.Id);
                _mapper.Map(model, stationActivityEdit);
                _unitOfWork.StationActivityRepository.UpdateStationActivity(stationActivityEdit);
                await _unitOfWork.Complete();
                await ChangeActivityMember(model.MemberList, stationActivityEdit.Id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit", model);
        }
        public async Task ChangeActivityMember(List<ListMemberViewModel> memberList, int stationActivityId)
        {
            foreach (var member in memberList)
            {
                var activityMember = await _unitOfWork.ActivityMemberRepository.GetMemberFromActivityByIds(member.Id, stationActivityId);
                if (member.IsChecked)
                {
                    if (activityMember == null)
                    {
                        AddMemberToActivity(stationActivityId, member.Id);
                        await IncreaseMemberPresence(member.Id);
                    }
                }
                else
                {
                    if (activityMember != null)
                    {
                        await _unitOfWork.ActivityMemberRepository.DeleteActivityMember(activityMember.Id);
                        await DecreaseMemberPresence(member.Id);
                    }
                }
            }
            await _unitOfWork.Complete();
        }
        public async Task<IActionResult> Delete(int id)
        {
            var activityMembers = await _unitOfWork.ActivityMemberRepository.GetActivityMembersById(id);
            foreach (var activityMember in activityMembers)
            {
                await DecreaseMemberPresence(activityMember.MemberId);
            }
            _unitOfWork.StationActivityRepository.DeleteStationActivity(id);
            await _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
        public async Task DecreaseMemberPresence(int memberId)
        {
            var memberPresence = await _unitOfWork.MemberRepository.GetMember(memberId);
            memberPresence.PresenceCounter--;
            _unitOfWork.MemberRepository.UpdateMember(memberPresence);
        }
    }
}
