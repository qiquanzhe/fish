using System;
using System.Collections.Generic;
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
            MessageBox.Show(workSpaceUnit.textBlock.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
