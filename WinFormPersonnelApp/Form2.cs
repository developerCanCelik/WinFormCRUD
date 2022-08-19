using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormPersonnelApp
{
    public partial class Form2 : Form
    {
        public string admin;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lbl_admin.Text = "HOŞGELDİNİZ "+ admin.ToUpper();
            GetData();
        }
        void GetData()
        {
            con = new SqlConnection("server=DESKTOP-G46VU0J; Initial Catalog=ogr; Integrated Security=True");
            da = new SqlDataAdapter("Select *From ogrenci", con);

            ds = new DataSet();
            con.Open();
            da.Fill(ds, "ogrenci");

            data_grid_view.DataSource = ds.Tables["ogrenci"];
            con.Close();
        }

        private void add_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into ogrenci(number,name,surname) values (" + txt_usernumber.Text + ",'" + txt_username.Text + "','" + txt_usersurname.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            GetData();

        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (data_grid_view.SelectedRows.Count > 0)
            {
                cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM ogrenci WHERE number=" + data_grid_view.CurrentRow.Cells[0].Value.ToString();
                cmd.ExecuteNonQuery();
                con.Close();
                data_grid_view.Rows.RemoveAt(data_grid_view.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Lüffen silinecek satırı seçin.");
            }
        }
    }
}


