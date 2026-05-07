using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ruletka
{
    class GameRound
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("winning_number")]
        public int WinningNumber { get; set; }

        [Column("winning_color")]
        public string WinningColor { get; set; }

        public List<Bet> Bets { get; set; } = new List<Bet>();
    }
}