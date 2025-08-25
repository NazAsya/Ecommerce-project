using Ecommerce.API.Models;
using Ecommerce.API.Models.Common;
using Ecommerce.API.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;


namespace Ecommerce.API.Repositories
//ReadRepository, verileri okumak için.
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
        //where T : BaseEntity kısmı ile T türünün mutlaka BaseEntity sınıfından türemiş olması şart koşulmuş. Çünkü BaseEntity içinde Id gibi ortak özellikler var. Yani T'nin nereden geldiğini belirtiyor bir bakıma.
    {
        //Bu kısım constructor(kurucu metot) kısmıdır. DI (Dependency Injection) ile dışarıdan AppDbContext nesnesi alınıyor ve _context değişkenine atanıyor.
        private readonly AppDbContext _context;
        public ReadRepository(AppDbContext context)
        {
            _context = context;
         //Bu satırda dışarıdan alınan context parametresi, yukarıda tanımlanan _context alanına atanır. Bu sınıfın içinde _context aracılığıyla AppDbContext kullanılarak veritabanı işlemleri yapılabilir. Yani AppDbContext yazmak yerine direkt olarak _context yazarak işlemleri yapabiliriz.
        }
        
       public DbSet<T> Table => _context.Set<T>();
        // "Context içindeki, T türündeki DbSet'i getir" demek.

        public IQueryable<T> GetAll()
        => Table;
        //Veritabanındaki ilgili tablodaki tüm kayıtları döner. IQueryable olarak döndüğü için sorguya filtre eklemek mümkündür ve veritabanına henüz gitmez.

        public async Task<T> GetByIdAsync(Guid Id)
         => await Table.FirstOrDefaultAsync(data => data.Id == Id);

       //Guid.Parse(Id):Id parametresi string olduğu için bunu veritabanındaki Guid türüyle karşılaştırmak üzere dönüştürür.
        //Table: _context.Set<T>() üzerinden erişilen veritabanı tablosudur (T entity'sine karşılık gelen tablo).
        //FirstOrDefaultAsync: Table içinde, Id alanı Guid.Parse(Id) ile eşleşen ilk veriyi getirir. Eşleşen kayıt yoksa null döner. Asenkron çalıştığı için veritabanını bloklamaz.
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        => await Table.FirstOrDefaultAsync(method);

       //Bu metot, şartlara uyan ilk veriyi asenkron olarak (await ile) veritabanından getirir.
        //Expression<Func<T, bool>> method = “T türündeki nesneler için bir filtre koşulu.” Ama bu sadece bir koşul değil, aynı zamanda veritabanına çevrilebilir bir sorgudur.  Bu yapı SQL’e çevrilebilmek için Expression yapısını ister. Normal Func ile bunu yapamaz.
        //FirstOrDefaultAsync(method): Verilen method koşuluna uyan ilk kaydı getirir, yoksa null döner. Await: Bu işlemin bitmesini bekler, çünkü veritabanıyla iletişim kurar(I/O işlemi)

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        => Table.Where(method);

        
        //Veritabanındaki T tipi nesneleri alır, ve dışarıdan verdiğin şarta (method parametresi) uyanları sorgu olarak döner.
        //Expression<Func<T, bool>> method: Dışarıdan alınan filtre ifadesidir.
        //Where(...) ifadesi, LINQ'in filtreleme metodudur. Method parametresi, filtre koşuludur.



    }
}
