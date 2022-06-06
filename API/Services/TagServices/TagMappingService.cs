using API.DTOs.TagDtos;
using AutoMapper;
using Domain.Entities.Assigments;
using Domain.Entities.Tags;
using Domain.Entities.Users;
using Domain.Interfaces;

namespace API.Services.TagServices
{
    public class TagMappingService: BaseService
    {
        public TagMappingService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task Add(TagMappingUpSertRequest tagMappingDto, User user)
        {
            try
            {
                await UnitOfWork.BeginTransaction();

                var tagRepos = UnitOfWork.Repository<TagMapping>();

                var tagMappingInput = Mapper.Map<TagMapping>(tagMappingDto);

                tagMappingInput.CreatedDate = DateTime.Now;
                tagMappingInput.CreatedById = user.Id;

                await tagRepos.InsertAsync(tagMappingInput);

                await UnitOfWork.CommitTransaction();
            }
            catch (Exception e)
            {
                await UnitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Delete(int tagMappingtId, User user)
        {
            try
            {
                await UnitOfWork.BeginTransaction();

                var tagMappingRepos = UnitOfWork.Repository<TagMapping>();

                var assignDb = await tagMappingRepos.FindAsync(tagMappingtId);
                if (assignDb == null)
                    throw new KeyNotFoundException();

                assignDb.IsDeleted = true;

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
