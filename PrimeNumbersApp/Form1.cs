using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace PrimeNumbersApp
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer _computeFor60Seconds = new System.Timers.Timer(60000);

        private bool _continue = false;

        private Font _font;
        private Brush _brush;

        public Form1()
        {
            InitializeComponent();
        }

        private static bool IsPrime(int number)
        {
            int boundary = (int)Math.Floor(Math.Sqrt(number));

            if (number == 1) return false;
            if (number == 2) return true;

            for (int i = 2; i <= boundary; ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        private void ComputePrimesButton_Click(object sender, EventArgs e)
        {
            ComputePrimesButton.Enabled = false;
            _computeFor60Seconds.Elapsed += OnEndTimer;
            _continue = _computeFor60Seconds.Enabled = true;
            int start = 2;
            while (_continue)
            {
                if (IsPrime(start))
                {
                    DisplayPrimeNumberTextbox.Text = start.ToString();
                }
                start++;
            }
            PrintButton.Enabled = true;
        }

        private void OnEndTimer(object sender, ElapsedEventArgs e)
        {
            _continue = _computeFor60Seconds.Enabled = false;
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            printDlg.Document = new System.Drawing.Printing.PrintDocument();
            printDlg.Document.PrinterSettings.PrinterName = "Microsoft XPS Document Writer";
            printDlg.Document.PrinterSettings.PrintToFile = true; 
            if (printDlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            _font = new System.Drawing.Font("Arial", 10);
            _brush = new SolidBrush(Color.Black);
            printDlg.Document.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(PrintPrime_PrintPage);

            printDlg.Document.Print();
        }

        private void PrintPrime_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Nickii Sonnenberg: " + DisplayPrimeNumberTextbox.Text, _font, _brush, 0, 0);
        }
    }
}
