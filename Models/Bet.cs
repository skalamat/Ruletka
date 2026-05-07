using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ruletka
{
    class Bet
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("round_id")]
        public int RoundId { get; set; }

        [Column("bet_type")]
        public string BetType { get; set; }

        [Column("value")]
        public decimal Value { get; set; }
    }
}