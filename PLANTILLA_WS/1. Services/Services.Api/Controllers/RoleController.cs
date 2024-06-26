using Application.Interfaces;
using Application.Services;
using Application.ViewModels;
using Common.Logs;
using Microsoft.AspNetCore.Mvc;

namespace Services.Api.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        protected readonly ILogger<ExceptionHandler> _logger;
        private readonly IRoleAppService _roleAppService;
        public RoleController(ILogger<ExceptionHandler> logger, IRoleAppService roleAppService)
        {
            _roleAppService = roleAppService;
            _logger = logger;
        }
        [HttpGet]
        [Route("GetRoles")]
        [Produces("Application/Json", Type = typeof(IQueryable<RoleViewModel>))]
        public IActionResult GetRoles()
        {
            var response = new ResponseViewModel();
            try
            {
                var roleResult = _roleAppService.GetRoles();
                if (roleResult == null)
                {
                    response.statusCode = 200;
                    response.message = "No existen roles";
                    response.ok = false;
                    return StatusCode(StatusCodes.Status200OK, response);
                }
                response.statusCode = 200;
                response.message = "Roles obtenidos con exito";
                response.ok = true;
                response.data = roleResult;
                return Ok(response);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Ha ocurrido un error al consultar los roles");
                response.statusCode = 404;
                response.message = "Ha ocurrido un error al consultar los roles";
                response.ok = false;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }
        }

        [HttpPost]
        [Route("AddRole")]
        [Produces("Application/Json", Type = typeof(IQueryable<RoleViewModel>))]
        public IActionResult AddRole([FromBody] RoleViewModel roleViewModel)
        {
            var response = new ResponseViewModel();
            try
            {
                var roleResult = _roleAppService.AddRole(roleViewModel);
                if (roleResult == null)
                {
                    response.statusCode = 200;
                    response.message = "Error al insertar el rol";
                    response.ok = false;
                    return StatusCode(StatusCodes.Status200OK, response);
                }
                response.statusCode = 200;
                response.message = "Rol insertado con exito";
                response.ok = true;
                response.data = roleResult;
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error al insertar el rol");
                response.statusCode = 404;
                response.message = "Ha ocurrido un error al insertar el rol";
                response.ok = false;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }
        }

        [HttpPut]
        [Route("UpdateRole")]
        [Produces("Application/Json", Type = typeof(IQueryable<RoleViewModel>))]
        public IActionResult UpdateRole([FromBody] RoleViewModel roleViewModel)
        {
            var response = new ResponseViewModel();
            try
            {
                var roleResult = _roleAppService.UpdateRole(roleViewModel);
                if (roleResult == null)
                {
                    response.statusCode = 200;
                    response.message = "Error al actualizar el rol";
                    response.ok = false;
                    return StatusCode(StatusCodes.Status200OK, response);
                }
                response.statusCode = 200;
                response.message = "Rol actualizar con exito";
                response.ok = true;
                response.data = roleResult;
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error al actualizar el rol");
                response.statusCode = 404;
                response.message = "Ha ocurrido un error al actualizar el rol";
                response.ok = false;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }
        }
        [HttpDelete]
        [Route("DeleteRole")]
        [Produces("Application/Json", Type = typeof(IQueryable<RoleViewModel>))]
        public IActionResult DeleteRole([FromQuery] int rolId)
        {
            var response = new ResponseViewModel();
            try
            {
                var roleResult = _roleAppService.DeleteRole(rolId);
                if (roleResult == 0)
                {
                    response.statusCode = 200;
                    response.message = "Error al eliminar el rol";
                    response.ok = false;
                    return StatusCode(StatusCodes.Status200OK, response);
                }
                response.statusCode = 200;
                response.message = "Rol eliminado con exito";
                response.ok = true;
                response.data = roleResult;
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error al eliminar el rol");
                response.statusCode = 404;
                response.message = "Ha ocurrido un error al eliminar el rol";
                response.ok = false;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }
        }
    }
}
