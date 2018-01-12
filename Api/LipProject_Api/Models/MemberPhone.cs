using System;
using System.Collections.Generic;

namespace LibProject_Api.Models
{
    public partial class MemberPhone
    {
        public int AdultId { get; set; }
        public int? JuvenileId { get; set; }
        public int PhoneId { get; set; }
        public string PhoneTypeId { get; set; }

        public AdultMember Adult { get; set; }
        public JuvenileMember JuvenileMember { get; set; }
        public Phone Phone { get; set; }
        public PhoneType PhoneType { get; set; }
    }
}
