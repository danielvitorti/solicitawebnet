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
    public class SolicitanteController : Controller
    {
        private ModeloDadosSolicita db = new ModeloDadosSolicita();

        // GET: Solicitante
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult index()
        {
            return View(db.sol_solicitante.ToList());
        }

        // GET: Solicitante/detalhes/5
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_solicitante sol_solicitante = db.sol_solicitante.Find(id);
            if (sol_solicitante == null)
            {
                return HttpNotFound();
            }
            return View(sol_solicitante);
        }

        // GET: Solicitante/cadastrar
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult cadastrar()
        {
            return View();
        }

        // POST: Solicitante/cadastrar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more detalhes see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult cadastrar([Bind(Include = "sol_id,sol_nome,sol_email,sol_foto,sol_telefone,sol_celular,sol_funcao,sol_data_cadastro")] sol_solicitante sol_solicitante)
        {
            if (ModelState.IsValid)
            {
                db.sol_solicitante.Add(sol_solicitante);
                db.SaveChanges();
                return RedirectToAction("index");
            }

            return View(sol_solicitante);
        }

        // GET: Solicitante/alterar/5
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult alterar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_solicitante sol_solicitante = db.sol_solicitante.Find(id);
            if (sol_solicitante == null)
            {
                return HttpNotFound();
            }
            return View(sol_solicitante);
        }

        // POST: Solicitante/alterar/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more detalhes see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult alterar([Bind(Include = "sol_id,sol_nome,sol_email,sol_foto,sol_telefone,sol_celular,sol_funcao,sol_data_cadastro")] sol_solicitante sol_solicitante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sol_solicitante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(sol_solicitante);
        }

        // GET: Solicitante/excluir/5
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult excluir(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_solicitante sol_solicitante = db.sol_solicitante.Find(id);
            if (sol_solicitante == null)
            {
                return HttpNotFound();
            }
            return View(sol_solicitante);
        }

        // POST: Solicitante/excluir/5
        [HttpPost, ActionName("excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult excluirConfirmed(int id)
        {
            sol_solicitante sol_solicitante = db.sol_solicitante.Find(id);
            db.sol_solicitante.Remove(sol_solicitante);
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
