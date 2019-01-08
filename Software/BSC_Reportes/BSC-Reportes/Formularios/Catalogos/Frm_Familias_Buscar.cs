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
using DevExpress.XtraTreeList;
using CapaDeDatos;
using DevExpress.XtraTreeList.Nodes;

namespace BSC_Reportes
{
    public partial class Frm_BFamilias : DevExpress.XtraEditors.XtraForm
    {
        private bool vTieneHijos;
        public int IdFamilia { get; set; }
        public string VNombreFamilia { get; set; }
        public Frm_BFamilias()
        {
            InitializeComponent();
        }
        
        private void NodosIniciales(TreeList tl)
        {
            CLS_Familias Nuevas = new CLS_Familias();
            Nuevas.ListarFamiliasIniciales();
            if (Nuevas.Exito)
            {
                for (int x = 0; x <Nuevas.Datos.Rows.Count; x++)
                {
                    try
                    {
                        tl.BeginUnboundLoad();
                        // Create a root node .
                        TreeListNode parentForRootNodes = null;
                        TreeListNode rootNode = tl.AppendNode(new object[] { Nuevas.Datos.Rows[x][1].ToString().Trim() }, parentForRootNodes);
                        NodosHijos(rootNode, tl, Convert.ToInt32(Nuevas.Datos.Rows[x][0].ToString()));
                        
                        tl.EndUnboundLoad();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show("Error Descripcion" + Ex.Message);
                    }
                }
            }
        }

        private void NodosHijos(TreeListNode Padre,TreeList tl, int ID)
        {
            CLS_Familias Nuevas = new CLS_Familias();
            Nuevas.FamiliaId = ID;
            Nuevas.ListarFamiliasHijos();
            if (Nuevas.Exito)
            {
                for (int x = 0; x < Nuevas.Datos.Rows.Count; x++)
                {
                    TreeListNode Hijo = null;
                    Hijo = tl.AppendNode(new object[] { Nuevas.Datos.Rows[x][1].ToString().Trim() }, Padre);
                    NodosHijos(Hijo, tl, Convert.ToInt32(Nuevas.Datos.Rows[x][0].ToString()));
                    
                }
            }
        }
        private void CreateColumns(TreeList tl)
        {
            //// Create three columns.
            tl.BeginUpdate();
            tl.Columns.Add();
            tl.Columns[0].VisibleIndex = 0;
            tl.Columns[0].Caption = "Nombre Familia";
            tl.EndUpdate();
        }
        private void Frm_BFamilias_Load(object sender, EventArgs e)
        {
            //CreateColumns(trlFamilia);
            NodosIniciales(trlFamilia);
        }

        private void trlFamilia_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            VNombreFamilia = string.Empty;
            vTieneHijos= e.Node.HasChildren;
            if(!vTieneHijos)
            {
                VNombreFamilia = e.Node.GetValue(TrFamilia).ToString();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (VNombreFamilia != string.Empty)
            {
                IdFamilia = 0;
                CLS_Familias consul = new CLS_Familias();
                consul.FamiliaNombre = VNombreFamilia;
                consul.ListarFamiliaNombre();
                if(consul.Exito)
                {
                    if (consul.Datos.Rows.Count > 0)
                    {
                        IdFamilia =Convert.ToInt32(consul.Datos.Rows[0][0].ToString());
                        Boolean FamiliaValida = Convert.ToBoolean(consul.Datos.Rows[0][5].ToString());
                        if (FamiliaValida == false)
                        {
                            this.Close();
                        }
                    }
                }
            }
        }

        
    }
}