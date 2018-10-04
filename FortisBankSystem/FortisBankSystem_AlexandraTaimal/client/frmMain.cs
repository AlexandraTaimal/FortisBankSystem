using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//use bus folder for client folder
//DB_Soft is namespace 
using FortisBankSystem_AlexandraTaimal.bus;
using FortisBankSystem_AlexandraTaimal.data;
using System.IO;
using System.Xml; //for xml file
using System.Xml.Serialization; //for xml file


namespace FortisBankSystem_AlexandraTaimal
{
    public partial class frmMain : Form
    {
        // lists to store the accounts and transactions
        private static List<Account> AccountList = new List<Account>();
        private static List<Transaction> TransactionList = new List<Transaction>();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            foreach (EnumTypeAccount element in Enum.GetValues(typeof(EnumTypeAccount)))
            {
                cboTypeAccount.Items.Add(element);
            }
            foreach (EnumTypeTransaction element in Enum.GetValues(typeof(EnumTypeTransaction)))
            {
                cboTypeTransation.Items.Add(element);
            }

        }
        //Add*************************************************************************************
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int accountNo = Convert.ToInt32(txtAccountNo1.Text);
            int pin = Convert.ToInt32(textPin.Text);
            double availableBalance = 0;
            Date openedDate = new Date(Convert.ToInt32(textBoxDay1.Text),
                                      Convert.ToInt32(textBoxMonth1.Text), Convert.ToInt32(textBoxYear1.Text));

            // creates the customer
            Customer cCustomer = new Customer();
            cCustomer.Id = Convert.ToInt32(textId.Text);
            cCustomer.Fn = textName.Text;
            cCustomer.Ln = textLastName.Text;
            cCustomer.Email = textEmail.Text;
            cCustomer.Phone = textPhone.Text;

            cCustomer.Address.StreetName = textStreetName.Text;
            cCustomer.Address.StreetNumber = Convert.ToInt32(textStreetNo.Text);
            cCustomer.Address.ApartNumber = Convert.ToInt32(textApartNo.Text);
            cCustomer.Address.PostalCode = textPostalCode.Text;
            cCustomer.Address.City = textCity.Text;
            cCustomer.Address.Province = textProvince.Text;
            cCustomer.Address.Country = textCountry.Text;

            // if TypeAccount is Checking
            if (cboTypeAccount.Text == EnumTypeAccount.Checking.ToString())
            {
                // creates a new account
                Account aAccount;

                // polymorphism from Account to CheckingAccount
                aAccount = new CheckingAccount(EnumTypeAccount.Checking, accountNo, pin, availableBalance, openedDate, cCustomer, 4, 0);

                // adds the new account to the Account's list
                AccountList.Add(aAccount);

            }
            // if TypeAccount is Saving
            else if (cboTypeAccount.Text == EnumTypeAccount.Saving.ToString())
            {
                // creates a new account
                Account aAccount;

                // polymorphism from Account to SavingAccount
                aAccount = new SavingAccount(EnumTypeAccount.Saving, accountNo, pin, availableBalance, openedDate, cCustomer, 4, 0, 0, 0);

                // adds the new account to the Account's list
                AccountList.Add(aAccount);

            }
            else if (cboTypeAccount.Text == EnumTypeAccount.Credit.ToString())
            {
                // creates a new account
                Account aAccount;

                // polymorphism from Account to CreditAccount
                aAccount = new SavingAccount(EnumTypeAccount.Credit, accountNo, pin, availableBalance, openedDate, cCustomer, 4, 0, 0, 0);

                // adds the new account to the Account's list
                AccountList.Add(aAccount);

            }
            else if (cboTypeAccount.Text == EnumTypeAccount.Currency.ToString())
            {
                // creates a new account
                Account aAccount;

                // polymorphism from Account to CurrencygAccount
                aAccount = new SavingAccount(EnumTypeAccount.Currency, accountNo, pin, availableBalance, openedDate, cCustomer, 4, 0, 0, 0);

                // adds the new account to the Account's list
                AccountList.Add(aAccount);

            }
            

