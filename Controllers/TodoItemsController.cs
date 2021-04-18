using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers
{
    [Route("todos")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoService _todoService;

        public TodoItemsController(TodoService todoService)
        {
            _todoService = todoService;
        }

        // GET: api/todos
        [HttpGet]
        public ActionResult<List<TodoItemDTO>> Get() =>
            Ok(_todoService.Get()
            .ConvertAll(item => ItemToDTO(item)));

        // GET: api/todos/5
        [HttpGet("{id:length(24)}", Name = "GetTodoItem")]
        public ActionResult<TodoItemDTO> GetTodoItem(string id)
        {
            var todoItem = _todoService.Get(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return ItemToDTO(todoItem);
        }

        [HttpPost]
        public ActionResult<TodoItemDTO> Create(TodoItemCreateDTO todoItemCreateDTO)
        {
            var todoItem = new TodoItem
            {
                IsComplete = todoItemCreateDTO.IsComplete,
                Name = todoItemCreateDTO.Name
            };

            _todoService.Create(todoItem);

            return CreatedAtRoute("GetTodoItem", new { id = todoItem.Id.ToString() }, todoItem);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, TodoItemCreateDTO todoItemDTO)
        {
            var todoItem = _todoService.Get(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            todoItem.Name = todoItemDTO.Name;
            todoItem.IsComplete = todoItemDTO.IsComplete;

            _todoService.Update(id, todoItem);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var todoItem = _todoService.Get(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _todoService.Remove(todoItem.Id);

            return NoContent();
        }

        private static TodoItemDTO ItemToDTO(TodoItem todoItem) =>
            new TodoItemDTO
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };
    }
}
