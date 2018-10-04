using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortisBankSystem_AlexandraTaimal.bus
{
    public class Address
    {
        private int streetNumber;
        private String streetName;
        private int apartNumber;
        private String city;
        private String province;
        private String postalCode;
        private String country;

        public int StreetNumber { get => streetNumber; set => streetNumber = value; }
        public string StreetName { get => streetName; set => streetName = value; }
        public int ApartNumber { get => apartNumber; set => apartNumber = value; }
        public string City { get => city; set => city = value; }
        public string Province { get => province; set => province = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string Country { get => country; set => country = value; }

        public Address()
        {
            this.StreetNumber = 0000;
            this.StreetName = "unknown";
            this.ApartNumber = 0000;
            this.City = "unknown";
            this.Province = "unknown";
            this.PostalCode = "unknown";
            this.Country = "unknown";


        }
        public Address(int streetNumber, String streetName, int apartNumber, String city,
                String province, String postalCode, String country)
        {
            this.StreetNumber = streetNumber;
            this.StreetName = streetName;
            this.ApartNumber = apartNumber;
            this.City = city;
            this.Province = province;
            this.PostalCode = postalCode;
            this.Country = country;
        }



        public String toString()
        {
            String state;
            state = this.StreetNumber + " - " + this.StreetName + " - " + this.ApartNumber +
                    " - " + this.City + " - " + this.Province + " - " + this.PostalCode + " - " + this.Country;
            return state;
        }

    }
}
