using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Contracts.Sports.Request
{
    public class DeleteSportRequest
    {
        public int SportId { get; set; }
        public DeleteSportRequest(int sportId)
        {

            SportId = sportId;

        }
    }
}
