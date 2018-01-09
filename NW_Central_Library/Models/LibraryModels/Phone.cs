using System;
using System.Collections.Generic;

namespace NW_Central_Library.Models.LibraryModels
{
    public partial class Phone
    {
        public Phone()
        {
            MemberPhone = new HashSet<MemberPhone>();
        }

        public int Id { get; set; }
        public string PhoneNum { get; set; }
        public bool? InActive { get; set; }
        public DateTime? InActiveDate { get; set; }

        public ICollection<MemberPhone> MemberPhone { get; set; }
    }
}
