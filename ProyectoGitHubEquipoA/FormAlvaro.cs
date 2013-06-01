using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.Types;
using MySql.Data.MySqlClient;

namespace ProyectoGitHubEquipoA
{

    /*
     * ===========================================================
     * =========== FORMULARIO DE ASIGNATURAS DE 1 DAM ============
     * ================ HECHO POR ÁLVARO CUEVAS ==================
     * 
     * Dicho formulario de la aplicación trata de mostrar toda la
     * información relevante sobre las asignaturas dadas durante el
     * año completo asícomo profesores que las impartieron y demás
     * detalles teniendo en cuenta cada tipo de asignatura y las horas
     * semanales dedicadas a cada una.
     * 
     * ============================================================
     */

    public partial class FormAlvaro : Form
    {

        String cadenaConexion; //almacena ip del servidor sql, usuario y pw
        MySqlConnection conexion; //conector que lleva a cabo la conex a la BBDD
        MySqlCommand comando; //comando que lleva a cabo la query
        String sentenciaSQL; //consulta
        MySqlDataReader resultado; //lee la query y la ejecuta

        public FormAlvaro()
        {
            InitializeComponent();
            try
            {
                cadenaConexion = "Server = localhost; Database = test; Uid = root; Pwd = root; Port = 3306";
                conexion = new MySqlConnection(cadenaConexion);
                conexion.Open();
            }
            catch (Exception)
            {
                throw;
            }

            sentenciaSQL = "SELECT * FROM test.asignaturas";
            comando = new MySqlCommand(sentenciaSQL, conexion);
            resultado = comando.ExecuteReader();
            while (resultado.Read())
            {
                listBox5.Items.Add(resultado.GetString("id_profesor"));
                listBox1.Items.Add(resultado.GetString("nombre"));
                listBox2.Items.Add(resultado.GetString("apellido"));
                listBox3.Items.Add(resultado.GetString("asignatura"));
                listBox4.Items.Add(resultado.GetString("horas_semanales"));
            }

            conexion.Close();
        }

        //MUESTRA INFORMACION COMPLETA DE LA BBDD ASIGNATURAS EN CADA COMBOBOX
        private void button1_Click(object sender, EventArgs e)
        {
            conexion.Open();

            sentenciaSQL = "SELECT * FROM test.asignaturas";
            comando = new MySqlCommand(sentenciaSQL, conexion);
            resultado = comando.ExecuteReader();

            listBox1.Visible = true;
            listBox2.Visible = true;
            listBox3.Visible = true;
            listBox4.Visible = true;
            listBox5.Visible = true;

            conexion.Close();

        }

        //PERMITE INSERTAR NUEVA FILA DE DATOS A LA BBDD
        private void button2_Click(object sender, EventArgs e)
        {
            conexion.Open();

            sentenciaSQL = "INSERT INTO test.asignaturas (id_profesor, nombre, apellido, asignatura, horas_semanales) VALUES ('"
                + id_profesor.Text + "','" + nombre.Text + "','" + apellido.Text + "','" + asignatura.Text + "','" + horas_semana.Text + "');";


            comando = new MySqlCommand(sentenciaSQL, conexion);
            comando.ExecuteNonQuery();

            conexion.Close();
            label16.Visible = true;
            label20.Visible = true;

            listBox1.Visible = false;
            listBox2.Visible = false;
            listBox3.Visible = false;
            listBox4.Visible = false;
            listBox5.Visible = false;
        }

        //PERMITE DAR A CONOCER MAS INFORMACION ACERCA DE LAS ASIGNATURAS Y PROFESORES QUE LAS IMPARTEN
        private void button4_Click(object sender, EventArgs e)
        {
            conexion.Open();

            sentenciaSQL = "SELECT asignatura, MAX(horas_semanales) FROM test.asignaturas";
            comando = new MySqlCommand(sentenciaSQL, conexion);
            resultado = comando.ExecuteReader();

            if (resultado.Read())
            {
                label13.Text = resultado.GetString("asignatura") + " con " + resultado.GetString("MAX(horas_semanales)") + " horas por semana";

            }

            conexion.Close();
            conexion.Open();

            sentenciaSQL = "SELECT * FROM test.asignaturas WHERE nombre='Juan'";
            comando = new MySqlCommand(sentenciaSQL, conexion);
            resultado = comando.ExecuteReader();

            if (resultado.Read())
            {
                label14.Text = resultado.GetString("asignatura") + " impartido por " + resultado.GetString("nombre") + " " + resultado.GetString("apellido") + " con " + resultado.GetString("horas_semanales") + " horas dedicadas";

            }

            conexion.Close();
            conexion.Open();

            sentenciaSQL = "SELECT COUNT(asignatura), SUM(horas_semanales) FROM test.asignaturas";
            comando = new MySqlCommand(sentenciaSQL, conexion);
            resultado = comando.ExecuteReader();

            if (resultado.Read())
            {
                label17.Text = "Damos un total de " + resultado.GetString("COUNT(asignatura)") + " asignaturas con un total de " + resultado.GetString("SUM(horas_semanales)") + " horas semanales";

            }

            conexion.Close();
        }

        //ACTUALIZA LOS LISTBOX DE LA BD TRAS UNA PREVIA INSERCION DE DATOS
        private void button6_Click(object sender, EventArgs e)
        {
            conexion.Open();

            sentenciaSQL = "SELECT * FROM test.asignaturas";
            comando = new MySqlCommand(sentenciaSQL, conexion);
            resultado = comando.ExecuteReader();

            listBox1.Visible = true;
            listBox2.Visible = true;
            listBox3.Visible = true;
            listBox4.Visible = true;
            listBox5.Visible = true;

            label16.Visible = false;
            label20.Visible = false;

            conexion.Close();
        } 






    }
}
