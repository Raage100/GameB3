using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Domain.Errors
{
    public static partial class Errors
    {
        public static class Score
        {
            public static Error ScoreCouldNotBeCreated()
            {
                return Error.Failure("Score could not be created");
            }


        }
    }
}
