using Data.Entity;
using Data;

namespace Backend.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {

    }

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
