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
    public class SolicitacaoController : Controller
    {
        private ModeloDadosSolicita db = new ModeloDadosSolicita();

        // GET: Solicitacao
        [Authorize(Roles = "ROLE_ADMINISTRADOR,ROLE_USUARIO_COMUM")]
        public ActionResult index()
        {
            /* Combo com os status para filtro */

            var sol_solicitacao = db.sol_solicitacao.Include(s => s.sol_categoria_servico).Include(s => s.sol_causas).Include(s => s.sol_classificacao).Include(s => s.sol_grupo_resolvedor).Include(s => s.sol_impacto).Include(s => s.sol_produto).Include(s => s.sol_responsavel).Include(s => s.sol_solicitante).Include(s => s.sol_status).Include(s => s.sol_sub_causas).Include(s => s.sol_tipo_servico).Include(s => s.sol_urgencia);


            if (Request.RequestType == "POST")
            {
                string status_id = Request.Form["sol_status_id"];

                if (String.IsNullOrEmpty(status_id))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else
                {
                    int status = Convert.ToInt16(status_id);
                    sol_solicitacao = db.sol_solicitacao.Include(s => s.sol_categoria_servico).Include(s => s.sol_causas).Include(s => s.sol_classificacao).Include(s => s.sol_grupo_resolvedor).Include(s => s.sol_impacto).Include(s => s.sol_produto).Include(s => s.sol_responsavel).Include(s => s.sol_solicitante).Include(s => s.sol_status).Include(s => s.sol_sub_causas).Include(s => s.sol_tipo_servico).Include(s => s.sol_urgencia).Where(s => s.sol_status_id == status);
                }
                                
            }
            

            ViewBag.sol_status_id = new SelectList(db.sol_status, "sol_status_id", "sol_status_descricao");
            //ViewBag.sol_responsavel_id = new SelectList(db.sol_responsavel, "sol_responsavel_id", "sol_responsavel_nome");
            


            
            return View(sol_solicitacao.ToList());
        }

        // GET: Solicitacao/detalhes/5
        [Authorize(Roles = "ROLE_ADMINISTRADOR,ROLE_USUARIO_COMUM")]
        public ActionResult detalhes(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_solicitacao sol_solicitacao = db.sol_solicitacao.Find(id);
            if (sol_solicitacao == null)
            {
                return HttpNotFound();
            }
            return View(sol_solicitacao);
        }

        // GET: Solicitacao/nova
        [Authorize(Roles = "ROLE_ADMINISTRADOR,ROLE_USUARIO_COMUM")]
        public ActionResult nova()
        {
            ViewBag.sol_categoria_servico_id = new SelectList(db.sol_categoria_servico, "sol_categoria_servico_id", "sol_categoria_servico_descricao");
            ViewBag.sol_causa_id = new SelectList(db.sol_causas, "sol_causa_id", "sol_causa_descricao");
            ViewBag.sol_classificacao_id = new SelectList(db.sol_classificacao, "sol_classificacao_id", "sol_classificacao_descricao");
            ViewBag.sol_grupo_resolvedor_id = new SelectList(db.sol_grupo_resolvedor, "sol_grupo_resolvedor_id", "sol_grupo_resolvedor_descricao");
            ViewBag.sol_impacto_id = new SelectList(db.sol_impacto, "sol_impacto_id", "sol_impacto_descricao");
            ViewBag.sol_produto_id = new SelectList(db.sol_produto, "sol_produto_id", "sol_produto_descricao");
            ViewBag.sol_responsavel_id = new SelectList(db.sol_responsavel, "sol_responsavel_id", "sol_responsavel_nome");
            ViewBag.sol_solicitante_id = new SelectList(db.sol_solicitante, "sol_id", "sol_nome");
            ViewBag.sol_status_id = new SelectList(db.sol_status, "sol_status_id", "sol_status_descricao");
            ViewBag.sol_causa_id = new SelectList(db.sol_sub_causas, "sol_sub_causa_id", "sol_sub_causa_descricao");
            ViewBag.sol_tipo_servico_id = new SelectList(db.sol_tipo_servico, "sol_tipo_servico_id", "sol_tipo_servico_descricao");
            ViewBag.sol_urgencia_id = new SelectList(db.sol_urgencia, "sol_urgencia_id", "sol_urgencia_descricao");
            return View();
        }

        // POST: Solicitacao/nova
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more detalhes see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ROLE_ADMINISTRADOR,ROLE_USUARIO_COMUM")]
        public ActionResult nova([Bind(Include = "sol_solicitacao_id,sol_status_id,sol_solicitante_id,sol_tipo_servico_id,sol_categoria_servico_id,sol_urgencia_id,sol_impacto_id,sol_classificacao_id,sol_produto_id,sol_responsavel_id,sol_grupo_resolvedor_id,sol_causa_id,sol_sub_causa_id,sol_resumo_solicitacao,sol_justificativa_solicitacao,sol_solicitacao1,sol_solucao,sol_tempo")] sol_solicitacao sol_solicitacao)
        {
            if (ModelState.IsValid)
            {
                db.sol_solicitacao.Add(sol_solicitacao);
                db.SaveChanges();
                return RedirectToAction("index");
            }

            ViewBag.sol_categoria_servico_id = new SelectList(db.sol_categoria_servico, "sol_categoria_servico_id", "sol_categoria_servico_descricao", sol_solicitacao.sol_categoria_servico_id);
            ViewBag.sol_causa_id = new SelectList(db.sol_causas, "sol_causa_id", "sol_causa_descricao", sol_solicitacao.sol_causa_id);
            ViewBag.sol_classificacao_id = new SelectList(db.sol_classificacao, "sol_classificacao_id", "sol_classificacao_descricao", sol_solicitacao.sol_classificacao_id);
            ViewBag.sol_grupo_resolvedor_id = new SelectList(db.sol_grupo_resolvedor, "sol_grupo_resolvedor_id", "sol_grupo_resolvedor_descricao", sol_solicitacao.sol_grupo_resolvedor_id);
            ViewBag.sol_impacto_id = new SelectList(db.sol_impacto, "sol_impacto_id", "sol_impacto_descricao", sol_solicitacao.sol_impacto_id);
            ViewBag.sol_produto_id = new SelectList(db.sol_produto, "sol_produto_id", "sol_produto_descricao", sol_solicitacao.sol_produto_id);
            ViewBag.sol_responsavel_id = new SelectList(db.sol_responsavel, "sol_responsavel_id", "sol_responsavel_nome", sol_solicitacao.sol_responsavel_id);
            ViewBag.sol_solicitante_id = new SelectList(db.sol_solicitante, "sol_id", "sol_nome", sol_solicitacao.sol_solicitante_id);
            ViewBag.sol_status_id = new SelectList(db.sol_status, "sol_status_id", "sol_status_descricao", sol_solicitacao.sol_status_id);
            ViewBag.sol_causa_id = new SelectList(db.sol_sub_causas, "sol_sub_causa_id", "sol_sub_causa_descricao", sol_solicitacao.sol_causa_id);
            ViewBag.sol_tipo_servico_id = new SelectList(db.sol_tipo_servico, "sol_tipo_servico_id", "sol_tipo_servico_descricao", sol_solicitacao.sol_tipo_servico_id);
            ViewBag.sol_urgencia_id = new SelectList(db.sol_urgencia, "sol_urgencia_id", "sol_urgencia_descricao", sol_solicitacao.sol_urgencia_id);
            return View(sol_solicitacao);
        }

        // GET: Solicitacao/alterar/5
        [Authorize(Roles = "ROLE_ADMINISTRADOR,ROLE_USUARIO_COMUM")]
        public ActionResult alterar(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_solicitacao sol_solicitacao = db.sol_solicitacao.Find(id);
            if (sol_solicitacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.sol_categoria_servico_id = new SelectList(db.sol_categoria_servico, "sol_categoria_servico_id", "sol_categoria_servico_descricao", sol_solicitacao.sol_categoria_servico_id);
            ViewBag.sol_causa_id = new SelectList(db.sol_causas, "sol_causa_id", "sol_causa_descricao", sol_solicitacao.sol_causa_id);
            ViewBag.sol_classificacao_id = new SelectList(db.sol_classificacao, "sol_classificacao_id", "sol_classificacao_descricao", sol_solicitacao.sol_classificacao_id);
            ViewBag.sol_grupo_resolvedor_id = new SelectList(db.sol_grupo_resolvedor, "sol_grupo_resolvedor_id", "sol_grupo_resolvedor_descricao", sol_solicitacao.sol_grupo_resolvedor_id);
            ViewBag.sol_impacto_id = new SelectList(db.sol_impacto, "sol_impacto_id", "sol_impacto_descricao", sol_solicitacao.sol_impacto_id);
            ViewBag.sol_produto_id = new SelectList(db.sol_produto, "sol_produto_id", "sol_produto_descricao", sol_solicitacao.sol_produto_id);
            ViewBag.sol_responsavel_id = new SelectList(db.sol_responsavel, "sol_responsavel_id", "sol_responsavel_nome", sol_solicitacao.sol_responsavel_id);
            ViewBag.sol_solicitante_id = new SelectList(db.sol_solicitante, "sol_id", "sol_nome", sol_solicitacao.sol_solicitante_id);
            ViewBag.sol_status_id = new SelectList(db.sol_status, "sol_status_id", "sol_status_descricao", sol_solicitacao.sol_status_id);
            ViewBag.sol_causa_id = new SelectList(db.sol_sub_causas, "sol_sub_causa_id", "sol_sub_causa_descricao", sol_solicitacao.sol_causa_id);
            ViewBag.sol_tipo_servico_id = new SelectList(db.sol_tipo_servico, "sol_tipo_servico_id", "sol_tipo_servico_descricao", sol_solicitacao.sol_tipo_servico_id);
            ViewBag.sol_urgencia_id = new SelectList(db.sol_urgencia, "sol_urgencia_id", "sol_urgencia_descricao", sol_solicitacao.sol_urgencia_id);
            return View(sol_solicitacao);
        }

        // POST: Solicitacao/alterar/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more detalhes see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ROLE_ADMINISTRADOR,ROLE_USUARIO_COMUM")]
        public ActionResult alterar([Bind(Include = "sol_solicitacao_id,sol_status_id,sol_solicitante_id,sol_tipo_servico_id,sol_categoria_servico_id,sol_urgencia_id,sol_impacto_id,sol_classificacao_id,sol_produto_id,sol_responsavel_id,sol_grupo_resolvedor_id,sol_causa_id,sol_sub_causa_id,sol_resumo_solicitacao,sol_justificativa_solicitacao,sol_solicitacao1,sol_solucao,sol_tempo")] sol_solicitacao sol_solicitacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sol_solicitacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            ViewBag.sol_categoria_servico_id = new SelectList(db.sol_categoria_servico, "sol_categoria_servico_id", "sol_categoria_servico_descricao", sol_solicitacao.sol_categoria_servico_id);
            ViewBag.sol_causa_id = new SelectList(db.sol_causas, "sol_causa_id", "sol_causa_descricao", sol_solicitacao.sol_causa_id);
            ViewBag.sol_classificacao_id = new SelectList(db.sol_classificacao, "sol_classificacao_id", "sol_classificacao_descricao", sol_solicitacao.sol_classificacao_id);
            ViewBag.sol_grupo_resolvedor_id = new SelectList(db.sol_grupo_resolvedor, "sol_grupo_resolvedor_id", "sol_grupo_resolvedor_descricao", sol_solicitacao.sol_grupo_resolvedor_id);
            ViewBag.sol_impacto_id = new SelectList(db.sol_impacto, "sol_impacto_id", "sol_impacto_descricao", sol_solicitacao.sol_impacto_id);
            ViewBag.sol_produto_id = new SelectList(db.sol_produto, "sol_produto_id", "sol_produto_descricao", sol_solicitacao.sol_produto_id);
            ViewBag.sol_responsavel_id = new SelectList(db.sol_responsavel, "sol_responsavel_id", "sol_responsavel_nome", sol_solicitacao.sol_responsavel_id);
            ViewBag.sol_solicitante_id = new SelectList(db.sol_solicitante, "sol_id", "sol_nome", sol_solicitacao.sol_solicitante_id);
            ViewBag.sol_status_id = new SelectList(db.sol_status, "sol_status_id", "sol_status_descricao", sol_solicitacao.sol_status_id);
            ViewBag.sol_causa_id = new SelectList(db.sol_sub_causas, "sol_sub_causa_id", "sol_sub_causa_descricao", sol_solicitacao.sol_causa_id);
            ViewBag.sol_tipo_servico_id = new SelectList(db.sol_tipo_servico, "sol_tipo_servico_id", "sol_tipo_servico_descricao", sol_solicitacao.sol_tipo_servico_id);
            ViewBag.sol_urgencia_id = new SelectList(db.sol_urgencia, "sol_urgencia_id", "sol_urgencia_descricao", sol_solicitacao.sol_urgencia_id);
            return View(sol_solicitacao);
        }

        // GET: Solicitacao/excluir/5
        [Authorize(Roles = "ROLE_ADMINISTRADOR,ROLE_USUARIO_COMUM")]
        public ActionResult excluir(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sol_solicitacao sol_solicitacao = db.sol_solicitacao.Find(id);
            if (sol_solicitacao == null)
            {
                return HttpNotFound();
            }
            return View(sol_solicitacao);
        }

        // POST: Solicitacao/excluir/5
        [HttpPost, ActionName("excluir")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ROLE_ADMINISTRADOR,ROLE_USUARIO_COMUM")]
        public ActionResult excluirConfirmed(long id)
        {
            sol_solicitacao sol_solicitacao = db.sol_solicitacao.Find(id);
            db.sol_solicitacao.Remove(sol_solicitacao);
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
