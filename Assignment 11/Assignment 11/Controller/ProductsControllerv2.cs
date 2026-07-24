using Asp.Versioning;
using Assignment_11.Models;
using Assignment_11.Pagination;
using Assignment_11.Serivces;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_11.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiExplorerSettings(GroupName ="v2")]
    public class ProductsControllerv2 : ControllerBase
    {
        private readonly ProductServices _productServices;

        public ProductsControllerv2(ProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public string GetProducts([FromQuery] PageFilter pageFilter)
        {
            return "hello world";
        }
    }
}