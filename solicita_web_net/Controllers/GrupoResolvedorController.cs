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
    public class GrupoResolvedorController : Controller
    {
        private ModeloDadosSolicita db = new ModeloDadosSolicita();

        // GET: GrupoResolvedor
        public ActionResult index()
        {
            return View(db.sol_grupo_resolvedor.ToList());
        }

        // GET: GrupoResolvedor/detalhes/5
        public ActionResult detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_grupo_resolvedor sol_grupo_resolvedor = db.sol_grupo_resolvedor.Find(id);
            if (sol_grupo_resolvedor == null)
            {
                return HttpNotFound();
            }
            return View(sol_grupo_resolvedor);
        }

        // GET: GrupoResolvedor/cadastrar
        public ActionResult cadastrar()
        {
            return View();
        }

        // POST: GrupoResolvedor/cadastrar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more detalhes see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult cadastrar([Bind(Include = "sol_grupo_resolvedor_id,sol_grupo_resolvedor_descricao,sol_grupo_resolvedor_data_cadastro")] sol_grupo_resolvedor sol_grupo_resolvedor)
        {
            if (ModelState.IsValid)
            {
                db.sol_grupo_resolvedor.Add(sol_grupo_resolvedor);
                db.SaveChanges();
                return RedirectToAction("index");
            }

            return View(sol_grupo_resolvedor);
        }

        // GET: GrupoResolvedor/alterar/5
        public ActionResult alterar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_grupo_resolvedor sol_grupo_resolvedor = db.sol_grupo_resolvedor.Find(id);
            if (sol_grupo_resolvedor == null)
            {
                return HttpNotFound();
            }
            return View(sol_grupo_resolvedor);
        }

        // POST: GrupoResolvedor/alterar/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more detalhes see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult alterar([Bind(Include = "sol_grupo_resolvedor_id,sol_grupo_resolvedor_descricao,sol_grupo_resolvedor_data_cadastro")] sol_grupo_resolvedor sol_grupo_resolvedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sol_grupo_resolvedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(sol_grupo_resolvedor);
        }

        // GET: GrupoResolvedor/excluir/5
        public ActionResult excluir(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_grupo_resolvedor sol_grupo_resolvedor = db.sol_grupo_resolvedor.Find(id);
            if (sol_grupo_resolvedor == null)
            {
                return HttpNotFound();
            }
            return View(sol_grupo_resolvedor);
        }

        // POST: GrupoResolvedor/excluir/5
        [HttpPost, ActionName("excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult excluirConfirmed(int id)
        {
            sol_grupo_resolvedor sol_grupo_resolvedor = db.sol_grupo_resolvedor.Find(id);
            db.sol_grupo_resolvedor.Remove(sol_grupo_resolvedor);
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
