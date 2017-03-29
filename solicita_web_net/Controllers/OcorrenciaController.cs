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
    public class OcorrenciaController : Controller
    {
        private ModeloDadosSolicita db = new ModeloDadosSolicita();

        // GET: Ocorrencia
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult index()
        {
            return View(db.sol_ocorrencia.ToList());
        }

        // GET: Ocorrencia/detalhes/5
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult detalhes(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_ocorrencia sol_ocorrencia = db.sol_ocorrencia.Find(id);
            if (sol_ocorrencia == null)
            {
                return HttpNotFound();
            }
            return View(sol_ocorrencia);
        }

        // GET: Ocorrencia/cadastrar
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult cadastrar()
        {
            return View();
        }

        // POST: Ocorrencia/cadastrar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more detalhes see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult cadastrar([Bind(Include = "sol_ocorrencia_id,sol_ocorrencia_descricao,sol_ocorrencia_data_cadastro")] sol_ocorrencia sol_ocorrencia)
        {
            if (ModelState.IsValid)
            {
                db.sol_ocorrencia.Add(sol_ocorrencia);
                db.SaveChanges();
                return RedirectToAction("index");
            }

            return View(sol_ocorrencia);
        }

        // GET: Ocorrencia/alterar/5
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult alterar(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_ocorrencia sol_ocorrencia = db.sol_ocorrencia.Find(id);
            if (sol_ocorrencia == null)
            {
                return HttpNotFound();
            }
            return View(sol_ocorrencia);
        }

        // POST: Ocorrencia/alterar/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more detalhes see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult alterar([Bind(Include = "sol_ocorrencia_id,sol_ocorrencia_descricao,sol_ocorrencia_data_cadastro")] sol_ocorrencia sol_ocorrencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sol_ocorrencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(sol_ocorrencia);
        }

        // GET: Ocorrencia/excluir/5
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult excluir(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_ocorrencia sol_ocorrencia = db.sol_ocorrencia.Find(id);
            if (sol_ocorrencia == null)
            {
                return HttpNotFound();
            }
            return View(sol_ocorrencia);
        }

        // POST: Ocorrencia/excluir/5
        [HttpPost, ActionName("excluir")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ROLE_ADMINISTRADOR")]
        public ActionResult excluirConfirmed(short id)
        {
            sol_ocorrencia sol_ocorrencia = db.sol_ocorrencia.Find(id);
            db.sol_ocorrencia.Remove(sol_ocorrencia);
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
