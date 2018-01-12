using System;
using System.Collections.Generic;

namespace LibProject_Api.Models
{
    public partial class AdultMemberAddress
    {
        public int AdultId { get; set; }
        public int AddressId { get; set; }
        public bool? InActive { get; set; }
        public DateTime? InActiveDate { get; set; }

        public Address Address { get; set; }
        public AdultMember Adult { get; set; }
    }
}
