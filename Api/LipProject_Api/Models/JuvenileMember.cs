using System;
using System.Collections.Generic;

namespace LibProject_Api.Models
{
    public partial class JuvenileMember
    {
        public JuvenileMember()
        {
            MemberEmail = new HashSet<MemberEmail>();
            MemberPhone = new HashSet<MemberPhone>();
        }

        public int Id { get; set; }
        public int AdultId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidInit { get; set; }
        public string Suffix { get; set; }
        public DateTime Birthdate { get; set; }
        public bool? InActive { get; set; }
        public DateTime? InActiveDate { get; set; }

        public AdultMember Adult { get; set; }
        public ICollection<MemberEmail> MemberEmail { get; set; }
        public ICollection<MemberPhone> MemberPhone { get; set; }
    }
}
