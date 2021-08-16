using System;
using System.Collections.Generic;

#nullable disable

namespace SchemeForFarmerApi.SchemeForFarmerModel
{
    public partial class LandDetail
    {
        public int LandId { get; set; }
        public string AadharCardNumber { get; set; }
        public decimal Area { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string City { get; set; }

        public virtual CityState CityNavigation { get; set; }
    }
}
