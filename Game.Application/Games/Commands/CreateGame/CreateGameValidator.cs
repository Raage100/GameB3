using ErrorOr;
using FluentValidation;
using Game.Application.Common.Interfaces.Persistence;
using Game.Domain.Entites;
using Game.Domain.Errors;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Games.Commands.CreateGame
{
    internal class CreateGameValidator : AbstractValidator<CreateGameCommand>
    {
      
        public CreateGameValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }

     

    
    }
}
