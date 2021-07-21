using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTable.Repository
{
    public interface IDbRepository
    {
        dynamic GetEverything();
        IQueryable<Member> Get(int id);
        dynamic GetDates();
        void Create(Member member);
        void Update(Member member);
        IQueryable<Member> Delete(int id);
    }
}
