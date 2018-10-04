using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortisBankSystem_AlexandraTaimal.bus
{
   public class Transaction 
    {
        private int transactionNumber;
        private Account account;
        private string description;
        private double transactionAmount;
        private EnumTypeTransaction typeTransaction;
        private Date transactionDate;


        public int TransactionNumber { get => transactionNumber; set => transactionNumber = value; }
        public Account Account { get => account; set => account = value; }
        public string Description { get => description; set => description = value; }
        public double TransactionAmount { get => transactionAmount; set => transactionAmount = value; }
        public EnumTypeTransaction TypeTransaction { get => typeTransaction; set => typeTransaction = value; }
        public Date TransactionDate { get => transactionDate; set => transactionDate = value; }

        public Transaction() : base()
        {
            this.TransactionNumber = 0;
            this.Account = null;
            this.Description = "";
            this.TransactionAmount = 0000000000.00;
            this.TypeTransaction = EnumTypeTransaction.Deposit;
            this.transactionDate = new Date();
        }

        public Transaction(int transactionNumber, Account account, string description, double availableBalance, double transactionAmount, EnumTypeTransaction typeTransation, Date date)
        {
            this.TransactionNumber = transactionNumber;
            this.Account = account;
            this.Description = description;
            this.TransactionAmount = transactionAmount;
            this.TypeTransaction = typeTransaction;
            this.TransactionDate = date;
        }

        public override string ToString()
        {
            return this.transactionNumber + " - " + this.typeTransaction + " - " + this.transactionAmount + " - " + this.account.AccountNo + " - " + this.TransactionDate + " - " + this.description;
        }
 
    }
}
