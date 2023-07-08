using FluentValidation;
using Game.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Scores.Commands.CreateScore
{
    public class CreateScoreCommandValidator : AbstractValidator<CreateScoreCommand>
    {
        public CreateScoreCommandValidator()
        {
            RuleFor(x => x.Scores).NotEmpty()
                .ForEach(score => score.SetValidator(new ScoreValidator()));
            

          
               
 
        }  
    }


    public class ScoreValidator : AbstractValidator<Score>
    {
        public ScoreValidator()
        {
            RuleFor(score => score.SportId).NotEmpty().WithMessage("SportId is required");
            RuleFor(score => score.PlayerId).NotEmpty().WithMessage("Player id required");
                
        }
    }

}
