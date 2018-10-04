using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortisBankSystem_AlexandraTaimal.bus
{
    class CheckingAccount : Account
    {
        private int freeTransactions;
        private double extraFees;

        public CheckingAccount(EnumTypeAccount enumTypeAccount, int accountNo, int pin, double availableBalance, Date openedDate, Customer customer, int freeTransactions, double extraFees)
        {
            base.AccountNo = accountNo;
            base.Pin = pin;
            base.TypeAccount = enumTypeAccount;
            base.AvailableBalance = availableBalance;
            base.OpenedDate = openedDate;
            base.Customer = customer;
            this.FreeTransactions = freeTransactions;
            this.ExtraFees = extraFees;
        }

        public CheckingAccount()
        {
            base.TypeAccount = EnumTypeAccount.Checking;
            this.FreeTransactions = 0;
            this.ExtraFees = 0;
        }


        public int FreeTransactions { get => freeTransactions; set => freeTransactions = value; }
        public double ExtraFees { get => extraFees; set => extraFees = value; }

        public override double TotalBalance()
        {
            return this.AvailableBalance;
        }
    }
}
