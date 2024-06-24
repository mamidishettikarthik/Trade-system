using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleApp1
{
    public  class TradeSystem
    {
        private Dictionary<string, Asset> availableAssets; // Store available assets for trading
        private List<Transaction> transactions;           // Store executed transactions

        public TradeSystem()
        {
            availableAssets = new Dictionary<string, Asset>();
            transactions = new List<Transaction>();

            // Initialize available assets (can be extended)
            availableAssets["AAPL"] = new Stock("AAPL", 150.50);
            availableAssets["GOOG"] = new Stock("GOOG", 2500.75);
            availableAssets["GOLD"] = new Commodity("GOLD", 1800.00);
            availableAssets["US10Y"] = new Bond("US10Y", 1.75); // 10-year US Treasury Bond
        }

        public void BuyAsset(User user, string symbol, int quantity)
        {
            if (availableAssets.ContainsKey(symbol))
            {
                Asset asset = availableAssets[symbol];
                double totalPrice = asset.Price * quantity;

                if (user.Balance >= totalPrice)
                {
                    user.AddAsset(asset, quantity);
                    user.UpdateBalance(-totalPrice);

                    transactions.Add(new Transaction(user.Username, symbol, "Buy", quantity, asset.Price));

                    Console.WriteLine($"Successfully bought {quantity} of {symbol} at ${asset.Price} each.");
                }
                else
                {
                    Console.WriteLine($"Insufficient balance to buy {quantity} of {symbol}.");
                }
            }
            else
            {
                Console.WriteLine($"Asset with symbol {symbol} is not available for trading.");
            }
        }

        public void SellAsset(User user, string symbol, int quantity)
        {
            Asset asset = user.Holdings.Find(h => h.Symbol == symbol);

            if (asset != null)
            {
                int currentQuantity = user.Holdings.Count(h => h.Symbol == symbol);

                if (currentQuantity >= quantity)
                {
                    user.RemoveAsset(asset, quantity);
                    user.UpdateBalance(asset.Price * quantity);

                    transactions.Add(new Transaction(user.Username, symbol, "Sell", quantity, asset.Price));

                    Console.WriteLine($"Successfully sold {quantity} of {symbol} at ${asset.Price} each.");
                }
                else
                {
                    Console.WriteLine($"You don't have enough {symbol} to sell {quantity}.");
                }
            }
            else
            {
                Console.WriteLine($"You don't own any {symbol}.");
            }
        }

        public void DisplayAvailableAssets()
        {
            Console.WriteLine("Available Assets for Trading:");
            foreach (var asset in availableAssets.Values)
            {
                Console.WriteLine($"{asset.Type}: {asset.Symbol}, Price: ${asset.Price}");
            }
        }

        public void DisplayTransactions()
        {
            Console.WriteLine("Transaction History:");
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"User: {transaction.Username}, Symbol: {transaction.Symbol}, Type: {transaction.Type}, Quantity: {transaction.Quantity}, Price: ${transaction.Price}");
            }
        }


    }
}
