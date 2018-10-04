using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortisBankSystem_AlexandraTaimal.bus
{
    public abstract class Account :IPayable
    {
        private int accountNo;
        private int pin;
        private EnumTypeAccount typeAccount;
        private double availableBalance;
        private Date openedDate;
        private Customer customer;

        public int AccountNo { get => accountNo; set => accountNo = value; }
        public int Pin { get => pin; set => pin = value; }
        public EnumTypeAccount TypeAccount { get => typeAccount; set => typeAccount = value; }
        public double AvailableBalance { get => availableBalance; set => availableBalance = value; }
        public Date OpenedDate { get => openedDate; set => openedDate = value; }
        public Customer Customer { get => customer; set => customer = value; }
       

        public Account()
        {
            this.AccountNo = 0;
            this.Pin = 0000;
            this.TypeAccount = EnumTypeAccount.Checking;
            this.AvailableBalance = 0000000000.00;
            this.OpenedDate = new Date();
            this.Customer = null;
        }

        protected Account(int accountNo, int pin, EnumTypeAccount typeAccount, double availableBalance, Date openedDate, Customer customer)
        {
            this.AccountNo = accountNo;
            this.Pin = pin;
            this.TypeAccount = typeAccount;
            this.AvailableBalance = availableBalance;
            this.OpenedDate = openedDate;
            this.Customer = customer;
        }

        public override string ToString()
        {
            return this.AccountNo + " - " + this.typeAccount + " - " + this.availableBalance + " - " + this.openedDate + " - " + this.customer.Id + " - " + this.customer.Fn + " " + this.customer.Ln;
        }

        public abstract double TotalBalance();

    }
}
