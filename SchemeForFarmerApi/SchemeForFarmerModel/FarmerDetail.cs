using System;
using System.Collections.Generic;

#nullable disable

namespace SchemeForFarmerApi.SchemeForFarmerModel
{
    public partial class FarmerDetail
    {
        public FarmerDetail()
        {
            AppliedInsurances = new HashSet<AppliedInsurance>();
            RequestDetails = new HashSet<RequestDetail>();
        }

        public string AadharCardNumber { get; set; }
        public string FullName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string AadharDocument { get; set; }
        public string Pandocument { get; set; }
        public string CertificateDocument { get; set; }
        public string AccountNumber { get; set; }
        public string Ifsc { get; set; }
        public string Password { get; set; }
        public bool? Status { get; set; }

        public virtual CityState CityNavigation { get; set; }
        public virtual ICollection<AppliedInsurance> AppliedInsurances { get; set; }
        public virtual ICollection<RequestDetail> RequestDetails { get; set; }
    }
}
