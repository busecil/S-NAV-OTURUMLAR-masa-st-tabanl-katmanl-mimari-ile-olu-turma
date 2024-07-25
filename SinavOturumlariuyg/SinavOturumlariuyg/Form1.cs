using İslemler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Varliklar;

namespace SinavOturumlariuyg
{
    public partial class Form1 : Form
    {
        private SinavIslemleri _sinavIslemleri;
        private SinavIslemleri sı;
        private List<Sinav> al;
        public Form1()
        {
            if (al == null) al = new List<Sinav>();
            if (sı == null) sı = new SinavIslemleri();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            yukle();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sinav s = new Sinav();
            DateTime secilenSaat = dateTimePicker2.Value;
            DateTime saat = new DateTime(1, 1, 1, secilenSaat.Hour, secilenSaat.Minute, 0);
            s.Saat = saat.TimeOfDay;
            s.Aktif = checkBox1.Checked ? true : false; // aktif seçildiyse vt ye tru seçilmediyse false olarak kaydeder.
            sı.Ekle(s);
            al.Add(s);
            yukle();
            temizle();
        }

        private void temizle()
        {
            label2.Text = "-1";
            checkBox1.Checked = false;
            dateTimePicker2.Value = DateTime.Today;
        }

        private void yukle()
        {
            al = sı.tamaminiGetir().OrderBy(p => p.ID).ToList();
            dataGridView1.DataSource = al;
            dataGridView1.Columns[0].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label2.Text != "-1")
            {
                Sinav so = sı.tekilGetir(o => o.ID == Convert.ToInt32(label2.Text));
                if (so != null)
                {
                    sı.Sil(so);
                    yukle();
                    temizle();
                }
                else
                {
                    MessageBox.Show("Oturum Bulunamadığından Silinemedi");
                }
            }
            else
            {

                MessageBox.Show("Önce Silinecek Oturumu Seçiniz");

            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            parcala();
        }

        private void parcala()
        {
            if (dataGridView1.CurrentRow.Index > -1)
            {
                Sinav s = sı.tekilGetir(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                label2.Text = s.ID.ToString();
                TimeSpan time = new TimeSpan(s.Saat.Hours, s.Saat.Minutes, s.Saat.Seconds);
                DateTime secilenSaat = DateTime.Today.Add(time);
                dateTimePicker2.Value = secilenSaat;
                /* üsteki 3 satırda timespan olarak gelen veriyi datetime parse edip datetimepickere bastık  */
                checkBox1.Checked = s.Aktif;

            }
            else
            {
                MessageBox.Show("Kayıt seçiniz");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label2.Text != "-1" && (textBox1.Text.IndexOf("*") == -1))
            {
                Sinav go = al.Where(o => o.ID == Convert.ToInt32(label2.Text)).FirstOrDefault();
                if (go != null)
                {
                    DateTime secilenSaat = dateTimePicker2.Value;
                    DateTime saat = new DateTime(1, 1, 1, secilenSaat.Hour, secilenSaat.Minute, 0);

                    go.Saat = saat.TimeOfDay;
                    go.Aktif = checkBox1.Checked ? true : false;


                    sı.Guncelle(go);
                    yukle();
                    temizle();
                }
                else
                {
                    MessageBox.Show("Öğrenci Bulunamadığından Güncellenemedi");
                }
            }
            else
            {
                MessageBox.Show("Veriler Hatalı Formatta OLduğundan Güncellenemedi");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                yukle();
            }
            else
            {
                List<Sinav> gl = sı.sorgula(o => o.Saat.ToString().Contains(textBox1.Text));
                dataGridView1.DataSource = gl;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();

        }
    }
}
        
    


