using API.Authorization;
using API.DTOs.ProjectDtos;
using API.Services.Projects;
using Domain.Entities.ListTasks;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ListTasksController : ApplicationController
    {
        private readonly ListTaskService _listTaskService;

        public ListTasksController(ListTaskService listTaskService, IHttpContextAccessor httpContextAccessor):base(httpContextAccessor)
        {
            _listTaskService = listTaskService;
        }

        #region CRUD
        [HttpGet]
        public async Task<IList<ListTask>> GetAll()
        {
            return await _listTaskService.GetAll();
        }

        [HttpPut]
        public async Task Update(ListTaskUpsertRequest listTaskDto)
        {
            var user = GetCurrentUser();
            await _listTaskService.Update(listTaskDto, user);
        }

        [HttpGet("{id:int}")]
        public async Task<ListTask> GetOne([FromRoute] int id)
        {
            return await _listTaskService.GetOne(id);
        }

        [HttpPost]
        public async Task Add(ListTaskUpsertRequest listTaskDto)
        {
            var user = GetCurrentUser();
            await _listTaskService.Add(listTaskDto, user);
        }

        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            var user = GetCurrentUser();
            await _listTaskService.Delete(id, user);
        }

        #endregion

    }
}
