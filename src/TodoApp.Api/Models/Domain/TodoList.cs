using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp.Api.Models
{
    [Table("Lists")]
    public class TodoList
    {
        [Key]
        public Guid ListId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<TodoListItem> Items { get; set; }
    }
}