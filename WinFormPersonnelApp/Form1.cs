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
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM tblUser WHERE usr=@user AND psw=@pass";
            con = new SqlConnection("server=DESKTOP-G46VU0J; Initial Catalog=tblUser; Integrated Security=True");
            cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("user", user_name.Text);
            cmd.Parameters.AddWithValue("pass", user_password.Text);

            con.Open();

            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                //MessageBox.Show("Tebrikler başarı ile giriş yaptınız");
                Form2 frm2 = new Form2();
                frm2.admin = user_name.Text;
                frm2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ve şifreniz yanlış tekrar deneyiniz...");
            }
        }
    }
}
