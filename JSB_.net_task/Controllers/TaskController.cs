using JSB_.net_task.Data;
using JSB_.net_task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JSB_.net_task.Controllers
{
    [ApiController]
    [Route("api/task")]
    public class TaskController:ControllerBase
    {
            private readonly ApplicationDbContext _context;
            public TaskController(ApplicationDbContext context)
            {
                _context = context;
            }
        //Get All Tasks
        [HttpGet]
        public  ActionResult <ICollection<Models.Task>>  GetAllTasks()
        {
           
            var allTasks =  _context.Tasks
                .Include(t => t.TeamMember)
                .ToList();
            if (!allTasks.Any()) return NotFound("No Tasks Found");
            return Ok(allTasks) ;
        }
        
        //Get Task By Id
        [HttpGet("{id}")]
        public ActionResult<Models.Task> GetTaskById(int id)
        {
            var task = _context.Tasks
                       .Include(t => t.TeamMember)
                       .SingleOrDefault(t=>t.TaskId==id);
            if (task == null)
            {
                return NotFound("Id Doesn't Exist");
            }
            return Ok(task);
        }
        
        //Add New Task
        [HttpPost]
        public ActionResult Addtask(Models.Task task)
        {
            try
            {
                _context.Tasks.Add(task);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                
                return BadRequest("The Member You're trying to add the task to doesn't exist");
            }

            return Ok();
        }
        
        //Edit Task By Id
        [HttpPut("{id}")]
        public ActionResult EditTask(int id, Models.Task task)
        {
            try
            {
                var existingtask = _context.Tasks.Find(id);
                if (existingtask == null)
                {
                    return NotFound("Id Doesn't Exist");
                }
                existingtask.Name = task.Name;
                existingtask.Description = task.Description;
                existingtask.Status = task.Status;
                existingtask.StartDate = task.StartDate;
                existingtask.EndDate = task.EndDate;
                existingtask.TeamMemberId = task.TeamMemberId;
                _context.SaveChanges();
                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest("The Member You're trying to add the task to doesn't exist");
            }
  
        }
        
        //Delete Task By Id
        [HttpDelete("{id}")]
        public ActionResult DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                return NotFound("Id Doesn't Exist");
            }
            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
