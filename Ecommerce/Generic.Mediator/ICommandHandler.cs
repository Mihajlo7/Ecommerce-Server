using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Generic.Mediator
{
    public interface ICommandHandler<in TCommand, TRes> : IRequestHandler<TCommand, TRes>
        where TCommand : ICommand<TRes>
    {
    }
}
