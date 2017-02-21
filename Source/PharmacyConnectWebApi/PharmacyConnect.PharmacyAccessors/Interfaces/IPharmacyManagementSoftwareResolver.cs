namespace PharmacyConnect.PharmacyAccessorService.Interfaces
{
    public interface IPharmacyManagementSoftwareResolver
    {
        #region Public Methods

        IPharmacyManagementSoftwareAdapter GetPmsAdapterById(string id);

        #endregion
    }
}