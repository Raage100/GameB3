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

        public static class Sport
        {
            public static Error SportCouldNotBeCreated()
            {
                return Error.Failure("Sport could not be created");
            }

            public static Error SportDoesNotExist()
            {
                return Error.NotFound("Sport does not exist");
            }

            
            public static Error SportAlreadyExists() 
            {
                
                return Error.Conflict("Sport already exists");
            }

            public static Error SportCouldNotBeDeleted()
            {
                return Error.Failure("Sport could not be deleted");
            }

        }   
    }
}
