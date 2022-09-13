using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ClubSystemsProject.Models;

namespace ClubSystemsProject.DAL
{
    public class ClubInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ClubContext>
    {
        protected override void Seed(ClubContext context)
        {
            var members = new List<Member>
            {
            new Member{FirstName="Carson",LastName="Alexander",Email="genericemail@gmail.com"},
            new Member{FirstName="Billy",LastName="Bob",Email="genericemail@gmail.com"},
            new Member{FirstName="John",LastName="Jones",Email="genericemail@gmail.com"},
            new Member{FirstName="Spencer",LastName="Manson",Email="genericemail@gmail.com"},
            new Member{FirstName="Francis",LastName="Crock",Email="genericemail@gmail.com"},
            new Member{FirstName="Emily",LastName="Blossom",Email="genericemail@gmail.com"},
            new Member{FirstName="Richard",LastName="Cheese",Email="genericemail@gmail.com"}
            };

            members.ForEach(m => context.Members.Add(m));
            context.SaveChanges();

            var membershipTypes = new List<MembershipType>
            {
            new MembershipType{MembershipTypeID=1, MemType=MemType.Primary,},
            new MembershipType{MembershipTypeID=2, MemType=MemType.Secondary,},
            new MembershipType{MembershipTypeID=3, MemType=MemType.Tertiary,}
            };

            membershipTypes.ForEach(m => context.MembershipTypes.Add(m));
            context.SaveChanges();

            var memberships = new List<Membership>
            {
            new Membership{MemberID=1,MembershipTypeID=1,Balance=20.00m},
            new Membership{MemberID=1,MembershipTypeID=2,Balance=30.00m},
            new Membership{MemberID=2,MembershipTypeID=2,Balance=10.00m},
            new Membership{MemberID=3,MembershipTypeID=1,Balance=20.00m},
            new Membership{MemberID=4,MembershipTypeID=3,Balance=60.00m},
            new Membership{MemberID=5,MembershipTypeID=2,Balance=90.00m}

            };
            memberships.ForEach(m => context.Memberships.Add(m));
            context.SaveChanges();
        }
    }
}