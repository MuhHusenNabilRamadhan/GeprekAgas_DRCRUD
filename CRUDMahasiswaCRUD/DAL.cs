using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDMahasiswaCRUD
{
    class DAL
    {
        static string connectionString = "Data Source=DESKTOP-0FQM93C\\HUSENNABIL; Initial Catalog=DBAkademiADO;Integrated Security=True";
        public string GetConnectionString()
        {
            return connectionString;
        }

        SqlConnection conn = new SqlConnection(connectionString);

        SqlDataAdapter da;
        DataTable dtMahasiswa;
        DataTable dtProdi;


    }
}
