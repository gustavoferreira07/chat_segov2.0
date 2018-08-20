namespace chat_segov
{
    partial class tela_principal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tela_principal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.perfilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minhasMensagensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conversasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novaConversaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoGrupoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mudarTemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatarProblemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Usuario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chamarPrivadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Silver;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.perfilToolStripMenuItem,
            this.minhasMensagensToolStripMenuItem,
            this.conversasToolStripMenuItem,
            this.configuraçõesToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(641, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // perfilToolStripMenuItem
            // 
            this.perfilToolStripMenuItem.BackgroundImage = global::chat_segov.Properties.Resources.crowd_team_24;
            this.perfilToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.perfilToolStripMenuItem.Name = "perfilToolStripMenuItem";
            this.perfilToolStripMenuItem.Size = new System.Drawing.Size(77, 21);
            this.perfilToolStripMenuItem.Text = "    Perfil   ";
            this.perfilToolStripMenuItem.Click += new System.EventHandler(this.perfilToolStripMenuItem_Click);
            // 
            // minhasMensagensToolStripMenuItem
            // 
            this.minhasMensagensToolStripMenuItem.BackgroundImage = global::chat_segov.Properties.Resources.information_support_24;
            this.minhasMensagensToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.minhasMensagensToolStripMenuItem.Name = "minhasMensagensToolStripMenuItem";
            this.minhasMensagensToolStripMenuItem.Size = new System.Drawing.Size(160, 21);
            this.minhasMensagensToolStripMenuItem.Text = "    Minhas mensagens   ";
            this.minhasMensagensToolStripMenuItem.Click += new System.EventHandler(this.minhasMensagensToolStripMenuItem_Click);
            // 
            // conversasToolStripMenuItem
            // 
            this.conversasToolStripMenuItem.BackgroundImage = global::chat_segov.Properties.Resources.chat_support_24;
            this.conversasToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.conversasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novaConversaToolStripMenuItem,
            this.novoGrupoToolStripMenuItem,
            this.contatosToolStripMenuItem});
            this.conversasToolStripMenuItem.Name = "conversasToolStripMenuItem";
            this.conversasToolStripMenuItem.Size = new System.Drawing.Size(74, 21);
            this.conversasToolStripMenuItem.Text = "    Chat   ";
            this.conversasToolStripMenuItem.Click += new System.EventHandler(this.conversasToolStripMenuItem_Click);
            // 
            // novaConversaToolStripMenuItem
            // 
            this.novaConversaToolStripMenuItem.Name = "novaConversaToolStripMenuItem";
            this.novaConversaToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.novaConversaToolStripMenuItem.Text = "Nova conversa";
            this.novaConversaToolStripMenuItem.Click += new System.EventHandler(this.novaConversaToolStripMenuItem_Click);
            // 
            // novoGrupoToolStripMenuItem
            // 
            this.novoGrupoToolStripMenuItem.Name = "novoGrupoToolStripMenuItem";
            this.novoGrupoToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.novoGrupoToolStripMenuItem.Text = "Novo grupo";
            this.novoGrupoToolStripMenuItem.Click += new System.EventHandler(this.novoGrupoToolStripMenuItem_Click);
            // 
            // contatosToolStripMenuItem
            // 
            this.contatosToolStripMenuItem.Name = "contatosToolStripMenuItem";
            this.contatosToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.contatosToolStripMenuItem.Text = "Contatos";
            this.contatosToolStripMenuItem.Click += new System.EventHandler(this.contatosToolStripMenuItem_Click);
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.BackgroundImage = global::chat_segov.Properties.Resources.custom_settings_24;
            this.configuraçõesToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.configuraçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mudarTemaToolStripMenuItem});
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(128, 21);
            this.configuraçõesToolStripMenuItem.Text = "    Configurações  ";
            // 
            // mudarTemaToolStripMenuItem
            // 
            this.mudarTemaToolStripMenuItem.Name = "mudarTemaToolStripMenuItem";
            this.mudarTemaToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.mudarTemaToolStripMenuItem.Text = "Mudar tema";
            this.mudarTemaToolStripMenuItem.Click += new System.EventHandler(this.mudarTemaToolStripMenuItem_Click);
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.BackgroundImage = global::chat_segov.Properties.Resources.customer_support_24;
            this.ajudaToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobreToolStripMenuItem,
            this.relatarProblemaToolStripMenuItem});
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(81, 21);
            this.ajudaToolStripMenuItem.Text = "    Ajuda   ";
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.sobreToolStripMenuItem.Text = "Sobre";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // relatarProblemaToolStripMenuItem
            // 
            this.relatarProblemaToolStripMenuItem.Name = "relatarProblemaToolStripMenuItem";
            this.relatarProblemaToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.relatarProblemaToolStripMenuItem.Text = "Relatar problema";
            this.relatarProblemaToolStripMenuItem.Click += new System.EventHandler(this.relatarProblemaToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(502, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Usuários Online";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Usuario,
            this.Status});
            this.listView1.ContextMenuStrip = this.menu;
            this.listView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(451, 116);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(219, 236);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // Usuario
            // 
            this.Usuario.Text = "Usuário";
            this.Usuario.Width = 120;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 98;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chamarPrivadoToolStripMenuItem});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(160, 26);
            // 
            // chamarPrivadoToolStripMenuItem
            // 
            this.chamarPrivadoToolStripMenuItem.Image = global::chat_segov.Properties.Resources.if_66_wechat_1181189;
            this.chamarPrivadoToolStripMenuItem.Name = "chamarPrivadoToolStripMenuItem";
            this.chamarPrivadoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.chamarPrivadoToolStripMenuItem.Text = "Chamar privado";
            this.chamarPrivadoToolStripMenuItem.Click += new System.EventHandler(this.chamarPrivadoToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::chat_segov.Properties.Resources.ataliza;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button1.Location = new System.Drawing.Point(451, 356);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 29);
            this.button1.TabIndex = 8;
            this.button1.Text = "Atulizar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(20, 389);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(641, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 392);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Usuario logado:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(129, 391);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(0, 15);
            this.lblUsuario.TabIndex = 11;
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "Chat Segov 1.9";
            this.notifyIcon1.Visible = true;
            // 
            // tela_principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::chat_segov.Properties.Resources.chats;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(681, 431);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "tela_principal";
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.tela_principal_FormClosed);
            this.Load += new System.EventHandler(this.tela_principal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem conversasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novaConversaToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader Usuario;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem chamarPrivadoToolStripMenuItem;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem minhasMensagensToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoGrupoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mudarTemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ToolStripMenuItem contatosToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem perfilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatarProblemaToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

