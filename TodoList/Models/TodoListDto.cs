using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Models
{
    public class TodoListDto
    {
        [Required]
        public TodoListModel Todos { get; set; }
        public List<TodoTask> Tasks { get; set; }
    }
}
