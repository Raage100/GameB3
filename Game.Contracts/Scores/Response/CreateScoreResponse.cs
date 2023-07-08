using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Contracts.Scores.Response
{
    public class CreateScoreResponse
    {
        public bool ScoresSaved { get; set; }

        public CreateScoreResponse(bool scoresSaved)
        {
            ScoresSaved = scoresSaved;
            
        }
    }
}
