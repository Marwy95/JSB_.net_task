using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace JSB_.net_task.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        [Required]
        public string Name { get; set; } =string.Empty;
        [Required]
        public string Status { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set;}
        public DateTime EndDate { get; set; }
        public int? TeamMemberId { get; set; } 
        public TeamMember? TeamMember { get; set; } 


    }
}
