using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using The_social_network_camilo_jefernne_eimy.Clases;

namespace The_social_network_camilo_jefernne_eimy.Formularios
{
    public partial class login : Form
    {

       




        public login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            

    }
       

        private void button2_Click(object sender, EventArgs e)
        {
            Form formulario = new Form1();
            this.Hide();
            formulario.Show();
            
        }

        

        private void label2_Click(object sender, EventArgs e)
        {
            Form formulario = new InicioSecciión();
            this.Hide();
            formulario.Show();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cConexion cn = new cConexion();
            SqlCommand cmd = new SqlCommand("select userName,password,email from tblUser where userName='" + txtUser.Text + "' and password='" + txtPassword.Text + "' or email ='"+txtUser.Text+ "' and password='" + txtPassword.Text +"'", cn.AbrirConexion());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Form formulario = new principal();
                this.Hide();
                formulario.Show();
                Button boton1 = principal.miBoton;
                boton1.Text=txtUser.Text;

            }
            else
            {
                MessageBox.Show("Ingreso malo"); 
            }
            
            
        }
        
        

        public static void SetButtonText(Button button, string text)
        {
            button.Text = text;
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "USER";

            }
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "USER")
            {
                txtUser.Text = "";

            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "PASSWORD")
            {
                txtPassword.Text = "";
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave_1(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "PASSWORD";
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
