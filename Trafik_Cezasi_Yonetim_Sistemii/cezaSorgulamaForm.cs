// cezaSorgulamaForm.cs
using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Trafik_Cezasi_Yonetim_Sistemii
{
    public partial class cezaSorgulamaForm : Form
    {
        private Form1 _mainForm;

        public cezaSorgulamaForm(Form1 mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        // Bu varsayılan constructor, tasarımcıda sorun yaşamamak için kalabilir
        // ancak ana mantıkta her zaman Form1 referansı ile çağrılmalıdır.
        public cezaSorgulamaForm()
        {
            InitializeComponent();
        }

        private void cezaSorgulamaForm_Load(object sender, EventArgs e)
        {
            // Form yüklenirken özel bir işlem gerekmiyor.
        }

        // "Sorgula" Butonu
        private void button1_Click(object sender, EventArgs e)
        {
            string searchID = textBox1.Text.Trim();
            listBox1.Items.Clear();

            if (string.IsNullOrWhiteSpace(searchID))
            {
                MessageBox.Show("Lütfen sorgulamak için bir kimlik numarası girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var foundCezalar = GlobalData.Cezalar
                                      .Where(c => c.ID.Equals(searchID, StringComparison.OrdinalIgnoreCase))
                                      .ToList();

            if (foundCezalar.Any())
            {
                decimal totalUnpaidFines = 0;
                listBox1.Items.Add($"--- {searchID} ID'sine Ait Cezalar ---");

                foreach (var ceza in foundCezalar)
                {
                    listBox1.Items.Add(ceza); // Ceza nesnesini doğrudan ekliyoruz
                    if (!ceza.OdendiMi)
                    {
                        totalUnpaidFines += ceza.Tutar;
                    }
                }
                listBox1.Items.Add("------------------------------------");
                listBox1.Items.Add($"Toplam Ödenmemiş Borç: {totalUnpaidFines:C}");
            }
            else
            {
                MessageBox.Show("Belirtilen kimlik numarasına ait ceza bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // "Ceza Öde" Butonu
        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null || !(listBox1.SelectedItem is Ceza selectedCeza))
            {
                MessageBox.Show("Lütfen ödeme yapmak istediğiniz bir cezayı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedCeza.OdendiMi)
            {
                MessageBox.Show("Bu ceza zaten ödenmiş.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                selectedCeza.OdendiMi = true;
                MessageBox.Show("Ceza başarıyla ödendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Listeyi yenilemek için sorgulama işlemini tekrar tetikle
                button1_Click(sender, e);
            }
        }

        // "Ana Ekrana Dön" Butonu
        private void button2_Click(object sender, EventArgs e)
        {
            // Eğer _mainForm null değilse ve kapatılmadıysa onu göster
            if (_mainForm != null && !_mainForm.IsDisposed)
            {
                _mainForm.Show();
            }
            else // Beklenmedik bir durumda yeni bir ana form oluştur
            {
                Form1 newMainForm = new Form1();
                newMainForm.Show();
            }
            this.Close(); // Mevcut formu kapat
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}