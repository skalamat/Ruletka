using System;
using System.Collections.Generic;
using System.Text;

namespace Ruletka
{
    class GameRound
    {
        public int id;
        public int winningNumber;
        public string winningColor;

        public List<Bet> bets;

        public GameRound(int _id, int _winningNumber, string _winningColor)
        {
            id = _id;
            winningNumber = _winningNumber;
            winningColor = _winningColor;
            bets = new List<Bet>();
        }
    }
}
