using System.Web.Mvc;

namespace IceCloud.BeebApp.Infra.CrossCutting.Filters
{
    public class GlobalActionLogger : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //LOG de Auditoria

            if (filterContext.Exception != null)
            {
                //tratamento do erro

                filterContext.ExceptionHandled = true;
                filterContext.Result = new HttpStatusCodeResult(500);
            }

            base.OnActionExecuted(filterContext);
        }
    }
}