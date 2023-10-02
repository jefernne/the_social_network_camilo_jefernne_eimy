using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace The_social_network_camilo_jefernne_eimy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
           
          

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Switch_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmbPrivacy_SelectedIndexChanged(object sender, EventArgs e)
        {
  

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbPrivacy_Leave(object sender, EventArgs e)
        {
           
            if (cmbPrivacy.Text.Equals("Private"))
            {
                txtUserName.Visible = false;
                cmbGender.Visible = false;
                txtBirthdate.Visible = false;
                panel1.Visible = false;
                label1.Visible = false;
                label2.Visible = false;

            }
            if (cmbPrivacy.Text.Equals("Public"))
            {
                txtUserName.Visible = true;
                cmbGender.Visible = true;
                txtBirthdate.Visible = true;
                panel1.Visible = true;
                label1.Visible = true;
                label2.Visible = true;

            }

        }

       
    }
}
