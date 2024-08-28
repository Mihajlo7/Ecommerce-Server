using MediatR;

namespace Generic.Mediator
{
    public interface ICommand<out TRes> : IRequest<TRes>
    {

    }
}
