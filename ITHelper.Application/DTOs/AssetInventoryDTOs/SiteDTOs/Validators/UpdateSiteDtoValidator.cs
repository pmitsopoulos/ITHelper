using FluentValidation;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.SiteDTOs.Validators
{
    public class UpdateSiteDtoValidator : AbstractValidator<UpdateSiteDto>
    {
        private readonly ISiteRepository siteRepository;

        public UpdateSiteDtoValidator(ISiteRepository siteRepository)
        {
            this.siteRepository = siteRepository;
            Include(new GenericSiteDtoValidator(this.siteRepository));
        }
    }
}
