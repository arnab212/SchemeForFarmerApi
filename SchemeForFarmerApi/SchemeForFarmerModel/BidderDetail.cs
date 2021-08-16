using System;
using System.Collections.Generic;

#nullable disable

namespace SchemeForFarmerApi.SchemeForFarmerModel
{
    public partial class BidderDetail
    {
        public BidderDetail()
        {
            BidHistories = new HashSet<BidHistory>();
            SoldDetails = new HashSet<SoldDetail>();
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
        public string TradersLicenseDocument { get; set; }
        public string AccountNumber { get; set; }
        public string Ifsc { get; set; }
        public string Password { get; set; }
        public bool? Status { get; set; }

        public virtual CityState CityNavigation { get; set; }
        public virtual ICollection<BidHistory> BidHistories { get; set; }
        public virtual ICollection<SoldDetail> SoldDetails { get; set; }
    }
}
