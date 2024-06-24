using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleApp1
{
    public class Transaction
    {
        public string Username { get; }
        public string Symbol { get; }
        public string Type { get; } // "Buy" or "Sell"
        public int Quantity { get; }
        public double Price { get; }

        public Transaction(string username, string symbol, string type, int quantity, double price)
        {
            Username = username;
            Symbol = symbol;
            Type = type;
            Quantity = quantity;
            Price = price;
        }
    }
}
