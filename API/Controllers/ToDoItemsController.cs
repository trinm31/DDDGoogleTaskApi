using API.Authorization;
using API.DTOs.Todos;
using API.Services.TodoItems;
using API.Services.Todos;
using Domain.Entities.TodoItems;
using Domain.Entities.Todos;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ToDoItemsController : ApplicationController
    {
        private readonly TodoItemService _todoItemService;

        public ToDoItemsController(TodoItemService todoItemService, IHttpContextAccessor httpContextAccessor): base(httpContextAccessor)
        {
            _todoItemService = todoItemService;
        }

        #region CRUD

        [HttpGet]
        public async Task<IList<TodoItem>> GetAll()
        {
            return await _todoItemService.GetAll();
        }

        [HttpPut]
        public async Task Update(TodoItemUpSertRequest todoItemUpSertDto)
        {
            var user = GetCurrentUser();
            await _todoItemService.Update(todoItemUpSertDto, user);
        }

        [HttpGet("{id:int}")]
        public async Task<TodoItem> GetOne([FromRoute] int id)
        {
            return await _todoItemService.GetOne(id);
        }

        [HttpPost]
        public async Task Add(TodoItemUpSertRequest todoItemUpSertDto)
        {
            var user = GetCurrentUser();
            await _todoItemService.Add(todoItemUpSertDto, user);
        }

        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            var user = GetCurrentUser();
            await _todoItemService.Delete(id, user);
        }

        [HttpGet("[action]/{id:int}")]
        public async Task IsDone([FromRoute] int id)
        {
            await _todoItemService.IsDone(id);
        }

        #endregion

    }
}
