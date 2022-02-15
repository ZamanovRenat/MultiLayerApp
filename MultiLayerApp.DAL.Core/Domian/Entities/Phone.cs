using MultiLayerApp.DAL.Core.Domian.Entities.Base;

namespace MultiLayerApp.DAL.Core.Domian.Entities
{
    public class Phone : BaseEntity
    {
        public string Name { get; set; }    // название 
        public string Company { get; set; } // производитель
        public int Price { get; set; }  // цена
    }
}
