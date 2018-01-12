﻿using System;
using System.Collections.Generic;

namespace LibProject_Api.Models
{
    public partial class AddrType
    {
        public AddrType()
        {
            Address = new HashSet<Address>();
        }

        public string Id { get; set; }
        public string Type { get; set; }
        public bool? InActive { get; set; }
        public DateTime? InActiveDate { get; set; }

        public ICollection<Address> Address { get; set; }
    }
}
