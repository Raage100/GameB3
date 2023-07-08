using Game.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Sports.Commands.CreateSport
{
    public class CreateSportResult
    {
        public Sport Sport { get; set; }

        public CreateSportResult(Sport sport)
        {
            Sport = sport;
        }
    }
}
