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
                label1.Visible = true;
                listBox1.Visible = false;
            }
            else
            {
                label1.Visible = false;
                listBox1.Visible = true;
                foreach (Contact contact in connector.ExecuteQuerySelect())
                {
                    listBox1.Items.Add(contact.Firstname + " " + contact.Lastname + " " + contact.Numberphone);
                }                
            }
        }
    }
}
