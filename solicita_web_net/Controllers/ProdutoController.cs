using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using solicita_web_net.Models;

namespace solicita_web_net.Controllers
{
    public class ProdutoController : Controller
    {
        private ModeloDadosSolicita db = new ModeloDadosSolicita();

        // GET: Produto
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult index()
        {
            return View(db.sol_produto.ToList());
        }

        // GET: Produto/Details/5
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_produto sol_produto = db.sol_produto.Find(id);
            if (sol_produto == null)
            {
                return HttpNotFound();
            }
            return View(sol_produto);
        }

        // GET: Produto/cadastrar
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult cadastrar()
        {
            return View();
        }

        // POST: Produto/cadastrar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult cadastrar([Bind(Include = "sol_produto_id,sol_produto_descricao,sol_produto_data_cadastro")] sol_produto sol_produto)
        {
            if (ModelState.IsValid)
            {
                db.sol_produto.Add(sol_produto);
                db.SaveChanges();
                return RedirectToAction("index");
            }

            return View(sol_produto);
        }

        // GET: Produto/alterar/5
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult alterar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_produto sol_produto = db.sol_produto.Find(id);
            if (sol_produto == null)
            {
                return HttpNotFound();
            }
            return View(sol_produto);
        }

        // POST: Produto/alterar/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult alterar([Bind(Include = "sol_produto_id,sol_produto_descricao,sol_produto_data_cadastro")] sol_produto sol_produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sol_produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(sol_produto);
        }

        // GET: Produto/excluir/5
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult excluir(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_produto sol_produto = db.sol_produto.Find(id);
            if (sol_produto == null)
            {
                return HttpNotFound();
            }
            return View(sol_produto);
        }

        // POST: Produto/excluir/5
        [HttpPost, ActionName("excluir")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult excluirConfirmed(int id)
        {
            sol_produto sol_produto = db.sol_produto.Find(id);
            db.sol_produto.Remove(sol_produto);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
