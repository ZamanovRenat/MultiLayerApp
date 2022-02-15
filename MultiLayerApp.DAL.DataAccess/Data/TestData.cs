using System;
using System.Collections.Generic;
using MultiLayerApp.DAL.Core.Domian.Entities;

namespace MultiLayerApp.DAL.DataAccess.Data
{
    public class TestData
    {
        public static IEnumerable<Phone> Phones = new List<Phone>()
        {
            new Phone()
            {
                Id = Guid.Parse("01CF6F35-F4D2-4C78-8557-8EF7E3332CFD"),
                Name = "iPhone 12 128",
                Company = "Apple",
                Price = 64390,
            },
            new Phone()
            {
                Id = Guid.Parse("0DFCDB28-D41C-44FF-992A-27B5812534AB"),
                Name = "iPhone 12 256",
                Company = "Apple",
                Price = 74990,
            },
            new Phone()
            {
                Id = Guid.Parse("30EF3EEB-5EAD-4BA8-823B-FBCACA011C3C"),
                Name = "iPhone 13 128",
                Company = "Apple",
                Price = 74990,
            },
            new Phone()
            {
                Id = Guid.Parse("D6DBD304-7B02-4CF4-A318-B8B5DC11887C"),
                Name = "iPhone 13 256",
                Company = "Apple",
                Price = 84990,
            },
            new Phone()
            {
                Id = Guid.Parse("A7FC7D5E-4C30-40C4-9C6E-1704E7EB0858"),
                Name = "iPhone 13 mini 128",
                Company = "Apple",
                Price = 64390,
            },
            new Phone()
            {
                Id = Guid.Parse("9AB3327D-B854-44B9-98E5-74DD19C73A02"),
                Name = "iPhone 13 Pro 256",
                Company = "Apple",
                Price = 109990,
            },
            new Phone()
            {
                Id = Guid.Parse("ACA4C1A1-385E-4377-A64B-E1324D930B84"),
                Name = "iPhone 13 Pro Max 256",
                Company = "Apple",
                Price = 119990,
            },
        };
    }
}
