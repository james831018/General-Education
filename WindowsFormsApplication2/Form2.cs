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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        string cn;
        
        SqlConnection sc;
        SqlDataAdapter ad;
        DataSet ds;
        SqlCommand cmd;

        private void Form2_Load(object sender, EventArgs e)
        {
            cn = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                "AttachDbFilename=|DataDirectory|class.mdf;" +
                "Integrated Security=True";
            sc = new SqlConnection(cn);
            sc.Open();

            cmd = new SqlCommand();
            cmd.Connection = sc;
            //Image myimage = new Bitmap(@"D:\Images\myImage1.jpg");
            //userLabel.Image = Image.FromFile(Application.StartupPath + "\\picture\\Scissors.png");
            
            Image but4 = Image.FromFile(Application.StartupPath + "\\img\\but4.png");
            Image back = Image.FromFile(Application.StartupPath + "\\img\\4.jpg");
            this.BackgroundImage = back;
            search.BackgroundImage = but4;

        }

        private void search_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            //cmd = new SqlCommand();
            //cmd.Connection = sc;

            bool flag = false;
            string search = "SELECT name   FROM class ";

            //課程名稱
            if (txtname.Text != "")
            {
                search += "WHERE name = N'" + txtname.Text + "'";
                flag = true;
            }

            //成績範圍
            if (txtgrade1.Text != "" || txtgrade2.Text != "")
            {
                if (txtgrade1.Text == "" || txtgrade2.Text == "")
                {
                    MessageBox.Show("請輸入正確範圍!");
                    search = "SELECT name FROM class WHERE";
                    return;
                }
                else
                {
                    if(flag==false)
                        search += "WHERE (成績 >= " + txtgrade1.Text + ") AND (成績 <= " + txtgrade2.Text + ")";
                    else
                        search += "AND (成績 >= " + txtgrade1.Text + ") AND (成績 <= " + txtgrade2.Text + ")";
                }
                    
                flag = true;
            }

            //時間
            if (txttime1.Text != "" || txttime2.Text != "")
            {
                if (txttime1.Text == "" || txttime2.Text == "")
                {
                    MessageBox.Show("請輸入正確範圍!");
                    search = "SELECT name FROM class WHERE";
                    return;
                }
                else
                {
                    if (flag == false)
                        search += "WHERE (時間 >= " + txttime1.Text + ") AND (時間 <= " + txttime2.Text + ")";
                    else
                        search += "AND (時間 >= " + txttime1.Text + ") AND (時間 <= " + txttime2.Text + ")";
                }

                flag = true;
            }

            //點名
            if (cbrollcall.Text != "")
            {
                if (flag == false)
                    search += "WHERE 點名 = N'" + cbrollcall.Text + "'";
                else
                    search += "AND (點名 = N'" + cbrollcall.Text + "')";
                flag = true;
            }

            //考試
            if (rbtest.Text != "")
            {
                if (flag == false)
                    search += "WHERE 考試 = N'" + rbtest.Text + "'";
                else
                    search += "AND (考試 = N'" + rbtest.Text + "')";
                flag = true;
            }

            //報告
            if (rbreport.Text != "")
            {
                if (flag == false)
                    search += "WHERE 報告 = N'" + rbreport.Text + "'";
                else
                    search += "AND (報告 = N'" + rbreport.Text + "')";
                flag = true;
            }

            //作業
            if (rbhw.Text != "")
            {
                if (flag == false)
                    search += "WHERE 作業 = N'" + rbhw.Text + "'";
                else
                    search += "AND (作業 = N'" + rbhw.Text + "')";
                flag = true;
            }

            //星期
            if (rbday.Text != "")
            {
                if (flag == false)
                    search += "WHERE 星期 = N'" + rbday.Text + "'";
                else
                    search += "AND (星期 = N'" + rbday.Text + "')";
                flag = true;
            }

            //節數
            if (txtlesson1.Text != "" || txtlesson2.Text != "")
            {
                if (txtlesson1.Text == "" || txtlesson2.Text == "")
                {
                    MessageBox.Show("請輸入正確範圍!");
                    search = "SELECT name FROM class WHERE";
                    return;
                }
                else
                {
                    if (flag == false)
                        search += "WHERE (節數1 >= " + txtlesson1.Text + ") AND (節數2 <= " + txtlesson2.Text + ")";
                    else
                        search += "AND (節數1 >= " + txtlesson1.Text + ") AND (節數2 <= " + txtlesson2.Text + ")";
                }

                flag = true;
            }

            //綜合評價
            if (cball.Text != "")
            {
                if (flag == false)
                    search += "WHERE 綜合評價 = N'" + cball.Text + "'";
                else
                    search += "AND (綜合評價 = N'" + cball.Text + "')";
                flag = true;
            }

            cmd.CommandText = search;

            //ad = new SqlDataAdapter(search, sc);
            //ds = new DataSet();
            //ad.Fill(ds, "class");

            SqlDataReader rd = cmd.ExecuteReader();
            //int rowcount = ds.Tables[0].Rows.Count;

            while(rd.Read())
            {
                bool check = false;
                for(int i=0;i<listBox1.Items.Count;i++)
                {
                    if (rd.GetString(0) == listBox1.Items[i].ToString())
                    {
                        check = true;
                        break;
                    }
                }
                if (check == false)
                    listBox1.Items.Add(rd.GetString(0));
            }
            rd.Close();
            if (listBox1.Items.Count != 0)
                listBox1.SetSelected(0, true);
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            SqlCommand cmd = new SqlCommand();
            string search = "SELECT ID,name FROM class WHERE name = N'" + listBox1.SelectedItem.ToString() +"'";
            cmd.Connection = sc;
            cmd.CommandText = search;

            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                string newitem = "";
                newitem += rd.GetInt32(0).ToString() + " " + "\t" + rd.GetString(1);
                listBox2.Items.Add(newitem);
            }
            rd.Close();
            if (listBox2.Items.Count != 0)
                listBox2.SetSelected(0, true);
        }

        private void listBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            string selected = listBox2.SelectedItem.ToString();
            string[] separator = { " " };
            string[] output = selected.Split(separator, StringSplitOptions.None);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sc;
            cmd.CommandText = "SELECT * FROM class WHERE ID = " + int.Parse(output[0]);

            SqlDataReader rd = cmd.ExecuteReader();
            rd.Read();

            //順序: ID,name,成績,時間,點名,考試,報告,作業,星期,節數1,節數2,綜合評價
            lbname.Text = rd.GetString(1);
            lbscore.Text = rd.GetInt32(2).ToString();
            lbtime.Text = rd.GetInt32(3).ToString();
            lbrollcall.Text = rd.GetString(4);
            lbtest.Text = rd.GetString(5);
            lbreport.Text = rd.GetString(6);
            lbhw.Text = rd.GetString(7);
            lbday.Text = rd.GetString(8);
            lblesson.Text = rd.GetInt32(9).ToString() + " ~ " + rd.GetInt32(10).ToString();
            lball.Text = rd.GetString(11);
            textBox1.Text = rd.GetString(12).ToString();

            rd.Close();
        }
    }
}
