using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Models
{
    public class TodoTask
    {
        [Key, Required]
        public Guid Id { get; set; }
        [ForeignKey("TodoListForeignKey")]
        public Guid ListId { get; set; }
        public string Name { get; set; }
        public bool  Completed{ get; set; }
    }
}
