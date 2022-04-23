namespace WindowsTrivia
{
    partial class FrmLogueo
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
            this.lblError = new System.Windows.Forms.TextBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.label2 = new System.Windows.Forms.Label();
            this.userControlLogueo1 = new WindowsTrivia.controles.UserControlLogin();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("A Little Pot", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label1.Location = new System.Drawing.Point(103, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 83);
            this.label1.TabIndex = 0;
            this.label1.Text = "TRIVIA";
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.Gold;
            this.lblError.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblError.Enabled = false;
            this.lblError.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblError.Location = new System.Drawing.Point(12, 226);
            this.lblError.Multiline = true;
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(347, 33);
            this.lblError.TabIndex = 1;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(371, 263);
            this.shapeContainer1.TabIndex = 3;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.rectangleShape1.Location = new System.Drawing.Point(32, 45);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(304, 177);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("A Little Pot", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label2.Location = new System.Drawing.Point(337, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 38);
            this.label2.TabIndex = 4;
            this.label2.Text = "x";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // userControlLogueo1
            // 
            this.userControlLogueo1.BackColor = System.Drawing.Color.Gold;
            this.userControlLogueo1.Location = new System.Drawing.Point(33, 79);
            this.userControlLogueo1.Name = "userControlLogueo1";
            this.userControlLogueo1.Size = new System.Drawing.Size(293, 133);
            this.userControlLogueo1.TabIndex = 2;
            // 
            // FrmLogueo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(371, 263);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userControlLogueo1);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLogueo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLogueo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lblError;
        private controles.UserControlLogin userControlLogueo1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.Label label2;

    }
}