using FluentValidation;
using MovieBox.Common.Models;
using System;

namespace MovieBox.Validation.Movies
{
    public class MoviesValidator : BaseValidator<MovieModel>, IMoviesValidator
    {
        public MoviesValidator()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty();
            RuleFor(x => x.YearReleased).NotNull().NotEmpty().LessThan(DateTime.UtcNow.Year);
        }
    }
}