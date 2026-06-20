using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRUDMahasiswaCRUD
{
    public partial class Form3 : Form
    {
        static string connectionString = "Data Source=DESKTOP-0FQM93C\\HUSENNABIL; Initial Catalog=DBAkademiADO;Integrated Security=True";

        SqlConnection conn = new SqlConnection(connectionString);
        SqlDataAdapter da;
        DataTable dtMahasiswa;

        string NamaProdi { get; set; }
        DateTime TanggalDaftar { get; set; }

        public Form3(string Prodi, DateTime TglMasuk)
        {
            InitializeComponent();

            this.NamaProdi = Prodi;
            this.TanggalDaftar = TglMasuk;

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("sp_Report", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@inProdi", SqlDbType.VarChar, 50).Value = NamaProdi;

                // PERBAIKAN: Tambahkan .ToString() agar sesuai tipe VarChar
                cmd.Parameters.Add("@inTglMsuk", SqlDbType.VarChar, 4).Value = TanggalDaftar.Year.ToString();

                da = new SqlDataAdapter(cmd);
                dtMahasiswa = new DataTable();
                da.Fill(dtMahasiswa);

                // PERBAIKAN: Tutup koneksi secara aman
                conn.Close();

                DaftarMahasiswa rpt = new DaftarMahasiswa();
                rpt.SetDataSource(dtMahasiswa);
                crystalReportViewer1.ReportSource = rpt;

                // PERBAIKAN: Tambahkan refresh agar report tampil dengan sempurna
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}