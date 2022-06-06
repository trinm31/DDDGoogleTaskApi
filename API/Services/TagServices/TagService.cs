using API.DTOs.TagDtos;
using API.DTOs.TaskItems;
using AutoMapper;
using Domain.Entities.Tags;
using Domain.Entities.Tasks;
using Domain.Entities.Users;
using Domain.Interfaces;

namespace API.Services.TagServices
{
    public class TagService: BaseService
    {
        public TagService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IList<Tag>> GetAll()
        {
            var tags = await UnitOfWork.Repository<Tag>().GetAllAsync(x => x.IsDeleted == false);
            return tags.ToList();
        }

        public async Task<Tag> GetOne(int taskId)
        {
            return await UnitOfWork.Repository<Tag>().GetFirstOrDefaultAsync(x => x.Id == taskId && x.IsDeleted == false);
        }

        public async Task Update(TagUpSertRequest tagDto, User user)
        {
            try
            {
                await UnitOfWork.BeginTransaction();

                var tag = Mapper.Map<Tag>(tagDto);

                var tagRepos = UnitOfWork.Repository<Tag>();
                var tagDb = await tagRepos.FindAsync(tagDto.Id);
                if (tagDb == null)
                    throw new KeyNotFoundException();

                tagDb.Name = tag.Name;
                tagDb.Color = tag.Color;
                tagDb.UpdatedDate = DateTime.Now;
                tagDb.UpdatedById = user.Id;

                await UnitOfWork.CommitTransaction();
            }
            catch (Exception e)
            {
                await UnitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Add(TagUpSertRequest tagDto, User user)
        {
            try
            {
                await UnitOfWork.BeginTransaction();

                var tag = Mapper.Map<Tag>(tagDto);

                var tagRepos = UnitOfWork.Repository<Tag>();

                tag.CreatedDate = DateTime.Now;
                tag.CreatedById = user.Id;

                await tagRepos.InsertAsync(tag);

                await UnitOfWork.CommitTransaction();
            }
            catch (Exception e)
            {
                await UnitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Delete(int tagId, User user)
        {
            try
            {
                await UnitOfWork.BeginTransaction();

                var tagRepos = UnitOfWork.Repository<Tag>();
                var tag = await tagRepos.FindAsync(tagId);
                if (tag == null)
                    throw new KeyNotFoundException();

                tag.IsDeleted = true;

                await UnitOfWork.CommitTransaction();
            }
            catch (Exception e)
            {
                await UnitOfWork.RollbackTransaction();
                throw;
            }
        }
    }
}
