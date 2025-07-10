using FluentValidation;

namespace CFour.EndPoints.Compare.Create;

public class CreateCompareRequestValidator : AbstractValidator<CreateCompareRequest>
{
    public CreateCompareRequestValidator()
    {
        RuleFor(m => m.GameId)
            .NotNull()
            .NotEmpty();

        RuleFor(m => m.ChosenSystemSpecificationUnique)
            .NotNull()
            .NotEmpty();
    }
}