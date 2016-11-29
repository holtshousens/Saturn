using Microsoft.VisualBasic.FileIO;
using Saturn.DAL.DataContext;
using Saturn.DAL.DataObjects;
using System;
using System.Collections.Generic;
using System.Configuration;

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

            //testing new logic
            List<InputFileCreditCard> CSVFile = new List<InputFileCreditCard>();

            CSVFile = CSVFileToList(ConfigurationManager.AppSettings[_debitCard]);

            // next need to use the list and populate the data objects

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

                    List<InputFileDebitCard> newList = new List<InputFileDebitCard>();
                    //newList = CSVFileToList(sourcefile);
                    //distributeListToObjects(context, newList);
                }
                else if (sourceTag == _creditCard)
                {
                    string sourcefile = ConfigurationManager.AppSettings[sourceTag];

                    List<InputFileCreditCard> newList = new List<InputFileCreditCard>();
                    newList = CSVFileToList(sourcefile);
                    distributeListToObjects(context, newList);
                }
                else
                {
                    throw new NotImplementedException();
                }

                context.SaveChanges();
            }
        }

        private static List<InputFileCreditCard> CSVFileToList(string CSVFile)
        {
            using (TextFieldParser parser = new TextFieldParser(CSVFile))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;

                string[] fields;

                List<InputFileCreditCard> CSVList = new List<InputFileCreditCard>();

                fields = parser.ReadFields();
                // handle header
                DateTime LoadDateTime = DateTime.Now;

                while (!parser.EndOfData)
                {
                    fields = parser.ReadFields();

                    //read in fields to variables
                    DateTime transactionDate = Convert.ToDateTime(fields[0]);
                    DateTime transactionLoadDate = LoadDateTime;
                    string transactionName = fields[1];
                    string cardType = fields[2];
                    string cardUser = fields[3];
                    string transactionGroup = fields[4];
                    double amountCr = String.IsNullOrEmpty(fields[5]) == true ? 0 : Convert.ToDouble(fields[5]);
                    double amountDr = String.IsNullOrEmpty(fields[6]) == true ? 0 : Convert.ToDouble(fields[6]);

                    CSVList.Add(new InputFileCreditCard()
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

                return CSVList;
            }
        }

        private static TransactionContext distributeListToObjects(TransactionContext context, List<InputFileCreditCard> CSVList)
        {
            foreach (var item in CSVList)
            {
                Transaction transaction = new Transaction
                {
                    TransactionDate = item.TransactionDate,
                    TransactionAmount = item.AmountCr + item.AmountDr,
                    TransactionName = item.TransactionName,
                    TransactionLoadDateTime = item.TransactionLoadDateTime
                };

                TransactionGroup transactionGroup = new TransactionGroup
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
