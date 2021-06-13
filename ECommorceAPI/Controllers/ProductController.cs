using ECommerce.Service.Interface;
using ECommerce.Service.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommorce.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly ILogger<ProductController> logger;
        public ProductController(IProductService _productService, ILogger<ProductController> _logger)
        {
            productService = _productService;
            logger = _logger;
        }

        [HttpGet]
        [ActionName("GetAttributeLookups")]
        public async Task<IActionResult> GetAttributeLookups()
        {
            try
            {
                var result = await productService.GetAttributeLookup();
                return Ok(result);
            }
            catch (Exception ex)
            {
                //added comment
                logger.LogError(new EventId(500), ex, "Error while processing request {0}", ex);
                return StatusCode(500);
            }
        }


        [HttpGet]
        [ActionName("GetProductCategory")]
        public async Task<IActionResult> GetProductCategory()
        {
            var result = await productService.GetProductCategory();
            return Ok(result);
        }

        [HttpGet]
        [ActionName("GetProductDetails")]
        public async Task<IActionResult> GetProductDetails([FromQuery] ProductRequest productRequest)
        {
            try
            {
                var result = await productService.GetProductDetails(productRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //added comment
                logger.LogError(new EventId(500), ex, "Error while processing request {0}", ex);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [ActionName("GetProductDetailsById")]
        public async Task<IActionResult> GetProductDetailsById([FromQuery] int Id)
        {
            try
            {
                var result = await productService.GetProductDetailsById(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //added comment
                logger.LogError(new EventId(500), ex, "Error while processing request {0}", ex);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [ActionName("GetProductAttribute")]
        public async Task<IActionResult> GetProductAttribute([FromQuery] string attributeId)
        {
            try
            {
                var result = await productService.GetProductAttribute(Convert.ToInt32(attributeId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                //added comment
                logger.LogError(new EventId(500), ex, "Error while processing request {0}", ex);
                return StatusCode(500);
            }

        }

        [HttpGet]
        [ActionName("GetProductAttributeLoockupName")]
        public async Task<IActionResult> GetProductAttributeLoockupName([FromQuery] string categoryId)
        {
            try
            {
                var result = await productService.GetProductAttributeLookup(Convert.ToInt32(categoryId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                //added comment
                logger.LogError(new EventId(500), ex, "Error while processing request {0}", ex);
                return StatusCode(500);
            }

        }

        [HttpPost]
        [ActionName("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] AddUpdateProductViewModel addUpdateProductViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                var result = await productService.AddProduct(addUpdateProductViewModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //added comment
                logger.LogError(new EventId(500), ex, "Error while processing request {0}", ex);
                return StatusCode(500);
            }

        }
        [HttpPut]
        [ActionName("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] AddUpdateProductViewModel addUpdateProductViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                var result = await productService.UpdateProduct(addUpdateProductViewModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //added comment
                logger.LogError(new EventId(500), ex, "Error while processing request {0}", ex);
                return StatusCode(500);
            }

        }

    }
}
