using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_social_network_camilo_jefernne_eimy.Formularios
{
    public partial class recuperarPassword : Form
    {
        public recuperarPassword()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }



 

        private void button1_Click(object sender, EventArgs e)
        {


            
            
            if (txtCode.Text == InicioSecciión.var)
            {
                Form formulario = new CambiarPassword();
                this.Hide();
                formulario.Show();
            }
            else
            {
                MessageBox.Show("Código incorrecto");
            }
        }

        private void recuperarPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
