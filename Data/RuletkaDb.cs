using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruletka.Data
{
    class RuletkaDb : DbContext
    {
        public DbSet<Bet>Bets {  get; set; }
        public DbSet<GameRound> GameRounds { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("Data source=ruletka.db");
            }

        public void DodajUzytkownika(User user)
        {
            Users.Add(user);
            SaveChanges();
        }
    }
}
