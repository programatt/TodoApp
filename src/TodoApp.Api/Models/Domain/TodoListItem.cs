using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp.Api.Models
{
    [Table("Items")]
    public class TodoListItem
    {
        [Key]
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Completed { get; set; }
        [ForeignKey("List")]
        public Guid ListId { get; set; }
        public virtual TodoList List { get; set; }
    }
}