using Game.Application.Common.Interfaces.Persistence;
using Game.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Infrastructure.Persistence
{
    public class GameDbContext : DbContext, IGameDbContext
    {
        public DbSet<Gamee> Gamees { get ; set ; }
        public DbSet<Player> Players { get ; set ; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Sport> Sports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Gamee)
                .WithMany(g => g.Players)
                .HasForeignKey(p => p.GameeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Score>()
                .HasOne(s => s.Player)
                .WithMany(p => p.Scores)
                .HasForeignKey(s => s.PlayerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Score>()
                .HasOne(s => s.Sport)
                .WithMany(s => s.Scores)
                .HasForeignKey(s => s.SportId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Sport>()
                .HasOne(s => s.Gamee)
                .WithMany(g => g.Sports)
                .HasForeignKey(s => s.GameeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
