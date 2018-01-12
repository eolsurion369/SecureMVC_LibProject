using System;
using System.Collections.Generic;

namespace LibProject_Api.Models
{
    public partial class Address
    {
        public Address()
        {
            AdultMemberAddress = new HashSet<AdultMemberAddress>();
        }

        public int Id { get; set; }
        public string AddrTypeId { get; set; }
        public string AddrLn1 { get; set; }
        public string AddrLn2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public bool? InActive { get; set; }
        public DateTime? InActiveDate { get; set; }

        public AddrType AddrType { get; set; }
        public ICollection<AdultMemberAddress> AdultMemberAddress { get; set; }
    }
}
