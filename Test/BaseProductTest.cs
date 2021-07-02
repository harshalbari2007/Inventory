using Backend.Repositories;
using Data;
using Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class BaseProductTest
    {
        protected Mock<IProductRepository> productRepository;
        protected Mock<DatabaseContext> mockContext;

        [TestInitialize]
        public void Setup()
        {

            var Product = new List<Product>() {
                new Product() { ProductId = 1, ProductName = "Product A",ProductDescription="Product Desc A", ProductPrice = 200 , CreatedDate=DateTime.UtcNow,IsActive=true },
                new Product() { ProductId = 2, ProductName = "Product B",ProductDescription="Product Desc B", ProductPrice = 400 , CreatedDate=DateTime.UtcNow,IsActive=true },
            };

            var ProductQueryable = Product.AsQueryable();
            Mock<DbSet<Product>> ProductMockSet = new Mock<DbSet<Product>>();
            ProductMockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(ProductQueryable.Expression);
            ProductMockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(ProductQueryable.ElementType);
            ProductMockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(ProductQueryable.GetEnumerator);

            productRepository = new Mock<IProductRepository>();
            productRepository.Setup(d => d.Add(It.IsAny<Data.Entity.Product>())).Returns(Task.FromResult(new Data.Entity.Product()));
            productRepository.Setup(d => d.Update(It.IsAny<Data.Entity.Product>())).Returns(Task.FromResult(new Data.Entity.Product()));
            productRepository.Setup(d => d.Delete(It.IsAny<Data.Entity.Product>())).Returns(Task.FromResult(new Data.Entity.Product()));
            productRepository.Setup(d => d.GetById(It.IsAny<long>())).Returns((long i) => Product.Where(u => u.ProductId == i).Single());
            productRepository.Setup(d => d.GetAll()).Returns(Product);

            mockContext = new Mock<DatabaseContext>();

            mockContext.Setup(x => x.Set<Product>()).Returns(ProductMockSet.Object);
        }
    }
}
