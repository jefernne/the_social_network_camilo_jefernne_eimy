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
using The_social_network_camilo_jefernne_eimy.Formularios;
using System.Text.RegularExpressions;

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
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
           
        }
        public static string nombreAleatorio()
        {
            string caracteresValidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            int longitud = 4; 

            
            Random random = new Random();
            char[] usernameChars = new char[longitud];

            for (int i = 0; i < longitud; i++)
            {
                int index = random.Next(0, caracteresValidos.Length);
                usernameChars[i] = caracteresValidos[index];
            }

            return new string(usernameChars);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Switch_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            string validarcorrro = txtEmail.Text;

            if (ValidarCorreoElectronico(validarcorrro))
            {
                int id = contadorMaximo() + 1;
                if (cmbPrivacy.Text.Equals("Public"))
                {
                    
                    cConexion cn = new cConexion();
                    SqlCommand cmd = new SqlCommand("insert into  tblUser values(" + id + ",'" + txtUserName.Text + "','" + txtEmail.Text + "','" + txtPassword.Text + "','" + txtConfirmPassword.Text + "','" + dtBirthdate.Text + "','" + cmbGender.Text + "')", cn.AbrirConexion());
                    cmd.ExecuteNonQuery();

                    if (txtPassword.Text != txtConfirmPassword.Text)
                    {
                        MessageBox.Show("Contraseña incorrecta");
                    }
                }
                if (cmbPrivacy.Text.Equals("Private"))
                {
                    string user = nombreAleatorio();
                    cConexion cn = new cConexion();
                    SqlCommand cmd = new SqlCommand("insert into  tblUser values(" + id + ",'" + user + "','" + txtEmail.Text + "','" + txtPassword.Text + "','" + txtConfirmPassword.Text + "','" + dtBirthdate.Text + "','" + cmbGender.Text + "')", cn.AbrirConexion());
                    cmd.ExecuteNonQuery();

                    if (txtPassword.Text != txtConfirmPassword.Text)
                    {
                        MessageBox.Show("Contraseña incorrecta");
                    }
                    MessageBox.Show("Your user name is "+user+"please don't forget it");

                }
                Form formulario = new login();
                this.Hide();
                formulario.Show();

            }
            else
            {
                MessageBox.Show("Correo Electronico malo vuelve a intentarlo");
            }

            



        }

        private void cmbPrivacy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbPrivacy.Text.Equals("Private"))
            {
                txtUserName.Visible = false;
                cmbGender.Visible = false;
                dtBirthdate.Visible = false;
                panel1.Visible = false;
                label1.Visible = false;
                label2.Visible = false;




            }
            if (cmbPrivacy.Text.Equals("Public"))
            {
                txtUserName.Visible = true;
                cmbGender.Visible = true;
                dtBirthdate.Visible = true;
                panel1.Visible = true;
                label1.Visible = true;
                label2.Visible = true;

            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void pbMostrar_Click(object sender, EventArgs e)
        {
            pbOcultar.BringToFront();        
            txtPassword.UseSystemPasswordChar = false;
        }

        private void pbOcultar_Click(object sender, EventArgs e)
        {
            pbMostrar.BringToFront();
            txtPassword.UseSystemPasswordChar = true;
        }

        private void pbMostrar1_Click(object sender, EventArgs e)
        {
            pbOcultar1.BringToFront();         
            txtConfirmPassword.UseSystemPasswordChar = false;
        }

        private void pbOcultar1_Click(object sender, EventArgs e)
        {
            
            pbMostrar1.BringToFront();
            txtConfirmPassword.UseSystemPasswordChar = true;
        }
        static bool ValidarCorreoElectronico(string correo)
        {
            // Expresión regular para validar el correo y que pertenezca a Gmail
            string patron = @"^\w+@gmail\.com$";

            // Aplicar la expresión regular
            return Regex.IsMatch(correo, patron);
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            
           cConexion cn = new cConexion();
            SqlCommand cmd = new SqlCommand("select email from tblUser where email ='" + txtEmail.Text + "'", cn.AbrirConexion());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);   
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if(dt.Rows.Count >= 1)
            {
                MessageBox.Show("Este email existe actualmente");
                Form formulario = new Form1();
                this.Hide();
                formulario.Show();

            }

        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            cConexion cn = new cConexion();
            SqlCommand cmd = new SqlCommand("select userName from tblUser where userName ='" + txtUserName.Text + "'", cn.AbrirConexion());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                MessageBox.Show("Este Nombre de usuario existe actualmente");
                Form formulario = new Form1();
                this.Hide();
                formulario.Show();

            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged_1(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void txtConfirmPassword_TextChanged_1(object sender, EventArgs e)
        {
            txtConfirmPassword.UseSystemPasswordChar = true;
        }
    }
}
