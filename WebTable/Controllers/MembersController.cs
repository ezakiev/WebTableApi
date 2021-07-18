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
        public IQueryable Get()
        {
            web_clientContext db = new web_clientContext();
            var members = from member in db.Members
                          select member;
            return members;
        }
    }
}
