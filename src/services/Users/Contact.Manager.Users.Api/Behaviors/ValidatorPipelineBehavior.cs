using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contact.Manager.Users.Framework.Application;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Contact.Manager.Users.Api.Behaviors
{
    public class ValidatorPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidatorPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = validators
                .Select(validator => validator.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            {
                throw new ValidationException(failures);
            }
            //    return failures.Any()
            //         ? Errors(failures)
            //         : next();
        }

        private static Task<TResponse> Errors(IEnumerable<ValidationFailure> failures)
        {
            var commandResult = new CommandResult();

            return null;
            //return commandResult.Errors;
            // var response = new Response();

            // foreach (var failure in failures)
            // {
            //     response.AddError(failure.ErrorMessage);
            // }

            // return Task.FromResult(response as TResponse);
        }
    }
}