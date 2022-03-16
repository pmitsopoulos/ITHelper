﻿using ITHelper.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.CommonFeatures.Requests.Commands
{
    public class GenericUpdateRequest<TUpdateEntityDto> : IRequest<BaseResponse>
    {
        public TUpdateEntityDto EntityTBU { get; set; }
    }
}
