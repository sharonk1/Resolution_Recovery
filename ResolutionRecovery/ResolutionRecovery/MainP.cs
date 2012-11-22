using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
//using System.Xml.Linq;


namespace Resolution_Recovery
{
    public partial class MainP : Form
    {
        public MainP()
        {
            InitializeComponent();
        }

        private void MainP_Load(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();


            try
            {
                xmlDoc.Load("options.xml");
                XmlNodeList res = xmlDoc.GetElementsByTagName("resolution1");
                string resolutionStr = res[0].InnerText;
                IList<string> resolution = resolutionStr.Split('x');

                string H = resolution[0].ToString();
                string W = resolution[1].ToString();
                Resolution.CResolution ChangeRes = new Resolution.CResolution(Convert.ToInt32(H), Convert.ToInt32(W));
                if (Screen.AllScreens.Length > 1)
                {
                    res = xmlDoc.GetElementsByTagName("resolution2");
                    resolutionStr = res[0].InnerText;
                    resolution = resolutionStr.Split('x');
                    H = resolution[0].ToString();
                    W = resolution[1].ToString();
                    Resolution.SECResolution ChangeSECRes = new Resolution.SECResolution(Convert.ToInt32(H), Convert.ToInt32(W));
                }
            }
            catch  (Exception msg)
            {
                MessageBox.Show("Some error occurred, please try again" + " " + msg.ToString());
            }


            this.Close();
        }


    }
}
