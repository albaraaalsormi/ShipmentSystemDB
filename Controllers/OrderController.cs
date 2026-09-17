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
    public class OrderController : BaseController
    {
        private readonly IOrderService _Order;

        public OrderController(ILogger<OrderController> logger, IOrderService OrderService)
            : base(logger)
        {
            _Order = OrderService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var Order = _Order.GetAll();
                return HandleResponse(Order);
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
                var Order = _Order.GetById(id);
                return HandleResponse(Order);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve user with ID: {id}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] OrderDto OrderDto)
        {
            try
            {
                if (OrderDto == null)
                {
                    return BadRequest(new { message = "Invalid user data.", success = false });
                }

                _Order.Create(OrderDto);
                return HandleResponse(new { message = "User created successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create user.");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] OrderDto OrderDto)
        {
            try
            {
                if (OrderDto == null)
                {
                    return BadRequest(new { message = "Invalid user data.", success = false });
                }

                _Order.Update(OrderDto);
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
                _Order.Delete(id);

                return HandleResponse(new
                {
                    message = "Order deleted successfully.",
                    success = true
                });
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to delete order with ID: {id}.");
            }
        }
    }
}
