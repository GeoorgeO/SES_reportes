using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Configuration;
using BSC_Reportes.Properties;

namespace BSC_Reportes
{
    public partial class rpt_Pedidos : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_Pedidos(int PedidosId)
        {
            InitializeComponent();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            queryParameter1.Name = "@PedidosId";
            queryParameter1.Type = typeof(int);
            queryParameter1.ValueInfo =Convert.ToString(PedidosId);
            sqlDataSource1.Queries[0].Parameters.Clear();
            sqlDataSource1.Queries[1].Parameters.Clear();
            sqlDataSource1.Queries[0].Parameters.Add(queryParameter1);
            sqlDataSource1.Queries[1].Parameters.Add(queryParameter1);
        }
    }
}
