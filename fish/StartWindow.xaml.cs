using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace fish
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            workspaceScoll.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            workspaceScoll.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
            LoadWorkSpaceImages();
        }

        private void Move_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private string[] recursed(string path, string[] patterns)
        {
            string[] arrList = new string[0];
            foreach (string str in patterns)
            {
                string[] list = Directory.GetFiles(path, str, SearchOption.AllDirectories);
                if (list != null)
                {
                    string[] temp = arrList;
                    arrList = new string[arrList.Length + list.Length];
                    Array.Copy(temp, 0, arrList, 0, temp.Length);
                    Array.Copy(list, 0, arrList, temp.Length, list.Length);
                }
            }
            return arrList;
        }

        private void InitRows(int rowCount, Grid g)
        {
            while (rowCount-- > 0)
            {
                RowDefinition rd = new RowDefinition();
                rd.Height = new GridLength(170);
                g.RowDefinitions.Add(rd);
            }
        }
        private void InitColumns(int colCount, Grid g)
        {
            while (colCount-- > 0)
            {
                ColumnDefinition rd = new ColumnDefinition();
                rd.Width = new GridLength(180);
                g.ColumnDefinitions.Add(rd);
            }
        }

        private void LoadWorkSpaceImages()
        {
            string[] list = this.recursed(@"D://WorkSpace", new string[] { "*.jpg", "*.png", "*.gif" });
            InitRows(list.Length/3+1,workspaceGrid);
            InitColumns(3,workspaceGrid);
            for (int i = 0;i < list.Length;i++)
            {
                workSpaceUnit workSpaceUnit = 
                    new workSpaceUnit(list[i].Split('\\')[1], 
                    new BitmapImage(new Uri(list[i],UriKind.Absolute)));
                workspaceGrid.Children.Add(workSpaceUnit);
                workSpaceUnit.MouseLeftButtonUp += WorkSpaceUnit_MouseLeftButtonUp;
                Grid.SetColumn(workSpaceUnit, i % 3);
                Grid.SetRow(workSpaceUnit, i / 3);
            }
        }

        private void WorkSpaceUnit_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            workSpaceUnit workSpaceUnit = sender as workSpaceUnit;
            showHandleWindow("D:\\WorkSpace\\" + workSpaceUnit.textBlock.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog =
                new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Multiselect = true;//该值确定是否可以选择多个文件
            openFileDialog.Title = "请选择文件夹";
            openFileDialog.Filter = "图像文件(*.jpg; *.jpg; *.jpeg; *.gif; *.png)| *.jpg; *.jpeg; *.gif; *.png";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = openFileDialog.FileName;
                showHandleWindow(file);
            }
        }

        private void showHandleWindow(string FileUrl)
        {
            ImageHandleWindow imageHandleWindow =
                new ImageHandleWindow(FileUrl);
            imageHandleWindow.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RunPythonScript("src/ar_main.py");
        }

        private void RunPythonScript(string sArgName, string args = "", params string[] teps)
        {
            Process p = new Process();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + sArgName;
            p.StartInfo.FileName = @"python.exe";
            string sArguments = path;
            foreach (string sigstr in teps)
            {
                sArguments += " " + sigstr;
            }
            sArguments += " " + args;
            p.StartInfo.Arguments = sArguments;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;

            bool success = p.Start();
            p.BeginOutputReadLine();
            //p.OutputDataReceived += new DataReceivedEventHandler(P_OutputDataReceived);
            Console.ReadLine();
            p.WaitForExit();
        }

        /*private void P_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                AppendText(e.Data + Environment.NewLine);
            }
        }

        private delegate void AppendTextCallback(string text);
        private string AppendText(string text)
        {
            //newfileurl = text;
            return text;
        }*/
    }
}
