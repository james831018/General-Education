using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class check_identity : Form
    {
        public check_identity()
        {
            InitializeComponent();
        }

        private void check_identity_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            Image img1 = Image.FromFile(Application.StartupPath + "\\img\\button2.png");
            Image back = Image.FromFile(Application.StartupPath + "\\img\\2.jpg");
            button1.BackgroundImage = img1;
            button2.BackgroundImage = img1;
            this.BackgroundImage = back;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="admin" && textBox2.Text == "admin")
            {
                Form1 f1 = new Form1();
                f1.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("帳號或密碼錯誤，請重新輸入");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
