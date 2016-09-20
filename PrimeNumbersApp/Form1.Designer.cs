namespace PrimeNumbersApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ComputePrimesButton = new System.Windows.Forms.Button();
            this.DisplayPrimeNumberTextbox = new System.Windows.Forms.TextBox();
            this.PrintButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ComputePrimesButton
            // 
            this.ComputePrimesButton.Location = new System.Drawing.Point(12, 12);
            this.ComputePrimesButton.Name = "ComputePrimesButton";
            this.ComputePrimesButton.Size = new System.Drawing.Size(121, 23);
            this.ComputePrimesButton.TabIndex = 0;
            this.ComputePrimesButton.Text = "Compute Primes:";
            this.ComputePrimesButton.UseVisualStyleBackColor = true;
            this.ComputePrimesButton.Click += new System.EventHandler(this.ComputePrimesButton_Click);
            // 
            // DisplayPrimeNumberTextbox
            // 
            this.DisplayPrimeNumberTextbox.Location = new System.Drawing.Point(139, 15);
            this.DisplayPrimeNumberTextbox.Name = "DisplayPrimeNumberTextbox";
            this.DisplayPrimeNumberTextbox.ReadOnly = true;
            this.DisplayPrimeNumberTextbox.Size = new System.Drawing.Size(133, 20);
            this.DisplayPrimeNumberTextbox.TabIndex = 1;
            // 
            // PrintButton
            // 
            this.PrintButton.Enabled = false;
            this.PrintButton.Location = new System.Drawing.Point(139, 68);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(75, 23);
            this.PrintButton.TabIndex = 2;
            this.PrintButton.Text = "Print to XPS";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.DisplayPrimeNumberTextbox);
            this.Controls.Add(this.ComputePrimesButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ComputePrimesButton;
        private System.Windows.Forms.TextBox DisplayPrimeNumberTextbox;
        private System.Windows.Forms.Button PrintButton;
    }
}

