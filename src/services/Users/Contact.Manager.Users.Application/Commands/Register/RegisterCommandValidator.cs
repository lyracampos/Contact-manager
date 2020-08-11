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
        }
    }
}