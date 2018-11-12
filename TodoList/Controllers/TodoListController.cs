using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReflectionIT.Mvc.Paging;
using TodoList.Models;
using TodoList.Services;

namespace TodoList.Controllers
{
    [Route("api")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private IListService _service;
        public TodoListController(IListService service)
        {
            _service = service;
        }
        // GET api/lists
        [HttpGet("lists")]
        public  async Task<IActionResult> GetAll( string  searchString= "", int skip = 0, int limit = 0)
        {
            // TODO get all the lists by search parameter
            try
            {
                var getlistsAsync = await _service.GetTodoListsAsync(searchString);
                IOrderedQueryable<TodoListDto> castList = getlistsAsync.OrderBy(x => x.Todos.Id) as IOrderedQueryable<TodoListDto>;
                if (limit < 1 || skip < 1)
                {
                    return Ok(castList);
                }
                var page = skip / limit; // Example - skip = 30 limit = 10 means page 3
                // PageList params: the list, the number of results per page, the page number.
                var paninateTodos = PagingList.CreateAsync<TodoListDto>(castList, limit, page);
                return Ok(paninateTodos);
            }
            catch
            {
                return BadRequest("No lists found");
            }

        }

        // GET api/lists/5
        [HttpGet("list/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            // Return the specified list DTO
            try
            {
                var result = await _service.GetTodoListByIdAsync(id);
                return Ok(result);

            }
            catch
            {
                return BadRequest("Nothing found for that Id");
            }

        }

        // POST api/lists
        [HttpPost]
        public IActionResult CreateNewList([FromBody] TodoListDto value)
        {
            // Create new list
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _service.CreateList(value);
            }
            catch
            {
                // TODO return the correct respnce.
                return null;
            }

            return CreatedAtAction("Get", new {id = value.Todos.Id}, value);
        }
        // POST api/lists
        [HttpPost("list/{id}/task/{taskId}/complete")]
        public IActionResult TaskCompleted(Guid id, Guid taskId)
        {
            // Create new list
            if (id != null && taskId != null)
            {
                var result = _service.CompleteTask(id, taskId);
                return AcceptedAtAction($"Task with id {taskId} Comlpeted");
            }
            else
            {
                return BadRequest();
            }
        }


    }
}
