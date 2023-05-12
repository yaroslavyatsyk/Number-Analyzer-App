using Number_Analysis_App;
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

namespace Number_Analyser_App
{
    /// <summary>
    /// Interaction logic for FrequencyWindow.xaml
    /// </summary>
    public partial class FrequencyWindow : Window
    {
        private NumberAnalyser analyser;
        public FrequencyWindow(NumberAnalyser analyser)
        {

            InitializeComponent();
            this.analyser = analyser;

            dataGrid.ItemsSource = analyser.GetDigitFrequencies();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
