using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortisBankSystem_AlexandraTaimal.bus
{
    public class Customer
    {
        private int id;
        private string fn;
        private string ln;
        private string email;
        private string phone;
        private Address address;
        //private List<Account> accountList;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value.Equals(""))
                {
                    FormatException fe = new FormatException();
                    throw (fe);
                }

                id = value;
            }
        }
        public string Fn { get => fn; set => fn = value; }
        public string Ln { get => ln; set => ln = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public Address Address { get => address; set => address = value; }

        public Customer() : base()
        {
            this.Id = 0000;
            this.Fn = "undefined";
            this.Ln = "undefined";
            this.Email = "";
            this.Phone = "";
            this.Address = new Address();

        }
        public Customer(int id, String fn, String ln, String email, String phone, int pin, Date date, Address address)
        {
            this.Id = id;
            this.Fn = fn;
            this.Ln = ln;
            this.Email = email;
            this.Phone = phone;
            this.Address = address;
        }
        public override string ToString()
        {
            String state;
            state = this.Id + " - " + this.Fn + " - " + this.Ln + " - " + this.Email + " - " + this.Phone + " - " + this.Address;
            return state;
        }

    }
}
