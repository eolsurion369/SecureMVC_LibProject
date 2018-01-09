﻿using System;
using System.Collections.Generic;

namespace WebApplication4.Models.LibraryModels
{
    public partial class PhoneType
    {
        public PhoneType()
        {
            MemberPhone = new HashSet<MemberPhone>();
        }

        public string Id { get; set; }
        public string Type { get; set; }
        public bool? InActive { get; set; }
        public DateTime? InActiveDate { get; set; }

        public ICollection<MemberPhone> MemberPhone { get; set; }
    }
}