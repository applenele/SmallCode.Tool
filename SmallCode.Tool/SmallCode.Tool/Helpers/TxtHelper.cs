/******************************************************
* author :  Lenny
* email  :  niel@dxy.cn 
* function: 
* time:	2017-07-01 16:21:45 
* clrversion :	4.0.30319.42000
******************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace SmallCode.Tool.Helpers
{
    public class TxtHelper
    {
        public static void ExportTxt(DataTable dt)
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt(*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 0;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.CreatePrompt = true;
            saveFileDialog1.Title = "导出txt文件到 ";

            DateTime now = DateTime.Now;
            saveFileDialog1.FileName = now.Second.ToString().PadLeft(2, '0');
            //now.Year.ToString().PadLeft(2)+now.Month.ToString().PadLeft(2, '0 ') +now.Day.ToString().PadLeft(2, '0 ')+ "_ " +now.Hour.ToString().PadLeft(2, '0 ') +now.Minute.ToString().PadLeft(2, '0 ') +
            saveFileDialog1.ShowDialog();

            Stream myStream;
            myStream = saveFileDialog1.OpenFile();
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.UTF8);
            String str = " ";

            //写内容
            for (int rowNo = 0; rowNo < dt.Rows.Count; rowNo++)
            {
                string tempstr = "";
                for (int columnNo = 0; columnNo < dt.Columns.Count; columnNo++)
                {
                    if (columnNo > 0)
                    {
                        tempstr += "\t";
                    }
                    tempstr += dt.Rows[rowNo][columnNo].ToString().Trim().Trim('\t');
                }
                sw.WriteLine(tempstr);
            }
            sw.Close();
            myStream.Close();
        }
    }
}
