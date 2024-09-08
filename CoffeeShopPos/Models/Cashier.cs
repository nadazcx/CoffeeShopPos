using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CoffeeShopPos.Models
{
    public class Cashier
    {
        private int _id;
        private string _userName;
        private string _pin;
        private string _name;
        private string _phoneNumber;
        private string _email;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Pin
        {
            get => _pin;
            set => _pin = value;
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => _phoneNumber = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string UserName
        {
            get => _userName;
            set => _userName = value;
        }
    }
}