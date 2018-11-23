using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CapaDeDatos;

namespace BSC_Reportes
{
    public partial class Frm_ConfigEmail : DevExpress.XtraEditors.XtraForm
    {
        int FilaSelect = 0;
        DataTable dt = new DataTable();
        public string UsuariosLogin { get; set; }
        public char UsuarioClase { get; set; }
        public int IdPantallaBotones { get; set; }
        public Frm_ConfigEmail()
        {
            InitializeComponent();
        }
        private static Frm_ConfigEmail m_FormDefInstance;
        public static Frm_ConfigEmail DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_ConfigEmail();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        private void EncabezadoTabla()
        {
            dt.Columns.Add("Correos");
        }
        private bool ValidaCampos()
        {
            bool Valor = false;
            if (txtCorreoRemitente.Text != string.Empty && txtCorreoUser.Text != string.Empty && txtCorreoPass.Text != string.Empty && txtCorreoServerSaliente.Text != string.Empty && txtCorreoServerEntrante.Text != string.Empty && cmbSeguridadSSL.Text != string.Empty && txtCorreoPuerto.Text != string.Empty)
            {
                Valor = true;
            }
            return Valor;
        }
        private void CargarConfigEmail()
        {
            CLS_Correos param = new CLS_Correos();
            param.MtdSeleccionar();
            if (param.Exito)
            {
                if (param.Datos.Rows.Count > 0)
                {
                    txtCorreoRemitente.Text = param.Datos.Rows[0][0].ToString();
                    txtCorreoUser.Text = param.Datos.Rows[0][1].ToString();
                    txtCorreoPass.Text = param.Datos.Rows[0][2].ToString();
                    txtCorreoPuerto.Text = param.Datos.Rows[0][6].ToString();
                    txtCorreoServerSaliente.Text = param.Datos.Rows[0][3].ToString();
                    txtCorreoServerEntrante.Text = param.Datos.Rows[0][4].ToString();
                    if (Convert.ToBoolean(param.Datos.Rows[0][5].ToString()))
                    {
                        cmbSeguridadSSL.SelectedIndex = 0;
                    }
                    else
                    {
                        cmbSeguridadSSL.SelectedIndex = 1;
                    }
                }
            }
        }
        private void CargarCorreosDestino()
        {
            CLS_Correos CargaR = new CLS_Correos();
            CargaR.MtdSeleccionarCorreosDestino();
            if (CargaR.Exito)
            {
                if (CargaR.Datos.Rows.Count > 0)
                {
                    for (int x = 0; x < CargaR.Datos.Rows.Count; x++)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = CargaR.Datos.Rows[x][0].ToString().Trim();
                        dt.Rows.Add(dr);
                    }
                    dtgCorreosDestino.DataSource = dt;
                }
            }
        }

