using System;
using System.Collections.Generic;

#nullable disable

namespace SchemeForFarmerApi.SchemeForFarmerModel
{
    public partial class BidHistory
    {
        public int BidId { get; set; }
        public string BidderAadharCardNumber { get; set; }
        public int RequestId { get; set; }
        public decimal BidPrice { get; set; }
        public DateTime? BidDate { get; set; }

        public virtual BidderDetail BidderAadharCardNumberNavigation { get; set; }
        public virtual RequestDetail Request { get; set; }
    }
}
