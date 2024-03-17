using FastEndpoints;
using MediatR;
using Template.Application.Users.Commands;
using Template.Web.Extensions;

namespace Template.Web.Api.Users.Create;

public class Create(IMediator mediator) : Endpoint<CreateUserRequest, CreateUserResponse>
{
    public override void Configure()
    {
        AllowAnonymous();

        Post(ApiRoutes.Users.Create);

        Summary(s => 
        {
            s.Summary = "Create a new user";
        });
    }

    public override async Task HandleAsync(CreateUserRequest req, CancellationToken ct)
    {
        FluentResults.Result<Guid> result = await mediator.Send(new CreateUserCommand(req.Name), ct);
       
        await (result.IsSuccess switch
        {
            true => SendOkAsync(new CreateUserResponse(result.Value), ct),
            false => this.SendProblemResponse(result, ct)
        });
    }
}
