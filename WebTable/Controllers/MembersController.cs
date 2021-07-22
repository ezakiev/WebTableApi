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
                ModelState.AddModelError("Null", "Not found input data");

            if (member.RegistrationDate > DateTime.Now)
                ModelState.AddModelError("RegDateTooBig", "The RegistrationDate is unacceptable");

            if (member.LastActivityDate > DateTime.Now)
                ModelState.AddModelError("LastActDateTooBig", "The LastActivityDate is unacceptable");

            if (member.RegistrationDate < Convert.ToDateTime("01.01.2000").Date)
                ModelState.AddModelError("RegDateTooSmall", "The RegistrationDate can not be earlier than 01.01.2000");

            if (member.LastActivityDate < Convert.ToDateTime("01.01.2000").Date)
                ModelState.AddModelError("LastActDateTooSmall", "The LastActivityDate can not be earlier than 01.01.2000");

            if (member.LastActivityDate < member.RegistrationDate)
                ModelState.AddModelError("LastActDateIsBiggerThanRegDate", "The LastActivivtyDate can not be bigger than RegistrationDate");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            dbRepository.Create(member);
            return CreatedAtRoute("GetMember", new { id = member.Id }, member);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Member updatedMember)
        {
            var member = dbRepository.Get(id);
            if (member == null)
            {
                return NotFound();
            }

            if (updatedMember == null)
                ModelState.AddModelError("Null", "Not found input data");

            if (updatedMember.RegistrationDate > DateTime.Now)
                ModelState.AddModelError("RegDateTooBig", "The RegistrationDate is unacceptable");

            if (updatedMember.LastActivityDate > DateTime.Now)
                ModelState.AddModelError("LastActDateTooBig", "The LastActivityDate is unacceptable");

            if (updatedMember.RegistrationDate < Convert.ToDateTime("01.01.2000").Date)
                ModelState.AddModelError("RegDateTooSmall", "The RegistrationDate can not be earlier than 01.01.2000");

            if (updatedMember.LastActivityDate < Convert.ToDateTime("01.01.2000").Date)
                ModelState.AddModelError("LastActDateTooSmall", "The LastActivityDate can not be earlier than 01.01.2000");

            if (updatedMember.LastActivityDate < updatedMember.RegistrationDate)
                ModelState.AddModelError("LastActDateIsBiggerThanRegDate", "The LastActivivtyDate can not be bigger than RegistrationDate");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            dbRepository.Update(updatedMember);
            return RedirectToRoute("GetAllItems");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedMember = dbRepository.Delete(id);

            if (deletedMember == null)
                ModelState.AddModelError("UserNotFound", $"There is no user with id = {id}");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return new ObjectResult(deletedMember);
        }

    }
}
