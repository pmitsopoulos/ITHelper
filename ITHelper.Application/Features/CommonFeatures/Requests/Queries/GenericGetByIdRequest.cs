using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.CommonFeatures.Requests.Queries
{
    public class GenericGetByIdRequest<TEntity> : IRequest<TEntity>
    {
        public int Id { get; set; }
    }
}