            MessageBox.Show("Account added", "Fortis Bank");
        }
        //AddTransaction*******************************************************************
        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            // Search the account to validate if it exists
            int accountNumber = Convert.ToInt32(txtAccountNo2.Text);

            // creates the account
            Account aAccount = searchAccount(accountNumber);
            if (aAccount != null)
            {
                double transactionAmount = Convert.ToDouble(txtTransactionAmount.Text);

                // if it's a deposit
                if (cboTypeTransation.SelectedIndex == 0)
                {
                    aAccount.AvailableBalance = aAccount.AvailableBalance + transactionAmount;
                }
                // if it's a Withdraw
                else if (cboTypeTransation.SelectedIndex == 1)
                {
                    if (aAccount.AvailableBalance < transactionAmount)
                    {
                        MessageBox.Show("The account available balance is not enought", "Fortis Bank");
                        return;
                    }
                    aAccount.AvailableBalance = aAccount.AvailableBalance - transactionAmount;
                }

                // creates the new Transaction
                Transaction tTransaction = new Transaction();

                tTransaction.TransactionNumber = Convert.ToInt32(txtTransactionNo.Text);

                tTransaction.TransactionDate = new Date(Convert.ToInt32(textBoxDay2.Text),
                          Convert.ToInt32(textBoxMonth2.Text), Convert.ToInt32(textBoxYear2.Text));

                tTransaction.TransactionAmount = transactionAmount;

                tTransaction.Description = txtDescription.Text;

                tTransaction.Account = aAccount;

                // adds the new transaction to the Transaction's list
                TransactionList.Add(tTransaction);

                MessageBox.Show("Transaction performed, New Balance: " + aAccount.AvailableBalance, "Fortis Bank");
            }
            else
            {
                MessageBox.Show("The account " + accountNumber + " does not exists", "Fortis Bank");
                return;
            }

        }

        private Account searchAccount(int accountNumber)
        {
            Account aAccount = null;

            foreach (Account element in AccountList)
            {
                if (element.AccountNo.Equals(accountNumber))
                {
                    return element;
                }
            }

            return aAccount;
        }
        //DisplayTransaction************************************************************
        private void btnDisplayTransaction_Click(object sender, EventArgs e)
        {
            this.listBoxCustomer.Items.Clear();//clear the listBox
            if (TransactionList.Count != 0)
            {
                foreach (Transaction tTransaction in TransactionList)
                {
                    this.listBoxCustomer.Items.Add(tTransaction);
                }
            }
            else
            {
                MessageBox.Show("There are not transactions", "Fortis Bank");
            }
        }
        //DisplayAccount******************************************************************
        private void btnDisplayAccount_Click(object sender, EventArgs e)
        {
            this.listBoxCustomer.Items.Clear();//clear the listBox
            if (AccountList.Count != 0)
            {
                foreach (Account aAccount in AccountList)
                {
                    this.listBoxCustomer.Items.Add(aAccount);
                }
            }
            else
            {
                MessageBox.Show("There are not accounts", "Fortis Bank");
            }
        }
        //Display all**********************************************************************
        private void btnAll_Click(object sender, EventArgs e)
        {
            this.listBoxCustomer.Items.Clear();//clear the listBox
            Boolean existData = false;
            if (AccountList.Count != 0)
            {
                existData = true;
                foreach (Account aAccount in AccountList)
                {
                    this.listBoxCustomer.Items.Add(aAccount);
                }
            }
            if (TransactionList.Count != 0)
            {
                existData = true;
                foreach (Transaction tTransaction in TransactionList)
                {
                    this.listBoxCustomer.Items.Add(tTransaction);
                }
            }

            if (existData == false)
            {
                MessageBox.Show("There are not accounts and transactions", "Fortis Bank");
            }
        }
        //Reset*******************************************************************************
        private void btnReset_Click(object sender, EventArgs e)
        {
            textId.Text = "";
            textName.Text = "";
            textLastName.Text = "";
            textPin.Text = "";            
            textEmail.Text = "";
            textPhone.Text = "";
            textStreetNo.Text = "";
            textStreetName.Text = "";
            textApartNo.Text = "";
            textCity.Text = "";
            textProvince.Text = "";
            textCountry.Text = "";
            textPostalCode.Text = "";
            cboTypeTransation.Text = "";
            cboTypeAccount.Text = "";
            listBoxCustomer.Items.Clear();

            txtTransactionNo.Text = "";
            txtTransactionAmount.Text = "";
            txtDescription.Text = "";
            txtAccountNo1.Text = "";
            txtAccountNo2.Text = "";




        }
        //Exit*********************************************************************************
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // get the selected object in the listBox
            Object obj = listBoxCustomer.SelectedItem;

            // Is it an Account ?
            if (obj.GetType().Equals(typeof(CheckingAccount)) || obj.GetType().Equals(typeof(SavingAccount)))
            {
                // converts from object to Student and removes the Student from the list
                Account a = (Account)obj;
                AccountList.Remove(a);
            }
            // Is it a Teacher ?
            else if (obj.GetType().Equals(typeof(Transaction)))
            {
                // converts from object to Teacher and removes the Teacher from the list
                Transaction t = (Transaction)obj;
                TransactionList.Remove(t);
            }

            // removes the item (student or teacher) from the listBox
            listBoxCustomer.Items.Remove(obj);
          
        }

        //Call the function WriteFile***************************************************
        private void btnWriteFile_Click(object sender, EventArgs e)
        {
           FileHandler.WriteToFile(AccountList, TransactionList);
        }

        //Call the function ReadFromFile****************************************************
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
           FileHandler.ReadFromFile(AccountList, TransactionList);
        }

       

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Account aAccount = null;

            bool found = false;
            foreach (Account element in AccountList)
            {
                if (element.AccountNo == Convert.ToInt32(txtSearching.Text))
                {
                    found = true;
                    aAccount = element;
                }
            }

            if (found)
            {
                MessageBox.Show(aAccount.ToString());
            }
            else
            {
                MessageBox.Show(txtSearching.Text + "   NOT FOUND in the collection");
            }
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void cboTypeAccount_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
