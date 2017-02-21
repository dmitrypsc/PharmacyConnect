#region Usings

using System;
using PharmacyConnect.PharmacyAccessorService.Interfaces;

#endregion

namespace PharmacyConnect.PharmacyAccessorService.PharmacyAdapters
{
    public class Rx30Adapter : IPharmacyManagementSoftwareAdapter
    {
        #region IPharmacyManagementSoftwareAdapter Members

        public void GetRxRefillRequest()
        {
            throw new NotImplementedException();
        }

        public string Id { get; set; }

        #endregion
    }
}