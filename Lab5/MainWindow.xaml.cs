using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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

namespace Lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new MainPage();
        }

        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new MainPage();
            ValBtn.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF9E7AD6");
            CryValBtn.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF9E7AD6");
            SettingBtn.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF9E7AD6");
            MainBtn.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FFFFFFFF");
        }

        private void ValBtn_Click(object sender, RoutedEventArgs e)
        {

            Main.Content = new ValPage();
            MainBtn.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF9E7AD6");
            CryValBtn.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF9E7AD6");
            SettingBtn.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF9E7AD6");
            ValBtn.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FFFFFFFF");
        }

        private void CryValBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new CryptoCurrencyPage();
            ValBtn.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF9E7AD6");
            MainBtn.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF9E7AD6");
            SettingBtn.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF9E7AD6");
            CryValBtn.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FFFFFFFF");
        }

        private void SettingBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Setting();
            ValBtn.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF9E7AD6");
            MainBtn.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF9E7AD6");
            CryValBtn.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF9E7AD6");
            SettingBtn.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FFFFFFFF");
        }
    }
}
