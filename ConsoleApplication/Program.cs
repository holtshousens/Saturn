using Saturn.DAL.DataContext;
using Saturn.DAL.DataObjects;
using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TransactionsDB"].ConnectionString;
            string sourcefile = ConfigurationManager.AppSettings["DebitCardSource"];

            using (var context = new TransactionContext(connectionString))
            {
                context.Configuration.AutoDetectChangesEnabled = false;
                context.Database.Log = Console.WriteLine;

                using (var reader = new StreamReader(File.OpenRead(sourcefile)))
                {
                    string header = reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var fields = line.Split(',');

                        var merchant = new Merchant
                        {
                            MerchantId = 1,
                            MerchantName = fields[4]
                        };

                        context.Merchants.Add(merchant);
                    }
                }

                context.SaveChanges();
            }

            /* var merchant = new Merchant
                {
                    MerchantId = 1,
                    MerchantName = "Tesco"
                }; */




            Console.ReadKey();
        }
    }
}
