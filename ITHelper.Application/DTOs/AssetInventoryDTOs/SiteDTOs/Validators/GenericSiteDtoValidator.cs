using FluentValidation;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.SiteDTOs.Validators
{
    public class GenericSiteDtoValidator : AbstractValidator <ISiteDto>
    {
        private readonly ISiteRepository siteRepository;

        public GenericSiteDtoValidator(ISiteRepository siteRepository)
        {
            this.siteRepository = siteRepository;
            RuleFor(s => s.Name).NotEmpty().NotNull().WithMessage("The name of the site is required");
        }
    }
}
