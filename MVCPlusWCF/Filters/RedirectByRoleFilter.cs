using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCPlusWCF.Filters
{
    public class RedirectByRoleFilter: ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var result = filterContext.Result as ViewResultBase;
            if (result != null)
            {
                var user = filterContext.HttpContext.User;
                if (user.IsInRole("Admin"))
                {
                    filterContext.Result = new RedirectResult("Home/AdminIndex");
                }
                else if (user.IsInRole("User"))
                {
                    filterContext.Result = new RedirectResult("Home/UserIndex");
                }
            }
        }
    }
}