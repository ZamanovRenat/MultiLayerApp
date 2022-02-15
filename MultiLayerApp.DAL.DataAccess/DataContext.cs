using Microsoft.EntityFrameworkCore;
using MultiLayerApp.DAL.Core.Domian.Entities;

namespace MultiLayerApp.DAL.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }

        public DataContext()
        {
            
        }
        public DataContext(DbContextOptions<DataContext> dbContextOptions)
            : base(dbContextOptions)
        {
            // Database.EnsureCreated();
        }
        //Конфигурирование моделей
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
