using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using DEBSAccesoSQL;
namespace Datos
{
    public class CAD : DEBSAccesoDatos
    {
        public CAD()
        {
            cConex = "Data Source=.;Initial Catalog=AdventureWorksLT2008R2;Trusted_Connection=Yes;";
            conexion = new SqlConnection(cConex);
        }
    }
}
