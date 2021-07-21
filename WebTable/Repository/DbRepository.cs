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
        public dynamic GetEverything()
        {
            var query = from member in context.Members
                        select new
                        {
                            Id = member.Id,
                            Name = member.Name,
                            Sername = member.Sername,
                            MiddleName = member.MiddleName,
                            Nickname = member.Nickname,
                            Email = member.Email,
                            RegistrationDate = member.RegistrationDate,
                            LastActiveDate = member.LastActivityDate
                        };
            return query;
        }
        public IQueryable<Member> Get(int id)
        {
            //var query = from member in context.Members
            //            where member.Id == id
            //            select member;
            //return query;
            //return context.Members.Find(id);
            return context.Set<Member>().AsQueryable();
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
            //Member member = Get(updatedMember.Id);
            //member.Name = updatedMember.Name;
            //member.Sername = updatedMember.Sername;
            //member.MiddleName = updatedMember.MiddleName;
            //member.Nickname = updatedMember.Nickname;
            //member.Email = updatedMember.Email;
            //member.RegistrationDate = updatedMember.RegistrationDate;
            //member.LastActivityDate = updatedMember.LastActivityDate;

            //context.Members.Update(member);
            //context.SaveChanges();
            context.Set<Member>().Update(updatedMember);
        }
        public IQueryable<Member> Delete(int id)
        {
            IQueryable<Member> member = Get(id);

            if (member != null)
            {
                //todo: дописать метод
                //context.Set<Member>().Remove(id);
                //context.SaveChanges();
            }

            return member;
        }
    }
}
