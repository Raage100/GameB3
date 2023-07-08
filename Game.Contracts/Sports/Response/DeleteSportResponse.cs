using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Contracts.Sports.Response
{
    public class DeleteSportResponse
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public DeleteSportResponse(int id, bool deleted)
        {
            Id = id;
            Deleted = deleted;
        }
    }
}
