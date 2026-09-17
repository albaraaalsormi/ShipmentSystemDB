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
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _Customer;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService CustomerService)
            : base(logger)
        {
            _Customer = CustomerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var Customer = _Customer.GetAll();
                return HandleResponse(Customer);
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
                var Customer = _Customer.GetById(id);
                return HandleResponse(Customer);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve user with ID: {id}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CustomerDto CustomerDto)
        {
            try
            {
                if (CustomerDto == null)
                {
                    return BadRequest(new { message = "Invalid user data.", success = false });
                }

                _Customer.Create(CustomerDto);
                return HandleResponse(new { message = "User created successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create user.");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] CustomerDto CustomerDto)
        {
            try
            {
                if (CustomerDto == null)
                {
                    return BadRequest(new { message = "Invalid user data.", success = false });
                }

                _Customer.Update(CustomerDto);
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
                _Customer.Delete(id);

                return HandleResponse(new
                {
                    message = "Customer deleted successfully.",
                    success = true
                });
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to delete customer with ID: {id}.");
            }
        }
    }
}
