using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Repositories
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly TodoListContext _context;
        public TodoListRepository(TodoListContext context)
        {
            _context = context;
        }

        public async Task AddLisAsynct(TodoListModel list)
        {
            var lists = _context.Set<TodoListModel>();
            await lists.AddAsync(list);
            _context.SaveChanges();

        }

        public async Task AddTaskAsync(IEnumerable<TodoTask> tasks)
        {
            var loacalTask = _context.Set<TodoTask>();
            await loacalTask.AddRangeAsync(tasks);
            _context.SaveChanges();
        }

        public async Task AddTaskAsync(TodoTask value)
        {
            var loacalTask = _context.Set<TodoTask>();
            await loacalTask.AddAsync(value);
            _context.SaveChanges();
        }

        public async Task ComleteTask(Guid id, Guid taskId)
        {
            var completedTask = await _context.Tasks.FirstOrDefaultAsync(x => x.ListId == id && x.Id == taskId);
            completedTask.Completed = true;
            _context.Entry(completedTask).State = EntityState.Modified;
            await (_context.SaveChangesAsync());
        }

        public async Task<IList<TodoListModel>> GetAllTodosAsync()
        {
            return await _context.TodoLists.ToListAsync();
        }

        public async Task<List<TodoTask>> getTasksByTodoIdAsync(Guid id)
        {
            var allTasks = await _context.Tasks.ToListAsync();
            return  allTasks.FindAll(x => x.ListId == id);
        }

        public async Task<TodoListModel> GetTodoByIdAsync(Guid Id)
        {
            return await _context.TodoLists.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
