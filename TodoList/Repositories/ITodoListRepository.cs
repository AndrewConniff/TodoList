using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Repositories
{
    public interface ITodoListRepository
    {
        Task<IList<TodoListModel>> GetAllTodosAsync();
        Task<TodoListModel> GetTodoByIdAsync(Guid Id);
        Task AddLisAsynct(TodoListModel list);
        Task ComleteTask(Guid id, Guid taskId);
        Task AddTaskAsync(IEnumerable<TodoTask> tasks);
        Task<List<TodoTask>> getTasksByTodoIdAsync(Guid id);
    }
}
