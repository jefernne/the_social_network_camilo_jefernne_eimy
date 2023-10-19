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
using System.Data.SqlClient;
using The_social_network_camilo_jefernne_eimy.Clases;

namespace The_social_network_camilo_jefernne_eimy
{
    public partial class Form1 : Form
    {
              
        private int contadorMaximo()
        {
            cConexion cn = new cConexion();
            SqlCommand cmd = new SqlCommand("select * from tblUser",cn.AbrirConexion());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            int id= dt.Rows.Count;
            return id;
        }

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

        private void btnContinue_Click(object sender, EventArgs e)
        {
             int id = contadorMaximo()+1;
             
            cConexion cn = new cConexion();
            SqlCommand cmd = new SqlCommand("insert into  tblUser values(" + id + ",'" + txtUserName.Text + "','" + txtEmail.Text + "','" + txtPassword.Text + "','" + txtConfirmPassword.Text + "','" + txtBirthDay.Text + "','" + cmbGender.Text + "')", cn.AbrirConexion());
            cmd.ExecuteNonQuery();
            
        }

        private void cmbPrivacy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbPrivacy.Text.Equals("Private"))
            {
                cmbGender.Visible = false;
                txtBirthDay.Visible = false;
                panel1.Visible = false;
                label1.Visible = false;
                label2.Visible = false;

            }
            if (cmbPrivacy.Text.Equals("Public"))
            {
                txtUserName.Visible = true;
                cmbGender.Visible = true;
                txtBirthDay.Visible = true;
                panel1.Visible = true;
                label1.Visible = true;
                label2.Visible = true;

            }

        }



    



       
    }
}
