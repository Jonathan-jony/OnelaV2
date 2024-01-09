using System;
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
    public partial class createContactForm : Form
    {
        public ListContacts listContacts = new ListContacts();
        public Contact _contact;
        public RepertoireForm GetFrm1;
        private DBConnector connector;
        public static string _firstName = "";
        public static string _lastName = "";
        public static string _numberPhone = "";
        public static string _active;
        public static string _image;

        public createContactForm()
        {
            InitializeComponent();
            connector = new DBConnector();
        }

        private void button_createContacts_Click(object sender, EventArgs e)
        {
            _firstName = textBox_firstnameNewContacts.Text;
            _lastName = textBox_lastnameNewContacts.Text;
            _numberPhone = textBox_numberNewContacts.Text;
            _active = "1";

            _contact = new Contact(_firstName, _lastName, _numberPhone, _active, _image);

            connector.ExecuteQueryInsert(_contact);

            listContacts.addContact(_contact);

            this.Close();

            RepertoireForm frm1 = new RepertoireForm();
            frm1.Show();
        }
    }
}
