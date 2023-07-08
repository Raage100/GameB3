using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Contracts.Scores.Request
{
    public class CreateScoreRequest
    {
        public int PlayerId { get; set; }
        public int SportId { get; set; }
        public int Points { get; set; }

    }
}
