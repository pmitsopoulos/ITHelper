

using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.UserDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.UserDTOs.Validators;
using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;
using ITHelper.Domain.AssetInventoryEntities;

namespace ITHelper.Application.Features.AssetInventoryFeatures.UsersFeatures.Handlers.Commands
{
    public class CreateUserRequestHandler : GenericCreateRequestHandler<IUnitOfWork, CreateUserDto, User, IUserRepository, CreateUserDtoValidator>
    {
        public CreateUserRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, 
            IUserRepository repository, CreateUserDtoValidator validator)
            : base(unitOfWork, mapper, repository, validator)
        {
        }
    }
}
