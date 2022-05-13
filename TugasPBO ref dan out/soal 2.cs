using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace TugasPBO_ref_dan_out
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static NpgsqlConnection koneksi()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=Bagus383`;database=kasir;");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool info = false;
            NpgsqlConnection con = koneksi();

            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select * from akun", con);
            cmd.ExecuteNonQuery();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmd.Dispose();
            con.Close();
            if (dt.Rows.Count > 1)
            {
                change_informasi(ref info);
                label1.Text = info.ToString();
                get_data();
            }
            else
            {
                label1.Text = info.ToString();
            }


        }
        private static void change_informasi(ref bool info)
        {
            info = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CRUD cRUD = new CRUD();
            cRUD.Show();
            this.Hide();
        }
        private void get_data()
        {
            NpgsqlConnection con = koneksi();
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select * from pegawai", con);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
