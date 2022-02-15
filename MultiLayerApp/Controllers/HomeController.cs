using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MultiLayerApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MultiLayerApp.DAL.Core.Domian.Entities;
using MultiLayerApp.DAL.Core.Interfaces;
using MultiLayerApp.Mappers;

namespace MultiLayerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Phone> _phoneRepository;

        public HomeController(
            ILogger<HomeController> logger,
            IRepository<Phone> phoneRepository)
        {
            _logger = logger;
            _phoneRepository = phoneRepository;
        }

        public IActionResult Index()
        {
            return View(_phoneRepository.GetAll());
        }

        public IActionResult Details(Guid id)
        {
            var phone = _phoneRepository.Get(id);

            if (phone is null)
                return NotFound();

            return View(phone);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PhoneViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var Phone = new Phone();
            var phone = PhoneMapper.MapFromModel(model, Phone);
            try
            {
                _phoneRepository.Create(phone);
            }
            catch (Exception e)
            {
                _logger.LogInformation("Ошибка при создании телефона");
                return BadRequest(e.Message);
            }

            return View(phone);
        }

        public IActionResult Update(Guid id)
        {
            if (id == null)
                return NotFound();
            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<Phone, PhoneViewModel>());
            var mapper = new Mapper(config);
            PhoneViewModel book = mapper.Map<Phone, PhoneViewModel>(_phoneRepository.Get(id));

            return View(book);
        }
        [HttpPost]
        public IActionResult Update(PhoneViewModel Model)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(
                    cfg => cfg.CreateMap<PhoneViewModel, Phone>());
                var mapper = new Mapper(config);
                Phone phone = mapper.Map<PhoneViewModel, Phone>(Model);
                _phoneRepository.Update(phone);
                return RedirectToAction("Index");
            }
            return View(Model);
        }
        public IActionResult Delete(Guid id)
        {
            Phone toDelete = _phoneRepository.Get(id);
            if (toDelete == null)
            {
                return NotFound();
            }

            try
            {
                _phoneRepository.Delete(toDelete);
            }
            catch (Exception e)
            {
                _logger.LogInformation("Ошибка при удалении телефона");
                return BadRequest(e.Message);
            }
            _logger.LogInformation("Телефон удален");
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
