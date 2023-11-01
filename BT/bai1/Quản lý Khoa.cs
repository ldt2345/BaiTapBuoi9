using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace bai1
{
    public partial class Quản_lý_Khoa : Form
    {

        function fn = new function();
        SqlConnection sqlconn;
        public Quản_lý_Khoa()
        {
            sqlconn = fn.conn;
            InitializeComponent();
        }

        private void btnThemKhoa_Click(object sender, EventArgs e)
        {
            try
            {
                if(KT_MaKhoa(txtMakhoa.Text) == true)
                {
                    sqlconn.Open();
                    string insertString = "insert into Khoa values('" + txtMakhoa.Text + "',N'" + txtTenKhoa.Text + "')";
                    SqlCommand cmd = new SqlCommand(insertString, sqlconn);
                    cmd.ExecuteNonQuery();
                    sqlconn.Close();
                    MessageBox.Show("Thanh cong");
                }
                else 
                {
                    MessageBox.Show("Trung ma khoa");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("That bai");
            }
        }
        bool KT_MaKhoa(string ma)
        {
            try
            {
                sqlconn.Open();
                string selectString = "select count(*) from Khoa where MaKhoa = '" + ma + "'";
                SqlCommand cmd = new SqlCommand(selectString, sqlconn);
                int count = (int)cmd.ExecuteScalar();
                sqlconn.Close();
                if (count >= 1)
                    return false;
                return true;
            }
            catch (Exception ex) { return false; }
        }

        private void btnxem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }

        private void btnXoaKhoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlconn.State == ConnectionState.Closed)
                {
                    sqlconn.Open();
                    
                }
                string deleteString = "delete Khoa where MaKhoa = '" + txtMakhoa.Text + "'";
                SqlCommand cmd = new SqlCommand(deleteString, sqlconn);
                cmd.ExecuteNonQuery();
                if (sqlconn.State == ConnectionState.Open)
                {
                    sqlconn.Close();
                }
                MessageBox.Show("Thanh cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai");
            }
        }

        private void btnSuaKhoa_Click(object sender, EventArgs e)
        {
            try
            {
                 if (sqlconn.State == ConnectionState.Closed)
                {
                    sqlconn.Open();
                    
                }
                string updateString = "update Khoa set TenKhoa = '" + txtTenKhoa.Text + "' where MaKhoa = '"+txtMakhoa.Text+"'";
                SqlCommand cmd = new SqlCommand(updateString, sqlconn);
                cmd.ExecuteNonQuery();
                if (sqlconn.State == ConnectionState.Open)
                {
                    sqlconn.Close();
                }
                MessageBox.Show("Thanh cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai");
            }
        }

    }
}
