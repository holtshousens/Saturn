using Saturn.DAL.DataContext;
using Saturn.DAL.DataObjects;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;

namespace ConsoleApplication
{
    public class Program
    {
        public static string connectionString;

        public static void Main(string[] args)
        {
            connectionString = ConfigurationManager.ConnectionStrings["TransactionsDB"].ConnectionString;

            loadData("DebitCardSource", connectionString);

            loadData("CreditCardSource", connectionString);

            Console.ReadKey();
        }

        public static void loadData(string sourceTag, string connectionString)
        {
            using (var context = new TransactionContext(connectionString))
            {
                context.Configuration.AutoDetectChangesEnabled = false;

                context.Database.Log = Console.WriteLine;

                if (sourceTag == "DebitCardSource")
                {
                    string sourcefile = ConfigurationManager.AppSettings[sourceTag];

                    using (var reader = new StreamReader(File.OpenRead(sourcefile)))
                    {
                        string header = reader.ReadLine();
                        var fields = header.Split(',');

                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            fields = line.Split(',');

                            var merchant = new Merchant
                            {
                                MerchantId = 1,
                                MerchantName = fields[4]
                            };

                            context.Merchants.Add(merchant);
                        }
                    }
                }
                else if (sourceTag == "CreditCardSource")
                {
                    throw new NotImplementedException();
                }
                else
                {
                    throw new NotImplementedException();
                }

                context.SaveChanges();
            }
        }
    }
}
