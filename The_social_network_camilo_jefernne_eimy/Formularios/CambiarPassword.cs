using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using The_social_network_camilo_jefernne_eimy.Clases;

namespace The_social_network_camilo_jefernne_eimy.Formularios
{
    public partial class CambiarPassword : Form
    {

        public CambiarPassword()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNewPass.Text == txtconfirmPass.Text)
            {
                string email = InicioSecciión.VariablesGlobales.CorreoRecuperacion;
                cConexion cn = new cConexion();
                SqlCommand cmd = new SqlCommand("update tblUser set password ='"+txtNewPass.Text+"' where email='"+email+"'",cn.AbrirConexion());
                cmd.ExecuteNonQuery();
                Form formulario = new login();
                this.Hide();
                formulario.Show();
                string correo = InicioSecciión.VariablesGlobales.CorreoRecuperacion;
                MessageBox.Show(correo);
            }

        }

        private void CambiarPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
