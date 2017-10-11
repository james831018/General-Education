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

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string cn;
        SqlConnection sc;
        DataSet ds;
        SqlDataAdapter ad;

        private void Form1_Load(object sender, EventArgs e)
        {
            cn = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                "AttachDbFilename=|DataDirectory|class.mdf;" +
                "Integrated Security=True";
            sc = new SqlConnection();
            sc.ConnectionString = cn;
            sc.Open();

            ad = new SqlDataAdapter("SELECT name,成績,考試 FROM class", cn);

            ds = new DataSet();
            ad.Fill(ds,"class");
            dataGridView1.DataSource = ds.Tables["class"];
            Image but3 = Image.FromFile(Application.StartupPath + "\\img\\but3.jpg");
            button1.BackgroundImage = but3;
            button2.BackgroundImage = but3;
            Image back = Image.FromFile(Application.StartupPath + "\\img\\3.jpg");
            this.BackgroundImage = back;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sc;
                cmd.CommandText = "INSERT INTO class(ID,name,成績,時間,點名,考試,報告,作業,星期,節數1,節數2,綜合評價,心得)VALUES(" + 
                    (ds.Tables["class"].Rows.Count+1) + ",N'" +
                    txtname.Text + "'," +txtgrade1.Text + "," + txttime1.Text + ",N'" + cbrollcall.Text +
                    "',N'" + rbtest.Text + "',N'" + rbreport.Text + "',N'" + rbhw.Text +
                    "',N'" + rbday.Text + "'," + txtlesson1.Text + "," + txtlesson2.Text + ",N'" + cball.Text +"',N'" + textBox1.Text + "')";
                /*cmd.CommandText = "INSERT INTO class(ID,name,成績,時間,點名,考試,報告,作業,星期,節數1,節數2,綜合評價)VALUES(" +
                (ds.Tables["class"].Rows.Count + 1) + ",N'" +
                txtname.Text + "'," + txtgrade1.Text + "," + txttime1.Text + ",N'" + cbrollcall.Text +
                "',N'" + rbtest.Text + "',N'" + rbreport.Text + "',N'" + rbhw.Text +
                "',N'" + rbday.Text + "'," + txtlesson1.Text + "," + txtlesson2.Text + ",'" + cball.Text +"')";*/
                cmd.ExecuteNonQuery();
                sc.Close();
                Form1_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtname.Text = "";txtgrade1.Text = "";txttime1.Text = "";cbrollcall.Text = ""; cbrollcall.Text = ""; rbtest.Text = "";
            rbreport.Text = ""; rbhw.Text = ""; rbday.Text = ""; txtlesson1.Text = ""; txtlesson2.Text = ""; cball.Text = "";textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sc;
                cmd.CommandText = "DELETE FROM class WHERE name= N'" + txtname.Text + "'";

                cmd.ExecuteNonQuery();
                sc.Close();
                Form1_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
