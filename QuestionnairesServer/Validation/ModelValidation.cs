using FluentValidation;
using QuestionnairesServer.Models;

namespace QuestionnairesServer.ModelValidation;

public class QuestionnaireModelValidator : AbstractValidator<QuestionnaireModel>
{
    public QuestionnaireModelValidator()
    {
        RuleFor(_ => _.Name)
            .NotEmpty();

        RuleFor(_ => _.StartDate)
            .NotNull()
            .LessThan(_ => _.EndDate).WithMessage("Start date must be before end date")
            .GreaterThan(DateTime.Now.ToLocalTime()).WithMessage("Start date can not be less than current date time")
            ;

        RuleFor(_ => _.EndDate)
            .NotNull()
            .GreaterThan(_ => _.StartDate).WithMessage("End date can not be less than start date")
            .GreaterThan(_ => DateTime.Now).WithMessage("End date can no be less than current date time")
            ;
    }
}