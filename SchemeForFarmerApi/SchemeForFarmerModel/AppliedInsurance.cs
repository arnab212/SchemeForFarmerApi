using System;
using System.Collections.Generic;

#nullable disable

namespace SchemeForFarmerApi.SchemeForFarmerModel
{
    public partial class AppliedInsurance
    {
        public int PolicyNumber { get; set; }
        public string AadharCardNumber { get; set; }
        public int CompanyId { get; set; }
        public string Season { get; set; }
        public string CropName { get; set; }
        public decimal Area { get; set; }

        public virtual FarmerDetail AadharCardNumberNavigation { get; set; }
        public virtual InsuranceCompany Company { get; set; }
    }
}
