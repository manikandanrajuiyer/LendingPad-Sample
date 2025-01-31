using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Core.Services.Products;
using Core.Services.Users;

using WebApi.Models.Products;
using WebApi.Models.Users;

namespace WebApi.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : BaseApiController
    {
        private readonly ICreateProductService _productService;
        private readonly IDeleteProductService _deleteProductService;
        private readonly IGetProductService _getProductService;
        private readonly IUpdateProductService _updateProductService;

        public ProductsController(ICreateProductService productService, IDeleteProductService deleteProductService, IGetProductService getProductService, IUpdateProductService updateProductService)
        {
            _productService = productService;
            _deleteProductService = deleteProductService;
            _getProductService = getProductService;
            _updateProductService = updateProductService;
        }

        [Route("{productId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage Add(Guid productId, [FromBody] ProductModel model)
        {
            var product = _getProductService.GetProduct(productId);

            if (product != null)
            {
                return Conflict($"Product with Id:{productId} already exists");
            }

            product = _productService.Add(productId, model.Name, model.Description, model.Price, model.Category);
            return Found(new ProductData(product));
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage GetProduct()
        {
            var product = _getProductService.GetAllProducts()
                .Select(p => new ProductData(p));

            return Found(product);
        }

        [Route("{productId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetProductById(Guid productId)
        {
            var product = _getProductService.GetProduct(productId);

            if(product is null)
            {
                return DoesNotExist();
            }
            return Found(new ProductData(product));
        }

        [Route("list/category/{category}")]
        [HttpGet]
        public HttpResponseMessage GetProductByCategory(string category)
        {
            var product = _getProductService.GetAllProductsByCategory(category)
                           .Select(p => new ProductData(p)).ToList();

            return Found(product);
        }

        [Route("{productId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateProduct(Guid productId, [FromBody] ProductModel model)
        {
            var product = _getProductService.GetProduct(productId);

            if (product is null)
            {
                return DoesNotExist();
            }

            _updateProductService.Update(product, model.Name, model.Description, model.Price, model.Category);
            
            return Found(new ProductData(product));
        }



        [Route("{productId:guid}")]
        [HttpDelete]
        public HttpResponseMessage Delete(Guid productId)
        {
            var product = _getProductService.GetProduct(productId);

            if (product is null)
            {
                return DoesNotExist();
            }

            _deleteProductService.Delete(productId);

            return NoContent();
        }

    }
}