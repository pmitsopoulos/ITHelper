using FluentValidation;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.IssueTrackerDTOs.SystemContactDTOs.Validators
{
    public class UpdateSystemContactDtoValidator : AbstractValidator<UpdateSystemContactDto>
    {
        private readonly ISystemContactRepository systemContactRepository;

        public UpdateSystemContactDtoValidator(ISystemContactRepository systemContactRepository)
        {
            this.systemContactRepository = systemContactRepository;
            Include(new GenericSystemContactDtoValidator(this.systemContactRepository));
        }
    }
}
