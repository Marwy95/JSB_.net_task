using JSB_.net_task.Data;
using JSB_.net_task.Models;
using Microsoft.AspNetCore.Mvc;

namespace JSB_.net_task.Controllers
{
    [ApiController]
    [Route("api/member")]
    public class TeamMemberController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TeamMemberController(ApplicationDbContext context)
        {
            _context = context;
        }
        //Get All Members
        [HttpGet]
        public IEnumerable<TeamMember> GetAllMembers()
        {
            var allmembers = _context.TeamMembers.ToList();
            return allmembers;
        }
        //Get Member By Id
        [HttpGet("{id}")]
        public ActionResult<TeamMember> GetMemberById(int id)
        {
            var member = _context.TeamMembers.Find(id);
            if (member == null)
            {
                return NotFound("Id Doesn't Exist");
            }
            return Ok(member);
        }
        [HttpPost]
        public ActionResult AddMember(TeamMember member)
        {
            try
            {
                _context.TeamMembers.Add(member);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.Message);
            }

            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult EditMember(int id,TeamMember member) {

            var existingMember = _context.TeamMembers.Find(id);
            if (existingMember == null)
            {
                return NotFound("Id Doesn't Exist");
            }
             existingMember.Name= member.Name ;
            existingMember.Email = member.Email;
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteMember(int id)
        {
            var member = _context.TeamMembers.Find(id);
            if (member == null)
            {
                return NotFound("Id Doesn't Exist");
            }
            _context.TeamMembers.Remove(member);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
