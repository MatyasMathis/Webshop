using FluentValidation;
using WebshopAPI.Models.DTOs;

namespace WebshopAPI.Validators;

public class RegisterInputValidator : AbstractValidator<AuthenticationDto>
{
    public RegisterInputValidator()
    {
        RuleFor(a => a.Email)
            .NotNull().WithMessage("Email not provided.")
            .EmailAddress().WithMessage("The provided email is invalid.");
        
        RuleFor(a => a.Password)
            .NotEmpty().WithMessage("Your password cannot be empty")
            .MinimumLength(8).WithMessage("Your password length must be at least 8.")
            .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
            .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
            .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
            .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.");
    }
}
