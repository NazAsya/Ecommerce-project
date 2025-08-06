using Ecommerce.API.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.API.Models
{
    public class Product
    {
      public int Id { get; set; }            // Ürün ID
      public string Name { get; set; }       // Ürün adı
      public decimal Price { get; set; }     // Fiyat-decimal: Tam sayı ve tam sayı olmayan sayıları belirtmek için kullanılan standart sistemdir.
       [Column(TypeName = "decimal(18,2)")]
        public int Stock { get; set; }
       public int CategoryId { get; set; }   
        // Kategoriye bağlanacak ID (FK) Ve her ürünün bir kategori Idsi olabileceğinden Icollection yerine bu şekilde tanımlanır. CategoryId aslında bir Foreign Keydir. Foreign Key Depend entity (kendi başına var olamayan, başka bir tabloya bağımlı olan tabloyu modelleyen entity) ve Principal Entity (Kendi başına var olabilen tabloyu modelleyen entity) arasındaki ilişkiyi sağlayan Keydir. 
        //Burada Principal Entity Category entityidir çünkü bir product ttablosuna ihtiyaç duymadan da kendi başına var olabilir. Depend Entity ise Product entitysidir çünkü category tablosu olmadan var olamaz. Bunların arasındaki ilişkiyi sağlayan ve onları birbirine bağlayan da CategoryId'dir yani bu da oreign Key olur.
        //Principal Key: Principal Entitydeki Id'nin kendisidir. Yani yine CategoryIddir.
        /// <summary>
        //Foreign Key, depent entityde yani burada da olduğu gibi product entitysinde tanımlanır.
        /// </summary>
      public Category Category { get; set; } // Kategori ile ilişki yani aslında navi
    }
}
