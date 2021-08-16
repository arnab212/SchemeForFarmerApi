using System;
using System.Collections.Generic;

#nullable disable

namespace SchemeForFarmerApi.SchemeForFarmerModel
{
    public partial class RequestDetail
    {
        public RequestDetail()
        {
            BidHistories = new HashSet<BidHistory>();
        }

        public int RequestId { get; set; }
        public string AadharCardNumber { get; set; }
        public string CropType { get; set; }
        public string CropName { get; set; }
        public string FertilizerType { get; set; }
        public decimal CropQuantity { get; set; }
        public string SoilPhcertificateDocument { get; set; }
        public decimal Msp { get; set; }
        public decimal CuurentBid { get; set; }
        public bool? Status { get; set; }

        public virtual FarmerDetail AadharCardNumberNavigation { get; set; }
        public virtual SoldDetail SoldDetail { get; set; }
        public virtual ICollection<BidHistory> BidHistories { get; set; }
    }
}
