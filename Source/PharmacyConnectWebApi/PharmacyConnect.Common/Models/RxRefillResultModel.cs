using System.Net;

namespace PharmacyConnect.Common.Models
{
    public class RxRefillResultModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}