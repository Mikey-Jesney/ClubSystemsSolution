using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubSystemsProject.Models
{
    public enum MemType
    {
        Primary, Secondary, Tertiary
    }
    public class MembershipType
    {
        public int MembershipTypeID { get; set; }
        public MemType MemType { get; set; }

        public virtual ICollection<Membership> Memberships { get; set; }
    }
}