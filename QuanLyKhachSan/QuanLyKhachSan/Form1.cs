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

namespace QuanLyKhachSan
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True ";
            con.ConnectionString = connectionString;
            con.Open();
            loadDataGridView();
        }

        private void loadDataGridView()
        {
            string sql = "Select * from tbIPhong";
            SqlDataAdapter adp = new SqlDataAdapter(sql,con);
            DataTable tabletbIPhong = new DataTable();
            adp.Fill(tabletbIPhong);
            DataGridView_tbIPhong.DataSource = tabletbIPhong;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)// NUT HUY
        {
            btnThem.Enabled = false;
            btnHuy.Enabled = true;
            txtMaphong.Text = "";
            txtTenphong.Text = "";
            txtDongia.Text = "";
        }

        private void DataGridView_tbIPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDongia.Text = DataGridView_tbIPhong.CurrentRow.Cells["DonGia"].Value.ToString();
            txtMaphong.Text = DataGridView_tbIPhong.CurrentRow.Cells["Maphong"].Value.ToString();
            txtTenphong.Text = DataGridView_tbIPhong.CurrentRow.Cells["Tenphong"].Value.ToString();
            txtMaphong.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaphong.Text = "";
            txtTenphong.Text = "";
            txtDongia.Text = "";
            txtMaphong.Enabled = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtMaphong.Text=="")
            {
                MessageBox.Show("Ban can nhap Ma Phong");
                txtMaphong.Focus();
                return;
            }
            if (txtTenphong.Text == "")
            {
                MessageBox.Show("Ban can nhap Ten Phong");
                txtTenphong.Focus();
                return;
            }
            else
            {
                string sql = "insert into tbIPhong Values('" + txtMaphong.Text + "','" + txtTenphong.Text + "'";
                if (txtDongia.Text != "")
                    sql = sql + "," + txtDongia.Text.Trim();
                sql = sql + ")";
               
                SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                loadDataGridView();
            }


        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = @" UPDATE tbIPhong SET
                        Maphong=N'" + txtMaphong.Text + @"',Tenphong =N'" + txtTenphong.Text + @"',Dongia =N'" + txtDongia.Text + @"'
                     Where (Maphong=N'" + txtMaphong.Text + @"')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            loadDataGridView();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "Detete From tbIPhong Where Maphong = '" + txtMaphong.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            loadDataGridView();
        }

        private void txtDongia_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(Char.IsDigit(ch)&&ch!=8)
            {
                e.Handled = true;
                MessageBox.Show("Sai dinh dang. Chi Nhap Dang so");
            }
        }
    }
}
