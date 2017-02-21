namespace PharmacyConnect.PharmacyAccessorService.Interfaces
{
    public interface IPharmacyManagementSoftwareAdapter
    {
        #region Public Properties

        string Id { get; set; }

        #endregion

        #region Public Methods

        void GetRxRefillRequest();

        #endregion
    }
}