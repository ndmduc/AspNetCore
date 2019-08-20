using Microsoft.EntityFrameworkCore;

namespace aspnetcoreapp.Data
{
    public class RazorPagesMovieContext : DbContext
    {
        public RazorPagesMovieContext(DbContextOptions<RazorPagesMovieContext> options) 
            : base(options)
        {
            
        }

        public DbSet<Models.Movie> Movie {get; set;}
    }
}