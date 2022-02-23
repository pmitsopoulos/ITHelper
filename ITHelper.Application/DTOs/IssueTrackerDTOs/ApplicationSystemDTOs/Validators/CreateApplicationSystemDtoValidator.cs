using FluentValidation;
using ITHelper.Application.Contracts.Persistence.IssueTracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.IssueTrackerDTOs.ApplicationSystemDTOs.Validators
{
    public class CreateApplicationSystemDtoValidator  : AbstractValidator<CreateApplicationSystemDto>
    {
        private readonly IApplicationSystemRepository applicationSystemRepository;

        public CreateApplicationSystemDtoValidator(IApplicationSystemRepository applicationSystemRepository)
        {
            this.applicationSystemRepository = applicationSystemRepository;
            Include(new GenericApplicationSystemDtoValidator(this.applicationSystemRepository));
        }
    }
}
