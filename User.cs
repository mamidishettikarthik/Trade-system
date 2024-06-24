using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleApp1
{
    public class User
    {
        public string Username { get; }
        public double Balance { get; private set; }
        public List<Asset> Holdings { get; }

        public User(string username, double initialBalance)
        {
            Username = username;
            Balance = initialBalance;
            Holdings = new List<Asset>();
        }

        public void AddAsset(Asset asset, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Holdings.Add(asset);
            }
        }

        public void RemoveAsset(Asset asset, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Holdings.Remove(asset);
            }
        }

        public void UpdateBalance(double amount)
        {
            Balance += amount;
        }
    }
}
