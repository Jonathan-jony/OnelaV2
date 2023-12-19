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
        public Frm1()
        {
            InitializeComponent();
            connector = new DBConnector();
            listBox1.Items.Clear();
            UpdateListBox(listContacts);
        }

        private void button_addContacts_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm2 frm2 = new Frm2();
            frm2.Show();
        }

        public void UpdateListBox(ListContacts listContacts)
        {

            if (connector.ExecuteQuerySelect() == null)
            {
                label_NoContact.Visible = true;
                listBox1.Visible = false;
            }
            else
            {
                label_NoContact.Visible = false;
                listBox1.Visible = true;
                foreach (Contact contact in connector.ExecuteQuerySelect())
                {
                    listBox1.Items.Add(contact.Firstname + " " + contact.Lastname + " " + contact.Numberphone);
                }                
            }
        }

        private void TextBox_search_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            string search = TextBox_search.Text;

            foreach (Contact contact in connector.ExecuteQuerySelectFilter(search))
            {
                listBox1.Items.Add(contact.Firstname + " " + contact.Lastname + " " + contact.Numberphone);
            }
            if (listBox1.Items.Count == 0)
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
