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
    public class CausasController : Controller
    {
        private ModeloDadosSolicita db = new ModeloDadosSolicita();

        // GET: Causas  
        [Authorize(Roles ="ROLE_ADMINISTRADOR")]
        public ActionResult index()
        {
            return View(db.sol_causas.ToList());
        }

        // GET: Causas/detalhes/5
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_causas sol_causas = db.sol_causas.Find(id);
            if (sol_causas == null)
            {
                return HttpNotFound();
            }
            return View(sol_causas);
        }

        // GET: Causas/cadastrar
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult cadastrar()
        {
            return View();
        }

        // POST: Causas/cadastrar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more detalhes see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult cadastrar([Bind(Include = "sol_causa_id,sol_causa_descricao,sol_causa_data_cadastro")] sol_causas sol_causas)
        {
            if (ModelState.IsValid)
            {
                db.sol_causas.Add(sol_causas);
                db.SaveChanges();
                return RedirectToAction("index");
            }

            return View(sol_causas);
        }

        // GET: Causas/alterar/5
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult alterar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_causas sol_causas = db.sol_causas.Find(id);
            if (sol_causas == null)
            {
                return HttpNotFound();
            }
            return View(sol_causas);
        }

        // POST: Causas/alterar/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more detalhes see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult alterar([Bind(Include = "sol_causa_id,sol_causa_descricao,sol_causa_data_cadastro")] sol_causas sol_causas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sol_causas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(sol_causas);
        }


        // GET: Causas/excluir/5
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult excluir(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_causas sol_causas = db.sol_causas.Find(id);
            if (sol_causas == null)
            {
                return HttpNotFound();
            }
            return View(sol_causas);
        }

        // POST: Causas/excluir/5
        [HttpPost, ActionName("excluir")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult excluirConfirmed(int id)
        {
            sol_causas sol_causas = db.sol_causas.Find(id);
            db.sol_causas.Remove(sol_causas);
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
