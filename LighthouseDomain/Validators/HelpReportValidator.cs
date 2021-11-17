using FluentValidation;
using LighthouseData.Model;

namespace LighthouseDomain.Validators
{
    public class HelpReportValidator : AbstractValidator<LighthouseHelpReport> {
        public HelpReportValidator()
        {
            RuleFor(helpReport => helpReport.UserReporter).SetValidator(new UserReporterValidator());
            RuleFor(helpReport => helpReport.Location).SetValidator(new LocationValidator());
        }
    }
}