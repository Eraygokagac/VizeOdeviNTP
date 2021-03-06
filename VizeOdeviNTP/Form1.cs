using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace VizeOdeviNTP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        XElement root;

        int sayi = 60;

        private void Form1_Load(object sender, EventArgs e)
        {
            XDocument doc = XDocument.Load("https://data.ibb.gov.tr/en/dataset/0efb7d74-fffe-4cb5-b675-75086f3d7e29/resource/ae6be6d3-ef7b-4eca-a356-9f90c745a8e8/download/tedaviedilenhayvanlar.xml");
            root = doc.Root;

            timer1.Interval = 30000;
            timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked==true)
                {
                    List<XElement> rammus = root.Elements()
                    .Where(s => s.Element("KISIR").Value == "true")
                    .ToList();
                    XDocument eray = XDocument.Parse("<root></root>");
                    XElement gokagac = eray.Root;
                    gokagac.Add(rammus);
                    gokagac.Save("KisirVeriler.xml");
                    MessageBox.Show("Veriler kaydedildi", "-BAŞARILI-", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("kaydetmediniz");
                }
            }
            catch
            {
                MessageBox.Show("Hata");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(checkBox2.Checked == true)
            {
                XDocument eray = XDocument.Parse("<root></root>");
                XElement gokagac = eray.Root;
                gokagac.Add(root.Elements());
                gokagac.Save("TümVeriler.xml");
                MessageBox.Show("Veriler Kaydedildi", "-BAŞARILI-", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if(checkBox3.Checked == true)
            {
                List<XElement> rammus = root.Elements()
                .Where(s => s.Element("KISIR").Value == "false")
                .ToList();
                XDocument eray=XDocument.Parse("<root></root>");
                XElement gokagac = eray.Root;
                gokagac.Add(rammus);
                gokagac.Save("KısırOlmayanVeriler.xml");
                MessageBox.Show("Veriler Kaydedildi", "-BAŞARILI-", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sayi>=0)
            {
                timer1.Interval = 30000;
                timer1.Enabled = true;
                int sayac = sayi--;

                if (MessageBox.Show("Veriler Kaydedilsin mi? Vazgeç derseniz 30 saniye ertelemiş olursunuz.", "Onay veriniz", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK)
                {
                    XDocument eray = XDocument.Parse("<root></root>");
                    XElement gokagac = eray.Root;
                    gokagac.Add(root.Elements());
                    gokagac.Save("TümVeriler.xml");
                    MessageBox.Show("Veriler Kaydedildi", "-BAŞARILI-", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
