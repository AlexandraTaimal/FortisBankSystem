using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortisBankSystem_AlexandraTaimal.bus
{
    class SavingAccount : Account
    {
        private double annualInterest;
        private double annualGain;
        private double extraFee;

        public double AnnualInterest { get => annualInterest; set => annualInterest = value; }
        public double AnnualGain { get => annualGain; set => annualGain = value; }
        public double ExtraFee { get => extraFee; set => extraFee = value; }


        public SavingAccount(EnumTypeAccount enumTypeAccount, int accountNo, int pin, double availableBalance, Date openedDate, Customer customer, int freeTransactions, double annualInterest, double annualGain, double extraFees)
        {
            base.AccountNo = accountNo;
            base.Pin = pin;
            base.TypeAccount = enumTypeAccount;
            base.AvailableBalance = availableBalance;
            base.OpenedDate = openedDate;
            base.Customer = customer;
            this.AnnualInterest = annualInterest;
            this.AnnualGain = annualGain;
            this.ExtraFee = extraFee;
        }

        public SavingAccount()
        {
            base.TypeAccount = EnumTypeAccount.Saving;
            this.AnnualInterest = 0;
            this.AnnualGain = 0;
            this.ExtraFee = 0;
        }

        public override double TotalBalance()
        {
            return this.AvailableBalance;
        }
    }
}
