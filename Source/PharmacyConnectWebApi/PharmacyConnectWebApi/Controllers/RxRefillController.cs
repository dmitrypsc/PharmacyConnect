#region Usings

using System.Web.Http;
using PharmacyConnect.PharmacyAccessorService.Interfaces;

#endregion

namespace PharmacyConnect.WebApi.Controllers
{
    public class RxRefillController : ApiController
    {
        #region Private Fields and Constants

        private readonly IPharmacyManagementSoftwareResolver _resolver;

        #endregion

        #region Constructors

        public RxRefillController(IPharmacyManagementSoftwareResolver resolver)
        {
            _resolver = resolver;
        }

        #endregion

        #region Public Methods

        public void Get()
        {
            var adapter = _resolver.GetAdapterById("rx30");

            adapter.GetRxRefillResult("505085", "103734");
        }

        #endregion
    }
}