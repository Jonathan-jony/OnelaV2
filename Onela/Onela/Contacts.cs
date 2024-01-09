using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Onela
{
    public class Contact
    {
        public string _firstname;
        public string _lastname;
        public string _numberphone;
        public string _active = null;
        public Contact(string Firstname, string Lastname, string numberPhone, string active)
        {
            _firstname = Firstname;
            _lastname = Lastname;
            _numberphone = numberPhone;
            _active = active;
        }
        public string Firstname
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;
            }
        }
        public string Lastname
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
            }
        }
        public string Numberphone
        {
            get
            {
                return _numberphone;
            }
            set
            {
                _numberphone = value;
            }
        }
        public string Active
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
            }
        }
    }
}