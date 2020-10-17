using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contact.Manager.Framework.Application;
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

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            // var failures = validators
            //     .Select(validator => validator.Validate(request))
            //     .SelectMany(result => result.Errors)
            //     .Where(error => error != null)
            //     .ToList();

            // return failures.Any()
            //      ? throw new ValidationException("Ocorreu um erro interno.", failures, true)
            //      : next();

            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                if (failures.Count != 0)
                    throw new FluentValidation.ValidationException(failures);
            }
            return await next();
        }
    }
}