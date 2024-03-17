namespace Template.Web.Api;

public static class ApiRoutes
{
    public static class Users
    {
        public const string GroupName = nameof(Users);

        public const string Create = $"/users/";

        public const string GetById = $"/users/{{id:guid}}/";
    }
}
