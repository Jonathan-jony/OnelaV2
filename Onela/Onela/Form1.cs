using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Onela
{
    public partial class Frm1 : Form
    {
        private ListContacts listContacts;
        private DBConnector connector;
        ContactDesign contactDesigns;
        public Frm1()
        {
            InitializeComponent();
            connector = new DBConnector();
            UpdateListBox(listContacts);
        }

        private void button_addContacts_Click(object sender, EventArgs e)
        {
            this.Hide();
            createContactForm frm2 = new createContactForm();
            frm2.Show();
        }

        public void UpdateListBox(ListContacts listContacts)
        {

            if (connector.ExecuteQuerySelect() == null)
            {
                label_NoContact.Visible = true;
            }
            else
            {
                contactDesigns = new ContactDesign();
                label_NoContact.Visible = false;
                foreach (Contact contact in connector.ExecuteQuerySelect())
                {
                    contactDesigns = new ContactDesign();
                    contactDesigns.ContactFirstName = contact.Firstname;
                    contactDesigns.ContactLastName = contact.Lastname;
                    contactDesigns.ContactNumberPhone = contact.Numberphone;

                    //if (flowLayoutPanel1.Controls.Count > 0)
                    //{
                    //    flowLayoutPanel1.Controls.Clear();
                    //}
                    flowLayoutPanel1.Controls.Add(contactDesigns);
                }                
            }
        }

        private void TextBox_search_TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            string search = TextBox_search.Text;

            foreach (Contact contact in connector.ExecuteQuerySelectFilter(search))
            {
                contactDesigns = new ContactDesign();
                contactDesigns.ContactFirstName = contact.Firstname;
                contactDesigns.ContactLastName = contact.Lastname;
                contactDesigns.ContactNumberPhone = contact.Numberphone;

                flowLayoutPanel1.Controls.Add(contactDesigns);
            }
            if (flowLayoutPanel1.Controls.Count == 0)
            {
                label_NoContact.Visible = true;
            }
            else
            {
                label_NoContact.Visible = false;
            }
        }
    }
}
