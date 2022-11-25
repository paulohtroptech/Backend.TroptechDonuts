using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Troptech.Donuts.Repositorio;
using TroptechDonuts.Dominio.Entidades;
using TroptechDonuts.Dominio.Excecoes;
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
            try
            {
                var listaDeClientes = _clienteRepo.BuscarTodosClientes();

                return StatusCode(200, listaDeClientes);
            }
            catch (ClienteException e)
            {
                return StatusCode(404, new Resultado(404, e.Message));
            }
        }


        [HttpGet("{cpf}")]
        public IActionResult GetBuscarClientePorCpf(string cpf)
        {
            try
            {
                var clienteBuscado = _clienteRepo.BuscarClientePorCpf(cpf);

                return StatusCode(200, clienteBuscado);
            }
            catch (ClienteException e)
            {
                return StatusCode(404, new Resultado(404, e.Message));
            }
        }

        [HttpPost]
        public IActionResult PostCadastrar([FromBody] Cliente cliente)
        {
            try
            {
                _clienteRepo.CadastrarCliente(cliente);

                return StatusCode(200, new Resultado(200, "O cliente foi cadastrado com sucesso"));
            }
            catch (ClienteException exc)
            {
                return StatusCode(500, new Resultado(500, exc.Message));
            }
        }


        [HttpDelete]
        [Route("{cpf}")]
        public IActionResult DeleteDeletar([FromRoute] string cpf)
        {

            try
            {
                _clienteRepo.DeletarCliente(cpf);

                return StatusCode(200, new Resultado(200, "O cliente foi removido com sucesso"));
            }
            catch (ClienteException e)
            {
                return StatusCode(404, new Resultado(404, e.Message));
            }
        }


        [HttpPut]
        public IActionResult PutAtualizarCliente([FromBody] Cliente clienteAtualizado)
        {
            try
            {
                _clienteRepo.AtualizarCliente(clienteAtualizado);

                return StatusCode(200, new Resultado(200, "O cliente foi atualizado com sucesso"));
            }
            catch (ClienteException e)
            {
                return StatusCode(404, new Resultado(404, e.Message));
            }
        }

    }
}
