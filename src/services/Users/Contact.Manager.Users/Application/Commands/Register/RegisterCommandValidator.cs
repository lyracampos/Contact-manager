using Contact.Manager.Users.Domain.Repositories;
using FluentValidation;

namespace Contact.Manager.Users.Application.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        private readonly IUserRepository userRepository;
        public RegisterCommandValidator(IUserRepository userRepository)
        {
            this.userRepository = userRepository;

            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("O campo Nome é obrigatório.");

            RuleFor(p => p.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("O campo Email é obrigatório.")
                .EmailAddress()
                .WithMessage("O campo Email está inválido.");

            RuleFor(p => p.Birth)
                .NotNull()
                .WithMessage("O campo Data de nascimento é obrigatório.");

            RuleFor(p => p.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("O campo Password é obrigatório.");

            RuleFor(p => p.PasswordConfirm)
               .NotEmpty()
               .NotNull()
               .WithMessage("O campo Confirmação de Password é obrigatório.");

            When(p => !string.IsNullOrEmpty(p.PasswordConfirm) &&
                      !string.IsNullOrEmpty(p.PasswordConfirm), () =>
            {
                RuleFor(p => p).Custom((p, context) =>
                {
                    if (!p.PasswordValid())
                    {
                        context.AddFailure("Password", "Os campos Password e Confirmação do password devem ser iguais.");
                    }
                });
            });


            //         RuleFor(x => x).Custom((x, context) =>
            // {
            //     if (x.Password != x.ConfirmPassword)
            //     {
            //         context.AddFailure(nameof(x.Password), "Passwords should match");
            //     }
            // });

        }
    }
}