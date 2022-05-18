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
    /// Логика взаимодействия для ValPage.xaml
    /// </summary>
    public partial class ValPage : Page
    {
        public ValPage()
        {
            InitializeComponent();
            this.fromcurrencytb.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput);
            this.incurrencytb.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput);


        }

        void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        public void get(string source)
        {

          
            string addres = "https://api.apilayer.com/currency_data/live?source="+ source +"&currencies=USD%2CEUR%2CCNY%2CJPY%2CRUB&apikey=UMF4vxJ2vEPUgBaLhU5IuJtTnfdj68PF";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(addres);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }
            dynamic obj = JsonConvert.DeserializeObject(response);
            var quotes1 = obj.quotes;
            if (source == "RUB")
            {
                string usd = (string)quotes1.RUBUSD;
                string eur = (string)quotes1.RUBEUR;
                string cny = (string)quotes1.RUBCNY;
                string jpy = (string)quotes1.RUBJPY;
                string rub = (string)quotes1.RUBRUB;
                usdtb.Text = usd;
                eurtb.Text = eur;
                cnytb.Text = cny;
                jpytb.Text = jpy;
                rubtb.Text = rub;
            }
            else if (source == "USD")
            {
                string usd = (string)quotes1.USDUSD;
                string eur = (string)quotes1.USDEUR;
                string cny = (string)quotes1.USDCNY;
                string jpy = (string)quotes1.USDJPY;
                string rub = (string)quotes1.USDRUB;
                usdtb.Text = usd;
                eurtb.Text = eur;
                cnytb.Text = cny;
                jpytb.Text = jpy;
                rubtb.Text = rub;
            }
            
        }

        public void getconvert(  string from, string to,  string amount)
        {
            string addres = "https://api.apilayer.com/currency_data/convert?to="+to+"&from="+from+"&amount=" + amount+ "&apikey=UMF4vxJ2vEPUgBaLhU5IuJtTnfdj68PF";
            
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

        private void CurreBtn_Click(object sender, RoutedEventArgs e)
        {
            var curr = JsonConvert.DeserializeObject<Currencyinfo>(File.ReadAllText("currency.json"));
            string currencyinfo = Convert.ToString(curr.Currency);
            get(currencyinfo);
        }

        private void ConvertBtn_Click(object sender, RoutedEventArgs e)
        {
            string amountcyr = fromcurrencytb.Text;
            string fromitem;
            string toitem;

            if (ConvertfromCB.SelectedItem == "")
            {
                MessageBox.Show("Заполните первое поле для конвертации");
            }
            else
            {
                switch (ConvertfromCB.SelectedIndex)
                    {
                        case 0:
                            fromitem = "USD";
                            break;
                        case 1:
                            fromitem = "EUR";
                            break;
                        case 2:
                            fromitem = "CNY";
                            break;
                        case 3:
                            fromitem = "JPY";
                            break;
                        case 4:
                            fromitem = "RUB";
                            break;
                        default:
                            fromitem = "USD";
                            break;
                    }

                switch (ConvertinCB.SelectedIndex)
                    {
                        case 0:
                            toitem = "USD";
                            break;
                        case 1:
                            toitem = "EUR";
                            break;
                        case 2:
                            toitem = "CNY";
                            break;
                        case 3:
                            toitem = "JPY";
                            break;
                        case 4:
                            toitem = "RUB";
                            break;
                        default:
                            toitem = "RUB";
                            break;
                }

                getconvert(fromitem, toitem, amountcyr);



            }
            
        }
    }   
}
