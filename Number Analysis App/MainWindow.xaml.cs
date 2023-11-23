using Number_Analyser_App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Forms;

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

                if(numberAnalysis.IsFactorial())
                {
                    IsFactorialTextBox.Text = "Yes";
                }
                else
                {
                    IsFactorialTextBox.Text = "No";
                }

                if(numberAnalysis.IsStrongNumber())
                {
                    IsStrongNumberTextBox.Text = "Yes";
                }
                else
                {
                    IsStrongNumberTextBox.Text = "No";
                    }
                FrequencyWindow frequency_OF_Digits = new FrequencyWindow(numberAnalysis);

                frequency_OF_Digits.Show();

                
         
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error, Should be a number","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (numberAnalysis is not null)
            {

                using (SaveFileDialog dialog = new SaveFileDialog())
                {

                    dialog.Filter = "PDF Files (*.pdf)|*.pdf";
                    dialog.DefaultExt = "pdf";
                    dialog.AddExtension = true;
                    dialog.FileName = "Number Analysis Report";
                    dialog.ShowDialog();

                    if (dialog.FileName != "")
                    {
                        iTextSharp.text.Document document = new iTextSharp.text.Document();
                        PdfWriter.GetInstance(document, new FileStream(dialog.FileName, FileMode.Create));
                        document.Open();
                        document.AddTitle("Number Analysis Report");
                        document.AddCreationDate();
                        document.Add(new iTextSharp.text.Paragraph("Number: " + numberAnalysis.Number.ToString()));
                        document.Add(new iTextSharp.text.Paragraph("Number of Digits: " + numberAnalysis.GetDigitsCount().ToString()));
                        document.Add(new iTextSharp.text.Paragraph("Sum of Digits: " + numberAnalysis.GetSumOfDigits().ToString()));
                        document.Add(new iTextSharp.text.Paragraph("Product of Digits: " + numberAnalysis.GetProductOfDigits().ToString()));
                        document.Add(new iTextSharp.text.Paragraph("Binary: " + numberAnalysis.ToBinary().ToString()));
                        document.Add(new iTextSharp.text.Paragraph("Octal: " + numberAnalysis.ToOctal().ToString()));
                        document.Add(new iTextSharp.text.Paragraph("Hexadecimal: " + numberAnalysis.ToHexadecimal().ToString()));
                        document.Add(new iTextSharp.text.Paragraph("Prime Number: " + numberAnalysis.isPrimeNumber().ToString()));
                        document.Add(new iTextSharp.text.Paragraph("Palindrome: " + numberAnalysis.IsPalindrome().ToString()));
                        document.Add(new iTextSharp.text.Paragraph("Amstrong Number: " + numberAnalysis.IsAmstrongNumber().ToString()));
                        document.Add(new iTextSharp.text.Paragraph("Max Digit: " + numberAnalysis.GetLargestDigit().ToString()));
                        document.Add(new iTextSharp.text.Paragraph("Min Digit: " + numberAnalysis.GetSmallestDigit().ToString()));
                        document.Add(new iTextSharp.text.Paragraph("Perfect Number: " + numberAnalysis.IsPerfectNumber().ToString()));
                        document.Add(new iTextSharp.text.Paragraph("Contains Even Digits: " + numberAnalysis.ContainsEvenDigits().ToString()));
                        document.Add(new iTextSharp.text.Paragraph("Contains Odd Digits: " + numberAnalysis.ContainsOddDigits().ToString()));
                        document.Add(new iTextSharp.text.Paragraph("Is Factorial: " + numberAnalysis.IsFactorial().ToString()));
                        document.Add(new iTextSharp.text.Paragraph("Is Strong Number: " + numberAnalysis.IsStrongNumber().ToString()));

                        document.AddTitle("Frequency of Digits");

                        PdfPTable table = new PdfPTable(2);

                        table.AddCell("Digit");
                        table.AddCell("Frequency");


                        var map = numberAnalysis.GetDigitFrequencies();

                        foreach (var item in map)
                        {
                            table.AddCell(item.Key.ToString());
                            table.AddCell(item.Value.ToString());
                        }

                        document.Add(table);
                        document.Close();
                        System.Windows.MessageBox.Show("Report Saved Successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                   




                   

                   

                }
            }
            else
            {
                System.Windows.MessageBox.Show("Please enter a number first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
