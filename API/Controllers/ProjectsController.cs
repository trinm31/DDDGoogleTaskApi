using API.Authorization;
using API.DTOs.Projects;
using API.Services.Projects;
using Domain.Entities.Projects;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ApplicationController
    {
        private readonly ProjectService _projectService;

        public ProjectsController(ProjectService projectService, IHttpContextAccessor httpContextAccessor): base(httpContextAccessor)
        {
            _projectService = projectService;
        }

        #region CRUD

        [HttpGet]
        public async Task<IList<Project>> GetAll()
        {
            return await _projectService.GetAll();
        }

        [HttpPut]
        public async Task Update(ProjectUpSertRequest projectDto)
        {
            var user = GetCurrentUser();
            await _projectService.Update(projectDto, user);
        }

        [HttpGet("{id:int}")]
        public async Task<Project> GetOne([FromRoute] int id)
        {
            return await _projectService.GetOne(id);
        }

        [HttpPost]
        public async Task Add(ProjectUpSertRequest projectDto)
        {
            var user = GetCurrentUser();
            await _projectService.Add(projectDto, user);
        }

        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            var user = GetCurrentUser();
            await _projectService.Delete(id, user);
        }

        #endregion

    }
}
