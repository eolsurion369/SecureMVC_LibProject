using System;
using System.Collections.Generic;

namespace LibProject_Api.Models
{
    public partial class Email
    {
        public Email()
        {
            MemberEmail = new HashSet<MemberEmail>();
        }

        public int Id { get; set; }
        public string Addr { get; set; }
        public bool? InActive { get; set; }
        public DateTime? InActiveDate { get; set; }

        public ICollection<MemberEmail> MemberEmail { get; set; }
    }
}
