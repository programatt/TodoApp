using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TodoApp.Api.Models;
using Database = TodoApp.Api.DataAccess.Database;

namespace TodoApp.Api.Controllers
{
    [RoutePrefix("api/lists")]
    public class ListsController : ApiController
    {
        private Database db = new Database();

        // GET: api/Lists
        [Route("")]
        public IEnumerable<TodoListView> GetLists()
        {
            return db.Lists.Select(todoList => new TodoListView
            {
                ListId = todoList.ListId,
                CreatedDate = todoList.CreatedDate,
                Items = todoList.Items.Select(i => new TodoListItemView
                {
                    ItemId = i.ItemId,
                    CreatedDate = i.CreatedDate,
                    Completed = i.Completed,
                    Name = i.Name
                }).ToList(),
                Name = todoList.Name
            }).ToList();
        }

        [Route("{id}")]
        // GET: api/Lists/5
        [ResponseType(typeof(TodoListView))]
        public async Task<IHttpActionResult> GetTodoList(Guid id)
        {
            TodoList todoList = await db.Lists.FindAsync(id);
            if (todoList == null)
            {
                return NotFound();
            }

            return Ok(new TodoListView
            {
                ListId = todoList.ListId,
                CreatedDate = todoList.CreatedDate,
                Items = todoList.Items.Select(i=> new TodoListItemView
                {
                    ItemId = i.ItemId,
                    CreatedDate = i.CreatedDate,
                    Completed = i.Completed,
                    Name = i.Name
                }).ToList(),
                Name = todoList.Name
             });
        }

        [Route("{id}")]
        // PUT: api/Lists/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTodoList(Guid id, TodoList todoList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != todoList.ListId)
            {
                return BadRequest();
            }

            db.Entry(todoList).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("")]
        // POST: api/Lists
        [ResponseType(typeof(TodoListView))]
        public async Task<IHttpActionResult> PostTodoList(TodoListView todoList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            todoList.ListId = Guid.NewGuid();
            todoList.CreatedDate = DateTime.Now;
            var entity = new TodoList
            {
                ListId = todoList.ListId,
                Name = todoList.Name,
                CreatedDate = todoList.CreatedDate
            };
            db.Lists.Add(entity);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TodoListExists(todoList.ListId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = entity.ListId }, todoList);
        }

        // DELETE: api/Lists/5
        [Route("{id}")]
        [ResponseType(typeof(TodoList))]
        public async Task<IHttpActionResult> DeleteTodoList(Guid id)
        {
            TodoList todoList = await db.Lists.FindAsync(id);
            if (todoList == null)
            {
                return NotFound();
            }

            db.Lists.Remove(todoList);
            await db.SaveChangesAsync();

            return Ok(todoList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TodoListExists(Guid id)
        {
            return db.Lists.Count(e => e.ListId == id) > 0;
        }
    }
}