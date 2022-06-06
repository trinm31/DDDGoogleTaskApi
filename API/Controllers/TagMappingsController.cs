using API.Authorization;
using API.DTOs.TagDtos;
using API.Services.TagServices;
using Domain.Entities.Tags;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TagMappingsController : ApplicationController
    {
        private readonly TagMappingService _tagMappingService;

        public TagMappingsController(TagMappingService tagMappingService, IHttpContextAccessor httpContextAccessor): base(httpContextAccessor)
        {
            _tagMappingService = tagMappingService;
        }

        [HttpPost]
        public async Task Add(TagMappingUpSertRequest tagMappingDto)
        {
            var user = GetCurrentUser();
            await _tagMappingService.Add(tagMappingDto, user);
        }

        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            var user = GetCurrentUser();
            await _tagMappingService.Delete(id, user);
        }

    }
}
