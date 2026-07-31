namespace Nexora.Application.Common.Errors;

public static class AuthErrors
{
    public static readonly Error InvalidCredentials =
        new(
            "Auth.InvalidCredentials",
            "Invalid email or password."
        );

    public static readonly Error UserNotFound =
        new(
            "Auth.UserNotFound",
            "User not found."
        );

    public static readonly Error EmailAlreadyExists =
        new(
            "Auth.EmailAlreadyExists",
            "A user with this email already exists."
        );

    public static readonly Error Unauthorized =
        new(
            "Auth.Unauthorized",
            "You are not authorized to perform this action."
        );
}