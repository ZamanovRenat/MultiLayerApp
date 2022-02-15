using System;
using MultiLayerApp.DAL.DataAccess.Data;

namespace MultiLayerApp.DAL.DataAccess.Initial
{
    public class DataDbInitializer: IDbInitializer

    {
        private readonly DataContext _dataContext;

        public DataDbInitializer(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void InitializeDb()
        {
            _dataContext.Database.EnsureDeleted();
            _dataContext.Database.EnsureCreated();

            _dataContext.AddRange(TestData.Phones);
            _dataContext.SaveChanges();
        }
    }
}
