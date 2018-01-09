﻿using System;
using System.Collections.Generic;

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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidInit { get; set; }
        public string Suffix { get; set; }
        public DateTime Birthdate { get; set; }
        public bool? InActive { get; set; }
        public DateTime? InActiveDate { get; set; }

        public ICollection<AdultMemberAddress> AdultMemberAddress { get; set; }
        public ICollection<CheckOut> CheckOut { get; set; }
        public ICollection<JuvenileMember> JuvenileMember { get; set; }
        public ICollection<MemberEmail> MemberEmail { get; set; }
        public ICollection<MemberPhone> MemberPhone { get; set; }
    }
}
