namespace AUTHENTY_SECAO
{
    partial class FormGrafico
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
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.lblEixoX = new System.Windows.Forms.Label();
            this.lblEixoY = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cartesianChart1.BackColor = System.Drawing.Color.White;
            this.cartesianChart1.Location = new System.Drawing.Point(61, 10);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(681, 404);
            this.cartesianChart1.TabIndex = 2;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // lblEixoX
            // 
            this.lblEixoX.AutoSize = true;
            this.lblEixoX.Location = new System.Drawing.Point(373, 417);
            this.lblEixoX.Name = "lblEixoX";
            this.lblEixoX.Size = new System.Drawing.Size(21, 13);
            this.lblEixoX.TabIndex = 3;
            this.lblEixoX.Text = "Mx";
            // 
            // lblEixoY
            // 
            this.lblEixoY.AutoSize = true;
            this.lblEixoY.Location = new System.Drawing.Point(34, 193);
            this.lblEixoY.Name = "lblEixoY";
            this.lblEixoY.Size = new System.Drawing.Size(21, 13);
            this.lblEixoY.TabIndex = 4;
            this.lblEixoY.Text = "My";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(187, 452);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "LN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 475);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "LN";
            // 
            // FormGrafico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 545);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEixoY);
            this.Controls.Add(this.lblEixoX);
            this.Controls.Add(this.cartesianChart1);
            this.Name = "FormGrafico";
            this.Text = "FormGrafico";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.Label lblEixoX;
        private System.Windows.Forms.Label lblEixoY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}