using System;
using System.Collections.Generic;

namespace TodoApp.Api.Models
{
    public class TodoListView
    {
        public Guid ListId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<TodoListItemView> Items { get; set; }
    }
}