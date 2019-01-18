using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;

namespace BSC_Reportes
{
    public partial class rpt_SucursalSurtir : DevExpress.XtraReports.UI.XtraReport
    {
        internal PdfExportOptions pdfOptions;

        public rpt_SucursalSurtir(int PedidosId, int Sucursal)
        {
            InitializeComponent();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            queryParameter1.Name = "@PedidosId";
            queryParameter1.Type = typeof(int);
            queryParameter1.ValueInfo = Convert.ToString(PedidosId);
            queryParameter2.Name = "@Sucursal";
            queryParameter2.Type = typeof(int);
            queryParameter2.ValueInfo = Convert.ToString(Sucursal);
            sqlDataSource1.Queries[0].Parameters.Clear();
            sqlDataSource1.Queries[0].Parameters.Add(queryParameter1);
            sqlDataSource1.Queries[0].Parameters.Add(queryParameter2);
        }

    }
}
