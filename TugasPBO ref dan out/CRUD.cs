using Npgsql;
using System.Data;
using System;
using System.Windows.Forms;

namespace TugasPBO_ref_dan_out
{
    public partial class CRUD : Form
    {
        public CRUD()
        {
            InitializeComponent();
            get_data();
        }
        private static NpgsqlConnection koneksi()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=Bagus383`;database=kasir;");
        }
        private static void change_info(ref bool info)
        {
            info = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool info = false;
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("insert into pegawai (id_pegawai,nama,no_telepon) values ('" + id.Text + "', '" + nama.Text + "', '" + nomor.Text + "')", con);
                int n = cmd.ExecuteNonQuery();
                get_data();
                if (n == 1)
                {
                    change_info(ref info);
                    label1.Text = info.ToString();
                }
            }
            catch (Exception)
            {
                label1.Text = info.ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool info = false;
            try
            {
                NpgsqlConnection con = koneksi();

                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("update pegawai set nama='" + nama.Text + "',no_telepon='" + nomor.Text + "' where id_pegawai = '" + id.Text + "' ", con);
                int n = cmd.ExecuteNonQuery();
                get_data();
                if (n == 1)
                {
                    change_info(ref info);
                    label1.Text = info.ToString();
                }
            }
            catch (Exception)
            {
                label1.Text = info.ToString();
            }


        }
        private void get_data ()
        {
            NpgsqlConnection con = koneksi();
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select * from pegawai", con);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable(); 
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool info = false;
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("delete from pegawai where id_pegawai = '" + id.Text + "' ", con);
                int n = cmd.ExecuteNonQuery();
                get_data ();
                if (n == 1)
                {
                    change_info(ref info);
                    label1.Text = info.ToString();
                }
            }
            catch (Exception)
            {
                    label1.Text = info.ToString();
            }

        }
    }
}
