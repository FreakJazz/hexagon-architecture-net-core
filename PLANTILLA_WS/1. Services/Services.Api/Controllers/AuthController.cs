using Common.Logs;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Interfaces;

//*****************************************************************************************************
//                                          SLENDERCODE
// GENERAL TEMPLATE NET CORE HEXAGON ARCHITECTURE WITH SWAGGER
//
// OBJETIVO: Get Token method
// ARCHIVO: AuthController.cs
//*****************************************************************************************************
//     FECHA              AUTOR
//  18Jun2024           Jazmin Rodriguez B            Emisión Inicial
//*****************************************************************************************************


namespace Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        protected readonly ILogger<ExceptionHandler> _logger;
        private readonly IUsersAppService _usersAppService;
        private readonly IPasswordHasherAppService _passwordHasherAppService;

        public AuthController(ILogger<ExceptionHandler> logger, IConfiguration configuration, IUsersAppService userAppService, IPasswordHasherAppService passwordHasherAppService)
        {
            _configuration = configuration;
            _usersAppService = userAppService;
            _passwordHasherAppService = passwordHasherAppService;
            _logger = logger;
        }
        
        [HttpPost]
        [Route("AuthenticateUser")]
        public IActionResult AuthenticateUser([FromBody] loginModel login)
        {
            try
            {
                var response = new ResponseViewModel();
                var user = _usersAppService.GetUserByUsernameAndPassword(login);
                if (user == null)
                {
                    response.statusCode = 404;
                    response.message = "No existe el usuario";
                    response.ok = false;
                    response.data = null;
                    return StatusCode(StatusCodes.Status404NotFound, response);
                }
                if (!_passwordHasherAppService.VerifyPassword(login.password, user.password))
                {
                    response.statusCode = 400;
                    response.message = "Contraseña Incorrecta";
                    response.ok = false;
                    response.data = null;
                    return StatusCode(StatusCodes.Status400BadRequest, response);
                }
                var secretKey = _configuration.GetSection("ConfigKeys").GetSection("jwtKey").Value;
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                var tokenExpiration = DateTime.UtcNow.AddMinutes(int.Parse(_configuration.GetSection("ConfigKeys").GetSection("TimeAuthToken").Value));
                // Crear AuthToken expira cada 10 minutos 
                var jwtAuth = new JwtSecurityToken(
                    claims: BuildClaims(user),
                    expires: tokenExpiration,
                    signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                );
                var Authtoken = new JwtSecurityTokenHandler().WriteToken(jwtAuth);
                var token = new
                {
                    Authtoken,
                    ExpiresAuthToken = tokenExpiration,
                };

                response.statusCode = 200;
                response.message = "Usuario obtenido con exito";
                response.ok = true;
                response.data = token;
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Se produjo un error al procesar la solicitud. " });
            }
        }

        [HttpPost]
        [Route("RegisterUser")]
        public IActionResult RegisterUser([FromBody] UserViewModel register)
        {
            try
            {
                var response = new ResponseViewModel();
                var userHash = new UserViewModel
                {
                    idUser = register.idUser,
                    nameUser = register.nameUser,
                    lastnameUser = register.lastnameUser,
                    email = register.email,
                    password = _passwordHasherAppService.HashPassword(register.password),
                    bornDate = register.bornDate,
                    role = register.role,
                    sex = register.sex,
                    dniUser = register.dniUser
                };
                var user = _usersAppService.RegisterUser(userHash);
                if (user == null)
                {
                    response.statusCode = 404;
                    response.message = "Error al registrar el usuario";
                    response.ok = false;
                    response.data = null;
                    return StatusCode(StatusCodes.Status404NotFound, response);
                }
                var secretKey = _configuration.GetSection("ConfigKeys").GetSection("jwtKey").Value;
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                var tokenExpiration = DateTime.UtcNow.AddMinutes(int.Parse(_configuration.GetSection("ConfigKeys").GetSection("TimeAuthToken").Value));
                
                // Crear AuthToken expira cada 10 minutos 
                var jwtAuth = new JwtSecurityToken(
                    claims: BuildClaims(user),
                    expires: tokenExpiration,
                    signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                );
                var Authtoken = new JwtSecurityTokenHandler().WriteToken(jwtAuth);
                var token = new
                {
                    Authtoken,
                    ExpiresAuthToken = tokenExpiration,
                };
                response.statusCode = 201;
                response.message = "Usuario creado con exito";
                response.ok = true;
                response.data = token;
                return StatusCode(StatusCodes.Status201Created, response);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Se produjo un error al procesar la solicitud. " });
            }
        }

        private Claim[] BuildClaims(UserViewModel register)
        {
            return new[]
            {
                new Claim("idUser", register.idUser.ToString()),
                new Claim("nameUser", register.nameUser),
                new Claim("lastnameUser", register.lastnameUser),
                new Claim("email", register.email),
                new Claim("bornDate", register.bornDate.ToString("yyyy-MM-dd")),
                new Claim("role", register.role),
                new Claim("sex", register.sex),
                new Claim("dniUser", register.dniUser)
            };
        }
    }
}
