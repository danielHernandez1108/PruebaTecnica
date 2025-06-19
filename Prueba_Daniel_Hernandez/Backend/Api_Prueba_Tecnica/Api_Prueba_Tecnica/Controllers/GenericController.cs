using Api_Prueba_Tecnica.Logic;
using Application.Services;
using Dominio.Models;
using Dominio.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Prueba_Tecnica.Controllers
{
    public class GenericController : Controller
    {
        private Response _SetResponse;
        GenericService _service;


        public GenericController(GenericService GenericService)
        {
            _SetResponse = new Response();
            _service = GenericService;
        }


        [HttpGet]
        [Route("Api/GetExams")]
        public async Task<IActionResult> GetExams()
        {
            var reply = new Reply();
            Console.WriteLine($"Solicitud recibida: {Request.Method} {Request.Path}");
            reply = await _service.GetExams();
            return _SetResponse.GetHttpResponse(reply);
        }
    }
}
