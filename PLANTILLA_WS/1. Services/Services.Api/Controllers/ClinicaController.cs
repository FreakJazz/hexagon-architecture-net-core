using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.Services;
using Application.ViewModels;
using Common.Logs;

namespace Services.Api.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicaController : ControllerBase
    {
        protected readonly ILogger<ExceptionHandler> _logger;
        private readonly IClinicaAppService _clinicaAppService;
        public ClinicaController(ILogger<ExceptionHandler> logger, IClinicaAppService clinicaAppService)
        {
            _clinicaAppService = clinicaAppService;
            _logger = logger;
        }
        [HttpGet]
        [Route("GetClinicaById")]
        [Produces("Application/Json", Type = typeof(IQueryable<ClinicaViewModel>))]
        public IActionResult GetClinicaById([FromQuery] int clinicaId)
        {
            var response = new ResponseViewModel();
            try
            {
                var clinicaResult = _clinicaAppService.GetClinicaById(clinicaId);
                if (clinicaResult == null)
                {
                    response.statusCode = 200;
                    response.message = "No existe la clinica";
                    response.ok = false;
                    return StatusCode(StatusCodes.Status200OK, response);
                }
                response.statusCode = 200;
                response.message = "Clinica obtenida con exito";
                response.ok = true;
                response.data = clinicaResult;
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error al consultar la clinica");
                response.statusCode = 404;
                response.message = "Ha ocurrido un error al consultar la clinica";
                response.ok = false;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }
        }
        [HttpPost]
        [Route("AddClinica")]
        [Produces("Application/Json", Type = typeof(IQueryable<ClinicaViewModel>))]
        public IActionResult AddClinica([FromBody] ClinicaViewModel clinicaViewModel)
        {
            var response = new ResponseViewModel();
            try
            {
                var clinicaResult = _clinicaAppService.RegisterClinica(clinicaViewModel);
                if (clinicaResult == null)
                {
                    response.statusCode = 200;
                    response.message = "Error al insertar la clinica";
                    response.ok = false;
                    return StatusCode(StatusCodes.Status200OK, response);
                }
                response.statusCode = 200;
                response.message = "Clinica insertada con exito";
                response.ok = true;
                response.data = clinicaResult;
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error al insertar la clinica");
                response.statusCode = 404;
                response.message = "Ha ocurrido un error al insertar la clinica";
                response.ok = false;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }
        }
        [HttpPut]
        [Route("UpdateClinica")]
        [Produces("Application/Json", Type = typeof(IQueryable<ClinicaViewModel>))]
        public IActionResult UpdateClinica([FromBody] ClinicaViewModel clinicaViewModel)
        {
            var response = new ResponseViewModel();
            try
            {
                var clinicaResult = _clinicaAppService.UpdateClinica(clinicaViewModel);
                if (clinicaResult == null)
                {
                    response.statusCode = 200;
                    response.message = "Error al actualizar la clinica";
                    response.ok = false;
                    return StatusCode(StatusCodes.Status200OK, response);
                }
                response.statusCode = 200;
                response.message = "Clinica actualizada con exito";
                response.ok = true;
                response.data = clinicaResult;
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error al actualizar la clinica");
                response.statusCode = 404;
                response.message = "Ha ocurrido un error al actualizar la clinica";
                response.ok = false;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }
        }
        [HttpDelete]
        [Route("DeleteClinica")]
        [Produces("Application/Json", Type = typeof(IQueryable<ClinicaViewModel>))]
        public IActionResult DeleteClinica([FromQuery] int clinicaId)
        {
            var response = new ResponseViewModel();
            try
            {
                var roleResult = _clinicaAppService.DeleteClinica(clinicaId);
                if (roleResult == 0)
                {
                    response.statusCode = 200;
                    response.message = "Error al eliminar la clinica";
                    response.ok = false;
                    return StatusCode(StatusCodes.Status200OK, response);
                }
                response.statusCode = 200;
                response.message = "Clinica eliminada con exito";
                response.ok = true;
                response.data = roleResult;
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error al eliminar la clinica");
                response.statusCode = 404;
                response.message = "Ha ocurrido un error al eliminar la clinica";
                response.ok = false;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }
        }
    }
}
