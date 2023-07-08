using ErrorOr;
using Game.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Scores.Commands.CreateScore
{
    public class CreateScoreCommand : IRequest<ErrorOr<CreateScoreResult>>
    {
        public List<Score>  Scores { get; set; }
    }
}
