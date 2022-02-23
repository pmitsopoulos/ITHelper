using FluentValidation;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.SiteDTOs.Validators
{
    public class CreateSiteDtoValidator : AbstractValidator<CreateSiteDto>
    {
        private readonly ISiteRepository siteRepository;

        public CreateSiteDtoValidator(ISiteRepository siteRepository)
        {
            this.siteRepository = siteRepository;
            Include(new GenericSiteDtoValidator(this.siteRepository));  
        }
    }
}
