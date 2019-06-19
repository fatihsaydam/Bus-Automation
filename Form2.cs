using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _130505Win_FormOtobüsOtomasyonu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Doldur(45, true);
        }

        void Doldur(int sira, bool arkaBesliMi)
        {
            for (int i = 1; i <= sira; i++)
            {
                Button btn = new Button();
                btn.Width = btn.Height = 40;
                if (i % 5 == 3)
                    btn.Margin = new Padding(40, 0, 0, 0);
                else
                    btn.Margin = new Padding(0);
                btn.Click += btn_Click;
                flowLayoutPanel1.Controls.Add(btn);

            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
