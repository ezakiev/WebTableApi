using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTable.Repository
{
    public class DbRepository : IDbRepository
    {
        private readonly web_clientContext context;
        public DbRepository(web_clientContext context)
        {
            this.context = context;
        }
        public IQueryable<Member> GetEverything()
        {
            return context.Members;
        }
        public Member Get(int id)
        {
            return context.Members.Find(id);
        }
        public dynamic GetDates()
        {
            var members = from member in context.Members
                        select new { Id = member.Id, RegistrationDate = member.RegistrationDate, 
                            LastActivityDate = member.LastActivityDate };
            return members;
        }
        public void Create(Member member)
        {
            context.Members.Add(member);
            context.SaveChanges();
        }
        public void Update(Member updatedMember)
        {
            Member member = Get(updatedMember.Id);
            member.Name = updatedMember.Name;
            member.Sername = updatedMember.Sername;
            member.MiddleName = updatedMember.MiddleName;
            member.Nickname = updatedMember.Nickname;
            member.Email = updatedMember.Email;
            member.RegistrationDate = updatedMember.RegistrationDate;
            member.LastActivityDate = updatedMember.LastActivityDate;

            context.Members.Update(member);
            context.SaveChanges();
        }
        public Member Delete(int id)
        {
            Member member = Get(id);

            if (member != null)
            {
                context.Members.Remove(member);
                context.SaveChanges();
            }

            return member;
        }
    }
}
