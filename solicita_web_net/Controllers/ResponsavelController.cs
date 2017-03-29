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
    public class ResponsavelController : Controller
    {
        private ModeloDadosSolicita db = new ModeloDadosSolicita();

        // GET: Responsavel
        
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult index()
        {
            return View(db.sol_responsavel.ToList());
        }

        // GET: Responsavel/detalhes/5
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_responsavel sol_responsavel = db.sol_responsavel.Find(id);
            if (sol_responsavel == null)
            {
                return HttpNotFound();
            }
            return View(sol_responsavel);
        }

        // GET: Responsavel/cadastrar
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult cadastrar()
        {
            return View();
        }

        // POST: Responsavel/cadastrar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more detalhes see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult cadastrar([Bind(Include = "sol_responsavel_id,sol_responsavel_nome,sol_responsavel_cargo,sol_responsavel_data_cadastro")] sol_responsavel sol_responsavel)
        {
            if (ModelState.IsValid)
            {
                db.sol_responsavel.Add(sol_responsavel);
                db.SaveChanges();
                return RedirectToAction("index");
            }

            return View(sol_responsavel);
        }

        // GET: Responsavel/alterar/5
        [Authorize]
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult alterar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_responsavel sol_responsavel = db.sol_responsavel.Find(id);
            if (sol_responsavel == null)
            {
                return HttpNotFound();
            }
            return View(sol_responsavel);
        }

        // POST: Responsavel/alterar/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more detalhes see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult alterar([Bind(Include = "sol_responsavel_id,sol_responsavel_nome,sol_responsavel_cargo,sol_responsavel_data_cadastro")] sol_responsavel sol_responsavel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sol_responsavel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(sol_responsavel);
        }

        // GET: Responsavel/excluir/5
        [Authorize]
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult excluir(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_responsavel sol_responsavel = db.sol_responsavel.Find(id);
            if (sol_responsavel == null)
            {
                return HttpNotFound();
            }
            return View(sol_responsavel);
        }

        // POST: Responsavel/excluir/5
        [HttpPost, ActionName("excluir")]
        [Authorize]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult excluirConfirmed(int id)
        {
            sol_responsavel sol_responsavel = db.sol_responsavel.Find(id);
            db.sol_responsavel.Remove(sol_responsavel);
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
