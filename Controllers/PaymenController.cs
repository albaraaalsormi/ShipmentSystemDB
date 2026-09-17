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
    public class PaymentController : BaseController
    {
        private readonly IPaymentService _Payment;

        public PaymentController(ILogger<PaymentController> logger, IPaymentService PaymentService)
            : base(logger)
        {
            _Payment = PaymentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var Payment = _Payment.GetAll();
                return HandleResponse(Payment);
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
                var Payment = _Payment.GetById(id);
                return HandleResponse(Payment);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve user with ID: {id}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] PaymentDto PaymentDto)
        {
            try
            {
                if (PaymentDto == null)
                {
                    return BadRequest(new { message = "Invalid user data.", success = false });
                }

                _Payment.Create(PaymentDto);
                return HandleResponse(new { message = "User created successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create user.");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] PaymentDto PaymentDto)
        {
            try
            {
                if (PaymentDto == null)
                {
                    return BadRequest(new { message = "Invalid user data.", success = false });
                }

                _Payment.Update(PaymentDto);
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
                _Payment.Delete(id);

                return HandleResponse(new
                {
                    message = "Payment deleted successfully.",
                    success = true
                });
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to delete payment with ID: {id}.");
            }
        }
    }
}
