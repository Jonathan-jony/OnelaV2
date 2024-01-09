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
using System.Xml.Linq;

namespace Onela
{
    public partial class ContactDesign : UserControl
    {

        public event EventHandler ModifyButtonClick;

        private DBConnector connector;
        private Contact contact = null;
        private string _contactFirstName;
        private string _contactLastName;
        private string _contactNumberPhone;
        private string _contactActive;
        private Image _contactImage;

        public ContactDesign()
        {
            InitializeComponent();
            OnModifyButtonClick(EventArgs.Empty);
            connector = new DBConnector();

            pictureBox1.Image = Resources.izlUGPTOOCbs6O2AT1o0P_1020;
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
            set 
            { 
                _contactImage = value; 
            }
        }
        public string ContactActive
        {
            get
            {
                return _contactActive;
            }
            set 
            { 
                _contactActive = value;
                if (_contactActive == "0")
                {

                    pictureBox1.Image = Resources.photo.jpg;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {        
            Contact contact = connector.ExecuteQuerySelectOneContact(_contactNumberPhone);
            modifyContactForm modifyContactForm = new modifyContactForm(contact);
            modifyContactForm.Show();
        }
        protected virtual void OnModifyButtonClick(EventArgs e)
        {
            ModifyButtonClick?.Invoke(this, e);
        }
    }
}
