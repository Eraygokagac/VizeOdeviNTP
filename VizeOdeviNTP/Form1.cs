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
    }
}
