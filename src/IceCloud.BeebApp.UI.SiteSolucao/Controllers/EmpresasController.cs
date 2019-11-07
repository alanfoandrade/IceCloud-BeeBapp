using System;
using System.Web.Mvc;
using IceCloud.BeebApp.Application.Interfaces;
using IceCloud.BeebApp.Application.Services;
using IceCloud.BeebApp.Application.ViewModels;

namespace IceCloud.BeebApp.UI.SiteSolucao.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly IEmpresaAppService _empresaAppService;

        public EmpresasController()
        {
            _empresaAppService = new EmpresaAppService();
        }

        public ActionResult Index()
        {
            return View(_empresaAppService.GetAtivos());
        }

        public ActionResult Details(Guid id)
        {
            var empresaViewModel = _empresaAppService.GetById(id);

            if (empresaViewModel == null) return HttpNotFound();

            return View(empresaViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpresaEnderecoViewModel empresaDepartamento)
        {
            if (!ModelState.IsValid) return View(empresaDepartamento);

            _empresaAppService.Adicionar(empresaDepartamento);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            var empresaViewModel = _empresaAppService.GetById(id);

            if (empresaViewModel == null) return HttpNotFound();

            return View(empresaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmpresaViewModel empresaViewModel)
        {
            if (!ModelState.IsValid) return View(empresaViewModel);

            _empresaAppService.Atualizar(empresaViewModel);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            var empresaViewModel = _empresaAppService.GetById(id);

            if (empresaViewModel == null) return HttpNotFound();

            return View(empresaViewModel);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _empresaAppService.Remover(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _empresaAppService.Dispose();
        }
    }
}