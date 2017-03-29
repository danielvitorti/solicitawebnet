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
    public class StatusController : Controller
    {
        private ModeloDadosSolicita db = new ModeloDadosSolicita();

        // GET: Status
        public ActionResult index()
        {
            return View(db.sol_status.ToList());
        }

        // GET: Status/detalhes/5
        public ActionResult detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_status sol_status = db.sol_status.Find(id);
            if (sol_status == null)
            {
                return HttpNotFound();
            }
            return View(sol_status);
        }

        // GET: Status/cadastrar
        public ActionResult cadastrar()
        {
            return View();
        }

        // POST: Status/cadastrar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more detalhes see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult cadastrar([Bind(Include = "sol_status_id,sol_status_descricao,sol_status_data_cadastro")] sol_status sol_status)
        {
            if (ModelState.IsValid)
            {
                db.sol_status.Add(sol_status);
                db.SaveChanges();
                return RedirectToAction("index");
            }

            return View(sol_status);
        }

        // GET: Status/alterar/5
        public ActionResult alterar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_status sol_status = db.sol_status.Find(id);
            if (sol_status == null)
            {
                return HttpNotFound();
            }
            return View(sol_status);
        }

        // POST: Status/alterar/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more detalhes see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult alterar([Bind(Include = "sol_status_id,sol_status_descricao,sol_status_data_cadastro")] sol_status sol_status)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sol_status).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(sol_status);
        }

        // GET: Status/excluir/5
        public ActionResult excluir(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_status sol_status = db.sol_status.Find(id);
            if (sol_status == null)
            {
                return HttpNotFound();
            }
            return View(sol_status);
        }

        // POST: Status/excluir/5
        [HttpPost, ActionName("excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult excluirConfirmed(int id)
        {
            sol_status sol_status = db.sol_status.Find(id);
            db.sol_status.Remove(sol_status);
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
