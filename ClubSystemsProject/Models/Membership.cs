using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ClubSystemsProject.Models
{
    public class Membership
    {
        public int MembershipID { get; set; }
        public int MembershipTypeID { get; set; }
        public int MemberID { get; set; }
        public decimal Balance { get; set; }

        public virtual MembershipType MembershipType { get; set; }
        public virtual Member Member { get; set; }
    }
}