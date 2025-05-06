using FluentValidation;
using TaskManagementAPI.Models.User;

public class DtoUserValidator : AbstractValidator<DtoUser>
{
    public DtoUserValidator()
    {
        RuleFor(user => user.UserName)
            .NotEmpty().WithMessage("A username is mandatory.")
            .Length(5, 30).WithMessage("Username must have between 5 and 30 characters.");

        RuleFor(user => user.Role)
            .NotEmpty().WithMessage("Role is required.")
            .Must(role => role == "Admin" || role == "User").WithMessage("Role must have either 'Admin' or 'User'.");
    }
}
