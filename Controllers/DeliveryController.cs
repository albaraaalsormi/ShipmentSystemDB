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
    public class DeliveryController : BaseController
    {
        private readonly IDeliveryService _Delivery;

        public DeliveryController(ILogger<DeliveryController> logger, IDeliveryService DeliveryService)
            : base(logger)
        {
            _Delivery = DeliveryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var Delivery = _Delivery.GetAll();
                return HandleResponse(Delivery);
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
                var Delivery = _Delivery.GetById(id);
                return HandleResponse(Delivery);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve user with ID: {id}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] DeliveryDto DeliveryDto)
        {
            try
            {
                if (DeliveryDto == null)
                {
                    return BadRequest(new { message = "Invalid user data.", success = false });
                }

                _Delivery.Create(DeliveryDto);
                return HandleResponse(new { message = "User created successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create user.");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] DeliveryDto DeliveryDto)
        {
            try
            {
                if (DeliveryDto == null)
                {
                    return BadRequest(new { message = "Invalid user data.", success = false });
                }

                _Delivery.Update(DeliveryDto);
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
                _Delivery.Delete(id);

                return HandleResponse(new
                {
                    message = "Delivery deleted successfully.",
                    success = true
                });
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to delete delivery with ID: {id}.");
            }
        }
    }
}
