using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Data
{
    public class TodoListContext : DbContext
    {
        public TodoListContext(DbContextOptions<TodoListContext> options)
     : base(options)
        { }

        public DbSet<TodoTask> Tasks { get; set; }
        public DbSet<TodoListModel> TodoLists { get; set; }
    }
}
