using Domain.Entities;
using FluentValidation;

namespace Application.Validations.FluentValidation
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(m => m.Price).LessThanOrEqualTo(0);
            RuleFor(m => m.Name).NotEmpty();
            RuleFor(m => m.Name).MinimumLength(3);
            RuleFor(m=>m.DirectorId).LessThanOrEqualTo(0);
            RuleFor(m=>m.GenreId).LessThanOrEqualTo(0);

        }
    }
}
