


using ErrorOr;
using FluentValidation;
using MediatR;
using NovelSys.Application.Authentication.Commands.Register;
using NovelSys.Application.Authentication.Common;

namespace NovelSys.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest,TResponse> :
        IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
    {
        private readonly IValidator<TRequest>? _validator;

        public ValidationBehavior(IValidator<TRequest>? validator = null)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(
            TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(_validator is null) {
                return await next();
            }
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
           // var result = await next();
           if(validationResult.IsValid)
            {
                return await next();
            }

            var errors = validationResult.Errors
                .ConvertAll(validationFailure => Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage));
            return (dynamic)errors;
        }

        //public Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request, RequestHandlerDelegate<ErrorOr<AuthenticationResult>> next, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
