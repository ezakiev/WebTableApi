using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WebTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public MembersController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            using (web_clientContext db = new web_clientContext())
            {
                var members = from member in db.Members
                              select new {id = member.Id, name = member.Name, sername = member.Sername,
                              middle_name = member.MiddleName, nickname = member.Nickname, email = member.Email,
                              registration_date = member.RegistrationDate, last_active_date = member.LastActivityDate};
                return (JsonResult)members;
            }
        }
    }
}
