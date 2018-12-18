using System;
using System.Collections.Generic;
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
        }

        private string fileurl;
    }
}
