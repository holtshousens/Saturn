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
        private const string _debitCard = "DebitCardSource";
        private const string _creditCard = "CreditCardSource";
        private const string _connectionString = "TransactionsDB";

        public static string connectionString;

        public static void Main(string[] args)
        {
            connectionString = ConfigurationManager.ConnectionStrings[_connectionString].ConnectionString;

            loadData(_debitCard, connectionString);

            loadData(_creditCard, connectionString);

            Console.ReadKey();
        }

        public static void loadData(string sourceTag, string connectionString)
        {
            using (var context = new TransactionContext(connectionString))
            {
                context.Configuration.AutoDetectChangesEnabled = false;

                context.Database.Log = Console.WriteLine;

                if (sourceTag == _debitCard)
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
                else if (sourceTag == _creditCard)
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
