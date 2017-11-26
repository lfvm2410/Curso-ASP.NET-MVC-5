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
    public partial class Form2 : Form
    {
        public int id = 0;
        public Form1 form;
        private Alumno model = new Alumno();

        public Form2(int id, Form1 frm1)
        {
            this.id = id;
            this.form = frm1;

            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txtID.Text = this.id.ToString();

            if (this.id > 0)
            {
                btnEliminar.Visible = true;

                var alumno = model.Obtener(this.id);

                txtNombre.Text = alumno.Nombre;
                txtApellido.Text = alumno.Apellido;
                txtFechaNacimiento.Text = alumno.FechaNacimiento;

                if(alumno.Sexo == 1)
                {
                    rbHombre.Checked = true;
                    rbMujer.Checked = false;
                }
                else
                {
                    rbHombre.Checked = false;
                    rbMujer.Checked = true;
                }

            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var alumno = new Alumno
            {
                id = Convert.ToInt32(txtID.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                FechaNacimiento = txtFechaNacimiento.Text,
                Sexo = rbHombre.Checked ? 1 : 0
            };

            model.Guardar(alumno);

            this.form.CargarAlumnos();
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar este registro?", "Confirmar acción", MessageBoxButtons.YesNo) == DialogResult.Yes) 
            {
                model.Eliminar(this.id);

                this.form.CargarAlumnos();
                this.Close();
            }
        }
    }
}
