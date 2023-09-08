namespace Edito
{
    partial class frmMain
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            tlpMain = new TableLayoutPanel();
            tabEdito = new TabControl();
            tabArticles = new TabPage();
            tlpArticle = new TableLayoutPanel();
            dgvArticles = new DataGridView();
            tlpBox = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tbxTitreArticle = new TextBox();
            tbxCorpsArticle = new TextBox();
            tbxAuteurArticle = new TextBox();
            flpButton = new FlowLayoutPanel();
            btArticleRefresh = new Button();
            btArticleAdd = new Button();
            btArticleUpdate = new Button();
            btArticleDelete = new Button();
            tabJournaux = new TabPage();
            tlpMainNewsPaper = new TableLayoutPanel();
            tlpDataGridView = new TableLayoutPanel();
            dgvNewsPaper = new DataGridView();
            label4 = new Label();
            tlpMainArticle = new TableLayoutPanel();
            btAddArticle = new Button();
            gbxAddArticle = new GroupBox();
            dgvAddArticle = new DataGridView();
            gbxDeleteArticle = new GroupBox();
            dgvDeleteArticle = new DataGridView();
            btDeleteArticle = new Button();
            tlpSecondNewsPaper = new TableLayoutPanel();
            flpNPButton = new FlowLayoutPanel();
            btAddNP = new Button();
            btUpdateNP = new Button();
            btDeleteNP = new Button();
            tlpBoxNP = new TableLayoutPanel();
            tbxTitleNewsPaper = new TextBox();
            dtpNewsPaper = new DateTimePicker();
            label5 = new Label();
            label6 = new Label();
            btNPRefresh = new Button();
            tabCompositions = new TabPage();
            bsArticles = new BindingSource(components);
            bsNewsPaper = new BindingSource(components);
            bsArticleInNewspaper = new BindingSource(components);
            bsAsso = new BindingSource(components);
            tlpView = new TableLayoutPanel();
            dgvView = new DataGridView();
            bsView = new BindingSource(components);
            tlpMain.SuspendLayout();
            tabEdito.SuspendLayout();
            tabArticles.SuspendLayout();
            tlpArticle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvArticles).BeginInit();
            tlpBox.SuspendLayout();
            flpButton.SuspendLayout();
            tabJournaux.SuspendLayout();
            tlpMainNewsPaper.SuspendLayout();
            tlpDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNewsPaper).BeginInit();
            tlpMainArticle.SuspendLayout();
            gbxAddArticle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAddArticle).BeginInit();
            gbxDeleteArticle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDeleteArticle).BeginInit();
            tlpSecondNewsPaper.SuspendLayout();
            flpNPButton.SuspendLayout();
            tlpBoxNP.SuspendLayout();
            tabCompositions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bsArticles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsNewsPaper).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsArticleInNewspaper).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsAsso).BeginInit();
            tlpView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsView).BeginInit();
            SuspendLayout();
            // 
            // tlpMain
            // 
            tlpMain.AutoSize = true;
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(tabEdito, 0, 0);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Margin = new Padding(1);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 1;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.Size = new Size(890, 569);
            tlpMain.TabIndex = 0;
            // 
            // tabEdito
            // 
            tabEdito.Appearance = TabAppearance.FlatButtons;
            tabEdito.Controls.Add(tabArticles);
            tabEdito.Controls.Add(tabJournaux);
            tabEdito.Controls.Add(tabCompositions);
            tabEdito.Dock = DockStyle.Fill;
            tabEdito.Location = new Point(1, 1);
            tabEdito.Margin = new Padding(1);
            tabEdito.Name = "tabEdito";
            tabEdito.Padding = new Point(20, 3);
            tabEdito.SelectedIndex = 0;
            tabEdito.Size = new Size(888, 567);
            tabEdito.TabIndex = 0;
            tabEdito.SelectedIndexChanged += tabEdito_SelectedIndexChanged;
            // 
            // tabArticles
            // 
            tabArticles.BackColor = SystemColors.Control;
            tabArticles.Controls.Add(tlpArticle);
            tabArticles.Location = new Point(4, 27);
            tabArticles.Margin = new Padding(1);
            tabArticles.Name = "tabArticles";
            tabArticles.Padding = new Padding(1);
            tabArticles.Size = new Size(880, 536);
            tabArticles.TabIndex = 0;
            tabArticles.Text = "Articles";
            // 
            // tlpArticle
            // 
            tlpArticle.ColumnCount = 1;
            tlpArticle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpArticle.Controls.Add(dgvArticles, 0, 0);
            tlpArticle.Controls.Add(tlpBox, 0, 1);
            tlpArticle.Controls.Add(flpButton, 0, 2);
            tlpArticle.Dock = DockStyle.Fill;
            tlpArticle.Location = new Point(1, 1);
            tlpArticle.Name = "tlpArticle";
            tlpArticle.RowCount = 3;
            tlpArticle.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpArticle.RowStyles.Add(new RowStyle());
            tlpArticle.RowStyles.Add(new RowStyle());
            tlpArticle.Size = new Size(878, 534);
            tlpArticle.TabIndex = 2;
            // 
            // dgvArticles
            // 
            dgvArticles.AllowUserToAddRows = false;
            dgvArticles.AllowUserToDeleteRows = false;
            dgvArticles.AllowUserToResizeRows = false;
            dgvArticles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvArticles.BackgroundColor = SystemColors.Control;
            dgvArticles.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.LightCyan;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.LightCyan;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvArticles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvArticles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArticles.Dock = DockStyle.Fill;
            dgvArticles.EnableHeadersVisualStyles = false;
            dgvArticles.Location = new Point(3, 3);
            dgvArticles.MultiSelect = false;
            dgvArticles.Name = "dgvArticles";
            dgvArticles.ReadOnly = true;
            dgvArticles.RowHeadersVisible = false;
            dgvArticles.RowHeadersWidth = 102;
            dgvArticles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArticles.Size = new Size(872, 370);
            dgvArticles.StandardTab = true;
            dgvArticles.TabIndex = 2;
            // 
            // tlpBox
            // 
            tlpBox.AutoSize = true;
            tlpBox.ColumnCount = 2;
            tlpBox.ColumnStyles.Add(new ColumnStyle());
            tlpBox.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpBox.Controls.Add(label1, 0, 0);
            tlpBox.Controls.Add(label2, 0, 1);
            tlpBox.Controls.Add(label3, 0, 2);
            tlpBox.Controls.Add(tbxTitreArticle, 1, 0);
            tlpBox.Controls.Add(tbxCorpsArticle, 1, 1);
            tlpBox.Controls.Add(tbxAuteurArticle, 1, 2);
            tlpBox.Dock = DockStyle.Fill;
            tlpBox.Location = new Point(1, 377);
            tlpBox.Margin = new Padding(1);
            tlpBox.Name = "tlpBox";
            tlpBox.RowCount = 3;
            tlpBox.RowStyles.Add(new RowStyle());
            tlpBox.RowStyles.Add(new RowStyle());
            tlpBox.RowStyles.Add(new RowStyle());
            tlpBox.Size = new Size(876, 98);
            tlpBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(1, 0);
            label1.Margin = new Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new Size(43, 25);
            label1.TabIndex = 0;
            label1.Text = "Titre";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(1, 25);
            label2.Margin = new Padding(1, 0, 1, 0);
            label2.Name = "label2";
            label2.Size = new Size(43, 48);
            label2.TabIndex = 1;
            label2.Text = "Corps";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(1, 73);
            label3.Margin = new Padding(1, 0, 1, 0);
            label3.Name = "label3";
            label3.Size = new Size(43, 25);
            label3.TabIndex = 2;
            label3.Text = "Auteur";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbxTitreArticle
            // 
            tbxTitreArticle.Dock = DockStyle.Fill;
            tbxTitreArticle.Location = new Point(46, 1);
            tbxTitreArticle.Margin = new Padding(1);
            tbxTitreArticle.Name = "tbxTitreArticle";
            tbxTitreArticle.Size = new Size(829, 23);
            tbxTitreArticle.TabIndex = 3;
            // 
            // tbxCorpsArticle
            // 
            tbxCorpsArticle.Dock = DockStyle.Fill;
            tbxCorpsArticle.Location = new Point(46, 26);
            tbxCorpsArticle.Margin = new Padding(1);
            tbxCorpsArticle.Multiline = true;
            tbxCorpsArticle.Name = "tbxCorpsArticle";
            tbxCorpsArticle.Size = new Size(829, 46);
            tbxCorpsArticle.TabIndex = 4;
            // 
            // tbxAuteurArticle
            // 
            tbxAuteurArticle.Dock = DockStyle.Fill;
            tbxAuteurArticle.Location = new Point(46, 74);
            tbxAuteurArticle.Margin = new Padding(1);
            tbxAuteurArticle.Name = "tbxAuteurArticle";
            tbxAuteurArticle.Size = new Size(829, 23);
            tbxAuteurArticle.TabIndex = 5;
            // 
            // flpButton
            // 
            flpButton.AutoSize = true;
            flpButton.Controls.Add(btArticleRefresh);
            flpButton.Controls.Add(btArticleAdd);
            flpButton.Controls.Add(btArticleUpdate);
            flpButton.Controls.Add(btArticleDelete);
            flpButton.Dock = DockStyle.Fill;
            flpButton.Location = new Point(3, 479);
            flpButton.Name = "flpButton";
            flpButton.Size = new Size(872, 52);
            flpButton.TabIndex = 1;
            flpButton.WrapContents = false;
            // 
            // btArticleRefresh
            // 
            btArticleRefresh.Image = Properties.Resources.Synchroniser_48;
            btArticleRefresh.ImageAlign = ContentAlignment.MiddleLeft;
            btArticleRefresh.Location = new Point(3, 3);
            btArticleRefresh.Margin = new Padding(3, 3, 21, 3);
            btArticleRefresh.Name = "btArticleRefresh";
            btArticleRefresh.Size = new Size(114, 46);
            btArticleRefresh.TabIndex = 0;
            btArticleRefresh.Text = "&Actualiser";
            btArticleRefresh.TextAlign = ContentAlignment.MiddleRight;
            btArticleRefresh.UseVisualStyleBackColor = true;
            btArticleRefresh.Click += btArticleActualiser_Click;
            // 
            // btArticleAdd
            // 
            btArticleAdd.Image = Properties.Resources.Ajouter;
            btArticleAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btArticleAdd.Location = new Point(141, 3);
            btArticleAdd.Name = "btArticleAdd";
            btArticleAdd.Size = new Size(114, 46);
            btArticleAdd.TabIndex = 1;
            btArticleAdd.Text = "A&jouter";
            btArticleAdd.TextAlign = ContentAlignment.MiddleRight;
            btArticleAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            btArticleAdd.UseVisualStyleBackColor = true;
            btArticleAdd.Click += btArticleAjouter_Click;
            // 
            // btArticleUpdate
            // 
            btArticleUpdate.Image = Properties.Resources.Modifier;
            btArticleUpdate.ImageAlign = ContentAlignment.MiddleLeft;
            btArticleUpdate.Location = new Point(261, 3);
            btArticleUpdate.Name = "btArticleUpdate";
            btArticleUpdate.Size = new Size(114, 46);
            btArticleUpdate.TabIndex = 2;
            btArticleUpdate.Text = "&Modifier";
            btArticleUpdate.TextAlign = ContentAlignment.MiddleRight;
            btArticleUpdate.UseVisualStyleBackColor = true;
            btArticleUpdate.Click += btArticleModifier_Click;
            // 
            // btArticleDelete
            // 
            btArticleDelete.Image = Properties.Resources.Supprimer;
            btArticleDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btArticleDelete.Location = new Point(381, 3);
            btArticleDelete.Name = "btArticleDelete";
            btArticleDelete.Size = new Size(114, 46);
            btArticleDelete.TabIndex = 3;
            btArticleDelete.Text = "&Supprimer";
            btArticleDelete.TextAlign = ContentAlignment.MiddleRight;
            btArticleDelete.UseVisualStyleBackColor = true;
            btArticleDelete.Click += btArticleSupprimer_Click;
            // 
            // tabJournaux
            // 
            tabJournaux.BackColor = SystemColors.Control;
            tabJournaux.Controls.Add(tlpMainNewsPaper);
            tabJournaux.Location = new Point(4, 27);
            tabJournaux.Margin = new Padding(1);
            tabJournaux.Name = "tabJournaux";
            tabJournaux.Padding = new Padding(1);
            tabJournaux.Size = new Size(880, 536);
            tabJournaux.TabIndex = 1;
            tabJournaux.Text = "Journaux";
            // 
            // tlpMainNewsPaper
            // 
            tlpMainNewsPaper.ColumnCount = 2;
            tlpMainNewsPaper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48.29483F));
            tlpMainNewsPaper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 51.7051735F));
            tlpMainNewsPaper.Controls.Add(tlpDataGridView, 0, 0);
            tlpMainNewsPaper.Controls.Add(tlpMainArticle, 1, 0);
            tlpMainNewsPaper.Controls.Add(tlpSecondNewsPaper, 0, 1);
            tlpMainNewsPaper.Controls.Add(btNPRefresh, 1, 1);
            tlpMainNewsPaper.Dock = DockStyle.Fill;
            tlpMainNewsPaper.Location = new Point(1, 1);
            tlpMainNewsPaper.Name = "tlpMainNewsPaper";
            tlpMainNewsPaper.RowCount = 2;
            tlpMainNewsPaper.RowStyles.Add(new RowStyle(SizeType.Percent, 73.5955048F));
            tlpMainNewsPaper.RowStyles.Add(new RowStyle(SizeType.Percent, 26.4044952F));
            tlpMainNewsPaper.Size = new Size(878, 534);
            tlpMainNewsPaper.TabIndex = 0;
            // 
            // tlpDataGridView
            // 
            tlpDataGridView.ColumnCount = 1;
            tlpDataGridView.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpDataGridView.Controls.Add(dgvNewsPaper, 0, 1);
            tlpDataGridView.Controls.Add(label4, 0, 0);
            tlpDataGridView.Dock = DockStyle.Fill;
            tlpDataGridView.Location = new Point(3, 3);
            tlpDataGridView.Name = "tlpDataGridView";
            tlpDataGridView.RowCount = 2;
            tlpDataGridView.RowStyles.Add(new RowStyle());
            tlpDataGridView.RowStyles.Add(new RowStyle());
            tlpDataGridView.Size = new Size(418, 387);
            tlpDataGridView.TabIndex = 0;
            // 
            // dgvNewsPaper
            // 
            dgvNewsPaper.AllowUserToAddRows = false;
            dgvNewsPaper.AllowUserToDeleteRows = false;
            dgvNewsPaper.AllowUserToResizeRows = false;
            dgvNewsPaper.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNewsPaper.BackgroundColor = SystemColors.Control;
            dgvNewsPaper.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNewsPaper.Dock = DockStyle.Fill;
            dgvNewsPaper.Location = new Point(3, 18);
            dgvNewsPaper.Name = "dgvNewsPaper";
            dgvNewsPaper.ReadOnly = true;
            dgvNewsPaper.RowHeadersVisible = false;
            dgvNewsPaper.RowTemplate.Height = 25;
            dgvNewsPaper.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNewsPaper.Size = new Size(412, 366);
            dgvNewsPaper.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(412, 15);
            label4.TabIndex = 1;
            label4.Text = "Sélectionnez un journal";
            // 
            // tlpMainArticle
            // 
            tlpMainArticle.ColumnCount = 2;
            tlpMainArticle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 78.7528839F));
            tlpMainArticle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.2471123F));
            tlpMainArticle.Controls.Add(btAddArticle, 1, 0);
            tlpMainArticle.Controls.Add(gbxAddArticle, 0, 0);
            tlpMainArticle.Controls.Add(gbxDeleteArticle, 0, 1);
            tlpMainArticle.Controls.Add(btDeleteArticle, 1, 1);
            tlpMainArticle.Dock = DockStyle.Fill;
            tlpMainArticle.Location = new Point(427, 3);
            tlpMainArticle.Name = "tlpMainArticle";
            tlpMainArticle.RowCount = 2;
            tlpMainArticle.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpMainArticle.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpMainArticle.Size = new Size(448, 387);
            tlpMainArticle.TabIndex = 1;
            // 
            // btAddArticle
            // 
            btAddArticle.Anchor = AnchorStyles.None;
            btAddArticle.Image = Properties.Resources.Ajouter;
            btAddArticle.ImageAlign = ContentAlignment.MiddleLeft;
            btAddArticle.Location = new Point(355, 72);
            btAddArticle.Name = "btAddArticle";
            btAddArticle.Size = new Size(90, 48);
            btAddArticle.TabIndex = 2;
            btAddArticle.Text = "Ajouter";
            btAddArticle.TextAlign = ContentAlignment.MiddleRight;
            btAddArticle.UseVisualStyleBackColor = true;
            btAddArticle.Click += btAddArticle_Click;
            // 
            // gbxAddArticle
            // 
            gbxAddArticle.Controls.Add(dgvAddArticle);
            gbxAddArticle.Dock = DockStyle.Fill;
            gbxAddArticle.Location = new Point(3, 3);
            gbxAddArticle.Name = "gbxAddArticle";
            gbxAddArticle.Size = new Size(346, 187);
            gbxAddArticle.TabIndex = 4;
            gbxAddArticle.TabStop = false;
            gbxAddArticle.Text = "Sélectionnez un article à ajouter";
            // 
            // dgvAddArticle
            // 
            dgvAddArticle.AllowUserToAddRows = false;
            dgvAddArticle.AllowUserToDeleteRows = false;
            dgvAddArticle.AllowUserToResizeRows = false;
            dgvAddArticle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAddArticle.BackgroundColor = SystemColors.Control;
            dgvAddArticle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAddArticle.Dock = DockStyle.Fill;
            dgvAddArticle.Location = new Point(3, 19);
            dgvAddArticle.Name = "dgvAddArticle";
            dgvAddArticle.ReadOnly = true;
            dgvAddArticle.RowHeadersVisible = false;
            dgvAddArticle.RowTemplate.Height = 25;
            dgvAddArticle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAddArticle.Size = new Size(340, 165);
            dgvAddArticle.TabIndex = 0;
            // 
            // gbxDeleteArticle
            // 
            gbxDeleteArticle.Controls.Add(dgvDeleteArticle);
            gbxDeleteArticle.Dock = DockStyle.Fill;
            gbxDeleteArticle.Location = new Point(3, 196);
            gbxDeleteArticle.Name = "gbxDeleteArticle";
            gbxDeleteArticle.Size = new Size(346, 188);
            gbxDeleteArticle.TabIndex = 5;
            gbxDeleteArticle.TabStop = false;
            gbxDeleteArticle.Text = "Sélectionnez un article à supprimer";
            // 
            // dgvDeleteArticle
            // 
            dgvDeleteArticle.AllowUserToAddRows = false;
            dgvDeleteArticle.AllowUserToDeleteRows = false;
            dgvDeleteArticle.AllowUserToResizeRows = false;
            dgvDeleteArticle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDeleteArticle.BackgroundColor = SystemColors.Control;
            dgvDeleteArticle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDeleteArticle.Dock = DockStyle.Fill;
            dgvDeleteArticle.Location = new Point(3, 19);
            dgvDeleteArticle.Name = "dgvDeleteArticle";
            dgvDeleteArticle.ReadOnly = true;
            dgvDeleteArticle.RowHeadersVisible = false;
            dgvDeleteArticle.RowTemplate.Height = 25;
            dgvDeleteArticle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDeleteArticle.Size = new Size(340, 166);
            dgvDeleteArticle.TabIndex = 0;
            // 
            // btDeleteArticle
            // 
            btDeleteArticle.Anchor = AnchorStyles.None;
            btDeleteArticle.Image = Properties.Resources.Supprimer;
            btDeleteArticle.ImageAlign = ContentAlignment.MiddleLeft;
            btDeleteArticle.Location = new Point(355, 266);
            btDeleteArticle.Name = "btDeleteArticle";
            btDeleteArticle.Size = new Size(90, 48);
            btDeleteArticle.TabIndex = 3;
            btDeleteArticle.Text = "Supprimer";
            btDeleteArticle.TextAlign = ContentAlignment.MiddleRight;
            btDeleteArticle.UseVisualStyleBackColor = true;
            btDeleteArticle.Click += btDeleteArticle_Click;
            // 
            // tlpSecondNewsPaper
            // 
            tlpSecondNewsPaper.ColumnCount = 1;
            tlpSecondNewsPaper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpSecondNewsPaper.Controls.Add(flpNPButton, 0, 1);
            tlpSecondNewsPaper.Controls.Add(tlpBoxNP, 0, 0);
            tlpSecondNewsPaper.Dock = DockStyle.Fill;
            tlpSecondNewsPaper.Location = new Point(3, 396);
            tlpSecondNewsPaper.Name = "tlpSecondNewsPaper";
            tlpSecondNewsPaper.RowCount = 2;
            tlpSecondNewsPaper.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpSecondNewsPaper.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpSecondNewsPaper.Size = new Size(418, 135);
            tlpSecondNewsPaper.TabIndex = 2;
            // 
            // flpNPButton
            // 
            flpNPButton.Controls.Add(btAddNP);
            flpNPButton.Controls.Add(btUpdateNP);
            flpNPButton.Controls.Add(btDeleteNP);
            flpNPButton.Dock = DockStyle.Fill;
            flpNPButton.Location = new Point(3, 70);
            flpNPButton.Name = "flpNPButton";
            flpNPButton.Size = new Size(412, 62);
            flpNPButton.TabIndex = 0;
            // 
            // btAddNP
            // 
            btAddNP.Image = Properties.Resources.Ajouter;
            btAddNP.ImageAlign = ContentAlignment.MiddleLeft;
            btAddNP.Location = new Point(3, 3);
            btAddNP.Name = "btAddNP";
            btAddNP.Size = new Size(100, 59);
            btAddNP.TabIndex = 0;
            btAddNP.Text = "Ajouter";
            btAddNP.TextAlign = ContentAlignment.MiddleRight;
            btAddNP.UseVisualStyleBackColor = true;
            btAddNP.Click += btAddNP_Click;
            // 
            // btUpdateNP
            // 
            btUpdateNP.Image = Properties.Resources.Modifier;
            btUpdateNP.ImageAlign = ContentAlignment.MiddleLeft;
            btUpdateNP.Location = new Point(109, 3);
            btUpdateNP.Name = "btUpdateNP";
            btUpdateNP.Size = new Size(100, 59);
            btUpdateNP.TabIndex = 1;
            btUpdateNP.Text = "Modifier";
            btUpdateNP.TextAlign = ContentAlignment.MiddleRight;
            btUpdateNP.UseVisualStyleBackColor = true;
            btUpdateNP.Click += btUpdateNP_Click;
            // 
            // btDeleteNP
            // 
            btDeleteNP.Image = Properties.Resources.Supprimer;
            btDeleteNP.ImageAlign = ContentAlignment.MiddleLeft;
            btDeleteNP.Location = new Point(215, 3);
            btDeleteNP.Name = "btDeleteNP";
            btDeleteNP.Size = new Size(100, 59);
            btDeleteNP.TabIndex = 2;
            btDeleteNP.Text = "Supprimer";
            btDeleteNP.TextAlign = ContentAlignment.MiddleRight;
            btDeleteNP.UseVisualStyleBackColor = true;
            btDeleteNP.Click += btDeleteNP_Click;
            // 
            // tlpBoxNP
            // 
            tlpBoxNP.ColumnCount = 2;
            tlpBoxNP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.9417477F));
            tlpBoxNP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 73.05825F));
            tlpBoxNP.Controls.Add(tbxTitleNewsPaper, 1, 0);
            tlpBoxNP.Controls.Add(dtpNewsPaper, 1, 1);
            tlpBoxNP.Controls.Add(label5, 0, 0);
            tlpBoxNP.Controls.Add(label6, 0, 1);
            tlpBoxNP.Dock = DockStyle.Fill;
            tlpBoxNP.Location = new Point(3, 3);
            tlpBoxNP.Name = "tlpBoxNP";
            tlpBoxNP.RowCount = 2;
            tlpBoxNP.RowStyles.Add(new RowStyle());
            tlpBoxNP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpBoxNP.Size = new Size(412, 61);
            tlpBoxNP.TabIndex = 1;
            // 
            // tbxTitleNewsPaper
            // 
            tbxTitleNewsPaper.Dock = DockStyle.Fill;
            tbxTitleNewsPaper.Location = new Point(114, 3);
            tbxTitleNewsPaper.Name = "tbxTitleNewsPaper";
            tbxTitleNewsPaper.Size = new Size(295, 23);
            tbxTitleNewsPaper.TabIndex = 0;
            // 
            // dtpNewsPaper
            // 
            dtpNewsPaper.Dock = DockStyle.Fill;
            dtpNewsPaper.Location = new Point(114, 32);
            dtpNewsPaper.Name = "dtpNewsPaper";
            dtpNewsPaper.ShowCheckBox = true;
            dtpNewsPaper.Size = new Size(295, 23);
            dtpNewsPaper.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(105, 29);
            label5.TabIndex = 2;
            label5.Text = "Titre journal";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(3, 29);
            label6.Name = "label6";
            label6.Size = new Size(105, 32);
            label6.TabIndex = 3;
            label6.Text = "Date de parution";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btNPRefresh
            // 
            btNPRefresh.Anchor = AnchorStyles.None;
            btNPRefresh.Image = Properties.Resources.Synchroniser_48;
            btNPRefresh.ImageAlign = ContentAlignment.MiddleLeft;
            btNPRefresh.Location = new Point(556, 433);
            btNPRefresh.Name = "btNPRefresh";
            btNPRefresh.Size = new Size(189, 60);
            btNPRefresh.TabIndex = 3;
            btNPRefresh.Text = "Actualiser";
            btNPRefresh.TextAlign = ContentAlignment.MiddleRight;
            btNPRefresh.UseVisualStyleBackColor = true;
            btNPRefresh.Click += btNPRefresh_Click;
            // 
            // tabCompositions
            // 
            tabCompositions.BackColor = SystemColors.Control;
            tabCompositions.Controls.Add(tlpView);
            tabCompositions.Location = new Point(4, 27);
            tabCompositions.Margin = new Padding(1);
            tabCompositions.Name = "tabCompositions";
            tabCompositions.Padding = new Padding(1);
            tabCompositions.Size = new Size(880, 536);
            tabCompositions.TabIndex = 2;
            tabCompositions.Text = "Compositions";
            // 
            // bsNewsPaper
            // 
            bsNewsPaper.PositionChanged += bsNewsPaper_PositionChanged;
            // 
            // tlpView
            // 
            tlpView.ColumnCount = 1;
            tlpView.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpView.Controls.Add(dgvView, 0, 0);
            tlpView.Dock = DockStyle.Fill;
            tlpView.Location = new Point(1, 1);
            tlpView.Name = "tlpView";
            tlpView.RowCount = 1;
            tlpView.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpView.Size = new Size(878, 534);
            tlpView.TabIndex = 0;
            // 
            // dgvView
            // 
            dgvView.AllowUserToAddRows = false;
            dgvView.AllowUserToDeleteRows = false;
            dgvView.BackgroundColor = SystemColors.Control;
            dgvView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvView.Dock = DockStyle.Fill;
            dgvView.Location = new Point(3, 3);
            dgvView.Name = "dgvView";
            dgvView.ReadOnly = true;
            dgvView.RowTemplate.Height = 25;
            dgvView.Size = new Size(872, 528);
            dgvView.TabIndex = 0;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(890, 569);
            Controls.Add(tlpMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(1);
            MaximumSize = new Size(906, 608);
            MinimumSize = new Size(906, 608);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edito";
            Load += frmMain_Load;
            tlpMain.ResumeLayout(false);
            tabEdito.ResumeLayout(false);
            tabArticles.ResumeLayout(false);
            tlpArticle.ResumeLayout(false);
            tlpArticle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvArticles).EndInit();
            tlpBox.ResumeLayout(false);
            tlpBox.PerformLayout();
            flpButton.ResumeLayout(false);
            tabJournaux.ResumeLayout(false);
            tlpMainNewsPaper.ResumeLayout(false);
            tlpDataGridView.ResumeLayout(false);
            tlpDataGridView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNewsPaper).EndInit();
            tlpMainArticle.ResumeLayout(false);
            gbxAddArticle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAddArticle).EndInit();
            gbxDeleteArticle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDeleteArticle).EndInit();
            tlpSecondNewsPaper.ResumeLayout(false);
            flpNPButton.ResumeLayout(false);
            tlpBoxNP.ResumeLayout(false);
            tlpBoxNP.PerformLayout();
            tabCompositions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)bsArticles).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsNewsPaper).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsArticleInNewspaper).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsAsso).EndInit();
            tlpView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvView).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tlpMain;
        private TabControl tabEdito;
        private TabPage tabArticles;
        private TabPage tabJournaux;
        private TabPage tabCompositions;
        private TableLayoutPanel tlpArticle;
        private DataGridView dgvArticles;
        private FlowLayoutPanel flpButton;
        private Button btArticleRefresh;
        private BindingSource bsArticles;
        private TableLayoutPanel tlpBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbxTitreArticle;
        private TextBox tbxCorpsArticle;
        private TextBox tbxAuteurArticle;
        private Button btArticleAdd;
        private Button btArticleUpdate;
        private Button btArticleDelete;
        private TableLayoutPanel tlpMainNewsPaper;
        private TableLayoutPanel tlpDataGridView;
        private DataGridView dgvNewsPaper;
        private Label label4;
        private TableLayoutPanel tlpMainArticle;
        private Button btAddArticle;
        private Button btDeleteArticle;
        private GroupBox gbxAddArticle;
        private DataGridView dgvAddArticle;
        private GroupBox gbxDeleteArticle;
        private DataGridView dgvDeleteArticle;
        private TableLayoutPanel tlpSecondNewsPaper;
        private FlowLayoutPanel flpNPButton;
        private Button btAddNP;
        private Button btUpdateNP;
        private Button btDeleteNP;
        private TableLayoutPanel tlpBoxNP;
        private TextBox tbxTitleNewsPaper;
        private DateTimePicker dtpNewsPaper;
        private Button btNPRefresh;
        private Label label5;
        private Label label6;
        private BindingSource bsNewsPaper;
        private BindingSource bsArticleInNewspaper;
        private BindingSource bsAsso;
        private TableLayoutPanel tlpView;
        private DataGridView dgvView;
        private BindingSource bsView;
    }
}