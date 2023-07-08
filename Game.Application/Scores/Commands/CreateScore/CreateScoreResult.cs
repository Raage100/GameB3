using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Scores.Commands.CreateScore
{
    public class CreateScoreResult
    {
        public bool ScoresSaved { get; set; }

        public CreateScoreResult( bool scoresSaved)
        {
            ScoresSaved =  scoresSaved;
        }
    }
}
