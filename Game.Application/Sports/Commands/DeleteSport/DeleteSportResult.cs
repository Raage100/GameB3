using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Sports.Commands.DeleteSport
{
    public class DeleteSportResult
    {
        public int Id { get; set; }
        public bool  Deleted { get; set; }

        public DeleteSportResult(int id, bool deleted)
        {
            Id = id;
            Deleted = deleted;
        }
    }
}
