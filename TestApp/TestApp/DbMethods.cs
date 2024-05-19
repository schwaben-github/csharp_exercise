using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class DbMethods
    {
        public void AddMember(Member member)
        {
            using (var context = new LibraryContext())
            {
                context.Members.Add(member);
                context.SaveChanges();
            }
        }

        public Member FindMember(int clanId)
        {
            using (var context = new LibraryContext())
            {
                return context.Members
                    .FirstOrDefault(m => m.ClanId == clanId);
            }
        }

        public void UpdateMember(Member updatedMember)
        {
            using (var context = new LibraryContext())
            {
                var member = context.Members.Find(updatedMember.ClanId);
                if (member != null)
                {
                    member.Ime = updatedMember.Ime;
                    member.Prezime = updatedMember.Prezime;
                    member.AdresaId = updatedMember.AdresaId;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteMember(int clanId)
        {
            using (var context = new LibraryContext())
            {
                var member = context.Members.Find(clanId);
                if (member != null)
                {
                    context.Members.Remove(member);
                    context.SaveChanges();
                }
            }
        }

        public List<Member> ListAllMembers()
        {
            using (var context = new LibraryContext())
            {
                return context.Members.ToList();
            }
        }
    }
}
