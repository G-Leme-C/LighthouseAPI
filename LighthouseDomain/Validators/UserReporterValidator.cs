using FluentValidation;
using LighthouseData.Model;

namespace LighthouseDomain.Validators
{
    public class UserReporterValidator : AbstractValidator<UserReporter> {
        public UserReporterValidator()
        {
            RuleFor(user => user.Email).NotEmpty().WithMessage("Preencha o e-mail.");
            RuleFor(user => user.Email).EmailAddress().WithMessage("Preencha um e-mail válido.");

            RuleFor(user => user.Name).NotEmpty().WithMessage("Preencha o nome.");
            RuleFor(user => user.Name).MinimumLength(2).WithMessage("O nome precisa ter pelo menos 2 caracteres.");
            RuleFor(user => user.Name).MaximumLength(300).WithMessage("O nome pode ter no máximo 300 caracteres.");
        }
    }
}