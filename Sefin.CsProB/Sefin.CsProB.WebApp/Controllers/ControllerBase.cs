using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sefin.CsProB.WebApp.Controllers
{
    public abstract class ControllerBase : Controller
    {
        public IKernel Kernel
        {
            get { return (IKernel)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IKernel)); }
        }
    }
}