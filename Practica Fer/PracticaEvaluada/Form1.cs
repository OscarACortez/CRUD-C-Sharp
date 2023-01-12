using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PracticaEvaluada
{
    public partial class Form1 : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=VideoJuegos;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string nombrej = txtN.Text;
            string jugador = txtJ.Text;
            string precio = txtP.Text;
            string cantidad = txtC.Text;
            string cadena = "insert into Juegos (Nombre,Jugador,Precio,Cantidad)values ('" + nombrej + "','" + jugador + "'," + precio + "," + cantidad + ")";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("Los Datos se Guardaron correctamente");

            int n = dgvJuegos.Rows.Add();
            dgvJuegos.Rows[n].Cells[0].Value = txtN.Text;
            dgvJuegos.Rows[n].Cells[1].Value = txtJ.Text;
            dgvJuegos.Rows[n].Cells[2].Value = txtP.Text;
            dgvJuegos.Rows[n].Cells[3].Value = txtC.Text;

            txtN.Text = "";
            txtJ.Text = "";
            txtP.Text = "";
            txtC.Text = "";


            conexion.Close();


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string idj = txtB.Text;
            string cadena = "select Nombre,Jugador,Precio,Cantidad from Juegos where IDJ = " + idj;
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                txtN.Text = registro["Nombre"].ToString();
                txtJ.Text = registro["Jugador"].ToString();
                txtP.Text = registro["Precio"].ToString();
                txtC.Text = registro["Cantidad"].ToString();
            }
            else
                MessageBox.Show("Ese Codigo No Existe!!!");
            conexion.Close();


        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string idj = txtB.Text;
            string nombrej = txtN.Text;
            string jugador = txtJ.Text;
            string precio = txtP.Text;
            string cantidad = txtC.Text;
            string cadena = "update Juegos set Nombre='"+nombrej+"',Jugador='"+jugador+"',Precio= "+precio+",Cantidad ="+cantidad+" where IDJ =" + idj;
            SqlCommand comando = new SqlCommand(cadena, conexion);
            int codigo;
            codigo = comando.ExecuteNonQuery();
            if (codigo == 1)
            {
                MessageBox.Show("Se Modificaron Los Datos!!!!");
                txtB.Text = "";
                txtN.Text = "";
                txtJ.Text = "";
                txtP.Text = "";
                txtC.Text = "";

            }
            else
                MessageBox.Show("No Existe Ningun ID con ese Caracter!!");
            conexion.Close();
            btnModificar.Enabled = false;




        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string id = txtB.Text;
            string cadena = "delete from Juegos where IDJ =" + id;
            SqlCommand comando = new SqlCommand(cadena, conexion);
            int ID;
            ID = comando.ExecuteNonQuery();
            if (ID == 1)
            {
                txtN.Text = "";
                txtJ.Text = "";
                txtP.Text = "";
                txtC.Text = "";

                
                MessageBox.Show("Se eliminaron correctamente los Datos!");


            }
            else
                MessageBox.Show("No Existe Ningun ID Con esos Caracteres!");
            conexion.Close();
            btnEliminar.Enabled = false;

        }

        private void dgvJuegos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {

 
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
