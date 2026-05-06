using System;
using System.Collections.Generic;
using System.Text;

namespace Ruletka
{
    class User
    {
        public int id;
        public string userName;
        public string email;
        public string password;
        public decimal balance;

        public List<Bet> bets;
        public List<Transaction> transactions;

        public User(int _id, string _userName, string _email, string _password)
        {
            id = _id;
            userName = _userName;
            email = _email;
            password = _password;
            balance = 0;
            bets = new List<Bet>();
            transactions = new List<Transaction>();
        }

    }
}
