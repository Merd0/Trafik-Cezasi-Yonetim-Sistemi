using System;
using System.Windows.Forms;

namespace Trafik_Cezasi_Yonetim_Sistemii
{
    public partial class cezaEkleForm : Form
    {
        private Form1 _mainForm;

        public cezaEkleForm(Form1 mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        public cezaEkleForm()
        {
            InitializeComponent();
        }

        private void cezaEkleForm_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string adSoyad = textBox1.Text.Trim();
            string plaka = textBox2.Text.Trim();
            string id = textBox3.Text.Trim();
            DateTime cezaTarihi = dateTimePicker1.Value;

            if (string.IsNullOrWhiteSpace(adSoyad) || string.IsNullOrWhiteSpace(plaka) || string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked)
            {
                MessageBox.Show("Lütfen en az bir ceza türü seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal totalFineAmount = 0;
            string cezaAciklamasi = "";

            if (checkBox1.Checked)
            {
                KirmiziIsikCezasi kirmiziIsik = new KirmiziIsikCezasi
                {
                    AdSoyad = adSoyad,
                    Plaka = plaka,
                    ID = id,
                    CezaTarihi = cezaTarihi,
                    Tutar = new KirmiziIsikCezasi().HesaplaCezaTutari(),
                    OdendiMi = false
                };
                GlobalData.Cezalar.Add(kirmiziIsik);
                totalFineAmount += kirmiziIsik.Tutar;
                cezaAciklamasi += "Kırmızı Işık İhlali, ";
            }

            if (checkBox2.Checked)
            {
                HizCezasi hiz = new HizCezasi
                {
                    AdSoyad = adSoyad,
                    Plaka = plaka,
                    ID = id,
                    CezaTarihi = cezaTarihi,
                    Tutar = new HizCezasi().HesaplaCezaTutari(),
                    OdendiMi = false
                };
                GlobalData.Cezalar.Add(hiz);
                totalFineAmount += hiz.Tutar;
                cezaAciklamasi += "Hız İhlali, ";
            }

            if (checkBox3.Checked)
            {
                ParkCezasi park = new ParkCezasi
                {
                    AdSoyad = adSoyad,
                    Plaka = plaka,
                    ID = id,
                    CezaTarihi = cezaTarihi,
                    Tutar = new ParkCezasi().HesaplaCezaTutari(),
                    OdendiMi = false
                };
                GlobalData.Cezalar.Add(park);
                totalFineAmount += park.Tutar;
                cezaAciklamasi += "Park İhlali, ";
            }

            cezaAciklamasi = cezaAciklamasi.TrimEnd(',', ' ');

            MessageBox.Show($"Ceza başarıyla eklendi!\nToplam Tutar: {totalFineAmount:C}\nCeza Türü(leri): {cezaAciklamasi}",
                "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_mainForm != null && !_mainForm.IsDisposed)
            {
                _mainForm.Show();
            }
            else
            {
                Form1 newMainForm = new Form1();
                newMainForm.Show();
            }
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
