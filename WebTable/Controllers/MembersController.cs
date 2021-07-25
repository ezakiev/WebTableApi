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
        readonly IDbRepository dbRepository;
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

        [HttpGet]
        public double GetMetrics()
        {
            return dbRepository.CountRR7D();
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
                ModelState.AddModelError("LastActDateIsBiggerThanRegDate", "The LastActivivtyDate can not be lower than RegistrationDate");

            if (member.Name == null)
                ModelState.AddModelError("NoName", "The Name is required");

            if (member.Sername == null)
                ModelState.AddModelError("NoSername", "The sername is required");

            if (member.Nickname == null)
                ModelState.AddModelError("NoNickname", "The nickname is required");

            if (member.Email == null)
                ModelState.AddModelError("NoEmail", "The emal is required");

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
                ModelState.AddModelError("LastActDateIsBiggerThanRegDate", "The LastActivivtyDate can not be lower than RegistrationDate");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            member.RegistrationDate = updatedMember.RegistrationDate;
            member.LastActivityDate = updatedMember.LastActivityDate;

            dbRepository.Update(member);
            return Ok("Succesfully updated");
        }

        [HttpPut]
        public IActionResult MultipleUpdate([FromBody] List<Member> updatedMembers)
        {
            for (int i = 0; i < updatedMembers.Count; i++)
            {
                Member member = updatedMembers[i];
                Member member_from_db = dbRepository.Get(member.Id);

                if (member_from_db == null)
                {
                    return NotFound($"There is no member with id = {member.Id}");
                }

                if (updatedMembers == null)
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

                member_from_db.RegistrationDate = member.RegistrationDate;
                member_from_db.LastActivityDate = member.LastActivityDate;
                updatedMembers[i] = member_from_db;
            }

            foreach(Member person in updatedMembers)
            {
                dbRepository.Update(person);
            }

            return Ok("Successfully updated");
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
