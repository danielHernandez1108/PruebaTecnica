using Application.Services;
using Api_Prueba_Tecnica.Logic;
using Autofac.Core;
using Dominio.Models;
using Dominio.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Prueba_Tecnica.Controllers
{
    public class LoginController : Controller
    {


        private Response _SetResponse;
        LoginService _service;


        public LoginController(LoginService ServiceLogin)
        {
            _SetResponse = new Response();
            _service = ServiceLogin;
        }


        [HttpPost]
        [Route("Api/Login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var reply = new Reply();
            Console.WriteLine($"Solicitud recibida: {Request.Method} {Request.Path}");
            reply = await _service.Login(user);
            return _SetResponse.GetHttpResponse(reply);
        }


    }
}
