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

         public List<int> FamiliaId = new List<int>();
        public List<String> FamiliaNombre = new List<String>();
        List<char> FamiliaTipo = new List<char>();

        public List<int> FamiliaPadreId = new List<int>();
        List<int> IvaId = new List<int>();
        List<int> Espadre = new List<int>();
        List<int> TieneArticulos = new List<int>();

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
            //NodosIniciales(trlFamilia);
            llenarlistas();
        }

        private void trlFamilia_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            VNombreFamilia = string.Empty;
            VNombreFamilia = e.Node.GetValue(TrFamilia).ToString();
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
                if (consul.Exito)
                {
                    if (consul.Datos.Rows.Count > 0)
                    {
                        IdFamilia = Convert.ToInt32(consul.Datos.Rows[0][0].ToString());
                        Boolean FamiliaValida = Convert.ToBoolean(consul.Datos.Rows[0][5].ToString());
                        this.Close();
                    }
                }
            }
        }

        private void llenarlistas()
        {
            CLS_Familias consul = new CLS_Familias();
            consul.ListarFamiliasGeneral();
            if (consul.Exito)
            {
                if (consul.Datos.Rows.Count > 0)
                {
                    for (int i = 0; i < consul.Datos.Rows.Count; i++)
                    {
                        FamiliaId.Add(Convert.ToInt32(consul.Datos.Rows[i][0].ToString()));
                        FamiliaNombre.Add(consul.Datos.Rows[i][1].ToString());
                        FamiliaTipo.Add(Convert.ToChar(consul.Datos.Rows[i][2].ToString()));

                        FamiliaPadreId.Add(Convert.ToInt32(consul.Datos.Rows[i][3].ToString()));
                        IvaId.Add(Convert.ToInt32(consul.Datos.Rows[i][4].ToString()));
                        Espadre.Add(Convert.ToInt32(consul.Datos.Rows[i][5]));
                        TieneArticulos.Add(Convert.ToInt32(consul.Datos.Rows[i][6]));
                    }
                    agregarprincipales(trlFamilia);
                }
            }
        }

        private void agregarprincipales(TreeList tl)
        {
            for (int x = 0; x < FamiliaId.Count; x++)
            {
                if (FamiliaPadreId[x] == 0)
                {
                    try
                    {
                        tl.BeginUnboundLoad();
                        // Create a root node .
                        TreeListNode parentForRootNodes = null;
                        TreeListNode rootNode = tl.AppendNode(new object[] { FamiliaNombre[x].ToString().Trim() }, parentForRootNodes);
                        AgregarHijos(rootNode, tl, Convert.ToInt32(FamiliaId[x].ToString()));

                        tl.EndUnboundLoad();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show("Error Descripcion" + Ex.Message);
                    }
                }
   
            }
        }

        private void AgregarHijos(TreeListNode Padre, TreeList tl, int ID)
        {
            
                for (int x = 0; x < FamiliaId.Count; x++)
                {
                    if (FamiliaPadreId[x] == ID)
                    {
                        TreeListNode Hijo = null;
                        Hijo = tl.AppendNode(new object[] { FamiliaNombre[x].ToString().Trim() }, Padre);
                        AgregarHijos(Hijo, tl, Convert.ToInt32(FamiliaId[x].ToString()));
                    }
                    

                }
            
        }


    }
}