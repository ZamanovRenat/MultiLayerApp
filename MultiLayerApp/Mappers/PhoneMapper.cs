using System;
using MultiLayerApp.DAL.Core.Domian.Entities;
using MultiLayerApp.Models;

namespace MultiLayerApp.Mappers
{
    public class PhoneMapper
    {
        public static Phone MapFromModel(PhoneViewModel model, Phone phone)
        {
            if (phone == null)
            {
                phone = new Phone();
                phone.Id = Guid.NewGuid();
            }

            phone.Name = model.Name;
            phone.Company = model.Company;
            phone.Price = model.Price;

            return phone;
        }
    }
}
