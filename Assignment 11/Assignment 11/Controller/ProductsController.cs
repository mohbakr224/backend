using Asp.Versioning;
using Assignment_11.Models;
using Assignment_11.Pagination;
using Assignment_11.Serivces;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_11.Controllers
{
    /// <summary>
    /// Provides endpoints for managing products.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ProducesResponseType(typeof(Products), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails),StatusCodes.Status400BadRequest)]
    public class ProductsController : ControllerBase
    {
        private readonly ProductServices _productServices;

        public ProductsController(ProductServices productServices)
        {
            _productServices = productServices;
        }

        /// <summary>
        /// Retrieves a paginated list of products with optional filtering and sorting.
        /// </summary>
        /// <param name="pageFilter">
        /// Contains pagination, filtering, and sorting parameters.
        /// </param>
        /// <returns>
        /// A paginated collection of products.
        /// </returns>
        /// <response code="200">Products retrieved successfully.</response>
        [HttpGet]
        [ProducesResponseType(typeof(PageResults<Products>), StatusCodes.Status200OK)]
        public ActionResult<PageResults<Products>> GetProducts([FromQuery] PageFilter pageFilter)
        {
            return Ok(_productServices.filteringProducts(pageFilter));
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="product">
        /// The product to create.
        /// </param>
        /// <returns>
        /// The created product.
        /// </returns>
        /// <response code="200">Product created successfully.</response>
        /// <response code="400">The request body is invalid.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Products), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Products> AddProducts([FromBody] Products product)
        {
            if (product == null)
            {
                return BadRequest("Product is required.");
            }

            return Ok(product);
        }
    }
}