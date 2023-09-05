using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;
using Microsoft.Office.Interop.Excel;


namespace eXcel
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        string DosyaYolu = "";
        string DosyaAdi = "";

        private void button1_Click(object sender, EventArgs e)
        {
            

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "desktop";
            ofd.Title = "Excel Dosyası Seçiniz...";
            ofd.Filter = "Excel Dosyası |*.xlsx| Excel Dosyası|*.xls";
            ofd.FilterIndex = 1;
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                 DosyaYolu = ofd.FileName;
                 DosyaAdi = ofd.SafeFileName;
                FileInfo fileInfo = new FileInfo(DosyaYolu);
                ExcelPackage package = new ExcelPackage(fileInfo);
                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

                


                // kaç tane satır var say
                int rows = worksheet.Dimension.Rows; 
                
               

                

                DialogResult dialogResult = MessageBox.Show("TARİH DÜZELTİLSİN Mİ?", "", MessageBoxButtons.YesNo);
                int tarih = 0;
                int sirket = 0;
                if (numericUpDown3.Value!=0)
                {
                    tarih = Convert.ToInt32(numericUpDown3.Value);
                }
                if (numericUpDown4.Value!=0)
                {
                    sirket = Convert.ToInt32(numericUpDown4.Value);
                }
                
                for ( int i = 1; i <= rows; i++) // satırlar arasında gez
                {
                    // ŞİRKET İSMİ KISALT
                    if (worksheet.Cells[i, sirket].Value!=null && worksheet.Cells[i, sirket].Value.ToString().Length > 30&&numericUpDown4.Value!=0)
                    {
                        worksheet.Cells[i, sirket].Value = worksheet.Cells[i, sirket].Value.ToString().Substring(0, 30);
                        if (i==rows)
                        {
                            MessageBox.Show("Şirket isimleri kısaltıldı.");
                        }
                    }
                    
                    
                        
                        if (dialogResult == DialogResult.Yes&&numericUpDown3.Value!=0)
                        {
                            if (worksheet.Cells[i, tarih].Value != null)
                            {
                                //TARİH '.' İŞARETİNDEN '/' İŞARETİNE DÖNÜŞTÜR. 13.01.2023 -> 13/01/2023
                                worksheet.Cells[i, tarih].Value = worksheet.Cells[i, tarih].Value.ToString().Replace('.', '/');
                                if (i == rows)
                                {
                                    MessageBox.Show("Tarih düzeltildi.");
                                }
                            }
                        }
                          
                        
                    
                    
                    

                    
                    
                    
                }
                


                // kaydet
                package.Save();

            }
            
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            groupBox1.Visible = false;
            button5.Dock = DockStyle.Fill;
        }

        private void satir_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "desktop";
            ofd.Title = "Excel Dosyası Seçiniz...";
            ofd.Filter = "Excel Dosyası |*.xlsx| Excel Dosyası|*.xls";
            ofd.FilterIndex = 1;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DosyaYolu = ofd.FileName;
                DosyaAdi = ofd.SafeFileName;
                FileInfo fileInfo = new FileInfo(DosyaYolu);
                ExcelPackage package = new ExcelPackage(fileInfo);
                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                worksheet.DeleteColumn(1); //birinci kolonu sil
                MessageBox.Show("İlk kolon silindi.");
                worksheet.DeleteRow(1); //birinci satırı sil
                MessageBox.Show("İlk satır silindi.");
                package.Save();
            }
                
        }

        private void kolon_button_Click(object sender, EventArgs e)
        {
            
                
               
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "desktop";
            ofd.Title = "Excel Dosyası Seçiniz...";
            ofd.Filter = "Excel Dosyası |*.xlsx| Excel Dosyası|*.xls";
            ofd.FilterIndex = 1;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DosyaYolu = ofd.FileName;
                DosyaAdi = ofd.SafeFileName;
                FileInfo fileInfo = new FileInfo(DosyaYolu);
                ExcelPackage package = new ExcelPackage(fileInfo);
                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();




                // kaç tane satır var say
                int rows = worksheet.Dimension.Rows;





                

                for (int i = 1; i <= rows; i++) // satırlar arasında gez
                {
                    worksheet.Cells[i, 7].Value = numericUpDown2.Value.ToString();
                }
                package.Save();
            }

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown2.Maximum = decimal.MaxValue;
        }

        private void button3_Click(object sender, EventArgs e)
        {/*
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "desktop";
            ofd.Title = "Excel Dosyası Seçiniz...";
            ofd.Filter = "Excel Dosyası |*.xlsx| Excel Dosyası|*.xls";
            ofd.FilterIndex = 1;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DosyaYolu = ofd.FileName;
                DosyaAdi = ofd.SafeFileName;
                FileInfo fileInfo = new FileInfo(DosyaYolu);
                ExcelPackage package = new ExcelPackage(fileInfo);
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                





            }




            */
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); ;
            ofd.Title = "Excel Dosyası Seçiniz...";
            ofd.Filter = "Excel Dosyası |*.xlsx| Excel Dosyası|*.xls";
            ofd.FilterIndex = 1;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DosyaYolu = ofd.FileName;
                DosyaAdi = ofd.SafeFileName;
                FileInfo fileInfo = new FileInfo(DosyaYolu);
                ExcelPackage package = new ExcelPackage(fileInfo);
                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                worksheet.DeleteColumn(1); //birinci kolonu sil
                MessageBox.Show("İlk kolon silindi.");
                worksheet.DeleteRow(1); //birinci satırı sil
                MessageBox.Show("İlk satır silindi.");
                package.Save();
            
                



                // kaç tane satır var say
                int rows = worksheet.Dimension.Rows;





                DialogResult dialogResult = MessageBox.Show("TARİH DÜZELTİLSİN Mİ?", "", MessageBoxButtons.YesNo);
                int tarih = 0;
                int sirket = 0;
                if (numericUpDown3.Value != 0)
                {
                    tarih = Convert.ToInt32(numericUpDown3.Value);
                }
                if (numericUpDown4.Value != 0)
                {
                    sirket = Convert.ToInt32(numericUpDown4.Value);
                }

                for (int i = 1; i <= rows; i++) // satırlar arasında gez
                {
                    // ŞİRKET İSMİ KISALT
                    if (worksheet.Cells[i, sirket].Value != null && worksheet.Cells[i, sirket].Value.ToString().Length > 30 && numericUpDown4.Value != 0)
                    {
                        worksheet.Cells[i, sirket].Value = worksheet.Cells[i, sirket].Value.ToString().Substring(0, 30);
                        if (i == rows)
                        {
                            MessageBox.Show("Şirket isimleri kısaltıldı.");
                        }
                    }



                    if (dialogResult == DialogResult.Yes && numericUpDown3.Value != 0)
                    {
                        if (worksheet.Cells[i, tarih].Value != null)
                        {
                            //TARİH '.' İŞARETİNDEN '/' İŞARETİNE DÖNÜŞTÜR. 13.01.2023 -> 13/01/2023
                            worksheet.Cells[i, tarih].Value = worksheet.Cells[i, tarih].Value.ToString().Replace('.', '/');
                            if (i == rows)
                            {
                                MessageBox.Show("Tarih düzeltildi.");
                            }
                        }
                    }









                }
                for (int i = 1; i <= rows; i++) // satırlar arasında gez
                {
                    worksheet.Cells[i, 7].Value = numericUpDown2.Value.ToString();
                }
                package.Save();



                // kaydet

                
                string kaydet = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                Microsoft.Office.Interop.Excel.Application xlApplication = new Microsoft.Office.Interop.Excel.Application();
                xlApplication.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook workbook = xlApplication.Workbooks.Open(DosyaYolu);
                workbook.Worksheets.Select(1);
                //Microsoft.Office.Interop.Excel.Worksheet worksheet1 in workbook.Worksheets
                
                    //worksheet1.Activate();
                    workbook.SaveAs(kaydet + "/KDV1.txt", Microsoft.Office.Interop.Excel.XlFileFormat.xlCurrentPlatformText);
                



            }




        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }

        private void gelişmişSeçeneklerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gelişmişSeçeneklerToolStripMenuItem.Checked==true)
            {
                groupBox1.Visible = true;
                button5.Dock = DockStyle.None;
            }
            else
            {
                groupBox1.Visible = false;
                button5.Dock = DockStyle.Fill;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
