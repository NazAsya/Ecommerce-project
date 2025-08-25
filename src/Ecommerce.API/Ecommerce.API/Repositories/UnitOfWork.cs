
using Ecommerce.API.Models.Data;

namespace Ecommerce.API.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        //Veritabanı bağlantı nesnesi. 
        public IUserReadRepository UserReadRepository { get; }
        public IUserWriteRepository UserWriteRepository { get; }

        public IProductReadRepository ProductReadRepository { get; }
        public IProductWriteRepository ProductWriteRepository { get; }

        public IOrderReadRepository OrderReadRepository { get; }
        public IOrderWriteRepository OrderWriteRepository { get; }

        public IOrderItemReadRepository OrderItemReadRepository { get; }
        public IOrderItemWriteRepository OrderItemWriteRepository { get; }

        public ICategoryReadRepository CategoryReadRepository { get; }
        public ICategoryWriteRepository CategoryWriteRepository { get; }

        //Yukarıdaki kısımda her repository birer property olarak tanımlanır, sadece okunabilir olur. Böylece dışarıdan erişim sağlanabilir ancak değiştirilmez.

        public UnitOfWork(
            AppDbContext context,
            ICategoryReadRepository categoryReadRepository,
            ICategoryWriteRepository categoryWriteRepository,
            IOrderReadRepository orderReadRepository,
            IOrderWriteRepository orderWriteRepository,
            IOrderItemReadRepository orderItemReadRepository,
            IOrderItemWriteRepository orderItemWriteRepository,
            IProductReadRepository productReadRepository,
            IProductWriteRepository productWriteRepository,
            IUserReadRepository userReadRepository,
            IUserWriteRepository userWriteRepository)
        {
            _context = context;

            CategoryReadRepository = categoryReadRepository;
            CategoryWriteRepository = categoryWriteRepository;

            OrderReadRepository = orderReadRepository;
            OrderWriteRepository = orderWriteRepository;

            OrderItemReadRepository = orderItemReadRepository;
            OrderItemWriteRepository = orderItemWriteRepository;

            ProductReadRepository = productReadRepository;
            ProductWriteRepository = productWriteRepository;

            UserReadRepository = userReadRepository;
            UserWriteRepository = userWriteRepository;
        }
        public async Task<int> CompleteAsync()
        {
         return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
        _context.Dispose();
        }
    }
}
