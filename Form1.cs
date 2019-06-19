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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //ComboBox' da ki seçenekler her değiştiğinde kodları tek tek yazmayıp bir sefer yazıp bir daha kullanacağımızda çağırmak için method oluşturuyoruz.
        private void KoltukDoldur(int sirasayisi, bool arkabeslimi)
        {   //ComboBox' da ki seçenekler değiştiğinde koltuklar da değişeceği için düzen bozulmaması için foreach döngüsünü yavaşlatmak için oluşturyoruz.
        yavaslat:
            //ComboBox' da ki seçenekler değiştiğinde koltuk düzeni değişeceği için koltuklar üzerine yazılmasın diye önceki koltuk düzenini foreach döngüsü ile kaldırıyoruz.
            foreach (Control con in this.Controls)
            {
                if (con is Button)// Eğer form üzerindeki kontroller butonsa sil diyoruz.
                {
                    con.Dispose();
                    goto yavaslat;
                }
            }
            int koltukNo = 1;//Koltuklara numara vermek için değişken tanımlıyoruz
            for (int i = 0; i < sirasayisi; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (arkabeslimi)
                    {
                        if (j == 2 & i != sirasayisi - 1)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (j == 2)
                        {
                            continue;
                        }
                    }
                    if (i == 6 & j > 2)
                    {
                        continue;
                    }
                    Button koltuk = new Button();
                    koltuk.ContextMenuStrip = contextMenuStrip1;
                    koltuk.MouseDown += koltuk_MouseDown;
                    koltuk.Width = koltuk.Height = 40;
                    koltuk.Top = 30 + (i * 40);
                    koltuk.Left = 10 + (j * 45);
                    koltuk.Text = koltukNo.ToString();
                    koltukNo++;
                    this.Controls.Add(koltuk);
                }
            }
        }
        Button sagtiklanan;
        void koltuk_MouseDown(object sender, MouseEventArgs e)
        {
            sagtiklanan = (Button)sender;
        }
        int bossayactra = 55;
        int bossayacneo = 46;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                KoltukDoldur(14, true);
                lblBos.Text = bossayactra.ToString();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                KoltukDoldur(12, false);
                lblBos.Text = bossayacneo.ToString();
            }
        }
        int baysayac = 1;
        private void bayToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Rezervasyon(Color.Blue);
            lblBaySayac.Text = baysayac.ToString();
            baysayac++;
            if (comboBox1.SelectedIndex == 0)
            {
                bossayactra--;
                lblBos.Text = bossayactra.ToString();

            }
            else if (comboBox1.SelectedIndex == 1)
            {
                bossayacneo--;
                lblBos.Text = bossayacneo.ToString();

            }
        }

        private void Rezervasyon(Color renk)
        {
            KayitFormu kayit = new KayitFormu();
            DialogResult sonuc = kayit.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                if (kayit.txtİsim.Text == "" || kayit.txtSoyisim.Text == "" || kayit.mskdtxtTelefon.Text == "")
                {
                    MessageBox.Show("Lütfen Zorunlu Yerleri Doldurunuz");
                }
                else
                {
                    ListViewItem satir = new ListViewItem();
                    satir.Text = sagtiklanan.Text;
                    satir.SubItems.Add(kayit.txtİsim.Text);
                    satir.SubItems.Add(kayit.txtSoyisim.Text);
                    satir.SubItems.Add(kayit.mskdtxtTelefon.Text);
                    listView1.Items.Add(satir);
                    sagtiklanan.BackColor = renk;
                }
            }
            else
            {
                MessageBox.Show("Kayıt Yapılamadı");
            }
        }
        int bayansayac = 1;
        private void bayanToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Rezervasyon(Color.Pink);
            lblBayanSayac.Text = bayansayac.ToString();
            bayansayac++;
            if (comboBox1.SelectedIndex == 0)
            {
                bossayactra--;
                lblBos.Text = bossayactra.ToString();

            }
            else if (comboBox1.SelectedIndex == 1)
            {
                bossayacneo--;
                lblBos.Text = bossayacneo.ToString();

            }
        }
    }
}
