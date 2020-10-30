using Contact.Manager.Users.Domain.Repositories;
using FluentValidation;

namespace Contact.Manager.Users.Application.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        private readonly IUserRepository userRepository;

        private void ValidateName()
        {
            RuleFor(p => p.Name)
                .NotEmpty().NotNull().WithMessage("O campo Nome é obrigatório.");
        }
        private void ValidateEmail()
        {
            RuleFor(p => p.Email)
               .NotEmpty().NotNull().WithMessage("O campo Email é obrigatório.")
               .EmailAddress().WithMessage("O campo Email está inválido.");

            When(p => !string.IsNullOrEmpty(p.Email), () =>
            {
                RuleFor(p => p).Custom((p, context) =>
                {
                    var user = this.userRepository.GetByEmail(p.Email).Result;
                    if (user != null)
                    {
                        context.AddFailure("Email", $"O e-mail informado já esta em uso. '{p.Email}'");
                    }
                });
            });
        }

        private void ValidatePassword()
        {
            RuleFor(p => p.Password)
               .NotEmpty().NotNull().WithMessage("O campo Password é obrigatório.");

            RuleFor(p => p.PasswordConfirm)
               .NotEmpty().NotNull().WithMessage("O campo Confirmação de Password é obrigatório.");

            When(p => !string.IsNullOrEmpty(p.PasswordConfirm) && !string.IsNullOrEmpty(p.PasswordConfirm), () =>
            {
                RuleFor(p => p).Custom((p, context) =>
                {
                    if (!p.PasswordValid())
                    {
                        context.AddFailure("Password", "Os campos Password e Confirmação do password devem ser iguais.");
                    }
                });
            });
        }
        public RegisterCommandValidator(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            ValidateName();
            ValidateEmail();
            ValidatePassword();
        }
    }
}