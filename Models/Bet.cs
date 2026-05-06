using System;
using System.Collections.Generic;
using System.Text;

namespace Ruletka
{
    class Bet
    {
        public int id;
        public int userId;
        public int roundId;
        public string betType;
        public decimal value;

        public Bet(int _id, int _userId, int _roundId, string _betType, decimal _value)
        {
            id = _id;
            userId = _userId;
            roundId = _roundId;
            betType = _betType;
            value = _value;
        }
    }
}
