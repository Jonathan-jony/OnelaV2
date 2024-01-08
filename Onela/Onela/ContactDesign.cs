﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Onela
{
    public partial class ContactDesign : UserControl
    {
        private DBConnector connector;
        private Contact contact = null;
        private string _contactFirstName;
        private string _contactLastName;
        private string _contactNumberPhone;
        private Image _contactImage;

        public ContactDesign()
        {
            InitializeComponent();

            connector = new DBConnector();
        }

        public string ContactFirstName
        {
            get
            {
                return _contactFirstName;
            }
            set
            {
                _contactFirstName = value;
                lbl_firstname.Text = value;
            }
        }
        public string ContactLastName
        {
            get
            {
                return _contactLastName;
            }
            set
            {
                _contactLastName = value;
                lbl_lastname.Text = value;
            }
        }
        public string ContactNumberPhone
        {
            get
            {
                return _contactNumberPhone;
            }
            set 
            { 
                _contactNumberPhone = value; 
                lbl_numberphone.Text = value;
            }
        }
        public Image ContactImage
        {
            get
            {
                return _contactImage;
            }
            set { _contactImage = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm1 frm = new Frm1();
            frm.Hide();
            Contact contact = connector.ExecuteQuerySelectOneContact(_contactNumberPhone);
            modifyContactForm modifyContactForm = new modifyContactForm(contact);
            modifyContactForm.Show();
        }
    }
}
