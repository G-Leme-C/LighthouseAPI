using FluentValidation;
using LighthouseData.Model;

namespace LighthouseDomain.Validators
{
    public class LocationValidator : AbstractValidator<Location> {
        public LocationValidator()
        {
            RuleFor(location => location.Latitude)
                .MinimumLength(4).When(location => !string.IsNullOrWhiteSpace(location.Latitude))
                .WithMessage("Latitude precisa ter tamanho 4 no mínimo.");

            RuleFor(location => location.Longitude)
                .MinimumLength(4).When(location => !string.IsNullOrWhiteSpace(location.Longitude))
                .WithMessage("Longitude precisa ter tamanho 4 no mínimo.");
            
            RuleFor(location => location.Latitude).MaximumLength(20).WithMessage("Latitude pode ter no máximo 20 caracteres.");
            RuleFor(location => location.Longitude).MaximumLength(20).WithMessage("Longitude pode ter no máximo 20 caracteres.");
        }
    }
}