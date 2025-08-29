using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_76_phuc
{
    public partial class Power : Form
    {
        public Power()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = "x\u207F = ";
            label4.Text = "Chương Trình Tính Luỹ thừa: x\u207F";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        public static double power_76_phuc(double x_76_phuc, int n_76_phuc)
        {
            if (n_76_phuc == 0)
                return 1.0;
            else if (n_76_phuc > 0)
                return x_76_phuc * power_76_phuc(x_76_phuc, n_76_phuc - 1);
            else
                return power_76_phuc(x_76_phuc, n_76_phuc + 1) / x_76_phuc;
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double x;
            int n;
            double kq;
            x = double.Parse(txtX.Text);
            n = int.Parse(txtN.Text);
            kq = power_76_phuc(x, n);
            txtKQ.Text = kq.ToString();
        }
    }
}
