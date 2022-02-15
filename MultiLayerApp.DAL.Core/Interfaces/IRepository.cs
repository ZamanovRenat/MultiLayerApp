﻿using System;
using System.Collections.Generic;
using MultiLayerApp.DAL.Core.Domian.Entities.Base;

namespace MultiLayerApp.DAL.Core.Interfaces
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(Guid id);
        void Create(T item);
        void Update(T item);
        void Delete(Guid id);
    }
}
