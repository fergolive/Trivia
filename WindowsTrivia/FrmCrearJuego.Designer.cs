namespace WindowsTrivia
{
    partial class FrmCrearJuego
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCrearJuego));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.txtUser = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCantMovimientos = new System.Windows.Forms.Label();
            this.lblFechaHoraFin = new System.Windows.Forms.Label();
            this.lblFechaHoraInicio = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnJugar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblContestOk = new System.Windows.Forms.Label();
            this.lbltitulo = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator4,
            this.txtUser,
            this.toolStripSeparator2,
            this.btnNuevo,
            this.toolStripSeparator3,
            this.toolStripButton1,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(85, 306);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("A Little Pot", 19F);
            this.toolStripLabel1.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(82, 41);
            this.toolStripLabel1.Text = "TRIVIA";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(82, 6);
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUser.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(82, 19);
            this.txtUser.Text = "usuario";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(82, 6);
            // 
            // btnNuevo
            // 
            this.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(82, 19);
            this.btnNuevo.Text = "Nuevo Juego";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(82, 6);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Checked = true;
            this.toolStripButton1.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(82, 19);
            this.toolStripButton1.Text = "Salir";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(82, 6);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(147, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha Hora Inicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(160, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha Hora Fin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(100, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cantidad de movimientos";
            // 
            // lblCantMovimientos
            // 
            this.lblCantMovimientos.AutoSize = true;
            this.lblCantMovimientos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantMovimientos.ForeColor = System.Drawing.Color.Black;
            this.lblCantMovimientos.Location = new System.Drawing.Point(279, 183);
            this.lblCantMovimientos.Name = "lblCantMovimientos";
            this.lblCantMovimientos.Size = new System.Drawing.Size(14, 15);
            this.lblCantMovimientos.TabIndex = 5;
            this.lblCantMovimientos.Text = "0";
            // 
            // lblFechaHoraFin
            // 
            this.lblFechaHoraFin.AutoSize = true;
            this.lblFechaHoraFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHoraFin.ForeColor = System.Drawing.Color.Black;
            this.lblFechaHoraFin.Location = new System.Drawing.Point(279, 149);
            this.lblFechaHoraFin.Name = "lblFechaHoraFin";
            this.lblFechaHoraFin.Size = new System.Drawing.Size(108, 15);
            this.lblFechaHoraFin.TabIndex = 6;
            this.lblFechaHoraFin.Text = "00-00-00 00:00:00";
            // 
            // lblFechaHoraInicio
            // 
            this.lblFechaHoraInicio.AutoSize = true;
            this.lblFechaHoraInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHoraInicio.ForeColor = System.Drawing.Color.Black;
            this.lblFechaHoraInicio.Location = new System.Drawing.Point(279, 116);
            this.lblFechaHoraInicio.Name = "lblFechaHoraInicio";
            this.lblFechaHoraInicio.Size = new System.Drawing.Size(108, 15);
            this.lblFechaHoraInicio.TabIndex = 7;
            this.lblFechaHoraInicio.Text = "00-00-00 00:00:00";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumero.ForeColor = System.Drawing.Color.Black;
            this.lblNumero.Location = new System.Drawing.Point(279, 82);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(14, 15);
            this.lblNumero.TabIndex = 9;
            this.lblNumero.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(204, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Numero";
            // 
            // btnJugar
            // 
            this.btnJugar.BackColor = System.Drawing.Color.Gold;
            this.btnJugar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJugar.Font = new System.Drawing.Font("A Little Pot", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJugar.ForeColor = System.Drawing.Color.Black;
            this.btnJugar.Location = new System.Drawing.Point(297, 250);
            this.btnJugar.Name = "btnJugar";
            this.btnJugar.Size = new System.Drawing.Size(91, 47);
            this.btnJugar.TabIndex = 10;
            this.btnJugar.Text = "Jugar";
            this.btnJugar.UseVisualStyleBackColor = false;
            this.btnJugar.Click += new System.EventHandler(this.btnJugar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(98, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Contestaciones Correctas";
            // 
            // lblContestOk
            // 
            this.lblContestOk.AutoSize = true;
            this.lblContestOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContestOk.ForeColor = System.Drawing.Color.Black;
            this.lblContestOk.Location = new System.Drawing.Point(279, 218);
            this.lblContestOk.Name = "lblContestOk";
            this.lblContestOk.Size = new System.Drawing.Size(14, 15);
            this.lblContestOk.TabIndex = 12;
            this.lblContestOk.Text = "0";
            // 
            // lbltitulo
            // 
            this.lbltitulo.AutoSize = true;
            this.lbltitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitulo.ForeColor = System.Drawing.Color.Black;
            this.lbltitulo.Location = new System.Drawing.Point(140, 55);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.Size = new System.Drawing.Size(0, 15);
            this.lbltitulo.TabIndex = 13;
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.Gold;
            this.lblError.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblError.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblError.Location = new System.Drawing.Point(93, 4);
            this.lblError.Multiline = true;
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(305, 36);
            this.lblError.TabIndex = 14;
            // 
            // FrmCrearJuego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(405, 306);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lbltitulo);
            this.Controls.Add(this.lblContestOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnJugar);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblFechaHoraInicio);
            this.Controls.Add(this.lblFechaHoraFin);
            this.Controls.Add(this.lblCantMovimientos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCrearJuego";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel txtUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCantMovimientos;
        private System.Windows.Forms.Label lblFechaHoraFin;
        private System.Windows.Forms.Label lblFechaHoraInicio;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnJugar;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblContestOk;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label lbltitulo;
        private System.Windows.Forms.TextBox lblError;

    }
}