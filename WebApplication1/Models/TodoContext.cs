using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace WebApplication1.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoProducts> TodoItems { get; set; } = null!;
    }
}
