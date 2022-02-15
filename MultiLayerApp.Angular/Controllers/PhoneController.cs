using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiLayerApp.Angular.Models;
using MultiLayerApp.DAL.Core.Domian.Entities;
using MultiLayerApp.DAL.Core.Interfaces;

namespace MultiLayerApp.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly IRepository<Phone> _phoneRepository;

        public PhoneController(IRepository<Phone> phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }
        [HttpGet]
        public List<PhoneViewModel> GetAll()
        {
            var phones = _phoneRepository.GetAll();

            var phoneModelList = phones.Select(x => new PhoneViewModel()
            {
                Name = x.Name,
                Company = x.Company,
                Price = x.Price,
            }).ToList();

            return phoneModelList;
        }
        [HttpGet("{id:guid}")]
        public ActionResult<PhoneViewModel> GetById(Guid id)
        {
            var phone = _phoneRepository.Get(id);

            if (phone == null)
                return NotFound();

            var phoneModel = new PhoneViewModel()
            {
                Company = phone.Company,
                Name = phone.Name,
                Price = phone.Price,
            };
            return phoneModel;
        }
        [HttpPost]
        public IActionResult Post(Phone phone)
        {
            if (ModelState.IsValid)
            {
                _phoneRepository.Create(phone);
                //db.SaveChanges();
                return Ok(phone);
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Put(Phone phone)
        {
            if (ModelState.IsValid)
            {
                _phoneRepository.Update(phone);
                //db.SaveChanges();
                return Ok(phone);
            }
            return BadRequest(ModelState);
        }
        //[HttpDelete("{id}")]
        //public IActionResult Delete(Guid id)
        //{
        //    Phone phone = _phoneRepository.Delete();.Products.FirstOrDefault(x => x.Id == id);
        //    if (product != null)
        //    {
        //        _phoneRepository..Products.Remove(product);
        //        db.SaveChanges();
        //    }
        //    return Ok(product);
        //}
    }
}
