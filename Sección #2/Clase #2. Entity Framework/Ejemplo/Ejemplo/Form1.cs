using Ejemplo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplo
{
    public partial class Form1 : Form
    {

        private Alumno model = new Alumno();
     
        public Form1()
        {
            InitializeComponent();

            gvAlumnos.AutoGenerateColumns = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarAlumnos();
        }

        public void CargarAlumnos() 
        {
            gvAlumnos.DataSource = model.Listar();
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            new Form2(0, this).ShowDialog();
        }

        private void gvAlumnos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            new Form2(Convert.ToInt32(gvAlumnos.Rows[e.RowIndex].Cells[0].Value), this).ShowDialog();
        }
    }
}
