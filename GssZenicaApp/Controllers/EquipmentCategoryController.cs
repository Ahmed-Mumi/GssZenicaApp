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
    public class EquipmentCategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EquipmentCategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var equipmentCategories = await _unitOfWork.EquipmentCategoryRepository.GetAllEquipmentCategories();
            var equipmentCategoriesViewModel = _mapper.Map<IEnumerable<ListEquipmentCategoryViewModel>>(equipmentCategories);
            return View(equipmentCategoriesViewModel);
        }
        [HttpGet]
        public IActionResult Create(bool isEquipmentView = false)
        {
            var equipmentCategoryAdd = new AddEquipmentCategoryViewModel
            {
                IsFromEquipmentView = isEquipmentView
            };
            return View(equipmentCategoryAdd);
        }
        public async Task<IActionResult> WriteOff(int id, int quantity)
        {
            var stock = await _unitOfWork.StockRepository.GetStockByEquipmentCategoryId(id);
            stock.TotalQuantity -= quantity;
            stock.LiveQuantity -= quantity;
            _unitOfWork.StockRepository.UpdateStock(stock);
            await _unitOfWork.Complete();
            return RedirectToAction("GetAllActiveBorrows");
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddEquipmentCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var equipmentCategoryAdd = _mapper.Map<EquipmentCategory>(model);
                _unitOfWork.EquipmentCategoryRepository.AddEquipmentCategory(equipmentCategoryAdd);
                if (await _unitOfWork.Complete())
                {
                    await CreateNewStock(equipmentCategoryAdd.Id);
                    if (model.IsFromEquipmentView)
                    {
                        return Json(new { isValid = true, redirectToUrl = Url.Action("Create", "Equipment") });
                    }
                    else
                    {
                        return Json(new
                        {
                            isValid = true,
                            view = "#view-AllEquipmentCategory",
                            html = RenderRazorViewHelper.RenderRazorViewToString(this, "_ViewAll", await GetEquipmentCategories())
                        });
                    }
                }
            }
            return RedirectToAction("Create");
        }
        public async Task CreateNewStock(int equipmentCategoryId)
        {
            var stock = new Stock
            {
                EquipmentCategoryId = equipmentCategoryId
            };
            _unitOfWork.StockRepository.AddStock(stock);
            await _unitOfWork.Complete();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var equipmentCategory = await _unitOfWork.EquipmentCategoryRepository.GetEquipmentCategory(id);
            var equipmentCategoryEdit = _mapper.Map<EditEquipmentCategoryViewModel>(equipmentCategory);
            return View(equipmentCategoryEdit);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditEquipmentCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var equipmentCategoryEdit = await _unitOfWork.EquipmentCategoryRepository.GetEquipmentCategory(model.Id);
                _mapper.Map(model, equipmentCategoryEdit);
                _unitOfWork.EquipmentCategoryRepository.UpdateEquipmentCategory(equipmentCategoryEdit);
                if (await _unitOfWork.Complete())
                {
                    return Json(new
                    {
                        isValid = true,
                        view = "#view-AllEquipmentCategory",
                        html = RenderRazorViewHelper.RenderRazorViewToString(this, "_ViewAll", await GetEquipmentCategories())
                    });
                }
            }
            return Json(new { isValid = false, html = RenderRazorViewHelper.RenderRazorViewToString(this, "Edit", model) });
        }
        public async Task<IActionResult> Delete(int id)
        {
            _unitOfWork.EquipmentCategoryRepository.DeleteEquipmentCategory(id);
            await _unitOfWork.Complete();
            return Json(new
            {
                view = "#view-AllEquipmentCategory",
                html = RenderRazorViewHelper.RenderRazorViewToString(this, "_ViewAll", await GetEquipmentCategories())
            });
        }
        public async Task<IEnumerable<ListEquipmentCategoryViewModel>> GetEquipmentCategories()
        {
            var equipmentCategories = await _unitOfWork.EquipmentRepository.GetAllEquipmentCategory();
            return _mapper.Map<IEnumerable<ListEquipmentCategoryViewModel>>(equipmentCategories);
        }
    }
}
