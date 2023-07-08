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
        public static class Player
        {
            public static Error PlayerCouldNotBeCreated()
            {
                return Error.Failure("Player could not be created");
            }

            public static Error PlayerDoesNotExist()
            {
                return Error.NotFound("Player does not exist");
            }

            public static Error PlayerAlreadyExists()
            {
                return Error.Conflict("Player already exists");
            }

            public static Error PlayerCouldNotBeDeleted()
            {
                return Error.Failure("Player could not be updated");
            }
        }
    }
}
