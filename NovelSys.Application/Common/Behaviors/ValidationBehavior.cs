


using ErrorOr;
using FluentValidation;
using MediatR;
using NovelSys.Application.Authentication.Commands.Register;
using NovelSys.Application.Authentication.Common;

namespace NovelSys.Application.Common.Behaviors
{
    public class ValidateRegisterCommandBehavior : 
        IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IValidator<RegisterCommand> _validator;

        public ValidateRegisterCommandBehavior(IValidator<RegisterCommand> validator)
        {
            _validator = validator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(
            RegisterCommand request, RequestHandlerDelegate<ErrorOr<AuthenticationResult>> next, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
           // var result = await next();
           if(validationResult.IsValid)
            {
                return await next();
            }

            var errors = validationResult.Errors
                .ConvertAll(validationFailure => Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage));
            return errors;
        }

        //public Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request, RequestHandlerDelegate<ErrorOr<AuthenticationResult>> next, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
