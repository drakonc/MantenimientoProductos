using System;
using CapaNegocio;
using System.Windows.Forms;
using CapaEntidades;

namespace CapaPresentacion
{
    public partial class FrmCategoria : Form
    {
        private string IdCategoria;
        private bool Editarse = false;
        E_Categoria objEntidad = new E_Categoria();
        N_Categoria objNegocio = new N_Categoria();
        BindingSource navTabla = new BindingSource();

        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
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
            LimpiarCajas();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            LlenarCajas();
        }

        private void tablaCategoria_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LlenarCajas();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(Editarse == false)
            {
                try
                {
                    objEntidad.NombreCategoria = txtNombre.Text.ToUpper();
                    objEntidad.DescripcionCategoria = txtDescripcion.Text.ToUpper();
                    objNegocio.InsertarCategoria(objEntidad);
                    MessageBox.Show("Se Guardo el Registro");
                    mostrarBuscarTabla("");
                    LimpiarCajas();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("No Se Pudo Guardar el Mensaje" + ex.Message);
                }
            }
            if(Editarse == true)
            {
                try
                {
                    objEntidad.IdCategoria = Convert.ToInt32(IdCategoria);
                    objEntidad.NombreCategoria = txtNombre.Text.ToUpper();
                    objEntidad.DescripcionCategoria = txtDescripcion.Text.ToUpper();
                    objNegocio.EditarCategoria(objEntidad);
                    MessageBox.Show("Se Guardo el Registro");
                    mostrarBuscarTabla("");
                    LimpiarCajas();
                    Editarse = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No Se Pudo Editar el Mensaje" + ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tablaCategoria.SelectedRows.Count > 0)
            {
                objEntidad.IdCategoria = Convert.ToInt32(tablaCategoria.CurrentRow.Cells[0].Value.ToString());
                DialogResult eliminar = MessageBox.Show("Esta seguro que desea eliminar la Categoria", "Eliminar", MessageBoxButtons.YesNo);
                if(eliminar == DialogResult.Yes)
                {
                    objNegocio.EliminarCategoria(objEntidad);
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
            navTabla.DataSource = objNegocio.ListarCategorias(buscar);
            tablaCategoria.DataSource = navTabla;
        }

        public void accionesTabla()
        {
            tablaCategoria.Columns[0].Visible = false;
            tablaCategoria.Columns[1].Width = 65;
            tablaCategoria.Columns[2].Width = 170;
            tablaCategoria.ClearSelection();
        }

        public void LimpiarCajas()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtNombre.Focus();
            Editarse = false;
        }

        public void LlenarCajas()
        {
            if (tablaCategoria.SelectedRows.Count > 0)
            {
                IdCategoria = tablaCategoria.CurrentRow.Cells[0].Value.ToString();
                txtCodigo.Text = tablaCategoria.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = tablaCategoria.CurrentRow.Cells[2].Value.ToString();
                txtDescripcion.Text = tablaCategoria.CurrentRow.Cells[3].Value.ToString();
                Editarse = true;
            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar ");
            }
        }

    }
}
