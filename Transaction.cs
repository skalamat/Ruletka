using System;
using System.Collections.Generic;
using System.Text;

namespace Ruletka
{
    class Transaction
    {
        public int id;
        public int userId;
        public decimal value;

        public Transaction(int _id, int _userId, decimal _value)
        {
            id = _id;
            userId = _userId;
            value = _value;
        }
    }
}
