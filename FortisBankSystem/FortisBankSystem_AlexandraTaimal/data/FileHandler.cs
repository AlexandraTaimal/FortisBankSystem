using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using FortisBankSystem_AlexandraTaimal.bus;
using System.Runtime.Serialization.Formatters.Binary; // for binary file


namespace FortisBankSystem_AlexandraTaimal.data
{
    class FileHandler    {
       

        //WriteToFile**********************************************************************
        private static String filePath = @"../../data/AccountTransaction.txt";
      
        public static void WriteToFile(List<Account> AccountList, List<Transaction> TransactionList)
        {
            using (StreamWriter writer = File.CreateText(filePath))
            {
                foreach (Account aAccount in AccountList)
                {
                    writer.WriteLine(EnumSelectType.Account + "|"
                                + aAccount.AccountNo + "|"
                                + aAccount.Pin + "|"
                                + aAccount.TypeAccount + "|"
                                + aAccount.AvailableBalance + "|"
                                + aAccount.OpenedDate + "|"
                                + aAccount.Customer.Id + "|"
                                + aAccount.Customer.Fn + "|"
                                + aAccount.Customer.Ln + "|"
                                + aAccount.Customer.Email + "|"
                                + aAccount.Customer.Phone + "|"
                                + aAccount.Customer.Address.StreetName + "|"
                                + aAccount.Customer.Address.StreetNumber + "|"
                                + aAccount.Customer.Address.ApartNumber + "|"
                                + aAccount.Customer.Address.PostalCode + "|"
                                + aAccount.Customer.Address.City + "|"
                                + aAccount.Customer.Address.Province + "|"
                                + aAccount.Customer.Address.Country);

                }
                foreach (Transaction aTransaction in TransactionList)
                {
                    writer.WriteLine(EnumSelectType.Transaction + "|"
                                + aTransaction.TransactionNumber + "|"
                                + aTransaction.Account.AccountNo + "|"
                                + aTransaction.Account.Pin + "|"
                                + aTransaction.Account.TypeAccount + "|"
                                + aTransaction.Account.AvailableBalance + "|"
                                + aTransaction.Account.OpenedDate + "|"
                                + aTransaction.Description + "|"
                                + aTransaction.TransactionAmount + "|"
                                + aTransaction.TypeTransaction + "|"
                                + aTransaction.TransactionDate);
                }

            }

            MessageBox.Show("File " + filePath + " was saved", "Fortis Bank");
        }
       

        //Read of File*******************************************************************
        public static void ReadFromFile(List<Account> AccountList, List<Transaction> TransactionList)
        {
            try
            {
                StreamReader reader = new StreamReader(filePath);
                String line = null;

                while ((line = reader.ReadLine()) != null)
                {
                    String[] fields = line.Split('|');

                    EnumSelectType tipo = (EnumSelectType)Enum.Parse(typeof(EnumSelectType), fields[0]);

                    if (tipo == EnumSelectType.Account)
                    {
                        EnumTypeAccount enumTypeAccount = (EnumTypeAccount)Enum.Parse(typeof(EnumTypeAccount), fields[3]);

                        int accountNo = Int32.Parse(fields[1]);
                        int pin = Int32.Parse(fields[2]);
                        double availableBalance = Double.Parse(fields[4]);
                        Date openedDate = null;

                        Customer customer = new Customer();
                        customer.Id = Int32.Parse(fields[6]);
                        customer.Fn = fields[7];
                        customer.Ln = fields[8];
                        customer.Email = fields[9];
                        customer.Phone = fields[10];
                        customer.Address.StreetName = fields[11];
                        customer.Address.StreetNumber = Int32.Parse(fields[12]);
                        customer.Address.ApartNumber = Int32.Parse(fields[13]);
                        customer.Address.PostalCode = fields[14];
                        customer.Address.City = fields[15];
                        customer.Address.Province = fields[16];
                        customer.Address.Country = fields[17];

                        if (enumTypeAccount == EnumTypeAccount.Checking)
                        {
                            Account aAccount = new CheckingAccount(enumTypeAccount, accountNo, pin, availableBalance, openedDate, customer, 4, 0);

                            AccountList.Add(aAccount);
                        }
                        else if (enumTypeAccount == EnumTypeAccount.Saving)
                        {
                            Account aAccount = new SavingAccount(enumTypeAccount, accountNo, pin, availableBalance, openedDate, customer, 4, 0, 0, 0);

                            AccountList.Add(aAccount);
                        }

                    }

                    else if (tipo == EnumSelectType.Transaction)
                    {
                        Transaction tTransaction = new Transaction();
                        Account aAccount;

                        int accountNo = Int32.Parse(fields[2]);
                        int pin = Int32.Parse(fields[3]);
                        double availableBalance = Double.Parse(fields[5]);
                        Date openedDate = null;

                        EnumTypeAccount enumTypeAccount = (EnumTypeAccount)Enum.Parse(typeof(EnumTypeAccount), fields[4]);

                        if (enumTypeAccount == EnumTypeAccount.Checking)
                        {
                            aAccount = new CheckingAccount(enumTypeAccount, accountNo, pin, availableBalance, openedDate, null, 4, 0);

                            tTransaction.TransactionNumber = Int32.Parse(fields[1]);
                            tTransaction.Account = aAccount;
                            tTransaction.Description = fields[7];
                            tTransaction.TransactionAmount = Double.Parse(fields[8]);
                            tTransaction.TypeTransaction = (EnumTypeTransaction)Enum.Parse(typeof(EnumTypeTransaction), fields[9]);

                            TransactionList.Add(tTransaction);
                        }
                        else if (enumTypeAccount == EnumTypeAccount.Saving)
                        {
                            aAccount = new SavingAccount(enumTypeAccount, accountNo, pin, availableBalance, openedDate, null, 4, 0, 0, 0);

                            tTransaction.TransactionNumber = Int32.Parse(fields[1]);
                            tTransaction.Account = aAccount;
                            tTransaction.Description = fields[7];
                            tTransaction.TransactionAmount = Double.Parse(fields[8]);
                            tTransaction.TypeTransaction = (EnumTypeTransaction)Enum.Parse(typeof(EnumTypeTransaction), fields[9]);

                            TransactionList.Add(tTransaction);
                        }
                    }

                }
                reader.Close();

                MessageBox.Show("File " + filePath + " was readed", "Fortis Bank");

            }
            catch (IOException ex)
            {
                MessageBox.Show("........File not FOUND....");
            }

        }
        
    }

}

