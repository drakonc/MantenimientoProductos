using System;
using CapaNegocio;
using CapaEntidades;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmMarca : Form
    {
        private string IdMarca;
        private bool Editarse = false;
        E_Marca objEntidad = new E_Marca();
        N_Marca objNegocio = new N_Marca();
        BindingSource navTabla = new BindingSource();

        public FrmMarca()
        {
            InitializeComponent();
        }

        private void FrmMarca_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
            accionesTabla();
        }
        private void cerrarFormulario_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            navTabla.MoveFirst();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            navTabla.MoveLast();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            navTabla.MoveNext();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            navTabla.MovePrevious();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarBuscarTabla(txtBuscar.Text);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCaja();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            LlenarCaja();
        }

        private void tablaMarca_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LlenarCaja();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editarse == false)
            {
                try
                {
                    objEntidad.NombreMarca = txtNombre.Text.ToUpper();
                    objEntidad.DescripcionMarca = txtDescripcion.Text.ToUpper();
                    objNegocio.InsertarMarca(objEntidad);
                    MessageBox.Show("Se Guardo el Registro");
                    mostrarBuscarTabla("");
                    LimpiarCaja();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No Se Pudo Guardar el Mensaje" + ex.Message);
                }
            }
            if(Editarse == true)
            {
                try
                {
                    objEntidad.IdMarca = Convert.ToInt32(IdMarca);
                    objEntidad.NombreMarca = txtNombre.Text.ToUpper();
                    objEntidad.DescripcionMarca = txtDescripcion.Text.ToUpper();
                    objNegocio.EditarMarca(objEntidad);
                    MessageBox.Show("Se Actualizo el Registro");
                    mostrarBuscarTabla("");
                    LimpiarCaja();
                    Editarse = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No Se Pudo Guardar el Mensaje" + ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(tablaMarca.SelectedRows.Count > 0)
            {
                objEntidad.IdMarca = Convert.ToInt32(tablaMarca.CurrentRow.Cells[0].Value.ToString());
                DialogResult eliminar = MessageBox.Show("Esta seguro que desea eliminar la Marca", "Eliminar", MessageBoxButtons.YesNo);
                if (eliminar == DialogResult.Yes)
                {
                    objNegocio.EliminarMarca(objEntidad);
                    mostrarBuscarTabla("");
                }
            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea eliminar ");
            }
        }

        public void mostrarBuscarTabla(string buscar)
        {
            navTabla.DataSource = objNegocio.ListarMarcas(buscar);
            tablaMarca.DataSource = navTabla;
        }

        public void accionesTabla()
        {
            tablaMarca.Columns[0].Visible = false;
            tablaMarca.Columns[1].Width = 65;
            tablaMarca.Columns[2].Width = 170;
            tablaMarca.ClearSelection();
        }

        public void LimpiarCaja()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtNombre.Focus();
            Editarse = false;
        }

        public void LlenarCaja()
        {
            if(tablaMarca.SelectedRows.Count > 0)
            {
                IdMarca = tablaMarca.CurrentRow.Cells[0].Value.ToString();
                txtCodigo.Text = tablaMarca.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = tablaMarca.CurrentRow.Cells[2].Value.ToString();
                txtDescripcion.Text = tablaMarca.CurrentRow.Cells[3].Value.ToString();
                Editarse = true;
            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar");
            }
        }
    }
}
