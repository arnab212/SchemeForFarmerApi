using System;
using System.Collections.Generic;

#nullable disable

namespace SchemeForFarmerApi.SchemeForFarmerModel
{
    public partial class CityState
    {
        public CityState()
        {
            BidderDetails = new HashSet<BidderDetail>();
            FarmerDetails = new HashSet<FarmerDetail>();
            LandDetails = new HashSet<LandDetail>();
        }

        public string City { get; set; }
        public string State { get; set; }

        public virtual ICollection<BidderDetail> BidderDetails { get; set; }
        public virtual ICollection<FarmerDetail> FarmerDetails { get; set; }
        public virtual ICollection<LandDetail> LandDetails { get; set; }
    }
}
