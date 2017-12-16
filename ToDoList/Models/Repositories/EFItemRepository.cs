using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class EFItemRepository : IItemRepository
    {
        ToDoListDbContext db = new ToDoListDbContext();
    }
}
