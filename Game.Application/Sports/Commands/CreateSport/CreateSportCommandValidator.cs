using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Sports.Commands.CreateSport
{
    public class CreateSportCommandValidator : AbstractValidator<CreateSportCommand>
    {
        public CreateSportCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.GameId).GreaterThan(0).NotEmpty().WithMessage("GameId is required");

        }
    }
    
}
