using System;
using System.Collections.Generic;

#nullable disable

namespace SchemeForFarmerApi.SchemeForFarmerModel
{
    public partial class SoldDetail
    {
        public int RequestId { get; set; }
        public string AadharCardNumber { get; set; }
        public DateTime? DateSold { get; set; }
        public decimal SoldPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual BidderDetail AadharCardNumberNavigation { get; set; }
        public virtual RequestDetail Request { get; set; }
    }
}
