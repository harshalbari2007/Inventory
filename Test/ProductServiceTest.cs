using Backend.Repositories;
using Data.Entity;
using Inventory.Controllers;
using Inventory.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class ProductServiceTest : BaseProductTest
    {
        [TestMethod]
        public async Task When_Get_Product_Data_Async_Response_Status_Ok()
        {
            var productRepository = new ProductRepository(mockContext.Object);

            var productService = new ProductService(productRepository);

            //Act
            var result = await productService.GetProduct();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        public async Task When_Insert_Product_Data_Async_Response_Status_Ok()
        {

            var productService = new ProductService(productRepository.Object);

            Product product = new Product()
            {
                CreatedDate = DateTime.UtcNow,
                IsActive = true,
                ProductDescription = "Product Desc",
                ProductName = "Product NAme",
                ProductPrice = 200
            };


            var result = await productService.InsertProduct(product);

            productRepository.Verify(m => m.Add(It.IsAny<Data.Entity.Product>()), Times.Once);
        }

        [TestMethod]
        public async Task When_Edit_Product_Data_Async_Response_Status_Ok()
        {

            var productService = new ProductService(productRepository.Object);

            Product product = new Product()
            {
                ProductId = 2,
                CreatedDate = DateTime.UtcNow,
                IsActive = true,
                ProductDescription = "Product Desc",
                ProductName = "Product NAme",
                ProductPrice = 200
            };


            var result = await productService.UpdateProduct(product);

            productRepository.Verify(m => m.Update(It.IsAny<Data.Entity.Product>()), Times.Once);
        }

    }
}
