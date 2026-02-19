using ControllerBaseApi.Data;
using ControllerBaseApi.Entities;
using ControllerBaseApi.Request;
using ControllerBaseApi.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ControllerBaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //APiController attribute is used to indicate that this controller will be used to handle API requests.
                    //It provides features such as automatic model validation and binding source inference.
    public class ProductsController(ProductRepository _productRepository) : ControllerBase
    {
        /*
         * 1. The [Route("api/[controller]")] attribute defines the route template for the controller.
         * 2. The [ApiController] attribute indicates that this controller will be used to handle API requests, providing features such as automatic model validation and binding source inference.
         * *****************************************************************************************
         * IActionResult: IActionResult is an interface that represents the result of an action method. It allows you to return different types of responses, such as JSON, XML, or a view.
         * ActionResult is a more flexible return type that can represent various HTTP status codes and content types, while returning a specific type (like string) limits the response to that type.
         * ActionResult<T> is a generic version of ActionResult that allows you to specify the type of content being returned, providing better type safety and clarity in your API responses.
         * 
         * 
         * 
         * 
         * 
         * 
         * */

        //Options Method : This method is used to handle HTTP OPTIONS requests,
        //which are typically used by clients to determine the allowed HTTP methods for a specific endpoint.
        //The method returns an HTTP 200 OK response with a header indicating the allowed methods (GET, POST, PUT, DELETE).

        [HttpOptions] //api/products
        public IActionResult Options()
        {
            Response.Headers.Append("Allow", "GET, POST, PUT, DELETE ,HEAD ,PATCH,OPTION");
            return NoContent();
        }


        //Head Method : This method is used to handle HTTP HEAD requests,
        //which are similar to GET requests but do not return a response body.

        [HttpHead("{id:int}")] //api/products/1

        public IActionResult Head(int id)
        {
            return _productRepository.ExistsById(id) ? Ok() : NotFound();
        }

        //Get Method: This method is used to handle HTTP GET requests to retrieve a product by its ID.

        [HttpGet("{id:int}")] //api/products/1
        public ActionResult<ProductResponses> Get(int id)
        {
            var product = _productRepository.GetProductById(id);

            if(product == null) 
                return NotFound();

            return Ok(ProductResponses.FromModel(product));
        }

        [HttpGet]
        public IActionResult Get(int page=1,int pageSize=10)
        {
            page = Math.Max(1,page);
            pageSize = Math.Clamp(pageSize, 1, 100);

            int count = _productRepository.TotalCount();

            var products = _productRepository.GetProductsPage(page, pageSize);

            var pageResult = PageResult<ProductResponses>.Create(
                ProductResponses.FromModelList(products),
                count,
                page,
                pageSize
                );
           return Ok(pageResult);


        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductRequest request)
        {
            if(_productRepository.ExistsByName(request.Name!))
                return Conflict("The Product With Yhis Name Is Already Exist!");

            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
            };
            _productRepository.AddProduct(product);
            return Ok(product);
        }

    }
}