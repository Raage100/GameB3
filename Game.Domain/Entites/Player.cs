using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Game.Domain.Entites
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public List<Score> Scores { get; set; }

        public int GameeId { get; set; }
        public Gamee Gamee { get; set; }
    }
}
