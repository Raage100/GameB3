using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Sports.Commands.DeleteSport
{
    public class DeleteSportCommandValidator : AbstractValidator<DeleteSportCommand>
    {
        public DeleteSportCommandValidator()
        {
            RuleFor(x => x.SportId).NotEmpty().WithMessage("Id is required");
        }
    }
}
