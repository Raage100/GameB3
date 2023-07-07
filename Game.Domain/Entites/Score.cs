using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Domain.Entites
{
    public class Score
    {
        public int ScoreId { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int SportId { get; set; }
        public Sport Sport { get; set; }
        public int Points { get; set; }
    }
}
