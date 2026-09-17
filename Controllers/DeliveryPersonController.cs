using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.DTOs;
using Application.IServices;
using UserManagement.Api.Controllers;
using Application.Services;
using Domain.Entities;

namespace UserManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryPersonController : BaseController
    {
        private readonly IDeliveryPersonService _DeliveryPerson;

        public DeliveryPersonController(ILogger<DeliveryPersonController> logger, IDeliveryPersonService DeliveryPersonService)
            : base(logger)
        {
            _DeliveryPerson = DeliveryPersonService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var DeliveryPerson = _DeliveryPerson.GetAll();
                return HandleResponse(DeliveryPerson);
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
                var DeliveryPerson = _DeliveryPerson.GetById(id);
                return HandleResponse(DeliveryPerson);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve user with ID: {id}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] DeliveryPersonDto DeliveryPersonDto)
        {
            try
            {
                if (DeliveryPersonDto == null)
                {
                    return BadRequest(new { message = "Invalid user data.", success = false });
                }

                _DeliveryPerson.Create(DeliveryPersonDto);
                return HandleResponse(new { message = "User created successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create user.");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] DeliveryPersonDto DeliveryPersonDto)
        {
            try
            {
                if (DeliveryPersonDto == null)
                {
                    return BadRequest(new { message = "Invalid user data.", success = false });
                }

                _DeliveryPerson.Update(DeliveryPersonDto);
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
                _DeliveryPerson.Delete(id);

                return HandleResponse(new
                {
                    message = "Delivery person deleted successfully.",
                    success = true
                });
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to delete delivery person with ID: {id}.");
            }
        }
    }
}
