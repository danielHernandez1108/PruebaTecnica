using Api_Prueba_Tecnica.Logic;
using Application.Services;
using Autofac.Core;
using Dominio.Models;
using Dominio.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Prueba_Tecnica.Controllers
{
    public class CreateOrderController : Controller
    {

        private Response _SetResponse;
        OrderService _service;


        public CreateOrderController(OrderService OrderService)
        {
            _SetResponse = new Response();
            _service = OrderService;
        }
        [HttpPost]
        [Route("Api/CreateOrder")]
        public async Task<IActionResult> CreateOrder1([FromBody] Orders orders)
        {
            Console.WriteLine($"Solicitud recibida: {Request.Method} {Request.Path}");
            var reply = new Reply();
            reply = await _service.CreateOrders(orders);
            return _SetResponse.GetHttpResponse(reply);
        }


        [HttpGet]
        [Route("Api/ConsultOrder")]
        public async Task<IActionResult> CreateOrder()
        {
            Console.WriteLine($"Solicitud recibida: {Request.Method} {Request.Path}");
            var reply = new Reply();
            reply = await _service.ConsultOrder();
            return _SetResponse.GetHttpResponse(reply);
        }
    }
}
