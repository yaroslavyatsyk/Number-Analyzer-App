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
using System.Numerics;

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
                long number = long.Parse(EnterNumberBox.Text);
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
                    dialog.FileName = "Number Analysis Report " +  DateTime.Today.ToString("yyyy/MM/dd");
                    dialog.ShowDialog();

                    if (dialog.FileName != "")
                    {
                        iTextSharp.text.Document document = new iTextSharp.text.Document();

                        // Specify the file stream in the PdfWriter.GetInstance
                        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(dialog.FileName, FileMode.Create));
                        writer.PageEvent = new PdfPageEventHelper();  // Set PageEvent to handle headers and footers

                        document.Open();

                        // Add title to the document
                        var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                        var titleParagraph = new iTextSharp.text.Paragraph("Number Analysis Report", titleFont);
                        titleParagraph.Alignment = Element.ALIGN_CENTER;
                        document.Add(titleParagraph);

                        // Add date to the document
                        var dateFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                        var dateParagraph = new iTextSharp.text.Paragraph("Date: " + DateTime.Today.ToString("yyyy/MM/dd"), dateFont);
                        dateParagraph.Alignment = Element.ALIGN_RIGHT;
                        document.Add(dateParagraph);

                        document.Add(new iTextSharp.text.Paragraph("\n"));


                        // Add content to the PDF (as in your existing code)

                        PdfPTable reportTable = new PdfPTable(2);

                        reportTable.AddCell("Number");
                        reportTable.AddCell(numberAnalysis.Number.ToString());

                        reportTable.AddCell("Number of Digits");
                        reportTable.AddCell(numberAnalysis.GetDigitsCount().ToString());

                        reportTable.AddCell("Sum of Digits");
                        reportTable.AddCell(numberAnalysis.GetSumOfDigits().ToString());

                        reportTable.AddCell("Product of Digits");
                        reportTable.AddCell(numberAnalysis.GetProductOfDigits().ToString());

                        reportTable.AddCell("Binary");
                        reportTable.AddCell(numberAnalysis.ToBinary().ToString());

                        reportTable.AddCell("Octal");
                        reportTable.AddCell(numberAnalysis.ToOctal().ToString());

                        reportTable.AddCell("Hexadecimal");
                        reportTable.AddCell(numberAnalysis.ToHexadecimal().ToString());

                        reportTable.AddCell("Prime Number");
                        if(numberAnalysis.isPrimeNumber())
                        {
                            reportTable.AddCell("Yes");
                        }
                        else
                        {
                            reportTable.AddCell("No");
                        }

                        reportTable.AddCell("Palindrome");
                        if(numberAnalysis.IsPalindrome())
                        {
                            reportTable.AddCell("Yes");
                        }
                        else
                        {
                            reportTable.AddCell("No");
                        }

                        reportTable.AddCell("Amstrong Number");
                        if(numberAnalysis.IsAmstrongNumber())
                        {
                            reportTable.AddCell("Yes");
                        }
                        else
                        {
                            reportTable.AddCell("No");
                        }

                        reportTable.AddCell("Largest Digit");
                        reportTable.AddCell(numberAnalysis.GetLargestDigit().ToString());

                        reportTable.AddCell("Smallest Digit");
                        reportTable.AddCell(numberAnalysis.GetSmallestDigit().ToString());

                        reportTable.AddCell("Perfect Number");
                        if(numberAnalysis.IsPerfectNumber())
                        {
                            reportTable.AddCell("Yes");
                        }
                        else
                        {
                            reportTable.AddCell("No");
                        }

                        reportTable.AddCell("Even Digits");
                        if(numberAnalysis.ContainsEvenDigits())
                        {
                            reportTable.AddCell("Yes");
                        }
                        else
                        {
                            reportTable.AddCell("No");
                        }

                        reportTable.AddCell("Odd Digits");
                        if(numberAnalysis.ContainsOddDigits())
                        {
                            reportTable.AddCell("Yes");
                        }
                        else
                        {
                            reportTable.AddCell("No");
                        }

                        reportTable.AddCell("Factorial");
                        if(numberAnalysis.IsFactorial())
                        {
                            reportTable.AddCell("Yes");
                        }
                        else
                        {
                            reportTable.AddCell("No");
                        }

                        reportTable.AddCell("Strong Number");
                        if(numberAnalysis.IsStrongNumber())
                        {
                            reportTable.AddCell("Yes");
                        }
                        else
                        {
                            reportTable.AddCell("No");
                        }
                       
                       
                        document.Add(reportTable);


                        var titleTable = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                        var titleTableParagraph = new iTextSharp.text.Paragraph("Digit Frequencies", titleTable);
                        titleTableParagraph.Alignment = Element.ALIGN_CENTER;
                        document.Add(titleTableParagraph);


                        document.Add(new iTextSharp.text.Paragraph("\n"));

                   

                        // Add table with digit frequencies
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

                        writer.Close();

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
