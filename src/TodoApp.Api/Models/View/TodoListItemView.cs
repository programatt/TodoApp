using System;

namespace TodoApp.Api.Models
{
    public class TodoListItemView
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Completed { get; set; }
    }
}