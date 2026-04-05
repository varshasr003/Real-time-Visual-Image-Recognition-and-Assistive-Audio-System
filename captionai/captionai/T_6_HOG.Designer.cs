namespace captionai
{
    partial class T_6_HOG
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
            this.label10 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hogpattern = new System.Windows.Forms.PictureBox();
            this.hogcanny = new System.Windows.Forms.PictureBox();
            this.canny = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.hogpattern)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hogcanny)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canny)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 35.25F);
            this.label10.ForeColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(3, -7);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(899, 78);
            this.label10.TabIndex = 141;
            this.label10.Text = "Histogram of Orientied Gradients";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(693, 400);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(319, 43);
            this.button3.TabIndex = 140;
            this.button3.Text = "Proceed";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(689, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 24);
            this.label3.TabIndex = 139;
            this.label3.Text = "HOG pattern";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(360, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 24);
            this.label2.TabIndex = 137;
            this.label2.Text = "HOG";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(33, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 24);
            this.label1.TabIndex = 135;
            this.label1.Text = "Edge Detected";
            // 
            // hogpattern
            // 
            this.hogpattern.Location = new System.Drawing.Point(693, 107);
            this.hogpattern.Margin = new System.Windows.Forms.Padding(4);
            this.hogpattern.Name = "hogpattern";
            this.hogpattern.Size = new System.Drawing.Size(319, 286);
            this.hogpattern.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hogpattern.TabIndex = 138;
            this.hogpattern.TabStop = false;
            // 
            // hogcanny
            // 
            this.hogcanny.Location = new System.Drawing.Point(364, 107);
            this.hogcanny.Margin = new System.Windows.Forms.Padding(4);
            this.hogcanny.Name = "hogcanny";
            this.hogcanny.Size = new System.Drawing.Size(319, 286);
            this.hogcanny.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hogcanny.TabIndex = 136;
            this.hogcanny.TabStop = false;
            // 
            // canny
            // 
            this.canny.Location = new System.Drawing.Point(37, 107);
            this.canny.Margin = new System.Windows.Forms.Padding(4);
            this.canny.Name = "canny";
            this.canny.Size = new System.Drawing.Size(319, 286);
            this.canny.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.canny.TabIndex = 134;
            this.canny.TabStop = false;
            // 
            // T_6_HOG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(27)))), ((int)(((byte)(152)))));
            this.ClientSize = new System.Drawing.Size(1017, 450);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hogpattern);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hogcanny);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.canny);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "T_6_HOG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "T_6_HOG";
            ((System.ComponentModel.ISupportInitialize)(this.hogpattern)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hogcanny)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canny)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox hogpattern;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox hogcanny;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox canny;
    }
}