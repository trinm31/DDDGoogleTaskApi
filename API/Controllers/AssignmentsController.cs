using API.Authorization;
using API.DTOs.TaskItemDtos;
using API.Services.Assignments;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentsController : ApplicationController
    {
        private readonly AssignmentService _assignService;

        public AssignmentsController(AssignmentService assignService, IHttpContextAccessor httpContextAccessor): base(httpContextAccessor)
        {
            _assignService = assignService;
        }

        [HttpPost]
        public async Task Add(AssignmentUpSertRequest assignUpSertDto)
        {
            var user = GetCurrentUser();
            await _assignService.Add(assignUpSertDto, user);
        }

        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            var user = GetCurrentUser();
            await _assignService.Delete(id, user);
        }
    }
}
