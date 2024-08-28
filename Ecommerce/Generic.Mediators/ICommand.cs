using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Generic.Mediators
{
    internal interface ICommand<out TRes> : IRequest<TRes>
    {
    }
}
