using Microsoft.AspNetCore.Mvc;

namespace ControllerBaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //APiController attribute is used to indicate that this controller will be used to handle API requests.
                    //It provides features such as automatic model validation and binding source inference.
    public class ProductsController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return "Product01";
        }
    }
}
