using System;
using System.Windows.Forms;

namespace Trafik_Cezasi_Yonetim_Sistemii
{
    public partial class polisPanel : Form
    {
        private Form1 _mainForm;

        public polisPanel(Form1 mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        public polisPanel()
        {
            InitializeComponent();
        }

        private void polisPanel_Load(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            string correctUsername = "polis";
            string correctPassword = "123";

            string enteredUsername = textBox1.Text;
            string enteredPassword = textBox2.Text;

            if (enteredUsername == correctUsername && enteredPassword == correctPassword)
            {
                MessageBox.Show("Giriş başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cezaEkleForm cezaEkle = new cezaEkleForm(_mainForm);
                cezaEkle.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
            }
        }
    }
}
