


using System;
using System.Drawing;
using System.Windows.Forms;

namespace Acessos
{
    partial class frmAprovacoesOrcamentos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.fluentTheme1 = new Telerik.WinControls.Themes.FluentTheme();
            this.materialTheme1 = new Telerik.WinControls.Themes.MaterialTheme();
            this.mainContainer = new Telerik.WinControls.UI.RadPanel();
            this.contentPanel = new Telerik.WinControls.UI.RadPanel();
            this.resultadosCard = new Telerik.WinControls.UI.RadGroupBox();
            this.dgvOrcamentosPendentes = new Telerik.WinControls.UI.RadGridView();
            this.filtrosCard = new Telerik.WinControls.UI.RadGroupBox();
            this.lblStatus = new Telerik.WinControls.UI.RadLabel();
            this.cmbFiltroStatus = new Telerik.WinControls.UI.RadDropDownList();
            this.lblDataInicio = new Telerik.WinControls.UI.RadLabel();
            this.dtpDataInicio = new Telerik.WinControls.UI.RadDateTimePicker();
            this.lblDataFim = new Telerik.WinControls.UI.RadLabel();
            this.dtpDataFim = new Telerik.WinControls.UI.RadDateTimePicker();
            this.btnFiltrar = new Telerik.WinControls.UI.RadButton();
            this.btnLimparFiltros = new Telerik.WinControls.UI.RadButton();
            this.estatisticasCard = new Telerik.WinControls.UI.RadPanel();
            this.iconStats = new Telerik.WinControls.UI.RadLabel();
            this.lblTotalPendentes = new Telerik.WinControls.UI.RadLabel();
            this.lblValorTotal = new Telerik.WinControls.UI.RadLabel();
            this.headerPanel = new Telerik.WinControls.UI.RadPanel();
            this.iconTitulo = new Telerik.WinControls.UI.RadLabel();
            this.lblTitulo = new Telerik.WinControls.UI.RadLabel();
            this.lblSubtitulo = new Telerik.WinControls.UI.RadLabel();
            this.progressBar = new Telerik.WinControls.UI.RadWaitingBar();
            this.dotsLineWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.DotsLineWaitingBarIndicatorElement();
            this.footerPanel = new Telerik.WinControls.UI.RadPanel();
            this.btnDetalhes = new Telerik.WinControls.UI.RadButton();
            this.btnAprovar = new Telerik.WinControls.UI.RadButton();
            this.btnRejeitar = new Telerik.WinControls.UI.RadButton();
            this.btnAtualizar = new Telerik.WinControls.UI.RadButton();
            this.btnFechar = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).BeginInit();
            this.mainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contentPanel)).BeginInit();
            this.contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultadosCard)).BeginInit();
            this.resultadosCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrcamentosPendentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrcamentosPendentes.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filtrosCard)).BeginInit();
            this.filtrosCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFiltroStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDataInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDataInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDataFim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDataFim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFiltrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLimparFiltros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estatisticasCard)).BeginInit();
            this.estatisticasCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalPendentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValorTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel)).BeginInit();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconTitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubtitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.footerPanel)).BeginInit();
            this.footerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDetalhes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAprovar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRejeitar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAtualizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFechar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.Controls.Add(this.contentPanel);
            this.mainContainer.Controls.Add(this.headerPanel);
            this.mainContainer.Controls.Add(this.footerPanel);
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(0, 0);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Size = new System.Drawing.Size(1000, 700);
            this.mainContainer.TabIndex = 0;
            this.mainContainer.ThemeName = "Fluent";
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.resultadosCard);
            this.contentPanel.Controls.Add(this.filtrosCard);
            this.contentPanel.Controls.Add(this.estatisticasCard);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 80);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(20);
            this.contentPanel.Size = new System.Drawing.Size(1000, 550);
            this.contentPanel.TabIndex = 1;
            this.contentPanel.ThemeName = "Fluent";
            // 
            // resultadosCard
            // 
            this.resultadosCard.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.resultadosCard.Controls.Add(this.dgvOrcamentosPendentes);
            this.resultadosCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultadosCard.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.resultadosCard.HeaderMargin = new System.Windows.Forms.Padding(1);
            this.resultadosCard.HeaderText = "📋 Orçamentos Pendentes de Aprovação";
            this.resultadosCard.Location = new System.Drawing.Point(20, 170);
            this.resultadosCard.Name = "resultadosCard";
            this.resultadosCard.Padding = new System.Windows.Forms.Padding(15);
            this.resultadosCard.Size = new System.Drawing.Size(960, 360);
            this.resultadosCard.TabIndex = 2;
            this.resultadosCard.Text = "📋 Orçamentos Pendentes de Aprovação";
            this.resultadosCard.ThemeName = "Fluent";
            // 
            // dgvOrcamentosPendentes
            // 
            this.dgvOrcamentosPendentes.AllowDrop = true;
            this.dgvOrcamentosPendentes.AutoSizeRows = true;
            this.dgvOrcamentosPendentes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrcamentosPendentes.Location = new System.Drawing.Point(15, 15);
            // 
            // 
            // 
            this.dgvOrcamentosPendentes.MasterTemplate.AllowAddNewRow = false;
            this.dgvOrcamentosPendentes.MasterTemplate.AllowColumnReorder = false;
            this.dgvOrcamentosPendentes.MasterTemplate.AllowDeleteRow = false;
            this.dgvOrcamentosPendentes.MasterTemplate.AllowDragToGroup = false;
            this.dgvOrcamentosPendentes.MasterTemplate.AllowEditRow = false;
            this.dgvOrcamentosPendentes.MasterTemplate.AllowRowResize = false;
            this.dgvOrcamentosPendentes.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvOrcamentosPendentes.MasterTemplate.EnableAlternatingRowColor = true;
            this.dgvOrcamentosPendentes.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgvOrcamentosPendentes.Name = "dgvOrcamentosPendentes";
            this.dgvOrcamentosPendentes.Size = new System.Drawing.Size(930, 330);
            this.dgvOrcamentosPendentes.TabIndex = 0;
            this.dgvOrcamentosPendentes.SelectionChanged += new System.EventHandler(this.dgvOrcamentosPendentes_SelectionChanged);
            this.dgvOrcamentosPendentes.DoubleClick += new System.EventHandler(this.dgvOrcamentosPendentes_DoubleClick);
            // 
            // filtrosCard
            // 
            this.filtrosCard.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.filtrosCard.Controls.Add(this.lblStatus);
            this.filtrosCard.Controls.Add(this.cmbFiltroStatus);
            this.filtrosCard.Controls.Add(this.lblDataInicio);
            this.filtrosCard.Controls.Add(this.dtpDataInicio);
            this.filtrosCard.Controls.Add(this.lblDataFim);
            this.filtrosCard.Controls.Add(this.dtpDataFim);
            this.filtrosCard.Controls.Add(this.btnFiltrar);
            this.filtrosCard.Controls.Add(this.btnLimparFiltros);
            this.filtrosCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.filtrosCard.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.filtrosCard.HeaderMargin = new System.Windows.Forms.Padding(1);
            this.filtrosCard.HeaderText = "🔍 Filtros de Busca";
            this.filtrosCard.Location = new System.Drawing.Point(20, 80);
            this.filtrosCard.Name = "filtrosCard";
            this.filtrosCard.Padding = new System.Windows.Forms.Padding(15);
            this.filtrosCard.Size = new System.Drawing.Size(960, 90);
            this.filtrosCard.TabIndex = 1;
            this.filtrosCard.Text = "🔍 Filtros de Busca";
            this.filtrosCard.ThemeName = "Fluent";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(15, 25);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(46, 19);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status:";
            // 
            // cmbFiltroStatus
            // 
            this.cmbFiltroStatus.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cmbFiltroStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFiltroStatus.Location = new System.Drawing.Point(15, 45);
            this.cmbFiltroStatus.Name = "cmbFiltroStatus";
            this.cmbFiltroStatus.Size = new System.Drawing.Size(150, 25);
            this.cmbFiltroStatus.TabIndex = 1;
            this.cmbFiltroStatus.ThemeName = "Fluent";
            // 
            // lblDataInicio
            // 
            this.lblDataInicio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDataInicio.Location = new System.Drawing.Point(185, 25);
            this.lblDataInicio.Name = "lblDataInicio";
            this.lblDataInicio.Size = new System.Drawing.Size(72, 19);
            this.lblDataInicio.TabIndex = 2;
            this.lblDataInicio.Text = "Data Início:";
            // 
            // dtpDataInicio
            // 
            this.dtpDataInicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataInicio.Location = new System.Drawing.Point(185, 45);
            this.dtpDataInicio.Name = "dtpDataInicio";
            this.dtpDataInicio.Size = new System.Drawing.Size(120, 25);
            this.dtpDataInicio.TabIndex = 3;
            this.dtpDataInicio.TabStop = false;
            this.dtpDataInicio.Text = "20/06/2025";
            this.dtpDataInicio.ThemeName = "Fluent";
            this.dtpDataInicio.Value = new System.DateTime(2025, 6, 20, 1, 59, 52, 754);
            // 
            // lblDataFim
            // 
            this.lblDataFim.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDataFim.Location = new System.Drawing.Point(325, 25);
            this.lblDataFim.Name = "lblDataFim";
            this.lblDataFim.Size = new System.Drawing.Size(62, 19);
            this.lblDataFim.TabIndex = 4;
            this.lblDataFim.Text = "Data Fim:";
            // 
            // dtpDataFim
            // 
            this.dtpDataFim.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDataFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataFim.Location = new System.Drawing.Point(325, 45);
            this.dtpDataFim.Name = "dtpDataFim";
            this.dtpDataFim.Size = new System.Drawing.Size(120, 25);
            this.dtpDataFim.TabIndex = 5;
            this.dtpDataFim.TabStop = false;
            this.dtpDataFim.Text = "20/06/2025";
            this.dtpDataFim.ThemeName = "Fluent";
            this.dtpDataFim.Value = new System.DateTime(2025, 6, 20, 1, 59, 52, 781);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(465, 43);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(80, 25);
            this.btnFiltrar.TabIndex = 6;
            this.btnFiltrar.Text = "🔍 Filtrar";
            this.btnFiltrar.ThemeName = "Fluent";
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnLimparFiltros
            // 
            this.btnLimparFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnLimparFiltros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimparFiltros.ForeColor = System.Drawing.Color.White;
            this.btnLimparFiltros.Location = new System.Drawing.Point(555, 43);
            this.btnLimparFiltros.Name = "btnLimparFiltros";
            this.btnLimparFiltros.Size = new System.Drawing.Size(80, 25);
            this.btnLimparFiltros.TabIndex = 7;
            this.btnLimparFiltros.Text = "🗑️ Limpar";
            this.btnLimparFiltros.ThemeName = "Fluent";
            this.btnLimparFiltros.Click += new System.EventHandler(this.btnLimparFiltros_Click);
            // 
            // estatisticasCard
            // 
            this.estatisticasCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.estatisticasCard.Controls.Add(this.iconStats);
            this.estatisticasCard.Controls.Add(this.lblTotalPendentes);
            this.estatisticasCard.Controls.Add(this.lblValorTotal);
            this.estatisticasCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.estatisticasCard.Location = new System.Drawing.Point(20, 20);
            this.estatisticasCard.Name = "estatisticasCard";
            this.estatisticasCard.Padding = new System.Windows.Forms.Padding(15);
            this.estatisticasCard.Size = new System.Drawing.Size(960, 60);
            this.estatisticasCard.TabIndex = 0;
            this.estatisticasCard.ThemeName = "Fluent";
            // 
            // iconStats
            // 
            this.iconStats.Font = new System.Drawing.Font("Segoe UI Symbol", 16F);
            this.iconStats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.iconStats.Location = new System.Drawing.Point(30, 21);
            this.iconStats.Name = "iconStats";
            this.iconStats.Size = new System.Drawing.Size(32, 33);
            this.iconStats.TabIndex = 0;
            this.iconStats.Text = "📊";
            // 
            // lblTotalPendentes
            // 
            this.lblTotalPendentes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalPendentes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTotalPendentes.Location = new System.Drawing.Point(65, 25);
            this.lblTotalPendentes.Name = "lblTotalPendentes";
            this.lblTotalPendentes.Size = new System.Drawing.Size(205, 25);
            this.lblTotalPendentes.TabIndex = 1;
            this.lblTotalPendentes.Text = "Orçamentos pendentes: 0";
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValorTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblValorTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblValorTotal.Location = new System.Drawing.Point(1518, 30);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(157, 25);
            this.lblValorTotal.TabIndex = 2;
            this.lblValorTotal.Text = "Valor total: R$ 0,00";
            this.lblValorTotal.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.headerPanel.Controls.Add(this.iconTitulo);
            this.headerPanel.Controls.Add(this.lblTitulo);
            this.headerPanel.Controls.Add(this.lblSubtitulo);
            this.headerPanel.Controls.Add(this.progressBar);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.ForeColor = System.Drawing.Color.White;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.headerPanel.Size = new System.Drawing.Size(1000, 80);
            this.headerPanel.TabIndex = 0;
            // 
            // iconTitulo
            // 
            this.iconTitulo.Font = new System.Drawing.Font("Segoe UI Symbol", 20F);
            this.iconTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.iconTitulo.Location = new System.Drawing.Point(20, 17);
            this.iconTitulo.Name = "iconTitulo";
            this.iconTitulo.Size = new System.Drawing.Size(39, 41);
            this.iconTitulo.TabIndex = 0;
            this.iconTitulo.Text = "✅";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(60, 14);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(283, 33);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Aprovação de Orçamentos";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(60, 46);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(295, 21);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Gerencie aprovações e rejeições de orçamentos";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.BackColor = System.Drawing.Color.Transparent;
            this.progressBar.Location = new System.Drawing.Point(750, 35);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(230, 6);
            this.progressBar.TabIndex = 3;
            this.progressBar.ThemeName = "Fluent";
            this.progressBar.Visible = false;
            this.progressBar.WaitingIndicators.Add(this.dotsLineWaitingBarIndicatorElement1);
            this.progressBar.WaitingIndicatorSize = new System.Drawing.Size(100, 14);
            this.progressBar.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsLine;
            // 
            // dotsLineWaitingBarIndicatorElement1
            // 
            this.dotsLineWaitingBarIndicatorElement1.Name = "dotsLineWaitingBarIndicatorElement1";
            // 
            // footerPanel
            // 
            this.footerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.footerPanel.Controls.Add(this.btnDetalhes);
            this.footerPanel.Controls.Add(this.btnAprovar);
            this.footerPanel.Controls.Add(this.btnRejeitar);
            this.footerPanel.Controls.Add(this.btnAtualizar);
            this.footerPanel.Controls.Add(this.btnFechar);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 630);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.footerPanel.Size = new System.Drawing.Size(1000, 70);
            this.footerPanel.TabIndex = 2;
            // 
            // btnDetalhes
            // 
            this.btnDetalhes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnDetalhes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDetalhes.ForeColor = System.Drawing.Color.White;
            this.btnDetalhes.Location = new System.Drawing.Point(20, 20);
            this.btnDetalhes.Name = "btnDetalhes";
            this.btnDetalhes.Size = new System.Drawing.Size(120, 35);
            this.btnDetalhes.TabIndex = 0;
            this.btnDetalhes.Text = "👁️ Ver Detalhes";
            this.btnDetalhes.ThemeName = "Fluent";
            this.btnDetalhes.Click += new System.EventHandler(this.btnDetalhes_Click);
            // 
            // btnAprovar
            // 
            this.btnAprovar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAprovar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAprovar.ForeColor = System.Drawing.Color.White;
            this.btnAprovar.Location = new System.Drawing.Point(600, 20);
            this.btnAprovar.Name = "btnAprovar";
            this.btnAprovar.Size = new System.Drawing.Size(100, 35);
            this.btnAprovar.TabIndex = 1;
            this.btnAprovar.Text = "✅ Aprovar";
            this.btnAprovar.ThemeName = "Fluent";
            this.btnAprovar.Click += new System.EventHandler(this.btnAprovar_Click);
            // 
            // btnRejeitar
            // 
            this.btnRejeitar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnRejeitar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRejeitar.ForeColor = System.Drawing.Color.White;
            this.btnRejeitar.Location = new System.Drawing.Point(710, 20);
            this.btnRejeitar.Name = "btnRejeitar";
            this.btnRejeitar.Size = new System.Drawing.Size(100, 35);
            this.btnRejeitar.TabIndex = 2;
            this.btnRejeitar.Text = "❌ Rejeitar";
            this.btnRejeitar.ThemeName = "Fluent";
            this.btnRejeitar.Click += new System.EventHandler(this.btnRejeitar_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnAtualizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAtualizar.ForeColor = System.Drawing.Color.White;
            this.btnAtualizar.Location = new System.Drawing.Point(490, 20);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(100, 35);
            this.btnAtualizar.TabIndex = 3;
            this.btnAtualizar.Text = "🔄 Atualizar";
            this.btnAtualizar.ThemeName = "Fluent";
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(880, 20);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(100, 35);
            this.btnFechar.TabIndex = 4;
            this.btnFechar.Text = "🚪 Fechar";
            this.btnFechar.ThemeName = "Fluent";
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // frmAprovacoesOrcamentos
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.mainContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(773, 522);
            this.Name = "frmAprovacoesOrcamentos";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.ThemeName = "Fluent";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAprovacoesOrcamentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).EndInit();
            this.mainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contentPanel)).EndInit();
            this.contentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultadosCard)).EndInit();
            this.resultadosCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrcamentosPendentes.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrcamentosPendentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filtrosCard)).EndInit();
            this.filtrosCard.ResumeLayout(false);
            this.filtrosCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFiltroStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDataInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDataInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDataFim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDataFim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFiltrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLimparFiltros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estatisticasCard)).EndInit();
            this.estatisticasCard.ResumeLayout(false);
            this.estatisticasCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalPendentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValorTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconTitulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubtitulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.footerPanel)).EndInit();
            this.footerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnDetalhes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAprovar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRejeitar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAtualizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFechar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }



        #region Componentes Modernos

        // APENAS TEMAS NECESSÁRIOS
        private Telerik.WinControls.Themes.FluentTheme fluentTheme1;
        private Telerik.WinControls.Themes.MaterialTheme materialTheme1;

        // LAYOUT MODERNO
        private Telerik.WinControls.UI.RadPanel mainContainer;
        private Telerik.WinControls.UI.RadPanel headerPanel;
        private Telerik.WinControls.UI.RadPanel contentPanel;
        private Telerik.WinControls.UI.RadPanel footerPanel;
        private Telerik.WinControls.UI.RadPanel estatisticasCard;

        // CARDS
        private Telerik.WinControls.UI.RadGroupBox filtrosCard;
        private Telerik.WinControls.UI.RadGroupBox resultadosCard;

        // CONTROLES DE INTERFACE
        private Telerik.WinControls.UI.RadLabel iconTitulo;
        private Telerik.WinControls.UI.RadLabel lblTitulo;
        private Telerik.WinControls.UI.RadLabel lblSubtitulo;
        private Telerik.WinControls.UI.RadLabel iconStats;
        private Telerik.WinControls.UI.RadLabel lblTotalPendentes;
        private Telerik.WinControls.UI.RadLabel lblValorTotal;

        // FILTROS
        private Telerik.WinControls.UI.RadLabel lblStatus;
        private Telerik.WinControls.UI.RadDropDownList cmbFiltroStatus;
        private Telerik.WinControls.UI.RadLabel lblDataInicio;
        private Telerik.WinControls.UI.RadDateTimePicker dtpDataInicio;
        private Telerik.WinControls.UI.RadLabel lblDataFim;
        private Telerik.WinControls.UI.RadDateTimePicker dtpDataFim;

        // BOTÕES
        private Telerik.WinControls.UI.RadButton btnFiltrar;
        private Telerik.WinControls.UI.RadButton btnLimparFiltros;
        private Telerik.WinControls.UI.RadButton btnDetalhes;
        private Telerik.WinControls.UI.RadButton btnAprovar;
        private Telerik.WinControls.UI.RadButton btnRejeitar;
        private Telerik.WinControls.UI.RadButton btnAtualizar;
        private Telerik.WinControls.UI.RadButton btnFechar;

        // PROGRESS BAR
        private Telerik.WinControls.UI.RadWaitingBar progressBar;
        private Telerik.WinControls.UI.DotsLineWaitingBarIndicatorElement dotsIndicator;

        #endregion

        private Telerik.WinControls.UI.DotsLineWaitingBarIndicatorElement dotsLineWaitingBarIndicatorElement1;
        private Telerik.WinControls.UI.RadGridView dgvOrcamentosPendentes;
    }
}
