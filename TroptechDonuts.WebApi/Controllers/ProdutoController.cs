using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TroptechDonuts.WebApi.Controllers
{
    public class ProdutoController : ControllerBase
    {
        // GET: ProdutoController
        public ActionResult Index()
        {
            return StatusCode(500);
        }

        // GET: ProdutoController/Details/5
        public ActionResult Details(int id)
        {
            return StatusCode(500);
        }

        // GET: ProdutoController/Create
        public ActionResult Create()
        {
            return StatusCode(500);
        }

        // POST: ProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return StatusCode(500);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // GET: ProdutoController/Edit/5
        public ActionResult Edit(int id)
        {
            return StatusCode(500);
        }

        // POST: ProdutoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return StatusCode(500);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // GET: ProdutoController/Delete/5
        public ActionResult Delete(int id)
        {
            return StatusCode(500);
        }

        // POST: ProdutoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return StatusCode(500);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
