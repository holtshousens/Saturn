using Saturn.DAL.DataContext;
using Saturn.DAL.DataObjects;
using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var merchant = new Merchant
            {
                MerchantId = 1,
                MerchantName = "Tesco"
            };

            using (var context = new TransactionContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Merchants.Add(merchant);
                context.SaveChanges();
            }

            Console.ReadKey();
        }
    }
}
