using System;
using System.Collections.Generic;

namespace NW_Central_Library.Models.LibraryModels
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
