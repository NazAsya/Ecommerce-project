namespace Ecommerce.API.Repositories
{
    public interface IUnitOfWork: IDisposable
    //IDisposable kaynak yönetimi için kullanılan özel bir ara yüzdür. İçinde sadece bir tane Dispose() metodu tanımlar. Dispose() metodu, bir nesnenin işi bittiğinde yönetilen dışındaki (unmanaged) kaynakları temizlemek için çağrılır.
    // Eğer bir sınıf yönetilmeyen kaynakları kullanıyorsa, bunları serbest bırakmak için Dispose() metodunu implement etmelidir.
    //Unit of Work genellikle içinde bir DbContext veya başka veritabanı bağlantı nesneleri tutar. Bu nesneler veritabanı bağlantısı gibi yönetilmeyen kaynaklar içerir. Bu yüzden Unit of Work sınıfı, IDisposable arayüzünü implement eder ve Dispose() metodunda bu kaynakları kapatır, serbest bırakır. Böylece Unit of Work işi bittiğinde çağrılır ve kaynaklar temizlenir, bağlantı açık kalmaz.
    {
        IUserReadRepository UserReadRepository { get; }
        IUserWriteRepository UserWriteRepository { get; }

        IProductReadRepository ProductReadRepository { get; }
        IProductWriteRepository ProductWriteRepository { get; }


        IOrderReadRepository OrderReadRepository { get; }
        IOrderWriteRepository OrderWriteRepository { get; }

        IOrderItemReadRepository OrderItemReadRepository { get; }
        IOrderItemWriteRepository OrderItemWriteRepository { get; }

        ICategoryReadRepository CategoryReadRepository { get; }
        ICategoryWriteRepository CategoryWriteRepository { get; }

        Task<int> CompleteAsync();
        //Burada CompleteAsync(); SaveChangesAsync() görevini yapacak, yani değişiklikleri veritabanı kaydedecek. int tipinde dönüş değeri, etkilenen kayıt sayısını gösterir.

    }
}
