using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArchivosVisuales
{

    struct Persona
    {
        public string name { get; set; }
        public int age { get; set; }
        public int grade { get; set; }
        public char gender { get; set; }
    }

    public partial class Form1 : Form
    {
        List<Persona> lista = new List<Persona>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {



            Persona persona = new Persona();
            persona.name = tbNombre.Text;
            persona.age = int.Parse(tbEdad.Text);
            persona.grade = int.Parse(tbNota.Text);
            if (cmbGender.SelectedIndex == 0)
                persona.gender = 'M';
            else
            {
                persona.gender = 'F';
            }
            //persona.gender = char.Parse(cmbGender.SelectedText.ToString());
            lista.Add(persona);
            mostrar();

        }

        public void mostrar()
        {
            dgvRegistros.DataSource = null;
            dgvRegistros.DataSource = lista;
        }

        public void guardar()
        {
            FileStream mArchivoEscritor = new FileStream("datos.dat", FileMode.OpenOrCreate, FileAccess.Write);
            using (BinaryWriter Escritor = new BinaryWriter(mArchivoEscritor))
            {

                foreach (Persona persona in lista)
                {
                    {
                        Escritor.Write(persona.name.Length);
                        Escritor.Write(persona.name.ToCharArray());
                        Escritor.Write(persona.age);
                        Escritor.Write(persona.grade);
                        Escritor.Write(persona.gender);
                    }

                }
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            /*//listBox1.Items.Clear();

            FileStream mArchivoLector = new FileStream("datos.dat", FileMode.Open, FileAccess.Read);
            using (BinaryReader Lector = new BinaryReader(mArchivoLector))
            {
                while (mArchivoLector.Position != mArchivoLector.Length)
                {
                    int length = Lector.ReadInt32();
                    char[] nombreArray = Lector.ReadChars(length);
                    string nombre = new string(nombreArray);
                    int edad = Lector.ReadInt32();
                    int nota = Lector.ReadInt32();
                    char genero = Lector.ReadChar();


                    //listBox1.Items.Add($"Nombre: {nombre}, Edad: {edad}, Nota: {nota}, Género: {genero}");
                }
            }*/

            guardar();
        }
        private void Mostrar()
        {
            tbNombre.Clear();
            tbEdad.Clear();
            tbNota.Clear();
            //tbGenero.Clear();
        }
    }
}
