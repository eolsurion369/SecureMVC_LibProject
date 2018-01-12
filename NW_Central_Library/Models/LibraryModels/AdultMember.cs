using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NW_Central_Library.Models.LibraryModels
{
    public partial class AdultMember
    {
        public AdultMember()
        {
            AdultMemberAddress = new HashSet<AdultMemberAddress>();
            CheckOut = new HashSet<CheckOut>();
            JuvenileMember = new HashSet<JuvenileMember>();
            MemberEmail = new HashSet<MemberEmail>();
            MemberPhone = new HashSet<MemberPhone>();
        }

        public int Id { get; set; }

        [Display (Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Middle Initial")]
        public string MidInit { get; set; }


        public string Suffix { get; set; }
        public DateTime Birthdate { get; set; }
        public bool? InActive { get; set; }
        public DateTime? InActiveDate { get; set; }

        public string FullName => $"{LastName}, {FirstName} {MidInit}";

        public ICollection<AdultMemberAddress> AdultMemberAddress { get; set; }
        public ICollection<CheckOut> CheckOut { get; set; }
        public ICollection<JuvenileMember> JuvenileMember { get; set; }
        public ICollection<MemberEmail> MemberEmail { get; set; }
        public ICollection<MemberPhone> MemberPhone { get; set; }
    }
}
