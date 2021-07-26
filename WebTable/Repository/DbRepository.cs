using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

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
                          let reg_date = member.RegistrationDate
                          let last_date = member.LastActivityDate
                        select new { Id = member.Id, RegistrationDate = reg_date.ToString("d"), 
                            LastActivityDate = last_date.ToString("d") };
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

        public double CountRR7D()
        {
            var members = from member in context.Members
                          select new
                          {
                              Id = member.Id,
                              RegistrationDate = member.RegistrationDate,
                              LastActivityDate = member.LastActivityDate
                          };

            double active_users_amount = 0;
            foreach (var member in members)
                if ((member.LastActivityDate - member.RegistrationDate).Days >= 7)
                    active_users_amount++;

            double rr7d = active_users_amount / Convert.ToDouble(context.Members.Count()) * 100;
            return rr7d;
        }

        public Dictionary<string, int> BuildHistogram()
        {
            var members = context.Members;
            var first_member = members.First();

            // Start values of min and max
            TimeSpan min_date_diff = first_member.LastActivityDate - first_member.RegistrationDate;
            TimeSpan max_date_diff = min_date_diff;

            // Searching for max and min amount of days in app
            foreach (var member in members)
            {
                var date_diff = member.LastActivityDate - member.RegistrationDate;
                min_date_diff = min_date_diff > date_diff ? date_diff : min_date_diff;
                max_date_diff = max_date_diff < date_diff ? date_diff : max_date_diff;
            }

            Dictionary<string, int> histogram_data = new Dictionary<string, int>();

            // Creating histogram ranges
            for (int i = min_date_diff.Days / 10; i <= max_date_diff.Days / 10; i++) // dividing by 10 for getting the histogram range number
            {
                StringBuilder sb = new StringBuilder(Convert.ToString(i));
                if (i == 0)
                    sb.Append(" - 10"); //creating 0-10 range
                else
                {
                    sb.Append("0 - ");
                    sb.Append(Convert.ToString(i + 1));
                    sb.Append("0");
                }
                histogram_data.Add(sb.ToString(), 0);
            }

            //Filling ranges
            foreach (var member in members)
            {
                int date_diff = (member.LastActivityDate - member.RegistrationDate).Days;
                int range_number = date_diff / 10; // The number of range in histogram, where this member has to go

                if (range_number == 0)
                    histogram_data["0 - 10"]++; // adding member to 0-10 range
                else
                {
                    StringBuilder sb = new StringBuilder(Convert.ToString(range_number)); //creating key of range
                    sb.Append("0 - ");
                    sb.Append(Convert.ToString(range_number + 1));
                    sb.Append("0");
                    histogram_data[sb.ToString()]++; //adding member to his range
                }
            }

            return histogram_data;
        }

    }
}
