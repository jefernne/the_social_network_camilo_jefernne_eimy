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
    public partial class DeleteAccount : Form
    {

        cConexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        int contador, boton, i;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public DeleteAccount()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            cn = new cConexion();
            cmd = new SqlCommand("select * from tblUser", cn.AbrirConexion());
            i = 0;
            boton = 0;
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Eliminar cuenta? esta acción es irreversible ?", "Alerta!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("delete from tblUser where email='" + txtEmail.Text + "'", cn.AbrirConexion());
                cmd.ExecuteNonQuery();
            }
        }
    }
}
