﻿using System;
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
    public class ImpactoController : Controller
    {
        private ModeloDadosSolicita db = new ModeloDadosSolicita();

        // GET: Impacto
        public ActionResult index()
        {
            return View(db.sol_impacto.ToList());
        }

        // GET: Impacto/detalhes/5
        public ActionResult detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_impacto sol_impacto = db.sol_impacto.Find(id);
            if (sol_impacto == null)
            {
                return HttpNotFound();
            }
            return View(sol_impacto);
        }

        // GET: Impacto/cadastrar
        public ActionResult cadastrar()
        {
            return View();
        }

        // POST: Impacto/cadastrar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more detalhes see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult cadastrar([Bind(Include = "sol_impacto_id,sol_impacto_descricao,sol_impacto_data_cadastro")] sol_impacto sol_impacto)
        {
            if (ModelState.IsValid)
            {
                db.sol_impacto.Add(sol_impacto);
                db.SaveChanges();
                return RedirectToAction("index");
            }

            return View(sol_impacto);
        }

        // GET: Impacto/alterar/5
        public ActionResult alterar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_impacto sol_impacto = db.sol_impacto.Find(id);
            if (sol_impacto == null)
            {
                return HttpNotFound();
            }
            return View(sol_impacto);
        }

        // POST: Impacto/alterar/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more detalhes see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult alterar([Bind(Include = "sol_impacto_id,sol_impacto_descricao,sol_impacto_data_cadastro")] sol_impacto sol_impacto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sol_impacto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(sol_impacto);
        }

        // GET: Impacto/excluir/5
        public ActionResult excluir(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_impacto sol_impacto = db.sol_impacto.Find(id);
            if (sol_impacto == null)
            {
                return HttpNotFound();
            }
            return View(sol_impacto);
        }

        // POST: Impacto/excluir/5
        [HttpPost, ActionName("excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult excluirConfirmed(int id)
        {
            sol_impacto sol_impacto = db.sol_impacto.Find(id);
            db.sol_impacto.Remove(sol_impacto);
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