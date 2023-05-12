using Number_Analyser_App;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Number_Analysis_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       private NumberAnalyser numberAnalysis;
     
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int number = Convert.ToInt32(EnterNumberBox.Text);
                numberAnalysis = new NumberAnalyser(number);

                ShowNumberBox.Text = numberAnalysis.Number.ToString();

                ShowDigitsOfNumberBox.Text = numberAnalysis.GetDigitsCount().ToString();

                SumOfDigitsBox.Text = numberAnalysis.GetSumOfDigits().ToString();
                ProductOfDigitsBox.Text = numberAnalysis.GetProductOfDigits().ToString();

                BinaryTextBox.Text = numberAnalysis.ToBinary().ToString();

                OctalTextBox.Text = numberAnalysis.ToOctal().ToString();

                HexaDecimalTextBox.Text = numberAnalysis.ToHexadecimal().ToString();

                if(numberAnalysis.isPrimeNumber())
                {
                    PrimeNumberBox.Text = "Yes";
                }
                else
                {
                    PrimeNumberBox.Text = "No";
                }

                if(numberAnalysis.IsPalindrome())
                {
                    PalindromeTextBox.Text = "Yes";
                }
                else
                {
                    PalindromeTextBox.Text = "No";
                }

                if(numberAnalysis.IsAmstrongNumber())
                {
                    AmstrongTextBox.Text = "Yes";
                }
                else
                {
                    AmstrongTextBox.Text = "No";
                }
                MaxDigitBox.Text = numberAnalysis.GetLargestDigit().ToString();
                MinDigitBox.Text = numberAnalysis.GetSmallestDigit().ToString();

                if (numberAnalysis.IsPerfectNumber())
                {
                    PerfectNumberBox.Text = "Yes";
                }
                else
                {
                    PerfectNumberBox.Text = "No";
                }

                if(numberAnalysis.ContainsEvenDigits())
                {
                    EvenDigitsBox.Text = "Yes";
                }
                else
                {
                    EvenDigitsBox.Text = "No";
                }

                if(numberAnalysis.ContainsOddDigits())
                {
                    OddDigitsBox.Text = "Yes";
                }
                else
                {
                    OddDigitsBox.Text = "No";
                }

                FrequencyWindow frequency_OF_Digits = new FrequencyWindow(numberAnalysis);

                frequency_OF_Digits.Show();

                
         
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, Should be a number","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
