using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для CryptoCurrencyPage.xaml
    /// </summary>
    public partial class CryptoCurrencyPage : Page
    {
        public CryptoCurrencyPage()
        {
            InitializeComponent();
            this.fromcurrencytb.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput);
            this.incurrencytb.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput);
        }

        void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void CryptoCurreBtn_Click(object sender, RoutedEventArgs e)
        {
            var curr = JsonConvert.DeserializeObject<Currencyinfo>(File.ReadAllText("currency.json"));
            string currencyinfo = Convert.ToString(curr.Currency);
            get(currencyinfo);
        }

        private void CryprtoConvertBtn_Click(object sender, RoutedEventArgs e)
        {
            string amountcyr = fromcurrencytb.Text;
            string fromitem;
            string toitem;

            if(ConvertfromCB.SelectedItem == "")
            {
                MessageBox.Show("Заполните первое поле для конвертации");
            }
            else
            {
                switch (ConvertfromCB.SelectedIndex)
                {
                    case 0:
                        fromitem = "BTC";
                        break;
                    case 1:
                        fromitem = "ETH";
                        break;
                    case 2:
                        fromitem = "BNB";
                        break;
                    case 3:
                        fromitem = "USDT";
                        break;
                    case 4:
                        fromitem = "DOGE";
                        break;
                    default:
                        fromitem = "";
                        break;
                }
                switch (ConvertinCB.SelectedIndex)
                {
                    case 0:
                        toitem = "BTC";
                        break;
                    case 1:
                        toitem = "ETH";
                        break;
                    case 2:
                        toitem = "BNB";
                        break;
                    case 3:
                        toitem = "USDT";
                        break;
                    case 4:
                        toitem = "DOGE";
                        break;
                    default:
                        toitem = "";
                        break;
                }

                getconvert(fromitem, toitem, amountcyr);
            }
        }

        public void get(string source)
        {

            string addres = "http://api.coinlayer.com/live&target=" + source + "&symbols=BTC,BNB,ETH,USDT,DOGE?access_key=404c52cdd7fd0f47209fec49b6c120c0";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(addres);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            dynamic obj = JsonConvert.DeserializeObject(response);
            var quotes1 = obj.rates;
            string bnb = (string)quotes1.BNB;
            string btc = (string)quotes1.BTC;
            string doge = (string)quotes1.DOGE;
            string eth = (string)quotes1.ETH;
            string usdt = (string)quotes1.USDT;
            if (source == "RUB")
            {  
                bnbtb.Text = bnb + " RUB";
                btctb.Text = btc + " RUB";
                dogetb.Text = doge + " RUB";
                ethtb.Text = eth + " RUB";
                usdttb.Text = usdt + " RUB";
            }
            else if (source == "USD")
            {
                bnbtb.Text = bnb + " USD";
                btctb.Text = btc + " USD";
                dogetb.Text = doge + " USD";
                ethtb.Text = eth + " USD";
                usdttb.Text = usdt + " USD";
            }
        }

        public void getconvert(string from, string to, string amount)
        {
            string addres = "http://api.coinlayer.com/convert?access_key=404c52cdd7fd0f47209fec49b6c120c0&to=" + to + "&from=" + from + "&amount=" + amount;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(addres);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }


            var obj = JsonConvert.DeserializeObject<Amount>(response);
            string res = Convert.ToString(obj.result);
            incurrencytb.Text = res;

        }
    }
}
