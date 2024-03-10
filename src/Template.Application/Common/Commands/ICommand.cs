using MediatR;

namespace Template.Application.Common.Commands
;

public interface ICommand : IRequest
{
}

public interface ICommond<out TResponse> : IRequest<TResponse>{
    
}
