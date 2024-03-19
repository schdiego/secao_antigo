namespace AUTHENTY_SECAO
{
    partial class FormSecaoTransversal
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelForm = new System.Windows.Forms.Panel();
            this.btnPoligonal = new System.Windows.Forms.Button();
            this.btnTe = new System.Windows.Forms.Button();
            this.btnEle = new System.Windows.Forms.Button();
            this.btnCircular = new System.Windows.Forms.Button();
            this.pBoxDesenho = new System.Windows.Forms.PictureBox();
            this.btnRetangular = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxDesenho)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Selecione o tipo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(13, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "SEÇÃO TRANSVERSAL";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(148)))), ((int)(((byte)(213)))));
            this.panel1.Location = new System.Drawing.Point(445, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 544);
            this.panel1.TabIndex = 11;
            // 
            // panelForm
            // 
            this.panelForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelForm.BackColor = System.Drawing.Color.White;
            this.panelForm.Location = new System.Drawing.Point(0, 149);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(445, 395);
            this.panelForm.TabIndex = 12;
            // 
            // btnPoligonal
            // 
            this.btnPoligonal.BackColor = System.Drawing.Color.White;
            this.btnPoligonal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPoligonal.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPoligonal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnPoligonal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnPoligonal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPoligonal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPoligonal.Image = global::AUTHENTY_SECAO.Properties.Resources.Poligonal_50x50_;
            this.btnPoligonal.Location = new System.Drawing.Point(360, 54);
            this.btnPoligonal.Name = "btnPoligonal";
            this.btnPoligonal.Size = new System.Drawing.Size(63, 73);
            this.btnPoligonal.TabIndex = 4;
            this.btnPoligonal.UseVisualStyleBackColor = false;
            this.btnPoligonal.Click += new System.EventHandler(this.btnPoligonal_Click);
            // 
            // btnTe
            // 
            this.btnTe.BackColor = System.Drawing.Color.White;
            this.btnTe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTe.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnTe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnTe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTe.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTe.Image = global::AUTHENTY_SECAO.Properties.Resources.Te_50x50_;
            this.btnTe.Location = new System.Drawing.Point(275, 54);
            this.btnTe.Name = "btnTe";
            this.btnTe.Size = new System.Drawing.Size(63, 73);
            this.btnTe.TabIndex = 3;
            this.btnTe.UseVisualStyleBackColor = false;
            this.btnTe.Click += new System.EventHandler(this.btnTe_Click);
            // 
            // btnEle
            // 
            this.btnEle.BackColor = System.Drawing.Color.White;
            this.btnEle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEle.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnEle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnEle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEle.Image = global::AUTHENTY_SECAO.Properties.Resources.Ele_50x50_;
            this.btnEle.Location = new System.Drawing.Point(190, 54);
            this.btnEle.Name = "btnEle";
            this.btnEle.Size = new System.Drawing.Size(63, 73);
            this.btnEle.TabIndex = 2;
            this.btnEle.UseVisualStyleBackColor = false;
            this.btnEle.Click += new System.EventHandler(this.btnEle_Click);
            // 
            // btnCircular
            // 
            this.btnCircular.BackColor = System.Drawing.Color.White;
            this.btnCircular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCircular.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCircular.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCircular.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnCircular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCircular.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCircular.Image = global::AUTHENTY_SECAO.Properties.Resources.Circulo__50x50_;
            this.btnCircular.Location = new System.Drawing.Point(105, 54);
            this.btnCircular.Name = "btnCircular";
            this.btnCircular.Size = new System.Drawing.Size(63, 73);
            this.btnCircular.TabIndex = 1;
            this.btnCircular.UseVisualStyleBackColor = false;
            this.btnCircular.Click += new System.EventHandler(this.btnCircular_Click);
            // 
            // pBoxDesenho
            // 
            this.pBoxDesenho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pBoxDesenho.BackColor = System.Drawing.Color.White;
            this.pBoxDesenho.Location = new System.Drawing.Point(455, 0);
            this.pBoxDesenho.Name = "pBoxDesenho";
            this.pBoxDesenho.Size = new System.Drawing.Size(497, 544);
            this.pBoxDesenho.TabIndex = 10;
            this.pBoxDesenho.TabStop = false;
            // 
            // btnRetangular
            // 
            this.btnRetangular.BackColor = System.Drawing.Color.White;
            this.btnRetangular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetangular.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRetangular.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnRetangular.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnRetangular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetangular.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRetangular.Image = global::AUTHENTY_SECAO.Properties.Resources.Retangular__50x50_;
            this.btnRetangular.Location = new System.Drawing.Point(20, 54);
            this.btnRetangular.Name = "btnRetangular";
            this.btnRetangular.Size = new System.Drawing.Size(63, 73);
            this.btnRetangular.TabIndex = 0;
            this.btnRetangular.UseVisualStyleBackColor = false;
            this.btnRetangular.Click += new System.EventHandler(this.btnRetangular_Click);
            // 
            // FormSecaoTransversal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(952, 544);
            this.Controls.Add(this.btnPoligonal);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.btnTe);
            this.Controls.Add(this.btnEle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCircular);
            this.Controls.Add(this.pBoxDesenho);
            this.Controls.Add(this.btnRetangular);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSecaoTransversal";
            this.Text = "SecaoTransversal";
            ((System.ComponentModel.ISupportInitialize)(this.pBoxDesenho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.PictureBox pBoxDesenho;
        private System.Windows.Forms.Button btnRetangular;
        private System.Windows.Forms.Button btnCircular;
        private System.Windows.Forms.Button btnPoligonal;
        private System.Windows.Forms.Button btnTe;
        private System.Windows.Forms.Button btnEle;
        public System.Windows.Forms.Panel panelForm;
    }
}