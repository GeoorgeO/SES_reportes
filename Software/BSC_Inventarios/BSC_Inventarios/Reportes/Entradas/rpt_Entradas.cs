using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace BSC_Inventarios
{
    public partial class rpt_Entradas : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_Entradas(long EntradaId, decimal Sucursal)
        {
            InitializeComponent();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            queryParameter1.Name = "@EntradaMercanciaId";
            queryParameter1.Type = typeof(long);
            queryParameter1.ValueInfo = Convert.ToString(EntradaId);
            queryParameter2.Name = "@SucursalesId";
            queryParameter2.Type = typeof(decimal);
            queryParameter2.ValueInfo = Convert.ToString(Sucursal);
            queryParameter3.Name = "@EntradasMercanciaId";
            queryParameter3.Type = typeof(long);
            queryParameter3.ValueInfo = Convert.ToString(EntradaId);
            queryParameter4.Name = "@SucursalesId";
            queryParameter4.Type = typeof(decimal);
            queryParameter4.ValueInfo = Convert.ToString(Sucursal);
            sqlDataSource1.Queries[0].Parameters.Clear();
            sqlDataSource1.Queries[1].Parameters.Clear();
            sqlDataSource1.Queries[0].Parameters.Add(queryParameter1);
            sqlDataSource1.Queries[0].Parameters.Add(queryParameter2);
            sqlDataSource1.Queries[1].Parameters.Add(queryParameter3);
            sqlDataSource1.Queries[1].Parameters.Add(queryParameter4);
        }
    }
}
