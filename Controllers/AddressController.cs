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
    public class AddressController : BaseController
    {
        private readonly IAddressService _Address;

        public AddressController(ILogger<AddressController> logger, IAddressService AddressService)
            : base(logger)
        {
            _Address = AddressService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var Address = _Address.GetAll();
                return HandleResponse(Address);
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
                var Address = _Address.GetById(id);
                return HandleResponse(Address);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve user with ID: {id}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddressDto AddressDto)
        {
            try
            {
                if (AddressDto == null)
                {
                    return BadRequest(new { message = "Invalid user data.", success = false });
                }

                _Address.Create(AddressDto);
                return HandleResponse(new { message = "User created successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create user.");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] AddressDto AddressDto)
        {
            try
            {
                if (AddressDto == null)
                {
                    return BadRequest(new { message = "Invalid user data.", success = false });
                }

                _Address.Update(AddressDto);
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
                _Address.Delete(id);

                return HandleResponse(new
                {
                    message = "Address deleted successfully.",
                    success = true
                });
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to delete address with ID: {id}.");
            }
        }
    }
}
