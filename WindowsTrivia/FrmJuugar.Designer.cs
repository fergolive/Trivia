namespace WindowsTrivia
{
    partial class FrmJuugar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmJuugar));
            this.lblMovPermitidos = new System.Windows.Forms.Label();
            this.lblMovRealliz = new System.Windows.Forms.Label();
            this.txtPregunta = new System.Windows.Forms.TextBox();
            this.rdb3 = new System.Windows.Forms.RadioButton();
            this.rdb2 = new System.Windows.Forms.RadioButton();
            this.rdb1 = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblContestCorrectas = new System.Windows.Forms.Label();
            this.btnResponder = new System.Windows.Forms.Button();
            this.lblAvisoRespuesta = new System.Windows.Forms.Label();
            this.panelPregResp = new System.Windows.Forms.Panel();
            this.lblerror = new System.Windows.Forms.Label();
            this.btnTirarDados = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnguardar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblUser = new System.Windows.Forms.ToolStripLabel();
            this.panel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panelPregResp.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMovPermitidos
            // 
            this.lblMovPermitidos.AutoSize = true;
            this.lblMovPermitidos.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblMovPermitidos.Location = new System.Drawing.Point(141, 305);
            this.lblMovPermitidos.Name = "lblMovPermitidos";
            this.lblMovPermitidos.Size = new System.Drawing.Size(35, 13);
            this.lblMovPermitidos.TabIndex = 9;
            this.lblMovPermitidos.Text = "label1";
            // 
            // lblMovRealliz
            // 
            this.lblMovRealliz.AutoSize = true;
            this.lblMovRealliz.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblMovRealliz.Location = new System.Drawing.Point(7, 305);
            this.lblMovRealliz.Name = "lblMovRealliz";
            this.lblMovRealliz.Size = new System.Drawing.Size(35, 13);
            this.lblMovRealliz.TabIndex = 10;
            this.lblMovRealliz.Text = "label2";
            // 
            // txtPregunta
            // 
            this.txtPregunta.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtPregunta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPregunta.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txtPregunta.Location = new System.Drawing.Point(3, 3);
            this.txtPregunta.Multiline = true;
            this.txtPregunta.Name = "txtPregunta";
            this.txtPregunta.Size = new System.Drawing.Size(246, 32);
            this.txtPregunta.TabIndex = 12;
            this.txtPregunta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rdb3
            // 
            this.rdb3.AutoSize = true;
            this.rdb3.Location = new System.Drawing.Point(17, 65);
            this.rdb3.Name = "rdb3";
            this.rdb3.Size = new System.Drawing.Size(85, 17);
            this.rdb3.TabIndex = 2;
            this.rdb3.TabStop = true;
            this.rdb3.Text = "radioButton3";
            this.rdb3.UseVisualStyleBackColor = true;
            this.rdb3.CheckedChanged += new System.EventHandler(this.rdb3_CheckedChanged);
            // 
            // rdb2
            // 
            this.rdb2.AutoSize = true;
            this.rdb2.Location = new System.Drawing.Point(16, 39);
            this.rdb2.Name = "rdb2";
            this.rdb2.Size = new System.Drawing.Size(85, 17);
            this.rdb2.TabIndex = 1;
            this.rdb2.TabStop = true;
            this.rdb2.Text = "radioButton2";
            this.rdb2.UseVisualStyleBackColor = true;
            this.rdb2.CheckedChanged += new System.EventHandler(this.rdb2_CheckedChanged);
            // 
            // rdb1
            // 
            this.rdb1.AutoSize = true;
            this.rdb1.Location = new System.Drawing.Point(16, 13);
            this.rdb1.Name = "rdb1";
            this.rdb1.Size = new System.Drawing.Size(85, 17);
            this.rdb1.TabIndex = 0;
            this.rdb1.TabStop = true;
            this.rdb1.Text = "radioButton1";
            this.rdb1.UseVisualStyleBackColor = true;
            this.rdb1.CheckedChanged += new System.EventHandler(this.rdb1_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdb3);
            this.panel2.Controls.Add(this.rdb1);
            this.panel2.Controls.Add(this.rdb2);
            this.panel2.Location = new System.Drawing.Point(3, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(246, 100);
            this.panel2.TabIndex = 14;
            // 
            // lblContestCorrectas
            // 
            this.lblContestCorrectas.AutoSize = true;
            this.lblContestCorrectas.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblContestCorrectas.Location = new System.Drawing.Point(7, 274);
            this.lblContestCorrectas.Name = "lblContestCorrectas";
            this.lblContestCorrectas.Size = new System.Drawing.Size(95, 13);
            this.lblContestCorrectas.TabIndex = 15;
            this.lblContestCorrectas.Text = "Contestaciones ok";
            // 
            // btnResponder
            // 
            this.btnResponder.Location = new System.Drawing.Point(280, 213);
            this.btnResponder.Name = "btnResponder";
            this.btnResponder.Size = new System.Drawing.Size(94, 43);
            this.btnResponder.TabIndex = 16;
            this.btnResponder.Text = "Responder";
            this.btnResponder.UseVisualStyleBackColor = true;
            this.btnResponder.Click += new System.EventHandler(this.btnResponder_Click);
            // 
            // lblAvisoRespuesta
            // 
            this.lblAvisoRespuesta.AutoSize = true;
            this.lblAvisoRespuesta.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblAvisoRespuesta.Location = new System.Drawing.Point(380, 228);
            this.lblAvisoRespuesta.Name = "lblAvisoRespuesta";
            this.lblAvisoRespuesta.Size = new System.Drawing.Size(35, 13);
            this.lblAvisoRespuesta.TabIndex = 17;
            this.lblAvisoRespuesta.Text = "label1";
            // 
            // panelPregResp
            // 
            this.panelPregResp.Controls.Add(this.txtPregunta);
            this.panelPregResp.Controls.Add(this.panel2);
            this.panelPregResp.Location = new System.Drawing.Point(280, 59);
            this.panelPregResp.Name = "panelPregResp";
            this.panelPregResp.Size = new System.Drawing.Size(252, 147);
            this.panelPregResp.TabIndex = 18;
            // 
            // lblerror
            // 
            this.lblerror.AutoSize = true;
            this.lblerror.ForeColor = System.Drawing.Color.Crimson;
            this.lblerror.Location = new System.Drawing.Point(7, 34);
            this.lblerror.Name = "lblerror";
            this.lblerror.Size = new System.Drawing.Size(0, 13);
            this.lblerror.TabIndex = 15;
            // 
            // btnTirarDados
            // 
            this.btnTirarDados.Location = new System.Drawing.Point(280, 260);
            this.btnTirarDados.Name = "btnTirarDados";
            this.btnTirarDados.Size = new System.Drawing.Size(94, 41);
            this.btnTirarDados.TabIndex = 19;
            this.btnTirarDados.Text = "Tirar dados";
            this.btnTirarDados.UseVisualStyleBackColor = true;
            this.btnTirarDados.Click += new System.EventHandler(this.btnTirarDados_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 325);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(538, 22);
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnguardar,
            this.btnSalir,
            this.toolStripSeparator1,
            this.lblUser});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(538, 25);
            this.toolStrip1.TabIndex = 21;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnguardar
            // 
            this.btnguardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnguardar.Image = ((System.Drawing.Image)(resources.GetObject("btnguardar.Image")));
            this.btnguardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(53, 22);
            this.btnguardar.Text = "Guardar";
            this.btnguardar.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(33, 22);
            this.btnSalir.Text = "Salir";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // lblUser
            // 
            this.lblUser.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(46, 22);
            this.lblUser.Text = "usuario";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button10);
            this.panel1.Controls.Add(this.button11);
            this.panel1.Controls.Add(this.button12);
            this.panel1.Controls.Add(this.button13);
            this.panel1.Controls.Add(this.button14);
            this.panel1.Controls.Add(this.button15);
            this.panel1.Controls.Add(this.button16);
            this.panel1.Controls.Add(this.button17);
            this.panel1.Controls.Add(this.button18);
            this.panel1.Location = new System.Drawing.Point(45, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 205);
            this.panel1.TabIndex = 22;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(3, 3);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(60, 60);
            this.button10.TabIndex = 0;
            this.button10.Text = "button10";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Enter += new System.EventHandler(this.button1_Enter);
            this.button10.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttons_KeyDown);
            this.button10.Leave += new System.EventHandler(this.button1_Leave);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(69, 3);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(60, 60);
            this.button11.TabIndex = 1;
            this.button11.Text = "button11";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Enter += new System.EventHandler(this.button1_Enter);
            this.button11.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttons_KeyDown);
            this.button11.Leave += new System.EventHandler(this.button1_Leave);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(135, 3);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(60, 60);
            this.button12.TabIndex = 2;
            this.button12.Text = "button12";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Enter += new System.EventHandler(this.button1_Enter);
            this.button12.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttons_KeyDown);
            this.button12.Leave += new System.EventHandler(this.button1_Leave);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(3, 69);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(60, 60);
            this.button13.TabIndex = 3;
            this.button13.Text = "button13";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Enter += new System.EventHandler(this.button1_Enter);
            this.button13.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttons_KeyDown);
            this.button13.Leave += new System.EventHandler(this.button1_Leave);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(69, 69);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(60, 60);
            this.button14.TabIndex = 4;
            this.button14.Text = "button14";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Enter += new System.EventHandler(this.button1_Enter);
            this.button14.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttons_KeyDown);
            this.button14.Leave += new System.EventHandler(this.button1_Leave);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(135, 69);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(60, 60);
            this.button15.TabIndex = 5;
            this.button15.Text = "button15";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Enter += new System.EventHandler(this.button1_Enter);
            this.button15.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttons_KeyDown);
            this.button15.Leave += new System.EventHandler(this.button1_Leave);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(3, 135);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(60, 60);
            this.button16.TabIndex = 6;
            this.button16.Text = "button16";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Enter += new System.EventHandler(this.button1_Enter);
            this.button16.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttons_KeyDown);
            this.button16.Leave += new System.EventHandler(this.button1_Leave);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(69, 135);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(60, 60);
            this.button17.TabIndex = 7;
            this.button17.Text = "button17";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Enter += new System.EventHandler(this.button1_Enter);
            this.button17.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttons_KeyDown);
            this.button17.Leave += new System.EventHandler(this.button1_Leave);
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(135, 135);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(60, 60);
            this.button18.TabIndex = 8;
            this.button18.Text = "button18";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Enter += new System.EventHandler(this.button1_Enter);
            this.button18.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttons_KeyDown);
            this.button18.Leave += new System.EventHandler(this.button1_Leave);
            // 
            // FrmJuugar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 347);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnTirarDados);
            this.Controls.Add(this.lblerror);
            this.Controls.Add(this.panelPregResp);
            this.Controls.Add(this.lblAvisoRespuesta);
            this.Controls.Add(this.btnResponder);
            this.Controls.Add(this.lblContestCorrectas);
            this.Controls.Add(this.lblMovRealliz);
            this.Controls.Add(this.lblMovPermitidos);
            this.Name = "FrmJuugar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmJuugar";
            this.Load += new System.EventHandler(this.FrmJuugar_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelPregResp.ResumeLayout(false);
            this.panelPregResp.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMovPermitidos;
        private System.Windows.Forms.Label lblMovRealliz;
        private System.Windows.Forms.TextBox txtPregunta;
        private System.Windows.Forms.RadioButton rdb3;
        private System.Windows.Forms.RadioButton rdb2;
        private System.Windows.Forms.RadioButton rdb1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblContestCorrectas;
        private System.Windows.Forms.Button btnResponder;
        private System.Windows.Forms.Label lblAvisoRespuesta;
        private System.Windows.Forms.Panel panelPregResp;
        private System.Windows.Forms.Label lblerror;
        private System.Windows.Forms.Button btnTirarDados;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnguardar;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lblUser;
        private System.Windows.Forms.FlowLayoutPanel panel1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
    }
}