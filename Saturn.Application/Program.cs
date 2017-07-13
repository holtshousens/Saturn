using Microsoft.VisualBasic.FileIO;
using Saturn.Domain;
using Saturn.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Saturn.Application
{
    public class Program
    {
        private const string DebitCard = "DebitCardSource";
        private const string CreditCard = "CreditCardSource";
        private const string ConnectionString = "TransactionsDB";

        private static string _connectionString;

        public static void Main(string[] args)
        {
            _connectionString = ConfigurationManager.ConnectionStrings[ConnectionString].ConnectionString;

            LoadData(DebitCard, _connectionString);

            LoadData(CreditCard, _connectionString);

            //testing new logic
            var csvFile = new List<InputFileCreditCard>();

            csvFile = CsvFileToList(ConfigurationManager.AppSettings[DebitCard]);

            // next need to use the list and populate the data objects

            Console.ReadKey();
        }

        public static void LoadData(string sourceTag, string connectionString)
        {
            using (var context = new TransactionContext())
            {
                context.Configuration.AutoDetectChangesEnabled = false;

                context.Database.Log = Console.WriteLine;

                switch (sourceTag)
                {
                    case DebitCard:
                    {
                        var sourcefile = ConfigurationManager.AppSettings[sourceTag];

                        var newList = new List<InputFileDebitCard>();
                        //newList = CSVFileToList(sourcefile);
                        //distributeListToObjects(context, newList);
                    }
                        break;
                    case CreditCard:
                    {
                        var sourcefile = ConfigurationManager.AppSettings[sourceTag];

                        var newList = CsvFileToList(sourcefile);
                        DistributeListToObjects(context, newList);
                    }
                        break;
                    default:
                        throw new NotImplementedException();
                }

                context.SaveChanges();
            }
        }

        private static List<InputFileCreditCard> CsvFileToList(string csvFile)
        {
            using (var parser = new TextFieldParser(csvFile))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;

                var csvList = new List<InputFileCreditCard>();

                var fields = parser.ReadFields();
                if (fields == null) throw new ArgumentNullException(nameof(fields));
                // handle header
                var loadDateTime = DateTime.Now;

                while (!parser.EndOfData)
                {
                    fields = parser.ReadFields();

                    //read in fields to variables
                    if (fields == null) continue;
                    var transactionDate = Convert.ToDateTime(fields[0]);
                    var transactionLoadDate = loadDateTime;
                    var transactionName = fields[1];
                    var cardType = fields[2];
                    var cardUser = fields[3];
                    var transactionGroup = fields[4];
                    var amountCr = string.IsNullOrEmpty(fields[5]) == true ? 0 : Convert.ToDouble(fields[5]);
                    var amountDr = string.IsNullOrEmpty(fields[6]) == true ? 0 : Convert.ToDouble(fields[6]);

                    csvList.Add(new InputFileCreditCard()
                    {
                        TransactionDate = transactionDate,
                        TransactionName = transactionName,
                        CardType = cardType,
                        CardUser = cardUser,
                        TransactionGroup = transactionGroup,
                        AmountCr = amountCr,
                        AmountDr = amountDr
                    });
                }

                return csvList;
            }
        }

        private static TransactionContext DistributeListToObjects(TransactionContext context, IEnumerable<InputFileCreditCard> csvList)
        {
            foreach (var item in csvList)
            {
                var transaction = new Transaction
                {
                    TransactionDate = item.TransactionDate,
                    TransactionAmount = item.AmountCr + item.AmountDr,
                    TransactionName = item.TransactionName,
                    TransactionLoadDateTime = item.TransactionLoadDateTime
                };

                var transactionGroup = new TransactionGroup
                {
                    TransactionGroupName = item.TransactionGroup
                };
            
                context.Transactions.Add(transaction);
                context.TransactionGroups.Add(transactionGroup);
            }

            context.SaveChanges();

            return context;
        }
    }
}
