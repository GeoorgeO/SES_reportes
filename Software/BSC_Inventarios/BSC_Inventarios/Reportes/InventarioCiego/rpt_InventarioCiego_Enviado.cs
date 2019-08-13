using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace BSC_Inventarios
{
    public partial class rpt_InventarioCiego_Enviado : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_InventarioCiego_Enviado(long InventarioCiegoFolio)
        {
            InitializeComponent();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            queryParameter1.Name = "@InventarioCiegoFolio";
            queryParameter1.Type = typeof(long);
            queryParameter1.ValueInfo = Convert.ToString(InventarioCiegoFolio);
            queryParameter2.Name = "@InventarioCiegoFolio";
            queryParameter2.Type = typeof(long);
            queryParameter2.ValueInfo = Convert.ToString(InventarioCiegoFolio);
            sqlDataSource1.Queries[0].Parameters.Clear();
            sqlDataSource1.Queries[1].Parameters.Clear();
            sqlDataSource1.Queries[0].Parameters.Add(queryParameter1);
            sqlDataSource1.Queries[1].Parameters.Add(queryParameter2);
        }
    }
}
