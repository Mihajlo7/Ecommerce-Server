using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Generic.Mediator
{
    public interface IQueryHandler<in TQuery, TRes> : IRequestHandler<TQuery, TRes> where TQuery : IQuery<TRes>
    {
    }
}
