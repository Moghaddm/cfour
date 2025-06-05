using FluentValidation;

namespace CFour.Features.Match.Create;

public class CreateMatchRequestValidator : AbstractValidator<CreateMatchRequest>
{
    public CreateMatchRequestValidator()
    {
    }
}