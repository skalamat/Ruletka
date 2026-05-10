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
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "ruletka.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        public void AddUser(User user)
        {
            Users.Add(user);
            SaveChanges();
        }
        public User LoginUser(string username, string password)
        {
            foreach (var user in Users)
            {
                if(user.UserName == username && user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }
        public void UpdateBalance(int userId, double newBalance)
        {
            foreach (var user in Users)
            {
                if (user.Id == userId)
                {
                    user.Balance = newBalance;
                    SaveChanges();
                }
            }
        }
    }
}
