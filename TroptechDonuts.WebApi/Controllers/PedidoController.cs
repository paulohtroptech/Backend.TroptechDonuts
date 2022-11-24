using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TroptechDonuts.WebApi.Controllers
{
    public class PedidoController : ControllerBase
    {
        // GET: PedidoController
        public ActionResult Index()
        {
            return StatusCode(500);
        }

        // GET: PedidoController/Details/5
        public ActionResult Details(int id)
        {
            return StatusCode(500);
        }

        // GET: PedidoController/Create
        public ActionResult Create()
        {
            return StatusCode(500);
        }

        // POST: PedidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // GET: PedidoController/Edit/5
        public ActionResult Edit(int id)
        {
            return StatusCode(500);
        }

        // POST: PedidoController/Edit/5
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

        // GET: PedidoController/Delete/5
        public ActionResult Delete(int id)
        {
            return StatusCode(500);
        }

        // POST: PedidoController/Delete/5
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
