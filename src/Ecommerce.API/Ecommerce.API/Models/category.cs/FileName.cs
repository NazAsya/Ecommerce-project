using Ecommerce.API.Models;
using Ecommerce.API.Models.Common;

namespace Ecommerce.API.Models
{
    public class Category: BaseEntity
    {
        public Guid Id { get; set; }                    
        //Kategori ID
        public string Name { get; set; }               
        //Kategori adı
        

        public ICollection<Product> Products { get; set; } = new List<Product>();
        //Bir kategoride birden fazla ürün olabileceğini tanımlar. 
        //1 kategori= NativeOverlapped product
    }
}
