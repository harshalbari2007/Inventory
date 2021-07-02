using Backend.Repositories;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;

namespace Inventory.Service
{
    public interface IProductService
    {
        Task<List<Product>> GetProduct();
        Task<int> InsertProduct(Product product);
        Task<int> UpdateProduct(Product product);
        Task<int> DeleteProduct(int productid);
    }
    public class ProductService : IProductService
    {
        IProductRepository productRepository;

        public ProductService(IProductRepository productRepos)
        {
            productRepository = productRepos;
        }

        public async Task<List<Product>> GetProduct()
        {
            return productRepository.GetAll().Where(x => x.IsActive == true).ToList();
        }

        public async Task<int> InsertProduct(Product product)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    await productRepository.Add(product);
                    scope.Complete();
                    return product.ProductId;
                }
                catch (System.Exception ex)
                {
                    scope.Dispose();
                    throw ex;
                }
            }
        }

        public async Task<int> UpdateProduct(Product product)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    Product editproduct = new Product
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        ProductPrice = product.ProductPrice,
                        CreatedDate = DateTime.UtcNow,
                        IsActive = true,
                        ProductDescription = product.ProductDescription
                    };
                    
                    await productRepository.Update(editproduct);
                    scope.Complete();
                    return editproduct.ProductId;
                }
                catch (System.Exception ex)
                {
                    scope.Dispose();
                    throw ex;
                }
            }
        }

        public async Task<int> DeleteProduct(int productid)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var data = productRepository.GetById(productid);
                    await productRepository.Delete(data);
                    scope.Complete();
                    return data.ProductId;
                }
                catch (System.Exception ex)
                {
                    scope.Dispose();
                    throw ex;
                }
            }
        }
    }
}