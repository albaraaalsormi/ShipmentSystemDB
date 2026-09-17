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
    public class ShipmentController : BaseController
    {
        private readonly IShipmentService _Shipment;

        public ShipmentController(ILogger<ShipmentController> logger, IShipmentService ShipmentService)
            : base(logger)
        {
            _Shipment = ShipmentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var Shipment = _Shipment.GetAll();
                return HandleResponse(Shipment);
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
                var Shipment = _Shipment.GetById(id);
                return HandleResponse(Shipment);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve user with ID: {id}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ShipmentDto ShipmentDto)
        {
            try
            {
                if (ShipmentDto == null)
                {
                    return BadRequest(new { message = "Invalid user data.", success = false });
                }

                _Shipment.Create(ShipmentDto);
                return HandleResponse(new { message = "User created successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create user.");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] ShipmentDto ShipmentDto)
        {
            try
            {
                if (ShipmentDto == null)
                {
                    return BadRequest(new { message = "Invalid user data.", success = false });
                }

                _Shipment.Update(ShipmentDto);
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
                _Shipment.Delete(id);

                return HandleResponse(new
                {
                    message = "Shipment deleted successfully.",
                    success = true
                });
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to delete shipment with ID: {id}.");
            }
        }
    }
}
