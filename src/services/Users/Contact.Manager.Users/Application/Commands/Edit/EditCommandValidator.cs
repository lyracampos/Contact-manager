using Contact.Manager.Users.Domain.Repositories;
using FluentValidation;

namespace Contact.Manager.Users.Application.Commands.Edit
{
    public class EditCommandValidator : AbstractValidator<EditCommand>
    {
        private readonly IUserRepository userRepository;

        public EditCommandValidator(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            ValidateName();
        }

        private void ValidateName()
        {
            RuleFor(p => p.Name)
                .NotEmpty().NotNull().WithMessage("O campo Nome é obrigatório.");
        }
    }
}