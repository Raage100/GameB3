using Game.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Common.Interfaces.Persistence
{
    public interface IGameDbContext
    {

        public DbSet<Gamee> Gamees { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Sport> Sports { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
