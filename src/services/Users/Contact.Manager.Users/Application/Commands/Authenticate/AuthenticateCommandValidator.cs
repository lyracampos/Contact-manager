using FluentValidation;

namespace Contact.Manager.Users.Application.Commands.Authenticate
{
    public class AuthenticateCommandValidator : AbstractValidator<AuthenticateCommand>
    {
        private void ValidateUserName()
        {
            RuleFor(p => p.UserName)
                .NotEmpty().NotNull().WithMessage("O campo UserName é obrigatório.");
        }
        private void ValidatePassword()
        {
            RuleFor(p => p.Password)
                .NotEmpty().NotNull().WithMessage("O campo Password é obrigatório.");
        }

        public AuthenticateCommandValidator()
        {
            ValidateUserName();
            ValidatePassword();
        }
    }
}