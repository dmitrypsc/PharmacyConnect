#region Usings

using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PharmacyConnect.Common.Models;
using PharmacyConnect.PharmacyAccessorService.Interfaces;
using PharmacyConnect.PharmacyAccessorService.Models;

#endregion

namespace PharmacyConnect.PharmacyAccessorService.PharmacyAdapters
{
    public class Rx30Adapter : IPharmacyManagementSoftwareAdapter
    {
        #region Private Static Fields and Constants

        private const string RootUri = "https://refillrxdata.rx30.com:6065";

        private const int TestLicense = 103734;

        private const string TestUri = "https://refillrxdata.rx30.com:6065/hello_Zr8EXTgLNw";

        private const string TestUsername = "prescribewellness";
        private const string TestPassword = "gxY886bXticP";

        #endregion

        #region IPharmacyManagementSoftwareAdapter Members

        public async Task<RxRefillResultModel> GetRxRefillResultAsync(string rxId, string licenseId)
        {
            if (string.IsNullOrEmpty(rxId))
            {
                throw new ArgumentNullException(nameof(rxId));
            }

            if (string.IsNullOrEmpty(licenseId))
            {
                throw new ArgumentNullException(nameof(licenseId));
            }

            int rxIdNumber;
            int licenseIdNumber;

            if (!int.TryParse(rxId, out rxIdNumber))
            {
                throw new ArgumentException($"{nameof(rxId)} is not a number.");
            }

            if (!int.TryParse(licenseId, out licenseIdNumber))
            {
                throw new ArgumentException($"{nameof(licenseId)} is not a number.");
            }

            RxRefillResultModel responseModel = new RxRefillResultModel();

            try
            {
                RefillRequestModel requestModel = new RefillRequestModel
                {
                    RxNumber = rxIdNumber,
                    License = licenseIdNumber
                };

                string uriParam = JsonConvert.SerializeObject(requestModel);
                string requestUri = $"{RootUri}/{uriParam}";

                HttpWebRequest request = WebRequest.CreateHttp(requestUri);
                request.ContentType = "application/json;charset=UTF-8";
                string authInfo = TestUsername + ":" + TestPassword;
                authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                request.Headers["Authorization"] = "Basic " + authInfo;

                HttpWebResponse response = (HttpWebResponse) await request.GetResponseAsync();

                responseModel.StatusCode = response.StatusCode;
            }
            catch (Exception exception)
            {
                throw new Exception($"Exception occurred while receiving a response from the server. RxNumber : {rxId}. License : {licenseId}", exception);
            }

            return responseModel;
        }

        public string Id => PharmacyManagementSoftwareIds.Rx30Id;

        #endregion
    }

    public class RefillRequestModel
    {
        #region Public Properties

        [JsonProperty("function")]
        public string Function { get; set; } = "ScanRxSubmitRefill";

        [JsonProperty("license")]
        public int License { get; set; }

        [JsonProperty("rxnbr")]
        public int RxNumber { get; set; }

        #endregion
    }

    public class RefillResponseModel
    {
        #region Public Properties

        public string CallDoctorOk { get; set; }
        public string CallDoctorOkSource { get; set; }
        public string JobId { get; set; }
        public string Status { get; set; }

        #endregion
    }
}