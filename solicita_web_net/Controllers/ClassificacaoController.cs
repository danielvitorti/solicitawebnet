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
    public class ClassificacaoController : Controller
    {
        private ModeloDadosSolicita db = new ModeloDadosSolicita();

        // GET: Classificacao
        public ActionResult index()
        {
            return View(db.sol_classificacao.ToList());
        }

        // GET: Classificacao/detalhes/5
        public ActionResult detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_classificacao sol_classificacao = db.sol_classificacao.Find(id);
            if (sol_classificacao == null)
            {
                return HttpNotFound();
            }
            return View(sol_classificacao);
        }

        // GET: Classificacao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Classificacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more detalhes see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sol_classificacao_id,sol_classificacao_descricao,sol_classificacao_data_cadastro")] sol_classificacao sol_classificacao)
        {
            if (ModelState.IsValid)
            {
                db.sol_classificacao.Add(sol_classificacao);
                db.SaveChanges();
                return RedirectToAction("index");
            }

            return View(sol_classificacao);
        }

        // GET: Classificacao/alterar/5
        public ActionResult alterar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_classificacao sol_classificacao = db.sol_classificacao.Find(id);
            if (sol_classificacao == null)
            {
                return HttpNotFound();
            }
            return View(sol_classificacao);
        }

        // POST: Classificacao/alterar/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more detalhes see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult alterar([Bind(Include = "sol_classificacao_id,sol_classificacao_descricao,sol_classificacao_data_cadastro")] sol_classificacao sol_classificacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sol_classificacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(sol_classificacao);
        }

        // GET: Classificacao/excluir/5
        public ActionResult excluir(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_classificacao sol_classificacao = db.sol_classificacao.Find(id);
            if (sol_classificacao == null)
            {
                return HttpNotFound();
            }
            return View(sol_classificacao);
        }

        // POST: Classificacao/excluir/5
        [HttpPost, ActionName("excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult excluirConfirmed(int id)
        {
            sol_classificacao sol_classificacao = db.sol_classificacao.Find(id);
            db.sol_classificacao.Remove(sol_classificacao);
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
