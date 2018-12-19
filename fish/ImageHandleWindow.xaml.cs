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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Scripting.Hosting;

namespace fish
{
    /// <summary>
    /// ImageHandleWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ImageHandleWindow : Window
    {

        private string fileurl;
        private string newfileurl;
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

        private void Move_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void RunPythonScript(string sArgName, string args = "", params string[] teps)
        {
            Process p = new Process();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + sArgName;
            p.StartInfo.FileName = @"python3.exe";
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
            p.OutputDataReceived += new DataReceivedEventHandler(P_OutputDataReceived);
            Console.ReadLine();
            p.WaitForExit();
        }

        private void P_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                AppendText(e.Data + Environment.NewLine);
            }
        }

        private delegate void AppendTextCallback(string text);
        private string AppendText(string text)
        {
            newfileurl = text;
            return text;
        }

        private void OriginalImage(object sender, RoutedEventArgs e)
        {
            HandlingImage.Source = new BitmapImage(new Uri(@"" + fileurl, UriKind.Absolute));
        }

        private void BrightImage(object sender, RoutedEventArgs e)
        {
            RunPythonScript("bright.py", "-u", fileurl);
            string newurl = newfileurl.Replace("/", "\\");
            HandlingImage.Source = new BitmapImage(new Uri(@"" + newurl, UriKind.Absolute));
        }
        private void SketchImage(object sender, RoutedEventArgs e)
        {
            RunPythonScript("sketch.py","-u",fileurl);
            string newurl = newfileurl.Replace("/", "\\");
            HandlingImage.Source = new BitmapImage(new Uri(@""+newurl, UriKind.Absolute));
        }


        private void BlueImage(object sender, RoutedEventArgs e)
        {
            RunPythonScript("GaussianBlur.py", "-u", fileurl);
            string newurl = newfileurl.Replace("/", "\\");
            HandlingImage.Source = new BitmapImage(new Uri(@"" + newurl, UriKind.Absolute));
        }

        private void RegionalGrayImage(object sender, RoutedEventArgs e)
        {
            RunPythonScript("regionalGray.py", "-u", fileurl);
            string newurl = newfileurl.Replace("/", "\\");
            HandlingImage.Source = new BitmapImage(new Uri(@"" + newurl, UriKind.Absolute));
        }


        private void CannyImage(object sender, RoutedEventArgs e)
        {
            RunPythonScript("Canny.py", "-u", fileurl);
            string newurl = newfileurl.Replace("/", "\\");
            HandlingImage.Source = new BitmapImage(new Uri(@"" + newurl, UriKind.Absolute));
        }

        private void ReveseImage(object sender, RoutedEventArgs e)
        {
            RunPythonScript("reverse.py", "-u", fileurl);
            string newurl = newfileurl.Replace("/", "\\");
            HandlingImage.Source = new BitmapImage(new Uri(@"" + newurl, UriKind.Absolute));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void SaveImage(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "图像文件(*.bmp,*.png,*.jpg)|*.bmp;*.png;*.jpg | All Files | *.*",
                RestoreDirectory = true
            };
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
                pngBitmapEncoder.Frames.Add(BitmapFrame.Create((BitmapSource)this.HandlingImage.Source));
                System.IO.FileStream fileStream = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create);
                pngBitmapEncoder.Save(fileStream);
            }
        }

    }
}
