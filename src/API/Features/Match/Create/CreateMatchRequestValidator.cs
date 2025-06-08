using FluentValidation;

namespace CFour.Features.Match.Create;

public class CreateMatchRequestValidator : AbstractValidator<CreateMatchRequest>
{
    public CreateMatchRequestValidator()
    {
        RuleFor(m => m.GameId)
            .NotNull()
            .NotEmpty();

        RuleFor(m => m.ChosenSystemSpecificationUnique)
            .NotNull()
            .NotEmpty();
    }
}