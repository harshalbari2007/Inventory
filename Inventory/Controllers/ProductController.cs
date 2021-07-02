using Data.Entity;
using Inventory.Service;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Inventory.Controllers
{

    public class ProductController : ApiController
    {
        private IProductService productService;

        public ProductController(IProductService productSer)
        {
            productService = productSer;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetProduct()
        {
            try
            {
                var data = await productService.GetProduct();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var httpError = new HttpError() { Message = ex.ToString() };
                return Request.CreateResponse(HttpStatusCode.BadRequest, httpError);
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> InsertProduct(Product product)
        {
            try
            {
                var newId = await productService.InsertProduct(product);
                return Request.CreateResponse(HttpStatusCode.OK, newId);
            }
            catch (Exception ex)
            {
                var httpError = new HttpError() { Message = ex.ToString() };
                return Request.CreateResponse(HttpStatusCode.BadRequest, httpError);
            }
        }

        [HttpPut]
        public async Task<HttpResponseMessage> UpdateProduct(Product product)
        {
            try
            {
                var newId = await productService.UpdateProduct(product);
                return Request.CreateResponse(HttpStatusCode.OK, newId);
            }
            catch (Exception ex)
            {
                var httpError = new HttpError() { Message = ex.ToString() };
                return Request.CreateResponse(HttpStatusCode.BadRequest, httpError);
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteProduct(int productid)
        {
            try
            {
                var newId = await productService.DeleteProduct(productid);
                return Request.CreateResponse(HttpStatusCode.OK, newId);
            }
            catch (Exception ex)
            {
                var httpError = new HttpError() { Message = ex.ToString() };
                return Request.CreateResponse(HttpStatusCode.BadRequest, httpError);
            }
        }
    }
}
