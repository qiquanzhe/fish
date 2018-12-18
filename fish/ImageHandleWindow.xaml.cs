using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace fish
{
    /// <summary>
    /// ImageHandleWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ImageHandleWindow : Window
    {
        public ImageHandleWindow()
        {
            InitializeComponent();
        }
        public ImageHandleWindow(string FileUrl)
        {
            this.fileurl = FileUrl;
            InitializeComponent();
            optionSelectView.SelectedIndex = 0;
            HandlingImage.Source = new BitmapImage(new Uri(FileUrl, UriKind.Absolute));
        }

        private void Move_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }


        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            RunPythonScript("im.py","-u",fileurl);
            string newurl = fileurl.Replace("/", "\\");
            
            HandlingImage.Source = new BitmapImage(new Uri(@""+newurl, UriKind.Absolute));
        }

        private void RunPythonScript(string sArgName, string args = "", params string[] teps)
        {
            Process p = new Process();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + sArgName;// 获得python文件的绝对路径（将文件放在c#的debug文件夹中可以这样操作）
           
            //path = @"C:\Users\user\Desktop\test\" + sArgName;//(因为我没放debug下，所以直接写的绝对路径,替换掉上面的路径了)
            p.StartInfo.FileName = @"python3.exe";//没有配环境变量的话，可以像我这样写python.exe的绝对路径。如果配了，直接写"python.exe"即可
            string sArguments = path;
            foreach (string sigstr in teps)
            {
                sArguments += " " + sigstr;//传递参数
            }
            sArguments += " " + args;
            MessageBox.Show(sArguments);
            p.StartInfo.Arguments = sArguments;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;

            bool success = p.Start();
            MessageBox.Show(success.ToString());
            p.BeginOutputReadLine();
            p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            Console.ReadLine();
            p.WaitForExit();
        }
        //输出打印的信息
        private void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            MessageBox.Show(Environment.NewLine);
            if (!string.IsNullOrEmpty(e.Data))
            {
                AppendText(e.Data+ Environment.NewLine);
            }
        }
        private delegate void AppendTextCallback(string text);
        private string AppendText(string text)
        {
            //Console.WriteLine(text);     //此处在控制台输出.py文件print的结果
            //MessageBox.Show(text);
            fileurl = text;
            return text;
        }
        private string fileurl;
    }
}
