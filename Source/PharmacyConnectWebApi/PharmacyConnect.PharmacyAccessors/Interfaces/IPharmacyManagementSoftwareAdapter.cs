#region Usings

using System.Threading.Tasks;
using PharmacyConnect.Common.Models;

#endregion

namespace PharmacyConnect.PharmacyAccessorService.Interfaces
{
    public interface IPharmacyManagementSoftwareAdapter
    {
        #region Public Properties

        string Id { get; }

        #endregion

        #region Public Methods

        Task<RxRefillResultModel> GetRxRefillResultAsync(string rxId, string licenseId);

        #endregion
    }
}