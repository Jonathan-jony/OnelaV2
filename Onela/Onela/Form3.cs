using Onela.Properties;
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
    public partial class modifyContactForm : Form
    {
        private Contact _contact;
        private DBConnector connector;
        private string _oldNumberPhone;
        private bool _blocked;
  

        public modifyContactForm(Contact contact)
        {
            InitializeComponent();
            connector = new DBConnector();
            _contact = contact;
        }

        private void button_cancelModifyContacts_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void modifyContactForm_Load(object sender, EventArgs e)
        {
            textBox_firstnameModifyContact.Text = _contact.Firstname;
            textBox_lastnameModifyContact.Text = _contact.Lastname;
            textBox_numberModifyContact.Text = _contact.Numberphone;
            _oldNumberPhone = _contact.Numberphone;
            pictureBox_newContacts.Image = Resources.izlUGPTOOCbs6O2AT1o0P_1020;

            chk_Block.Checked = false;

            if (_contact.Active == "0")
            {
                chk_Block.Checked = true;
                pictureBox_newContacts.Image = Resources.XeGjq6Wp3oYyZKn54dO9r_1020;
            }            
        }

        private void button_modifyContacts_Click(object sender, EventArgs e)
        {
            _contact.Firstname = textBox_firstnameModifyContact.Text;
            _contact.Lastname = textBox_lastnameModifyContact.Text;
            _contact.Numberphone = textBox_numberModifyContact.Text;

            if (chk_Block.Checked == true)
            {
                _blocked = true;
            }

            _contact = new Contact(_contact.Firstname, _contact.Lastname, _contact.Numberphone, _contact.Active, _contact.Image);

            connector.ExecuteQueryUpdate(_contact, _oldNumberPhone, _blocked);

            this.Close();
            RepertoireForm frm1 = new RepertoireForm();
            frm1.Show();
        }
    }
}
