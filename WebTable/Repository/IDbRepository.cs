using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTable.Repository
{
    public interface IDbRepository
    {
        IQueryable<Member> GetEverything();
        Member Get(int id);
        dynamic GetDates();
        void Create(Member member);
        void Update(Member member);
        Member Delete(int id);
        double CountRR7D();
    }
}
