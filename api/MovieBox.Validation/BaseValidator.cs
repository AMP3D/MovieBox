using FluentValidation;
using FluentValidation.Results;
using System.Threading;
using System.Threading.Tasks;

namespace MovieBox.Validation
{
    public class BaseValidator<T> : AbstractValidator<T>, IBaseValidator<T>
    {
        public async Task<ValidationResult> ValidateAndThrowAsync(T instance, CancellationToken cancellation = default)
        {
            var result = await ValidateAsync(instance, cancellation);
            var throwError = result == null || !result.IsValid;

            if (throwError)
            {
                if (result != null)
                {
                    throw new ValidationException($"Validation failed. {result}");
                }

                throw new ValidationException($"Validation failed. Unable to validate object.");
            }

            return result;
        }
    }
}