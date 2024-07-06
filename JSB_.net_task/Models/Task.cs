namespace JSB_.net_task.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Name { get; set; } =string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set;}
        public DateTime EndDate { get; set; }


    }
}
