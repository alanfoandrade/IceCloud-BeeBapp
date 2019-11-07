using System.Web.Mvc;

namespace IceCloud.BeebApp.UI.SiteSolucao.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.AlertaErro = "OOPS! Ocorreu um erro";
            ViewBag.MensagemErro = "Tente novamente, ou contate um administrador";

            return View("Error");
        }

        public ActionResult NotFound()
        {
            ViewBag.AlertaErro = "Não encontrado";
            ViewBag.MensagemErro = "A página não existe, verifique o endereço";

            return View("Error");
        }
        public ActionResult AccessDenied()
        {
            ViewBag.AlertaErro = "Acesso Negado";
            ViewBag.MensagemErro = "Você não tem permissão para fazer isso";

            return View("Error");
        }

    }
}