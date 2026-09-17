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
    public class UserController : BaseController
    {
        private readonly IUserService _User;

        public UserController(ILogger<UserController> logger, IUserService UserService)
            : base(logger)
        {
            _User = UserService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var User = _User.GetAll();
                return HandleResponse(User);
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
                var User = _User.GetById(id);
                return HandleResponse(User);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve user with ID: {id}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserDto UserDto)
        {
            try
            {
                if (UserDto == null)
                {
                    return BadRequest(new { message = "Invalid user data.", success = false });
                }

                _User.Create(UserDto);

                return HandleResponse(new
                {
                    message = "User created successfully.",
                    success = true
                });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create user.");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] UserDto UserDto)
        {
            try
            {
                if (UserDto == null)
                {
                    return BadRequest(new { message = "Invalid user data.", success = false });
                }

                _User.Update(UserDto);

                return HandleResponse(new
                {
                    message = "User updated successfully.",
                    success = true
                });
            }
            catch (ArgumentNullException)
            {
                return NotFound(new
                {
                    message = "User not found to update.",
                    success = false
                });
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
                _User.Delete(id);

                return HandleResponse(new
                {
                    message = "User deleted successfully.",
                    success = true
                });
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to delete user with ID: {id}.");
            }
        }
    }
}

