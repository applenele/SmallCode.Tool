﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SmallCode.Tool.Helpers;

namespace SmallCode.Tool
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 在WPF中， OpenFileDialog位于Microsoft.Win32名称空间
            Microsoft.Win32.OpenFileDialog dialog =
                new Microsoft.Win32.OpenFileDialog();
            dialog.Title = "请选择文件";
            dialog.Filter = @"所有文件(*.*)|*.xls|*.xlsx|";
            if (dialog.ShowDialog() == true)
            {
                lbWarning.Content = "正在转换";
                Task.Factory.StartNew(() =>
                {
                    string file = dialog.FileName;
                    TestExcelRead(file);
                    this.Dispatcher.Invoke(() =>
                    {
                        lbWarning.Content = "转换完成";
                    });
                });

            }
        }

        static void TestExcelRead(string file)
        {
            try
            {
                using (ExcelHelper excelHelper = new ExcelHelper(file))
                {
                    DataTable dt = excelHelper.ExcelToDataTable("SQL Results", true);
                    TxtHelper.ExportTxt(dt);
                }
            }
            catch (Exception ex)
            {
                Debug.Print("Exception: " + ex.Message);
            }
        }
    }
}
