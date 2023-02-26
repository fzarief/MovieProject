using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MovieProject.Data
{
    public class MovieProjectContext : DbContext
    {
        public MovieProjectContext (DbContextOptions<MovieProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; } = default!;
    }
}
