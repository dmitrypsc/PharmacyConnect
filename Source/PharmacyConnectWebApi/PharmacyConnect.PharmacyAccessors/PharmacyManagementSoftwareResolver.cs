#region Usings

using System;
using PharmacyConnect.PharmacyAccessorService.Interfaces;
using PharmacyConnect.PharmacyAccessorService.Models;
using PharmacyConnect.PharmacyAccessorService.PharmacyAdapters;

#endregion

namespace PharmacyConnect.PharmacyAccessorService
{
    public class PharmacyManagementSoftwareResolver : IPharmacyManagementSoftwareResolver
    {
        #region IPharmacyManagementSoftwareResolver Members

        public IPharmacyManagementSoftwareAdapter GetAdapterById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            object result;
            switch (id)
            {
                case PharmacyManagementSoftwareIds.Rx30Id:
                    result = new Rx30Adapter();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(id));
            }

            return (IPharmacyManagementSoftwareAdapter) result;
        }

        #endregion
    }
}