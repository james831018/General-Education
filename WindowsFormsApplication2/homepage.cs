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
    public partial class homepage : Form
    {
        public homepage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            check_identity check = new check_identity();
            check.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        
        private void homepage_Load(object sender, EventArgs e)
        {
            //button1.AutoSizeMode;
            Image img1 = Image.FromFile(Application.StartupPath + "\\img\\button2.png");
            Image back = Image.FromFile(Application.StartupPath + "\\img\\2.jpg");

            //img1.Height = button1.Height;
            button1.BackgroundImage = img1;
            button2.BackgroundImage = img1;
            this.BackgroundImage = back;

        }
    }
}
