using ErrorOr;
using FluentValidation;
using Game.Application.Common.Interfaces.Persistence;
using Game.Domain.Entites;
using Game.Domain.Errors;


namespace Game.Application.Games.Commands.CreateGame
{
    public class CreateGameValidator : AbstractValidator<CreateGameCommand>
    {
      
        public CreateGameValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }

     

    
    }
}
