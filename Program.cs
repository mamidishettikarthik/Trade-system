using System;
using System.Collections.Generic;       
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleApp1
{
    class Program
    {
        static void Main()
        {
            TradeSystem tradeSystem = new TradeSystem();
            User user = new User("Karthik Mamidishetti", 5000.00);

            // Example usage:
            tradeSystem.DisplayAvailableAssets();

            Console.WriteLine("\nBuying assets...");
            tradeSystem.BuyAsset(user, "AAPL", 5);
            tradeSystem.BuyAsset(user, "GOLD", 2);

            Console.WriteLine("\nSelling assets...");
            tradeSystem.SellAsset(user, "AAPL", 2);

            Console.WriteLine("\nDisplaying user's holdings and balances:");
            Console.WriteLine($"Username: {user.Username}, Balance: ${user.Balance}");
            foreach (var asset in user.Holdings)
            {
                Console.WriteLine($"Asset: {asset.Type}, Symbol: {asset.Symbol}");
            }

            Console.WriteLine("\nDisplaying transaction history:");
            tradeSystem.DisplayTransactions();
            Console.ReadLine();
        }
    }



}
