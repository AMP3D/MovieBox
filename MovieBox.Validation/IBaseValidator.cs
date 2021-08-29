using FluentValidation;
using FluentValidation.Results;
using System.Threading;
using System.Threading.Tasks;

namespace MovieBox.Validation
{
    public interface IBaseValidator<T> : IValidator<T>
    {
        public Task<ValidationResult> ValidateAndThrowAsync(T instance, CancellationToken cancellation = default);
    }
}