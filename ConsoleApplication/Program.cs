using Saturn.DAL.DataContext;
using Saturn.DAL.DataObjects;
using System;
using System.Configuration;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TransactionsDB"].ConnectionString;

            var merchant = new Merchant
            {
                MerchantId = 1,
                MerchantName = "Tesco"
            };

            using (var context = new TransactionContext(connectionString))
            {
                context.Database.Log = Console.WriteLine;
                context.Merchants.Add(merchant);
                context.SaveChanges();
            }

            Console.ReadKey();
        }
    }
}
