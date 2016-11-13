using Microsoft.VisualBasic.FileIO;
using Saturn.DAL.DataContext;
using Saturn.DAL.DataObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;

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
            List<InputFile> CSVFile = new List<InputFile>();

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

                    buildContextFromFile(context, sourcefile);
                }
                else if (sourceTag == _creditCard)
                {
                    string sourcefile = ConfigurationManager.AppSettings[sourceTag];

                    buildContextFromFile(context, sourcefile);
                }
                else
                {
                    throw new NotImplementedException();
                }

                context.SaveChanges();
            }
        }

        private static void buildContextFromFile(TransactionContext context, string sourcefile)
        {
            using (var reader = new StreamReader(File.OpenRead(sourcefile)))
            {
                string line = reader.ReadLine();

                List<string> header = new List<string>();
                List<string> row = new List<string>();

                foreach (var field in line.Split(','))
                {
                    
                    header.Add(field);
                }
                
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();

                    foreach (var field in line.Split(','))
                    {
                        row.Add(field);
                    }

                    string nowString = DateTime.Now.ToString("dd/MM/yyyy");
                    DateTime now = DateTime.ParseExact(nowString, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    DateTime transactionDate = DateTime.ParseExact(row[1], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    // issue is that there is a comma in a text field causing a break...
                    Transaction transaction = new Transaction
                    {

                        TransactionDate = transactionDate,
                        TransactionAmount = row[3],
                        TransactionName = row[5],
                        TransactionLoadDate = now
                    };
                    Console.WriteLine(transaction.TransactionDate);

                    TransactionGroup transactionGroup = new TransactionGroup
                    {
                        TransactionGroupName = row[4]
                    };

                    AccountType accountType = new AccountType
                    {
                        accountNumber = row[2]
                    };

                    context.Transactions.Add(transaction);
                    context.TransactionGroups.Add(transactionGroup);
                    context.AccountTypes.Add(accountType);

                }
            }
        }

        private static List<InputFile> CSVFileToList(string CSVFile)
        {
            using (TextFieldParser parser = new TextFieldParser(CSVFile))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;

                string[] fields;

                var CSVList = new List<InputFile>();

                fields = parser.ReadFields();
                // handle header

                while (!parser.EndOfData)
                {
                    fields = parser.ReadFields();

                    //read in fields to variables
                    DateTime transactionDate = Convert.ToDateTime(fields[0]);
                    string transactionName = fields[1];
                    string cardType = fields[2];
                    string cardUser = fields[3];
                    string transactionGroup = fields[4];
                    double amountCr = String.IsNullOrEmpty(fields[5]) == true ? 0 : Convert.ToDouble(fields[5]);
                    double amountDr = String.IsNullOrEmpty(fields[6]) == true ? 0 : Convert.ToDouble(fields[6]);

                    CSVList.Add(new InputFile()
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
    }
}
