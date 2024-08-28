using MediatR;

namespace Generic.Mediators
{
    public interface IQuery<out TRes> : IRequest<TRes>
    {

    }
}
