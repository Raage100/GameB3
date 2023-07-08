using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Players.Commands.DeletePlayer
{
    public class DeletePlayerResult
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public DeletePlayerResult(int id, bool deleted)
        {
            Id = id;
            Deleted = deleted;
        }
    }
}
