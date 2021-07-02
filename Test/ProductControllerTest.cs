using Backend.Repositories;
using Data.Entity;
using Inventory.Controllers;
using Inventory.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class ProductControllerTest : BaseProductTest
    {
        [TestMethod]
        public async Task When_Get_Product_Async_Response_Status_Ok()
        {
            var productRepository = new ProductRepository(mockContext.Object);

            var productService = new ProductService(productRepository);

            var ProductController = new ProductController(productService)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new System.Web.Http.HttpConfiguration()
            };

            var result = await ProductController.GetProduct();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task When_Get_Product_Async_Response_Status_Bad_Request()
        {
            var productRepository = new ProductRepository(mockContext.Object);

            var productService = new ProductService(productRepository);

            var ProductController = new ProductController(null)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new System.Web.Http.HttpConfiguration()
            };

            var result = await ProductController.GetProduct();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task When_Insert_Product_Async_Response_Status_Ok()
        {
            var productRepository = new ProductRepository(mockContext.Object);

            var productService = new ProductService(productRepository);

            var ProductController = new ProductController(productService)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new System.Web.Http.HttpConfiguration()
            };

            Product product = new Product()
            {
                CreatedDate = DateTime.UtcNow,
                IsActive = true,
                ProductDescription = "Product Desc",
                ProductName = "Product NAme",
                ProductPrice = 200
            };

            var result = await ProductController.InsertProduct(product);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task When_Insert_Product_Async_Response_Status_Bad_Request()
        {
            var productRepository = new ProductRepository(mockContext.Object);

            var productService = new ProductService(productRepository);

            var ProductController = new ProductController(null)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new System.Web.Http.HttpConfiguration()
            };
            Product product = new Product()
            {
                CreatedDate = DateTime.UtcNow,
                IsActive = true,
                ProductDescription = "Product Desc",
                ProductName = "Product NAme",
                ProductPrice = 200
            };

            var result = await ProductController.InsertProduct(product);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task When_Edit_Product_Async_Response_Status_Ok()
        {
            var productRepository = new ProductRepository(mockContext.Object);

            var productService = new ProductService(productRepository);

            var ProductController = new ProductController(productService)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new System.Web.Http.HttpConfiguration()
            };

            Product product = new Product()
            {
                ProductId = 2,
                CreatedDate = DateTime.UtcNow,
                IsActive = true,
                ProductDescription = "Product Desc",
                ProductName = "Product NAme",
                ProductPrice = 200
            };

            var result = await ProductController.InsertProduct(product);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task When_Edit_Product_Async_Response_Status_Bad_Request()
        {
            var productRepository = new ProductRepository(mockContext.Object);

            var productService = new ProductService(productRepository);

            var ProductController = new ProductController(null)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new System.Web.Http.HttpConfiguration()
            };
            Product product = new Product()
            {
                ProductId = 2,
                CreatedDate = DateTime.UtcNow,
                IsActive = true,
                ProductDescription = "Product Desc",
                ProductName = "Product NAme",
                ProductPrice = 200
            };

            var result = await ProductController.InsertProduct(product);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task When_Delete_Product_Async_Response_Status_Ok()
        {
            var productRepository = new ProductRepository(mockContext.Object);

            var productService = new ProductService(productRepository);

            var ProductController = new ProductController(productService)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new System.Web.Http.HttpConfiguration()
            };

            var result = await ProductController.DeleteProduct(2);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task When_Delete_Product_Async_Response_Status_Bad_Request()
        {
            var productRepository = new ProductRepository(mockContext.Object);

            var productService = new ProductService(productRepository);

            var ProductController = new ProductController(null)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new System.Web.Http.HttpConfiguration()
            };

            var result = await ProductController.DeleteProduct(2);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.BadRequest);
        }
    }
}
