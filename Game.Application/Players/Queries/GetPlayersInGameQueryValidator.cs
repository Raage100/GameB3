using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Players.Queries
{
    public class GetPlayersInGameQueryValidator : AbstractValidator<GetPlayersInGameQuery>
    {
        public GetPlayersInGameQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
