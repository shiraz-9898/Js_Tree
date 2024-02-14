using Microsoft.EntityFrameworkCore;

namespace Js_Tree.Models
{
    public class TreeDbContext:DbContext
    {
        public TreeDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Tree> Trees { get; set; }
    }
}
