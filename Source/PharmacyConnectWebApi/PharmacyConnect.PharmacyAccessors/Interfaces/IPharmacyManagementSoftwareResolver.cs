namespace PharmacyConnect.PharmacyAccessorService.Interfaces
{
    public interface IPharmacyManagementSoftwareResolver
    {
        #region Public Methods

        IPharmacyManagementSoftwareAdapter GetAdapterById(string id);

        #endregion
    }
}