using System.Data.Entity;
using TodoApp.Api.Models;

namespace TodoApp.Api.DataAccess
{
    public class Database:DbContext
    {
        public Database():base("DefaultConnection"){}
        public virtual DbSet<TodoList> Lists { get; set; }
        public virtual DbSet<TodoListItem> Items { get; set; }
    }
}