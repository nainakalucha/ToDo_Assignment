using Adform_Todo.Common.Contracts;
using Adform_Todo.Common.Dtos;
using Adform_Todo.Common.Helpers;
using Adform_Todo.Common.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adform_ToDo.Controllers
{
    /// <summary>
    /// User controller.
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserManager _userManager;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        public UserController(ILogger<UserController> logger, IUserManager userService, IOptions<AppSettings> appSettings, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userService;
            _appSettings = appSettings.Value;
        }
        /// <summary>
        /// Takes UserName and Password and generates token on successful authentication. 
        /// </summary>
        /// <param name="loginModel">Conatains UserName,Password </param>
        /// <returns>ApiResponse on User Login </returns>
        [ProducesResponseType(typeof(RequestResponse<string>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            UserDto userDto = await _userManager.AuthenticateUser(loginModel.UserName, loginModel.Password);

            if (userDto != null)
            {
                // On Successful authentication, generate jwt token.
                string token = JwtTokenHelper.GenerateJwtToken(userDto, _appSettings);

                return Ok(
                    new RequestResponse<string>
                    {
                        IsSuccess = true,
                        Result = token,
                        Message = "User Login successful."
                    });
            }
            else
            {
                return BadRequest(
                    new RequestResponse<string>
                    {
                        IsSuccess = false,
                        Result = "User Login failed.",
                        Message = "Username/password is incorrect."
                    });
            }
        }
        /// <summary>
        /// Register users.
        /// </summary>
        /// <param name="createUserModel"></param>
        /// <returns>Api Response based on success/failure.</returns>
        [ProducesResponseType(typeof(RequestResponse<string>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(CreateUserModel createUserModel)
        {
            _logger.LogInformation("Started : Registering User.");
            CreateUserDto userDto = _mapper.Map<CreateUserDto>(createUserModel);
            bool _registrationSuccess = await _userManager.RegisterUser(userDto);
            if (_registrationSuccess)
            {
                return Ok(
                    new RequestResponse<string>
                    {
                        IsSuccess = true,
                        Result = "Success.",
                        Message = "Registration successful."
                    });
            }
            else
            {
                return BadRequest(
                    new RequestResponse<string>
                    {
                        IsSuccess = false,
                        Result = "Fail.",
                        Message = "Some error occurred. Please refresh page and try again."
                    });
            }
        }
    }
}
