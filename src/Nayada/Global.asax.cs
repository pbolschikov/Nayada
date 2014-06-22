using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Nayada.Windsor;

namespace Nayada
{
    public class MvcApplication : HttpApplication
    {
        private IWindsorContainer m_Container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            m_Container = bootstrapContainer();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private static IWindsorContainer bootstrapContainer()
        {
            var container = new WindsorContainer()
                .Install(FromAssembly.This());
            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            return container;
        }


        protected void Application_End()
        {
            if (m_Container != null)
            {
                m_Container.Dispose();
            }
        }
    }
}