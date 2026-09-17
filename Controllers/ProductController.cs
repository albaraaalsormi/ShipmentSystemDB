using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.DTOs;
using Application.IServices;
using UserManagement.Api.Controllers;
using Application.Services;

namespace UserManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        private readonly IProductService _Product;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
            : base(logger)
        {
            _Product = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var Product = _Product.GetAll();
                return HandleResponse(Product);
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to retrieve users.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var Product = _Product.GetById(id);
                return HandleResponse(Product);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve user with ID: {id}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductDto ProductDto)
        {
            try
            {
                if (ProductDto == null)
                {
                    return BadRequest(new { message = "Invalid user data.", success = false });
                }

                _Product.Create(ProductDto);
                return HandleResponse(new { message = "User created successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create user.");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] ProductDto ProductDto)
        {
            try
            {
                if (ProductDto == null)
                {
                    return BadRequest(new { message = "Invalid user data.", success = false });
                }

                _Product.Update(ProductDto);
                return HandleResponse(new { message = "User updated successfully.", success = true });
            }
            catch (ArgumentNullException)
            {
                return NotFound(new { message = "User not found to update.", success = false });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to update user.");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _Product.Delete(id);

                return HandleResponse(new
                {
                    message = "Product deleted successfully.",
                    success = true
                });
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to delete product with ID: {id}.");
            }
        }
    }
}
