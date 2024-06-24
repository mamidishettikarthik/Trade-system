using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleApp1
{
    // Define a base class for all assets
    public class Asset
    {
        public string Symbol { get; }
        public string Type { get; }
        public double Price { get; }

        public Asset(string symbol, string type, double price)
        {
            Symbol = symbol;
            Type = type;
            Price = price;
        }
    }

    // Example derived classes for specific asset types
    public class Bond : Asset
    {
        public Bond(string symbol, double price) : base(symbol, "Bond", price) { }
    }

    public class Commodity : Asset
    {
        public Commodity(string symbol, double price) : base(symbol, "Commodity", price) { }
    }

    public class Equity : Asset
    {
        public Equity(string symbol, double price) : base(symbol, "Equity", price) { }
    }

    public class Stock : Asset
    {
        public Stock(string symbol, double price) : base(symbol, "Stock", price) { }
    }

}
