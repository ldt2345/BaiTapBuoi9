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
    public partial class Form1 : Form
    {
        function fn = new function();
        SqlConnection connsql;
        public Form1()
        {
            InitializeComponent();
            connsql = fn.conn;
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadKhoa_ComboBox();
        }
        private void LoadKhoa_ComboBox()
        {
            connsql.Open();
            string selectString = "select * from khoa";
            SqlCommand cmd = new SqlCommand(selectString, connsql);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                comboBox1.Items.Add(rd["MaKhoa"]).ToString();
            }
            rd.Close();
            connsql.Close();
        }
        public bool KT_KhoaChinh(string pMa)
        {
            connsql.Open();
            string selectString = "select * from Lop where MaLop = '" + pMa + "'";
            SqlCommand cmd = new SqlCommand(selectString, connsql);
            SqlDataReader rd = cmd.ExecuteReader();
            if(rd.HasRows)
            {
                rd.Close();
                connsql.Close();
                return false;
            }
            else 
            {
                rd.Close();
                connsql.Close();
                return true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            try
            {
                if(KT_KhoaChinh(txtMalop.Text) == true)
                {
                    connsql.Open();
                    string insertString = "insert into Lop values('"+txtMalop.Text +"','"+ txtTenlop +"')";
                    SqlCommand cmd = new SqlCommand(insertString, connsql);
                    cmd.ExecuteNonQuery();
                    connsql.Close();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();

                }
                string deleteString = "delete Lop where MaLop = '" + txtMalop + "'";
                SqlCommand cmd = new SqlCommand(deleteString, connsql);
                cmd.ExecuteNonQuery();
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
                MessageBox.Show("Thanh cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();

                }
                string updateString = "update Lop set TenLop = '" + txtTenlop + "' where MaLop = '" + txtMalop + "'";
                SqlCommand cmd = new SqlCommand(updateString, connsql);
                cmd.ExecuteNonQuery();
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
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
