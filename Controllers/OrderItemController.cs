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
    public class OrderItemController : BaseController
    {
        private readonly IOrderItemService _OrderItem;

        public OrderItemController(ILogger<OrderItemController> logger, IOrderItemService OrderItemService)
            : base(logger)
        {
            _OrderItem = OrderItemService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var OrderItem = _OrderItem.GetAll();
                return HandleResponse(OrderItem);
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
                var OrderItem = _OrderItem.GetById(id);
                return HandleResponse(OrderItem);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve user with ID: {id}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] OrderItemDto OrderItemDto)
        {
            try
            {
                if (OrderItemDto == null)
                {
                    return BadRequest(new { message = "Invalid user data.", success = false });
                }

                _OrderItem.Create(OrderItemDto);
                return HandleResponse(new { message = "User created successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create user.");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] OrderItemDto OrderItemDto)
        {
            try
            {
                if (OrderItemDto == null)
                {
                    return BadRequest(new { message = "Invalid user data.", success = false });
                }

                _OrderItem.Update(OrderItemDto);
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
                _OrderItem.Delete(id);

                return HandleResponse(new
                {
                    message = "Order item deleted successfully.",
                    success = true
                });
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to delete order item with ID: {id}.");
            }
        }
        
        }

    }

