using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Tests.Models
{
    public class TestDbContext : ToDoListDbContext
    {
        public override DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server = localhost; Port = 8889; database = todo_test; uid = root; pwd = root;");
        }
    }
}
