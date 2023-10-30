using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using The_social_network_camilo_jefernne_eimy.Clases;

namespace The_social_network_camilo_jefernne_eimy.Formularios
{
    
    public partial class InicioSecciión : Form
    {
        public static class VariablesGlobales
        {
            public static string CorreoRecuperacion { get; set; }
        }


        public InicioSecciión()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            

        }
    

        


        public static String generarCodigo()
        {
            Random random = new Random();
            int codigoAleatorio = random.Next(1000, 10000);
            string codigoAleatorioString = codigoAleatorio.ToString();
            return codigoAleatorioString;
        }

         public static String var=generarCodigo();
        private void button1_Click(object sender, EventArgs e)
        {
           cConexion cn = new cConexion();
            SqlCommand cmd = new SqlCommand("Select email from tblUser where email ='" + txtEmail.Text + "'", cn.AbrirConexion());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable DT = new DataTable();
            adapter.Fill(DT);
            string consultaSQL = cmd.CommandText;
            

            if (DT.Rows.Count > 0)
            {
                try
                {
                    using (MailMessage mailMessage = new MailMessage())
                    {
                        mailMessage.To.Add(txtEmail.Text);
                        mailMessage.Subject = "Código de recuperación de cuenta";
                        mailMessage.Body = "<h1>su código es " + var + "</h1>";
                        mailMessage.IsBodyHtml = true;

                        mailMessage.From = new MailAddress("vgsocial2023@gmail.com", "VGSocial");

                        using (SmtpClient cliente = new SmtpClient())
                        {
                            cliente.UseDefaultCredentials = false;
                            cliente.Credentials = new NetworkCredential("vgsocial2023@gmail.com", "wkik locs szch okmq");
                            cliente.Port = 587;
                            cliente.EnableSsl = true;

                            cliente.Host = "smtp.gmail.com";
                            cliente.Send(mailMessage);

                        }
                        VariablesGlobales.CorreoRecuperacion = txtEmail.Text;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al enviar el correo: " + ex.Message);
                    throw;
                }
                Form formulario = new recuperarPassword();
                this.Hide();
                formulario.Show();
            }
            else
            {
                MessageBox.Show("Imposible este correo no es correcto");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form formulario = new login();
            this.Hide();
            formulario.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InicioSecciión_Load(object sender, EventArgs e)
        {

        }
    }
}
