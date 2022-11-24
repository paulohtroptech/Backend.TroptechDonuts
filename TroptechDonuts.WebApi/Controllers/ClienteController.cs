using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Troptech.Donuts.Repositorio;
using TroptechDonuts.Dominio.Interfaces;

namespace TroptechDonuts.WebApi.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteRepositorio _clienteRepo;

        public ClienteController(IClienteRepositorio clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }

        [HttpGet]
        public ActionResult GetBuscarTodosClientes()
        {
            var listaDeClientes = _clienteRepo.BuscarTodosClientes();

            return StatusCode(200, listaDeClientes);
        }

        //// GET: ClienteController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return StatusCode(500);
        //}

        //// GET: ClienteController/Create
        //public ActionResult Create()
        //{
        //    return StatusCode(500);
        //}

        //// POST: ClienteController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return StatusCode(200);
        //    }
        //    catch
        //    {
        //        return StatusCode(500);
        //    }
        //}

        //// GET: ClienteController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return Ok();
        //}

        //// POST: ClienteController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return StatusCode(200);
        //    }
        //    catch
        //    {
        //        return StatusCode(500);
        //    }
        //}

        //// GET: ClienteController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return StatusCode(200);
        //}
    }
}
