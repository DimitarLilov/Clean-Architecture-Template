namespace Template.Domain.Users;

public static class UserErrors
{
    public static readonly UserNotFoundError UserNotFound = new ("user.not.found", "User not found.");

    public static readonly UserNameIsEmptyError UserNameIsEmpty = new ("user.name.is.empty", "The user name is empty");
}
