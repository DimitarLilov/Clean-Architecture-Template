using Microsoft.AspNetCore.Mvc;

namespace Template.Web.Api.Users.GetById;

public class GetByIdRequest
{
    [FromRoute]
    public Guid Id { get; set; }
}