        public void OcultarBotones()
        {
            btnGuardar.Visible = false;
            btnProbar.Visible = false;
            btnAgregar.Visible = false;
        }
        public void MostrarBotones()
        {
            CLS_Pantallas clspantbotones = new CLS_Pantallas();
            clspantbotones.UsuariosLogin = UsuariosLogin;
            clspantbotones.pantallasid = IdPantallaBotones;
            clspantbotones.Mtdselecionarbotonespantalla();
            if (clspantbotones.Exito)
            {
                for (int t = 0; t < clspantbotones.Datos.Rows.Count; t++)
                {
                    switch (clspantbotones.Datos.Rows[t][0].ToString())
                    {
                        case "16":
                            btnGuardar.Visible = true;
                            break;
                        case "17":
                            btnProbar.Visible = true;
                            break;
                        case "18":
                            btnAgregar.Visible = true;
                            break;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show(clspantbotones.Mensaje);
            }
        }
        public void accesosuperusuario()
        {
            btnGuardar.Visible = true;
            btnProbar.Visible = true;
            btnAgregar.Visible = true;
        }
        private void Frm_ConfigEmail_Load(object sender, EventArgs e)
        {
            OcultarBotones();
            if (UsuarioClase == 'S')
            {
                accesosuperusuario();
            }
            else
            {
                MostrarBotones();
            }
            EncabezadoTabla();
            CargarConfigEmail();
            CargarCorreosDestino();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidaCampos())
            {
                CLS_Correos GuardarC = new CLS_Correos();
                GuardarC.CorreoRemitente = txtCorreoRemitente.Text;
                GuardarC.CorreoUsuario = txtCorreoUser.Text;
                GuardarC.CorreoContrasenia = txtCorreoPass.Text;
                GuardarC.CorreoServidorSalida = txtCorreoServerSaliente.Text;
                GuardarC.CorreoServidorEntrada = txtCorreoServerEntrante.Text;
                if (cmbSeguridadSSL.SelectedIndex == 0)
                {
                    GuardarC.CorreoCifradoSSL = 1;
                }
                else
                {
                    GuardarC.CorreoCifradoSSL = 0;
                }
                GuardarC.CorreoPuertoSalida = Convert.ToInt32(txtCorreoPuerto.Text);
                GuardarC.MtdSeleccionar();
                if (GuardarC.Exito)
                {
                    if (GuardarC.Datos.Rows.Count > 0)
                    {
                        GuardarC.MtdModificar();
                    }
                    else
                    {
                        GuardarC.MtdInsertar();
                    }
                    if (GuardarC.Exito)
                    {
                        XtraMessageBox.Show("Se han Guardado los Datos con Exito");
                    }
                    else
                    {
                        XtraMessageBox.Show(GuardarC.Mensaje);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Faltan Datos x llenar");
            }
        }
        private void txtCorreoRemitente_Paint(object sender, PaintEventArgs e)
        {
            if (txtCorreoRemitente.Text == string.Empty)
            {
                RectangleF rec = e.Graphics.ClipBounds;
                rec.Inflate(-1, -1);
                e.Graphics.DrawRectangle(Pens.Red, rec.Left, rec.Top, rec.Width, rec.Height);
            }
        }
        private void txtCorreoUser_Paint(object sender, PaintEventArgs e)
        {
            if (txtCorreoUser.Text == string.Empty)
            {
                RectangleF rec = e.Graphics.ClipBounds;
                rec.Inflate(-1, -1);
                e.Graphics.DrawRectangle(Pens.Red, rec.Left, rec.Top, rec.Width, rec.Height);
            }
        }
        private void txtCorreoPass_Paint(object sender, PaintEventArgs e)
        {
            if (txtCorreoPass.Text == string.Empty)
            {
                RectangleF rec = e.Graphics.ClipBounds;
                rec.Inflate(-1, -1);
                e.Graphics.DrawRectangle(Pens.Red, rec.Left, rec.Top, rec.Width, rec.Height);
            }
        }
        private void txtCorreoServerSaliente_Paint(object sender, PaintEventArgs e)
        {
            if (txtCorreoServerSaliente.Text == string.Empty)
            {
                RectangleF rec = e.Graphics.ClipBounds;
                rec.Inflate(-1, -1);
                e.Graphics.DrawRectangle(Pens.Red, rec.Left, rec.Top, rec.Width, rec.Height);
            }
        }
        private void txtCorreoServerEntrante_Paint(object sender, PaintEventArgs e)
        {
            if (txtCorreoServerEntrante.Text == string.Empty)
            {
                RectangleF rec = e.Graphics.ClipBounds;
                rec.Inflate(-1, -1);
                e.Graphics.DrawRectangle(Pens.Red, rec.Left, rec.Top, rec.Width, rec.Height);
            }
        }
        private void cmbSeguridadSSL_Paint(object sender, PaintEventArgs e)
        {
            if (cmbSeguridadSSL.Text == string.Empty)
            {
                RectangleF rec = e.Graphics.ClipBounds;
                rec.Inflate(-1, -1);
                e.Graphics.DrawRectangle(Pens.Red, rec.Left, rec.Top, rec.Width, rec.Height);
            }
        }
        private void txtCorreoPuerto_Paint(object sender, PaintEventArgs e)
        {
            if (txtCorreoPuerto.Text == string.Empty)
            {
                RectangleF rec = e.Graphics.ClipBounds;
                rec.Inflate(-1, -1);
                e.Graphics.DrawRectangle(Pens.Red, rec.Left, rec.Top, rec.Width, rec.Height);
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CLS_Correos GuardaC = new CLS_Correos();
            GuardaC.CorreoNombre = txtCorreoDestino.Text;
            GuardaC.MtdSeleccionarEspecifica();
            if (GuardaC.Exito)
            {
                if (GuardaC.Datos.Rows.Count == 0)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = txtCorreoDestino.Text;
                    dt.Rows.Add(dr);
                    dtgCorreosDestino.DataSource = dt;
                    GuardaC.MtdEliminar();
                    for (int x = 0; x < dtgValoresCorreosDestino.RowCount; x++)
                    {
                        GuardaC.CorreoNombre = dt.Rows[x][0].ToString(); ;
                        GuardaC.MtdInsertarCorreoDestino();
                    }
                    XtraMessageBox.Show("Se han Guardado los Registros con Exito");
                    txtCorreoDestino.Text = string.Empty;
                }
            }
            else
            {
                XtraMessageBox.Show("Este Correo ya Existe en la Lista");
            }
        }

        private void dtgCorreosDestino_Click(object sender, EventArgs e)
        {
            foreach (int i in dtgValoresCorreosDestino.GetSelectedRows())
            {
                DataRow row = dtgValoresCorreosDestino.GetDataRow(i);
                FilaSelect = i;
            } 
        }

        private void dtgCorreosDestino_DoubleClick(object sender, EventArgs e)
        {
            txtCorreoDestino.Text = dt.Rows[FilaSelect][0].ToString().Trim();
            dt.Rows.RemoveAt(FilaSelect);
            dtgCorreosDestino.DataSource = dt;
            CLS_Correos GuardaC = new CLS_Correos();
            GuardaC.MtdEliminar();
            for (int x = 0; x < dtgValoresCorreosDestino.RowCount; x++)
            {
                GuardaC.CorreoNombre = dt.Rows[x][0].ToString(); ;
                GuardaC.MtdInsertarCorreoDestino();
            }
        }

        private void btnProbar_Click(object sender, EventArgs e)
        {
            if(dtgValoresCorreosDestino.RowCount>0)
            {
                CLS_Email Envio = new CLS_Email();
                Envio.SendMailPrueba();
                XtraMessageBox.Show("Se han enviado el Correo con Exito");
            }
        }
    }
}