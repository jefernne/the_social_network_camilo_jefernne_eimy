using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using The_social_network_camilo_jefernne_eimy.Clases;
using static Siticone.Desktop.UI.Native.WinApi;

namespace The_social_network_camilo_jefernne_eimy.Formularios
{
    public partial class principal : Form
    {
        
        public principal()
        {
            InitializeComponent();
            
            this.StartPosition = FormStartPosition.CenterScreen;
            pnlBuscar.Visible = false;
            pnlUserName.Visible = false;
            pnlSettings.Visible = false;    
            pnlState.Visible = false;
            pnlProfile.Visible = false; 
            miBoton=btnNameUser;


        }

        private int contadorMaximo()
        {
            cConexion cn = new cConexion();
            SqlCommand cmd = new SqlCommand("select * from tblPost", cn.AbrirConexion());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            int id = dt.Rows.Count;
            return id;
        }

        public static Button miBoton;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtBuscar.BringToFront();
            pnlBuscar.Visible=false;
          
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
   
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            btnB.Text = null;
            cConexion cn = new cConexion();
            SqlCommand cmd = new SqlCommand("select userName from tblUser where userName ='" + txtBuscar.Text + "'", cn.AbrirConexion());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable DT = new DataTable();
            adapter.Fill(DT);
            if (DT.Rows.Count > 0)
            {
                //txtB.Text = "Contenido de la tabla DT:\n";
                foreach (DataRow row in DT.Rows)
                {
                    btnB.Text += row["userName"].ToString() + "\n";
                }
            }
            else
            {
                MessageBox.Show("No se encintró el usuario");
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            pnlBuscar.Visible=true;
        }

        private void txtB_Leave(object sender, EventArgs e)
        {
          pnlBuscar.Visible = false;
        }

     

        private void btnSelectedPost_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Imagenes|*.jpg; *.png";
            ofdSeleccionar.InitialDirectory=Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionar.Title = "Selected imagen";

            if(ofdSeleccionar.ShowDialog() == DialogResult.OK) 
            {
                pbImagen.Image=Image.FromFile(ofdSeleccionar.FileName);
            }
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int id = contadorMaximo() + 1;
            MemoryStream ms=new MemoryStream();
            pbImagen.Image.Save(ms, ImageFormat.Jpeg);
            byte[] aByte=ms.ToArray();

            cConexion cn = new cConexion();
           

            try
            {
                SqlCommand cmd = new SqlCommand("insert into  tblPost values(" + id + ",'" + btnNameUser.Text + "',@imagen)", cn.AbrirConexion());
                cmd.Parameters.AddWithValue("imagen", aByte);
               cmd.ExecuteNonQuery();
                MessageBox.Show("Imagen guardada");
                pbImagen.Image = null;

        }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

}

        private void principal_Load(object sender, EventArgs e)
        {

        }
        private bool panelVisible = true;

        private void btnNameUser_Click(object sender, EventArgs e)
        {
            pnlUserName.BringToFront();
            panelVisible = !panelVisible;
            pnlUserName.Visible = panelVisible;


        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form formulario = new login();
            this.Hide();
            formulario.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnlProfile.BringToFront();
            pnlProfile.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pnlSettings.BringToFront();
            pnlSettings.Visible = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            pnlState.BringToFront();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form formulario = new principal();
            this.Hide();
            formulario.Show();
           
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form formulario = new DeleteAccount();
            this.Hide();
            formulario.Show();
        }
        
        private void txtBuscarPost_TextChanged(object sender, EventArgs e)
        {


            int id = 0;
            
            id = int.Parse(txtBuscarPost.Text);

            string sql = "SELECT nameUser, post FROM tblPost WHERE idPost = " + id; // Nota: No es necesario rodear el ID con comillas
            cConexion cn = new cConexion();
            cn.AbrirConexion();

            try
            {
                SqlCommand cmd = new SqlCommand(sql, cn.AbrirConexion());
                SqlDataReader reader = cmd.ExecuteReader(); // Cambiado "MysqlDataReader" a "SqlDataReader"

                if (reader.HasRows)
                {
                    reader.Read();
                    MemoryStream ms = new MemoryStream((byte[])reader["post"]);
                    Bitmap bm = new Bitmap(ms);
                    pbImagen.Image = bm;
                    txtDueno.Text = reader["nameUser"].ToString();
                    // Puedes agregar el código para mostrar "post" si es necesario
                }
                else
                {
                    MessageBox.Show("No se encontraron post");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
               
                cn.CerrarConexion(); // Asegúrate de cerrar la conexión cuando hayas terminado
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pnlSettings.Visible = false;
            pnlSettings.SendToBack();
            pnlUserName.BringToFront();
        }
    }   


    }

