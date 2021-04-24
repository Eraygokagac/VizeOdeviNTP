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

        private void Form1_Load(object sender, EventArgs e)
        {
            XDocument doc = XDocument.Load("https://data.ibb.gov.tr/en/dataset/0efb7d74-fffe-4cb5-b675-75086f3d7e29/resource/ae6be6d3-ef7b-4eca-a356-9f90c745a8e8/download/tedaviedilenhayvanlar.xml");
            root = doc.Root;

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
    }
}
