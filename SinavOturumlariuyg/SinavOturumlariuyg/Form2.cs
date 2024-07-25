using İslemler;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinavOturumlariuyg
{
    public partial class Form2 : Form
    {
        SinavIslemleri sIslem;
        public Form2()
        {
            sIslem = new SinavIslemleri();
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            raporYukle();
            this.reportViewer1.RefreshReport();
        }

        private void raporYukle()
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "SinavOturumuuyg.Report1.rdlc";
            ReportDataSource rds = new ReportDataSource("DataSet1", sIslem.tamaminiGetir());
            reportViewer1.LocalReport.DataSources.Add(rds);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportEmbeddedResource = "SinavOturumuuyg.Report1.rdlc";
            ReportDataSource rds = new ReportDataSource("DataSet1", sIslem.sorgula(x => x.Saat.ToString()
            .ToLower().Contains(textBox1.Text)));
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }
    }
}
