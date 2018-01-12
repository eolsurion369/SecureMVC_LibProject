using System;
using System.Collections.Generic;

namespace LibProject_Api.Models
{
    public partial class LibraryLogin
    {
        public string UserId { get; set; }
        public string UserPw { get; set; }
        public DateTime PwupdateDate { get; set; }
        public DateTime PwexpirationDate { get; set; }
        public bool? AccountLockout { get; set; }
    }
}
