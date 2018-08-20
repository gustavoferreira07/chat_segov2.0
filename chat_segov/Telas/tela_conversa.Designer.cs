namespace chat_segov.Telas
{
    partial class tela_conversa
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tela_conversa));
            this.cbbDesti = new MetroFramework.Controls.MetroComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_status = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtMensagem = new MetroFramework.Controls.MetroTextBox();
            this.btn_enviar = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // cbbDesti
            // 
            this.cbbDesti.FormattingEnabled = true;
            this.cbbDesti.ItemHeight = 23;
            this.cbbDesti.Location = new System.Drawing.Point(6, 19);
            this.cbbDesti.Name = "cbbDesti";
            this.cbbDesti.Size = new System.Drawing.Size(156, 29);
            this.cbbDesti.TabIndex = 0;
            this.cbbDesti.UseSelectable = true;
            this.cbbDesti.SelectedIndexChanged += new System.EventHandler(this.cbbDesti_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbbDesti);
            this.groupBox1.Location = new System.Drawing.Point(23, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 67);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Destinatário";
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(413, 142);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(81, 19);
            this.lbl_status.TabIndex = 2;
            this.lbl_status.Text = "metroLabel1";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(23, 147);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(75, 19);
            this.metroLabel2.TabIndex = 6;
            this.metroLabel2.Text = "Conversa:";
            // 
            // txtMensagem
            // 
            // 
            // 
            // 
            this.txtMensagem.CustomButton.Image = null;
            this.txtMensagem.CustomButton.Location = new System.Drawing.Point(529, 1);
            this.txtMensagem.CustomButton.Name = "";
            this.txtMensagem.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtMensagem.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMensagem.CustomButton.TabIndex = 1;
            this.txtMensagem.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMensagem.CustomButton.UseSelectable = true;
            this.txtMensagem.CustomButton.Visible = false;
            this.txtMensagem.Lines = new string[0];
            this.txtMensagem.Location = new System.Drawing.Point(23, 482);
            this.txtMensagem.MaxLength = 32767;
            this.txtMensagem.Multiline = true;
            this.txtMensagem.Name = "txtMensagem";
            this.txtMensagem.PasswordChar = '\0';
            this.txtMensagem.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMensagem.SelectedText = "";
            this.txtMensagem.SelectionLength = 0;
            this.txtMensagem.SelectionStart = 0;
            this.txtMensagem.ShortcutsEnabled = true;
            this.txtMensagem.Size = new System.Drawing.Size(555, 27);
            this.txtMensagem.TabIndex = 7;
            this.txtMensagem.UseSelectable = true;
            this.txtMensagem.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMensagem.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtMensagem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMensagem_KeyDown);
            this.txtMensagem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtMensagem_MouseDown);
            // 
            // btn_enviar
            // 
            this.btn_enviar.Location = new System.Drawing.Point(584, 482);
            this.btn_enviar.Name = "btn_enviar";
            this.btn_enviar.Size = new System.Drawing.Size(72, 27);
            this.btn_enviar.TabIndex = 8;
            this.btn_enviar.Text = "Enviar";
            this.btn_enviar.UseSelectable = true;
            this.btn_enviar.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(23, 460);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(86, 19);
            this.metroLabel3.TabIndex = 9;
            this.metroLabel3.Text = "Mensagem:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::chat_segov.Properties.Resources.if_status_46254;
            this.pictureBox2.Location = new System.Drawing.Point(389, 143);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::chat_segov.Properties.Resources.if_status_busy_46252;
            this.pictureBox1.Location = new System.Drawing.Point(389, 143);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox3.Image = global::chat_segov.Properties.Resources.usuario;
            this.pictureBox3.Location = new System.Drawing.Point(392, 54);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 85);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(23, 184);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(633, 273);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "";
            // 
            // tela_conversa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 532);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.btn_enviar);
            this.Controls.Add(this.txtMensagem);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "tela_conversa";
            this.Text = "Chat privado";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.tela_conversa_FormClosed);
            this.Load += new System.EventHandler(this.tela_conversa_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroLabel lbl_status;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        public MetroFramework.Controls.MetroComboBox cbbDesti;
        public MetroFramework.Controls.MetroTextBox txtMensagem;
        public MetroFramework.Controls.MetroButton btn_enviar;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.RichTextBox richTextBox1;
    }
}