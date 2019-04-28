using lottoForm.CrawlerDrivers;
using lottoForm.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lottoForm
{
    public partial class FormMain : Form
    {
        //ILottoCralwer driver;
        public FormMain()
        {
            InitializeComponent();
            //driver = lottoCralwer;
        }

        private void btn_pilio_Click(object sender, EventArgs e)
        {
            ILottoCralwer lottoCralwer = new PilioDriver();
            var result = lottoCralwer.GetAllData();
            foreach(var r in result)
            {
                Console.WriteLine($"日期 {r.Date} 開獎號：{r.Content} 特別號：{r.Special}");
            }
            lottoCralwer.ExportCSV();
            MessageBox.Show("已存檔");
        }
    }
}
