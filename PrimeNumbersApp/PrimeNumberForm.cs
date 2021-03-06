﻿using System;
using System.Drawing;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace PrimeNumbersApp
{
    public partial class PrimeNumberForm : Form
    {
        static private int _computeInterval = 60000;
        static private int _interval = 1000;

        private System.Timers.Timer _computeFor60Seconds = new System.Timers.Timer(_interval);

        private int _continue = _computeInterval;

        private Font _font;
        private Brush _brush;

        public PrimeNumberForm()
        {
            InitializeComponent();
            _computeFor60Seconds.Elapsed += OnElapsedTimer;
        }

        private void ComputePrimesButton_Click(object sender, EventArgs e)
        {
            ComputePrimesButton.Enabled = PrintButton.Enabled = false;
            _continue = _computeInterval;
            _computeFor60Seconds.Enabled = true;
            progressBar.Maximum = 60;
            progressBar.Value = 0;

            Thread workerThread = new Thread(new ThreadStart(ComputePrimes));
            workerThread.Start();
        }

        private void ComputePrimes()
        {
            PrimeGenerator generator = new PrimeGenerator();
            generator.PrimeNumberGenerated += Generator_PrimeNumberGenerated;
            int number = 2;
            while (0 < _continue)
            {
                number = generator.GeneratePrimeNumber(number) + 1;
            }
        }

        private void Generator_PrimeNumberGenerated(object sender, PrimeNumberEventArgs e)
        {
            Invoke(new Action(() => DisplayPrimeNumberTextbox.Text = e.PrimeNumber.ToString()));
        }

        private void OnElapsedTimer(object sender, ElapsedEventArgs e)
        {
            _continue -= _interval;
            Invoke(new Action(() => progressBar.Value++));
            if (0 >= _continue)
            {
                _computeFor60Seconds.Stop();
                Invoke(new Action(() => ComputePrimesButton.Enabled = PrintButton.Enabled = true));
            }
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
            // TODO: Print out the numbers generated.
        }
    }
}
