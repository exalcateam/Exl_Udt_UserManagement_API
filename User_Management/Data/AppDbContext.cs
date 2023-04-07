using Microsoft.EntityFrameworkCore;
using User_Management.Model;

namespace User_Management.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
       public DbSet<UserDetail> Users { get; set; } 
    }
}
