using MediatR;

namespace Template.Application.Common.Queries;

public interface IQuery<out TResult> : IRequest<TResult>
{

}
