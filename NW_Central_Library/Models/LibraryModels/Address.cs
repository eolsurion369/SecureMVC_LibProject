using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NW_Central_Library.Models.LibraryModels
{
    public partial class Address
    {
        public Address()
        {
            AdultMemberAddress = new HashSet<AdultMemberAddress>();
        }

        public int Id { get; set; }

        [Display (Name = "Address Type")]
        public string AddrTypeId { get; set; }

        [Display (Name = "Address Line 1")]
        public string AddrLn1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddrLn2 { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        [Display(Name = "Inactive")]
        public bool? InActive { get; set; }

        [Display(Name = "Inactive Date")]
        public DateTime? InActiveDate { get; set; }

        public AddrType AddrType { get; set; }
        public ICollection<AdultMemberAddress> AdultMemberAddress { get; set; }
    }
}
