using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Sports.Queries
{
    public class GetSportsInGameQueryValidator : AbstractValidator<GetSportsInGameQuery>
    {
        public GetSportsInGameQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
