using System;
using System.Web.Mvc;
using IceCloud.BeebApp.Application.Interfaces;
using IceCloud.BeebApp.Application.Services;
using IceCloud.BeebApp.Application.ViewModels;

namespace IceCloud.BeebApp.UI.SiteSolucao.Controllers
{
    [Authorize]
    [RoutePrefix("area-administrativa/gestao-clientes")]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuariosController()
        {
            _usuarioAppService = new UsuarioAppService();
        }

        [AllowAnonymous]
        [Route("listar-todos")]
        public ActionResult Index()
        {
            return View(_usuarioAppService.GetAtivos());
        }

        [Route("{id:guid}/detalhes")]
        public ActionResult Details(Guid id)
        {
            var usuarioViewModel = _usuarioAppService.GetById(id);

            if (usuarioViewModel == null) return HttpNotFound();

            return View(usuarioViewModel);
        }

        [Route("criar-novo")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("criar-novo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioEnderecoTipoViewModel usuarioEnderecoTipo)
        {
            if (!ModelState.IsValid) return View(usuarioEnderecoTipo);

            _usuarioAppService.Adicionar(usuarioEnderecoTipo);

            return RedirectToAction("Index");
        }

        [Route("{id:guid}/editar")]
        public ActionResult Edit(Guid id)
        {
            var usuarioViewModel = _usuarioAppService.GetById(id);

            if (usuarioViewModel == null) return HttpNotFound();

            return View(usuarioViewModel);
        }

        [Route("{id:guid}/editar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid) return View(usuarioViewModel);

            _usuarioAppService.Atualizar(usuarioViewModel);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin, Gestor")]
        [Route("{id:guid}/excluir")]
        public ActionResult Delete(Guid id)
        {
            var usuarioViewModel = _usuarioAppService.GetById(id);

            if (usuarioViewModel == null) return HttpNotFound();

            return View(usuarioViewModel);
        }

        [Authorize(Roles = "Admin, Gestor")]
        [Route("{id:guid}/excluir")]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _usuarioAppService.Remover(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _usuarioAppService.Dispose();
        }
    }
}