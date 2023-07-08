using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Players.Commands.CreatePlayer
{
    public class CreatePlayerResult
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CreatePlayerResult(int id, string name)
        {
            Id = id;
            Name = name;

        }
    }
}
