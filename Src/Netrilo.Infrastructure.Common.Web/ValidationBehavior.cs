using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Common.Web
{
    public class ValidationBehavior<TRequest, TResponse>(IValidatorFactory validationFactory) : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IValidatorFactory _validationFactory = validationFactory;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var validator = _validationFactory.GetValidator(request.GetType());
            var result = validator?.Validate(new ValidationContext<TRequest>(request));

            if (result != null && !result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var response = await next();

            return response;
        }
    }
}
