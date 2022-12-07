using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TroptechDonuts.Dominio.Entidades;
using TroptechDonuts.Dominio.Excecoes;
using TroptechDonuts.Dominio.Interfaces;

namespace TroptechDonuts.WebApi.Controllers
{

    [ApiController]
    [Route("api/produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepo;

        public ProdutoController(IProdutoRepositorio produtoRepo)
        {
            _produtoRepo = produtoRepo;
        }


        [HttpGet]
        public ActionResult GetBuscarTodosProdutos()
        {
            try
            {
                var listaDeProdutos = _produtoRepo.BuscarTodosProdutos();

                return StatusCode(200, listaDeProdutos);
            }
            catch (ProdutoException e)
            {
                return StatusCode(404, new Resultado(404, e.Message));
            }
        }
        [HttpGet]
        [Route("ativo")]
        public ActionResult GetBuscarTodosProdutosAtivos()
        {
            try
            {
                var listaDeProdutos = _produtoRepo.BuscarTodosProdutosAtivos();

                return StatusCode(200, listaDeProdutos);
            }
            catch (ProdutoException e)
            {
                return StatusCode(404, new Resultado(404, e.Message));
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetBuscarProdutoPorId(int id)
        {
            try
            {
                var produtoBuscado = _produtoRepo.BuscarProdutoPorId(id);

                return StatusCode(200, produtoBuscado);
            }
            catch (ProdutoException e)
            {
                return StatusCode(404, new Resultado(404, e.Message));
            }
        }

        [HttpPost]
        public IActionResult PostCadastrarProduto([FromBody] Produto produto)
        {
            try
            {
                _produtoRepo.CadastrarProduto(produto);

                return StatusCode(200, new Resultado(200, "O produto foi cadastrado com sucesso"));
            }
            catch (ProdutoException exc)
            {
                return StatusCode(500, new Resultado(500, exc.Message));
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteDeletarProduto([FromRoute] int id)
        {

            try
            {
                _produtoRepo.DeletarProduto(id);

                return StatusCode(200, new Resultado(200, "O produto foi removido com sucesso"));
            }
            catch (ProdutoException e)
            {
                return StatusCode(404, new Resultado(404, e.Message));
            }
        }

        [HttpPut]
        public IActionResult PutAtualizarProduto([FromBody] Produto produtoAtualizado)
        {
            try
            {
                _produtoRepo.AtualizarProduto(produtoAtualizado);

                return StatusCode(200, new Resultado(200, "O produto foi atualizado com sucesso"));
            }
            catch (ProdutoException e)
            {
                return StatusCode(404, new Resultado(404, e.Message));
            }
        }


        [HttpPatch]
        [Route("status")]
        public IActionResult PatchAtualizarStatusProduto([FromBody] Produto produtoAtualizado)
        {
            try
            {
                _produtoRepo.AtualizarStatusProduto(produtoAtualizado);

                return StatusCode(200, new Resultado(200, "O produto foi atualizado com sucesso"));
            }
            catch (ProdutoException e)
            {
                return StatusCode(404, new Resultado(404, e.Message));
            }
        }

        [HttpPatch]
        [Route("quantidade")]
        public IActionResult PatchAtualizarQuantidadeProduto([FromBody] Produto produtoAtualizado)
        {
            try
            {
                _produtoRepo.AtualizarQuantidadeProduto(produtoAtualizado);

                return StatusCode(200, new Resultado(200, "O produto foi atualizado com sucesso"));
            }
            catch (ProdutoException e)
            {
                return StatusCode(404, new Resultado(404, e.Message));
            }
        }




    }
}
