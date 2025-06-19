using Dominio.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api_Prueba_Tecnica.Logic
{
    public class Response : ControllerBase
    {

        public IActionResult GetHttpResponse(Reply response)
        {
            switch (response.Status)
            {
                case 200:
                    response.Ok = true;
                    return Ok(response);

                case 201:
                    return Created("", response);

                case 204:
                    response.Ok = true;
                    response.Data = null;
                    return NoContent();

                case 401:
                    response.Ok = false;
                    response.Data = null;
                    return Unauthorized(response);

                case 404:
                    response.Ok = false;
                    response.Data = null;
                    return NotFound(response);
                case 409:
                    response.Ok = false;
                    response.Data = null;
                    return NotFound(response);
                case 400:
                    response.Ok = false;
                    response.Data = null;
                    return NotFound(response);

                case 500:
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = response.Message });

                default:
                    return BadRequest(response);
            };

        }

    }
}