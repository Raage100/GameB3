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
        public static class Gamee
        {
            public static Error GameCouldNotBeCreated()
            {
                return Error.Failure("Game could not be created");
            }
        }
    }
}
