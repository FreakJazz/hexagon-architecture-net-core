using Application.Interfaces;
using Application.ViewModels;
using Common.Logs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Services.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        protected readonly ILogger<ExceptionHandler> _logger;
        private readonly IUsersAppService _usersAppService;
        public UserController(ILogger<ExceptionHandler> logger, IUsersAppService userAppService)
        {
            _usersAppService = userAppService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetUserById")]
        [Produces("Application/Json", Type = typeof(IQueryable<UserViewModel>))]
        public IActionResult GetUserById([FromQuery] int UserId)
        {
            var response = new ResponseViewModel();
            try
            {
                var userResult = _usersAppService.GetUserById(UserId);
                if (userResult == null)
                {
                    response.statusCode = 200;
                    response.message = "No existe el usuario";
                    response.ok = false;
                    return StatusCode(StatusCodes.Status200OK, response);
                }
                response.statusCode = 200;
                response.message = "Usuario obtenido con exito";
                response.ok = true;
                response.data = userResult;
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error al consultar el usuario ID {UserId}", UserId);
                response.statusCode = 404;
                response.message = "Ha ocurrido un error al consultar el usuario";
                response.ok = false;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }
        }

        //[HttpGet]
        //[Route("GetAllUsers")]
        //[Produces("Application/Json", Type = typeof(IQueryable<UserViewModel>))]
        //public IActionResult GetAllUsers()
        //{
        //    var response = new ResponseViewModel();
        //    try
        //    {
        //        var userResult = _usersAppService.GetUsers();
        //        if (userResult == null)
        //        {
        //            response.statusCode = 200;
        //            response.message = "No existe el usuario";
        //            response.ok = false;
        //            return StatusCode(StatusCodes.Status200OK, response);
        //        }
        //        response.statusCode = 200;
        //        response.message = "Usuario obtenido con exito";
        //        response.ok = true;
        //        response.data = userResult;
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Ha ocurrido un error al consultar los usuarios");
        //        response.statusCode = 404;
        //        response.message = "Ha ocurrido un error al consultar el usuario";
        //        response.ok = false;
        //        return StatusCode(StatusCodes.Status404NotFound, response);
        //    }

        //}
    }
}
