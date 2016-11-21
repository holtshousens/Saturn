using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.DAL.DataObjects
{
    public class InputFileCreditCard : IInputFile
    {
        public DateTime TransactionDate { get; set; }
        public string TransactionName { get; set; }
        public string TransactionGroup { get; set; }
        public DateTime TransactionLoadDateTime { get; set; }

        public double AmountCr { get; set; } 
        public double AmountDr { get; set; } 

        public string CardType { get; set; }
        public string CardUser { get; set; }
    }
}
