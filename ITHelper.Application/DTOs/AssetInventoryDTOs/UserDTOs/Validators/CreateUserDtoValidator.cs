using FluentValidation;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.UserDTOs.Validators
{
    public  class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        private readonly IUserRepository userRepository;

        public CreateUserDtoValidator(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            Include(new GenericUserDtoValidator(this.userRepository));
        }
    }
}
