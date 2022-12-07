using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TroptechDonuts.Dominio.Entidades;
using TroptechDonuts.Dominio.Excecoes;
using TroptechDonuts.Dominio.Interfaces;

namespace TroptechDonuts.WebApi.Controllers
{
    [ApiController]
    [Route("api/pedido")]
    public class PedidoController : ControllerBase
    {

        private readonly IPedidoRepositorio _pedidoRepo;

        public PedidoController(IPedidoRepositorio pedidoRepo)
        {
            _pedidoRepo = pedidoRepo;
        }


        [HttpGet]
        public ActionResult GetBuscarTodosPedidos()
        {
            try
            {
                var listaDePedidos= _pedidoRepo.BuscarTodosPedidos();

                return StatusCode(200, listaDePedidos);
            }
            catch (PedidoException e)
            {
                return StatusCode(404, new Resultado(404, e.Message));
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetBuscarPedidoPorId(int id)
        {
            try
            {
                var pedidoBuscado = _pedidoRepo.BuscarPedidoPorId(id);

                return StatusCode(200, pedidoBuscado);
            }
            catch (PedidoException e)
            {
                return StatusCode(404, new Resultado(404, e.Message));
            }
        }

        [HttpGet("detalhe/{id}")]
        public IActionResult GetBuscarDetalhePedidoPorId(int id)
        {
            try
            {
                var pedidoBuscado = _pedidoRepo.BuscarDetalhePedidoPorId(id);

                return StatusCode(200, pedidoBuscado);
            }
            catch (PedidoException e)
            {
                return StatusCode(404, new Resultado(404, e.Message));
            }
        }

        [HttpPost]
        public IActionResult PostCadastrarPedido([FromBody] Pedido pedido)
        {
            try
            {
                _pedidoRepo.CadastrarPedido(pedido);

                return StatusCode(200, new Resultado(200, "O pedido foi cadastrado com sucesso"));
            }
            catch (PedidoException exc)
            {
                return StatusCode(500, new Resultado(500, exc.Message));
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteDeletarPedido([FromRoute] int id)
        {

            try
            {
                _pedidoRepo.DeletarPedido(id);

                return StatusCode(200, new Resultado(200, "O pedido foi removido com sucesso"));
            }
            catch (PedidoException e)
            {
                return StatusCode(404, new Resultado(404, e.Message));
            }
        }

        [HttpPut]
        public IActionResult PutAtualizarPedido([FromBody] Pedido pedidoAtualizado)
        {
            try
            {
                _pedidoRepo.AtualizarPedido(pedidoAtualizado);

                return StatusCode(200, new Resultado(200, "O pedido foi atualizado com sucesso"));
            }
            catch (PedidoException e)
            {
                return StatusCode(404, new Resultado(404, e.Message));
            }
        }


        [HttpPatch]
        [Route("status")]
        public IActionResult PatchAtualizarStatusProduto([FromBody] Pedido pedidoAtualizado)
        {
            try
            {
                _pedidoRepo.AtualizarStatusPedido(pedidoAtualizado);

                return StatusCode(200, new Resultado(200, "O pedido foi atualizado com sucesso"));
            }
            catch (PedidoException e)
            {
                return StatusCode(404, new Resultado(404, e.Message));
            }
        }

    }
}
