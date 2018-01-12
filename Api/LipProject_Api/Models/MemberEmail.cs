using System;
using System.Collections.Generic;

namespace LibProject_Api.Models
{
    public partial class MemberEmail
    {
        public int AdultId { get; set; }
        public int? JuvenileId { get; set; }
        public int EmailId { get; set; }

        public AdultMember Adult { get; set; }
        public Email Email { get; set; }
        public JuvenileMember JuvenileMember { get; set; }
    }
}
