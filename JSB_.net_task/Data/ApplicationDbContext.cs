using Microsoft.EntityFrameworkCore;

namespace JSB_.net_task.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
       // pro

    }
}
