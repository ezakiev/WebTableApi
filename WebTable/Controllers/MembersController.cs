using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WebTable.Repository;

namespace WebTable.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        IDbRepository dbRepository;
        public MembersController(IDbRepository dbRepository)
        {
            this.dbRepository = dbRepository;
        }

        [HttpGet(Name = "GetAllItems")]
        public IQueryable<Member> GetEverything()
        {
            return dbRepository.GetEverything();
        }

        [HttpGet("{id}", Name = "GetMember")]
        public IActionResult Get(int id)
        {
            Member member = dbRepository.Get(id);

            if (member == null)
                return NotFound();

            return new ObjectResult(member);
        }

        [HttpGet(Name = "GetDates")]
        public dynamic GetDates()
        {
            return dbRepository.GetDates();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Member member)
        {
            if (member == null)
            {
                return BadRequest();
            }
            dbRepository.Create(member);
            return CreatedAtRoute("GetMember", new { id = member.Id }, member);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Member updatedMember)
        {
            if (updatedMember == null || updatedMember.Id != id)
            {
                return BadRequest();
            }

            var member = dbRepository.Get(id);
            if (member == null)
            {
                return NotFound();
            }

            dbRepository.Update(updatedMember);
            return RedirectToRoute("GetAllItems");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedMember = dbRepository.Delete(id);

            if (deletedMember == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deletedMember   );
        }
    }
}
