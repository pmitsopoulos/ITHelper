using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.UserDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.UserDTOs.Validators;
using ITHelper.Application.Exceptions;
using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;
using ITHelper.Application.Responses;
using ITHelper.Domain.AssetInventoryEntities;


namespace ITHelper.Application.Features.AssetInventoryFeatures.UsersFeatures.Handlers.Commands
{
    public class UpdateUserRequestHandler : GenericUpdateRequestHandler<IUnitOfWork, IUserRepository, UpdateUserDto, User, UpdateUserDtoValidator>
    {
        public UpdateUserRequestHandler(IUnitOfWork unitOfWork, IMapper mapper,
            IUserRepository repository, UpdateUserDtoValidator validator)
            : base(unitOfWork, mapper, repository, validator)
        {
        }
    }
}
