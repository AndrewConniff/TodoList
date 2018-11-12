using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;
using TodoList.Repositories;

namespace TodoList.Services
{
    public class ListService : IListService
    {
        private readonly ITodoListRepository _repository;
        public ListService(ITodoListRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<TodoListDto>> GetTodoListsAsync(string sortString)
        {
            var todos =  await _repository.GetAllTodosAsync();
            var result = SearchTodos(todos, sortString);
            return await mapTodoDto(result);
        }

        private async Task<IEnumerable<TodoListDto>> mapTodoDto(IList<TodoListModel> result)
        {
            IList<TodoListDto> mappedDtos = new List<TodoListDto>();
            foreach (var item in result)
            {
               var mappedDto = await mapTodoDto(item);
                mappedDtos.Add(mappedDto);
            };
            IEnumerable<TodoListDto> castDto = new List<TodoListDto>();
            castDto = mappedDtos;

            return castDto.OrderBy(i => i.Id);
        }

        public async Task<TodoListDto> GetTodoListByIdAsync(Guid Id)
        {
            var todo = await _repository.GetTodoByIdAsync(Id);
            return await mapTodoDto(todo);
        }

        private async Task<TodoListDto> mapTodoDto(TodoListModel item)
        {
            TodoListDto mappedDto = new TodoListDto();
            mappedDto.Id = item.Id;
            mappedDto.Name = item.Name;
            mappedDto.Description = item.Description;
            mappedDto.Tasks = await _repository.getTasksByTodoIdAsync(item.Id);
            return mappedDto;
        }

        public IList<TodoListModel> SearchTodos(IList<TodoListModel> list, string sortString)
        {
            if (list.Count > 1 && !string.IsNullOrEmpty(sortString))
            {
                return list.Where(x => x.Name.ToLower().Contains(sortString.ToLower())).ToList();
            }
            return list;
        }

        public async Task CompleteTask(Guid id, Guid taskId)
        {
            await _repository.ComleteTask( id, taskId);
        }


        public async Task CreateList(TodoListDto list)
        {
            // todo find out in the controller what we need to pass in and create
            // the following object
            var tasks = list.Tasks.Where(x => x.Id != null);
            TodoListModel newList = new TodoListModel
            {
                Id = list.Id,
                Name = list.Name,
                Description = list.Description
            };
            foreach (var task in tasks)
            {
                task.ListId = list.Id;
            }
            // create the list first so the foreign key is there.
            await _repository.AddLisAsynct(newList);
            // add the tasks
            await _repository.AddTaskAsync(tasks);
        }

        Task<TodoTask> IListService.CompleteTask(Guid id, Guid taskId)
        {
            throw new NotImplementedException();
        }

        public async Task AddTaskAsync(Guid id, TodoTask value)
        {
            value.ListId = id;
            await _repository.AddTaskAsync(value);
        }
    }
}
