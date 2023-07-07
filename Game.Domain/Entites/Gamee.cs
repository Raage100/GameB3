using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Domain.Entites
{
    public class Gamee
    {
        public int GameeId { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public List<Sport> Sports { get; set; }
    }
}
