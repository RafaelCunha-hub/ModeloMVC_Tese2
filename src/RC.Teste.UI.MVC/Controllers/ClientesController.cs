using RC.Teste.Domain.Application.Interfaces;
using RC.Teste.Domain.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RC.Teste.UI.MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [Route("listar")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("{id:guid}/detalhes")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cliente = _clienteAppService.ObterPorId(id.Value);

            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [Route("incluir-novo")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("incluir-novo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                clienteViewModel = _clienteAppService.Adicionar(clienteViewModel);

                if (!clienteViewModel.ValidationResult.IsValid)
                {
                    foreach (var error in clienteViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, error.Message);
                    }

                    return View(clienteViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(clienteViewModel);
        }

        [Route("{id:guid}/atualizar")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cliente = _clienteAppService.ObterPorId(id.Value);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [Route("{id:guid}/atualizar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Atualizar(clienteViewModel);
                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        [Route("{id:guid}/excluir")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cliente = _clienteAppService.ObterPorId(id.Value);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [Route("{id:guid}/excluir")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remover(id);
            return RedirectToAction("Index");
        }

        [Route("incluir-novo")]
        [HttpPost]
        public JsonResult Add(ClienteViewModel clienteViewModel)
        {
            #region Comentário

            clienteViewModel = _clienteAppService.Adicionar(clienteViewModel);

            if (!clienteViewModel.ValidationResult.IsValid)
            {
                foreach (var error in clienteViewModel.ValidationResult.Erros)
                {
                    ModelState.AddModelError(string.Empty, error.Message);
                }

                return null;
            }

            #endregion

            var jsonRetorn = Json(_clienteAppService.Adicionar(clienteViewModel), JsonRequestBehavior.AllowGet);
            return jsonRetorn;
        }

        public JsonResult ObterClienteId(Guid? id)
        {
            var cliente = _clienteAppService.ObterPorId(id.Value);

            DateTime dataAgora = DateTime.Now;
            DateTime dataNascimento = new DateTime(1978, 11, 7);

            cliente.DataNascimento = cliente.DataNascimento.Date;


            return Json(cliente, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(ClienteViewModel clienteViewModel)
        {
            var cliente = _clienteAppService.Atualizar(clienteViewModel);

            return Json(cliente, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteClinete(Guid? id)
        {
            var cliente = _clienteAppService.ObterPorId(id.Value);

            if (cliente == null)
            {
                // Validar 
            }

            _clienteAppService.Remover(id.Value);

            return Json(cliente, JsonRequestBehavior.AllowGet);
        }

        public JsonResult List()
        {
            var retornoListClientes = _clienteAppService.ObterTodos();
            return Json(retornoListClientes, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clienteAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
