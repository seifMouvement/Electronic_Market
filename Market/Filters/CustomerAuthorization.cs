using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFDbFirstApprocheExample.Filters
{
    public class CustomerAuthorization : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.IsInRole("Customer") == false)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}