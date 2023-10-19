using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Remoting.Contexts;

namespace The_social_network_camilo_jefernne_eimy.Clases
{
    internal class cConexion
    {
        static private string CadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\eimyg\OneDrive\Documentos\dbVGSocial.mdf;Integrated Security = True; Connect Timeout = 30";


        //Definir una variable para cargar la base de datos
        private SqlConnection Conexion = new SqlConnection(CadenaConexion);

        //metodo para abrir la base de datos
        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }
        //metodo para cerrar la base de datos
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }


    }
}
