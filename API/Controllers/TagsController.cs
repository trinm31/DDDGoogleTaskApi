using API.Authorization;
using API.DTOs.TagDtos;
using API.DTOs.TaskItems;
using API.Services.TagServices;
using Domain.Entities.Tags;
using Domain.Entities.Tasks;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TagsController : ApplicationController
    {
        private readonly TagService _tagService;

        public TagsController(TagService tagService, IHttpContextAccessor httpContextAccessor): base(httpContextAccessor)
        {
            _tagService = tagService;
        }

        #region CRUD

        [HttpGet]
        public async Task<IList<Tag>> GetAll()
        {
            return await _tagService.GetAll();
        }

        [HttpPut]
        public async Task Update(TagUpSertRequest tagDto)
        {
            var user = GetCurrentUser();
            await _tagService.Update(tagDto, user);
        }

        [HttpGet("{id:int}")]
        public async Task<Tag> GetOne([FromRoute] int id)
        {
            return await _tagService.GetOne(id);
        }

        [HttpPost]
        public async Task Add(TagUpSertRequest tagDto)
        {
            var user = GetCurrentUser();
            await _tagService.Add(tagDto, user);
        }

        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            var user = GetCurrentUser();
            await _tagService.Delete(id, user);
        }

        #endregion
    }
}
