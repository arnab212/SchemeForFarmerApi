using System;
using System.Collections.Generic;

#nullable disable

namespace SchemeForFarmerApi.SchemeForFarmerModel
{
    public partial class InsuranceCompany
    {
        public InsuranceCompany()
        {
            AppliedInsurances = new HashSet<AppliedInsurance>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public decimal SumInsured { get; set; }

        public virtual ICollection<AppliedInsurance> AppliedInsurances { get; set; }
    }
}
