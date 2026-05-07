using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ruletka
{
    class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("user_name")]
        public string UserName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("balance")]
        public decimal Balance { get; set; }

        public List<Bet> Bets { get; set; } = new List<Bet>();
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}