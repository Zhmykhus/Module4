using System.Net.Http;
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

namespace Module4WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private string getPhoneNumber;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void GetDataButton_Click(object sender, RoutedEventArgs e)
        {
            await GetPhoneNumber();
        }

        private async Task GetPhoneNumber()
        {
            var responce = await httpClient.GetAsync("http://localhost:4444/TransferSimulator/mobilePhone");
            if(responce.IsSuccessStatusCode)
            {
                getPhoneNumber = await responce.Content.ReadAsStringAsync();
                PhoneNumberTextBox.Text = getPhoneNumber;
            }
            else
            {
                ResultTextBlock.Text = "Ошибка!";
            }
        }

        private void SendResultButton_Click(object sender, RoutedEventArgs e)
        {
            string phoneNumber = PhoneNumberTextBox.Text;

            if(ValidatePhoneNumber(phoneNumber))
            {
                ResultTextBlock.Text = "Номер валиден";
            }
            else
            {
                ResultTextBlock.Text = "Некорректный номер телефона";
            }
        }

        private bool ValidatePhoneNumber(string phoneNumber)
        {
           return phoneNumber.Length == 12 && phoneNumber.StartsWith("7") || phoneNumber.Length == 12 && phoneNumber.StartsWith("8");
        }
    }
}