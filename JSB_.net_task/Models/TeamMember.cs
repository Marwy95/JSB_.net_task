using System.ComponentModel.DataAnnotations;

namespace JSB_.net_task.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}
