using CFour.EndPoints.Game.Update;
using FluentValidation;

namespace CFour.Features.Game.Update;

public class UpdateGameRequestValidator : AbstractValidator<UpdateGameRequest>
{
    public UpdateGameRequestValidator()
    {
        
    }
}