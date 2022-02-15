using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiLayerApp.DAL.Core.Domian.Entities.Base;
using MultiLayerApp.DAL.Core.Interfaces;

namespace MultiLayerApp.DAL.DataAccess.Repositories
{
    public class EfRepository<T> : IRepository<T>
    where T : BaseEntity
    {
        private readonly DataContext _dataContext;

        public EfRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IEnumerable<T> GetAll()
        {
             return _dataContext.Set<T>().ToList();
        }

        public T Get(Guid id)
        {
            return _dataContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public void Create(T item)
        {
            _dataContext.Set<T>().Add(item);
            _dataContext.SaveChanges();
        }

        public void Update(T item)
        {
            _dataContext.SaveChanges();
        }

        public void Delete(T item)
        {
            _dataContext.Set<T>().Remove(item);
            _dataContext.SaveChanges();
        }
    }
}
