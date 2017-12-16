using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Tests.Models
{
    public class TestDbContext : ToDoListDbContext
    {
        public override DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"server = localhost; user id = root; password = root; port = 8889; database = todo_test; ");
        }
    }
}
