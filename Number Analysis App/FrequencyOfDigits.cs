using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Number_Analysis_App;

namespace Number_Analysis_App
{


    public partial class FrequencyOfDigits : Form
    {
        private NumberAnalyser numberAnalysis;
        public FrequencyOfDigits(NumberAnalyser numberAnalysis)
        {

            InitializeComponent();
            this.numberAnalysis = numberAnalysis;

            var frequencyOfDigits = numberAnalysis.GetDigitFrequencies();

            dataGridView1.RowCount = frequencyOfDigits.Keys.Count;

            dataGridView1.ColumnCount = 2;

            dataGridView1.Columns[0].Name = "Digit";
            dataGridView1.Columns[1].Name = "Frequency";

            for(int i = 0; i < frequencyOfDigits.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = frequencyOfDigits.Keys.ElementAt(i);
                dataGridView1.Rows[i].Cells[1].Value = frequencyOfDigits.Values.ElementAt(i);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
   
            this.Hide();
        }
    }
}
