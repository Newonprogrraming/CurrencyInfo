using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Lab5
{
    /// <summary>
    /// Логика взаимодействия для Setting.xaml
    /// </summary>
    public partial class Setting : Page
    {


        public Setting()
        {
            InitializeComponent();

        }

        private void CurreBtn_Click(object sender, RoutedEventArgs e)
        {
            string cur;
            switch (Currencycb.SelectedIndex)
            {
                case 0:
                    cur = "USD";
                    break;
                case 1:
                    cur = "RUB";
                    break;
                default:
                    cur = "";
                    break;
            }

            var curr = File.Exists("currency.json") ? JsonConvert.DeserializeObject<Currencyinfo>(File.ReadAllText("currency.json")) : new Currencyinfo
            {
                Currency = cur
            };
            curr.Currency = cur;

            File.WriteAllText("currency.json", JsonConvert.SerializeObject(curr));
        }

    }
}

