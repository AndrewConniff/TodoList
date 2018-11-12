using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Services
{
    public interface IListService
    {
        Task<TodoListDto> GetTodoListByIdAsync(Guid id);
        Task<IEnumerable<TodoListDto>> GetTodoListsAsync(string sortString);
        Task<TodoTask> CompleteTask(Guid id, Guid taskId);
        Task CreateList(TodoListDto list);
        Task AddTaskAsync(Guid id, TodoTask value);
    }
}
