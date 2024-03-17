using FastEndpoints;
using MediatR;
using Template.Application.Users.Queries.GetById;
using Template.Domain.Users;
using Template.Web.Extensions;

namespace Template.Web.Api.Users.GetById;

public class GetById(IMediator mediator) : Endpoint<GetByIdRequest, UserDto>
{
    public override void Configure()
    {
        AllowAnonymous();

        Get(ApiRoutes.Users.GetById);

        Summary(s => 
        {
            s.Summary = "Return user by id";
        });
    }

    public override async Task HandleAsync(GetByIdRequest req, CancellationToken ct)
    {
        FluentResults.Result<UserDto> result = await mediator.Send(new GetUserByIdQuery(new UserId(req.Id)), ct);
       
        await (result.IsSuccess switch
        {
            true => SendOkAsync(result.Value, ct),
            false => this.SendProblemResponse(result, ct)
        });
    }
}
