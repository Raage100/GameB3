using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Players.Commands.DeletePlayer
{
    public class DeletePlayerCommandValidator : AbstractValidator<DeletePlayerCommand>
    {
        public DeletePlayerCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
