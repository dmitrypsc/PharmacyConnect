#region Usings

using System.Web.Http;
using Microsoft.Practices.Unity;
using PharmacyConnect.PharmacyAccessorService;
using PharmacyConnect.PharmacyAccessorService.Interfaces;
using Unity.WebApi;

#endregion

namespace PharmacyConnect.WebApi
{
    public static class UnityConfig
    {
        #region Public Methods

        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IPharmacyManagementSoftwareResolver, PharmacyManagementSoftwareResolver>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        #endregion
    }
}