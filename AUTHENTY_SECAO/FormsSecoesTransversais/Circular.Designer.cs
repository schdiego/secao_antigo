namespace AUTHENTY_SECAO.FormsSecoesTransversais
{
    partial class Circular
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
            this.lbl_cm_1 = new System.Windows.Forms.Label();
            this.tBoxDiametro = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_cm_1
            // 
            this.lbl_cm_1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_cm_1.AutoSize = true;
            this.lbl_cm_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbl_cm_1.Location = new System.Drawing.Point(212, 51);
            this.lbl_cm_1.Name = "lbl_cm_1";
            this.lbl_cm_1.Size = new System.Drawing.Size(26, 17);
            this.lbl_cm_1.TabIndex = 13;
            this.lbl_cm_1.Text = "cm";
            // 
            // tBoxDiametro
            // 
            this.tBoxDiametro.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tBoxDiametro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tBoxDiametro.Location = new System.Drawing.Point(110, 48);
            this.tBoxDiametro.Name = "tBoxDiametro";
            this.tBoxDiametro.Size = new System.Drawing.Size(100, 23);
            this.tBoxDiametro.TabIndex = 12;
            this.tBoxDiametro.Text = "25";
            this.tBoxDiametro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBoxDiametro.TextChanged += new System.EventHandler(this.tBoxDiametro_TextChanged);
            this.tBoxDiametro.Leave += new System.EventHandler(this.tBoxDiametro_Leave);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(31, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Diametro";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(148)))), ((int)(((byte)(213)))));
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(159)))), ((int)(((byte)(217)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmar.Location = new System.Drawing.Point(297, 257);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(103, 40);
            this.btnConfirmar.TabIndex = 31;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AUTHENTY_SECAO.Properties.Resources.CIRCULAR__175x200_png;
            this.pictureBox1.Location = new System.Drawing.Point(244, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 186);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // Circular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(445, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lbl_cm_1);
            this.Controls.Add(this.tBoxDiametro);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Circular";
            this.Text = "Circular";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_cm_1;
        public System.Windows.Forms.TextBox tBoxDiametro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}