using System;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace  Acessos
{
    partial class frmVisualizarOrcamento
    {
        private System.ComponentModel.IContainer components = null;

       

        private void InitializeComponent()
        {
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.fluentTheme1 = new Telerik.WinControls.Themes.FluentTheme();
            this.materialTheme1 = new Telerik.WinControls.Themes.MaterialTheme();
            this.mainContainer = new Telerik.WinControls.UI.RadPanel();
            this.contentPanel = new Telerik.WinControls.UI.RadPanel();
            this.itensCard = new Telerik.WinControls.UI.RadGroupBox();
            this.dgvItens = new Telerik.WinControls.UI.RadGridView();
            this.clienteCard = new Telerik.WinControls.UI.RadGroupBox();
            this.iconCliente = new Telerik.WinControls.UI.RadLabel();
            this.lblCliente = new Telerik.WinControls.UI.RadLabel();
            this.lblEmail = new Telerik.WinControls.UI.RadLabel();
            this.lblTelefone = new Telerik.WinControls.UI.RadLabel();
            this.lblEndereco = new Telerik.WinControls.UI.RadLabel();
            this.cabecalhoCard = new Telerik.WinControls.UI.RadGroupBox();
            this.lblNumeroOrcamento = new Telerik.WinControls.UI.RadLabel();
            this.lblDataOrcamento = new Telerik.WinControls.UI.RadLabel();
            this.iconStatus = new Telerik.WinControls.UI.RadLabel();
            this.lblStatus = new Telerik.WinControls.UI.RadLabel();
            this.headerPanel = new Telerik.WinControls.UI.RadPanel();
            this.iconPrincipal = new Telerik.WinControls.UI.RadLabel();
            this.lblTitulo = new Telerik.WinControls.UI.RadLabel();
            this.lblSubtitulo = new Telerik.WinControls.UI.RadLabel();
            this.progressBar = new Telerik.WinControls.UI.RadWaitingBar();
            this.dotsLineWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.DotsLineWaitingBarIndicatorElement();
            this.footerPanel = new Telerik.WinControls.UI.RadPanel();
            this.resumoCard = new Telerik.WinControls.UI.RadPanel();
            this.lblSubtotal = new Telerik.WinControls.UI.RadLabel();
            this.iconFinanceiro = new Telerik.WinControls.UI.RadLabel();
            this.lblDesconto = new Telerik.WinControls.UI.RadLabel();
            this.lblValorTotal = new Telerik.WinControls.UI.RadLabel();
            this.btnSalvarPDF = new Telerik.WinControls.UI.RadButton();
            this.btnImprimir = new Telerik.WinControls.UI.RadButton();
            this.btnFechar = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).BeginInit();
            this.mainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contentPanel)).BeginInit();
            this.contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itensCard)).BeginInit();
            this.itensCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteCard)).BeginInit();
            this.clienteCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEndereco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cabecalhoCard)).BeginInit();
            this.cabecalhoCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblNumeroOrcamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDataOrcamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel)).BeginInit();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubtitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.footerPanel)).BeginInit();
            this.footerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resumoCard)).BeginInit();
            this.resumoCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubtotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconFinanceiro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDesconto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValorTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalvarPDF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImprimir)).BeginInit();
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
            this.mainContainer.Size = new System.Drawing.Size(1145, 719);
            this.mainContainer.TabIndex = 0;
            this.mainContainer.ThemeName = "Fluent";
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.itensCard);
            this.contentPanel.Controls.Add(this.clienteCard);
            this.contentPanel.Controls.Add(this.cabecalhoCard);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 90);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(25, 20, 25, 20);
            this.contentPanel.Size = new System.Drawing.Size(1145, 539);
            this.contentPanel.TabIndex = 1;
            this.contentPanel.ThemeName = "Fluent";
            // 
            // itensCard
            // 
            this.itensCard.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.itensCard.Controls.Add(this.dgvItens);
            this.itensCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itensCard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.itensCard.HeaderMargin = new System.Windows.Forms.Padding(1);
            this.itensCard.HeaderText = "📦 Itens do Orçamento";
            this.itensCard.Location = new System.Drawing.Point(25, 246);
            this.itensCard.Name = "itensCard";
            this.itensCard.Padding = new System.Windows.Forms.Padding(20);
            this.itensCard.Size = new System.Drawing.Size(1095, 273);
            this.itensCard.TabIndex = 2;
            this.itensCard.Text = "📦 Itens do Orçamento";
            this.itensCard.ThemeName = "Fluent";
            // 
            // dgvItens
            // 
            this.dgvItens.AutoSizeRows = true;
            this.dgvItens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItens.Location = new System.Drawing.Point(20, 20);
            // 
            // 
            // 
            this.dgvItens.MasterTemplate.AllowAddNewRow = false;
            this.dgvItens.MasterTemplate.AllowColumnReorder = false;
            this.dgvItens.MasterTemplate.AllowColumnResize = false;
            this.dgvItens.MasterTemplate.AllowDeleteRow = false;
            this.dgvItens.MasterTemplate.AllowDragToGroup = false;
            this.dgvItens.MasterTemplate.AllowRowResize = false;
            this.dgvItens.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvItens.MasterTemplate.ClipboardCopyMode = Telerik.WinControls.UI.GridViewClipboardCopyMode.Disable;
            this.dgvItens.MasterTemplate.ClipboardCutMode = Telerik.WinControls.UI.GridViewClipboardCutMode.Disable;
            this.dgvItens.MasterTemplate.ClipboardPasteMode = Telerik.WinControls.UI.GridViewClipboardPasteMode.Disable;
            this.dgvItens.MasterTemplate.EnableAlternatingRowColor = true;
            this.dgvItens.MasterTemplate.EnableGrouping = false;
            this.dgvItens.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgvItens.Name = "dgvItens";
            this.dgvItens.ReadOnly = true;
            this.dgvItens.ShowGroupPanel = false;
            this.dgvItens.Size = new System.Drawing.Size(1055, 233);
            this.dgvItens.TabIndex = 0;
            this.dgvItens.ThemeName = "Fluent";
            // 
            // clienteCard
            // 
            this.clienteCard.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.clienteCard.Controls.Add(this.iconCliente);
            this.clienteCard.Controls.Add(this.lblCliente);
            this.clienteCard.Controls.Add(this.lblEmail);
            this.clienteCard.Controls.Add(this.lblTelefone);
            this.clienteCard.Controls.Add(this.lblEndereco);
            this.clienteCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.clienteCard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.clienteCard.HeaderMargin = new System.Windows.Forms.Padding(1);
            this.clienteCard.HeaderText = "👤 Dados do Cliente";
            this.clienteCard.Location = new System.Drawing.Point(25, 126);
            this.clienteCard.Name = "clienteCard";
            this.clienteCard.Padding = new System.Windows.Forms.Padding(20);
            this.clienteCard.Size = new System.Drawing.Size(1095, 120);
            this.clienteCard.TabIndex = 1;
            this.clienteCard.Text = "👤 Dados do Cliente";
            this.clienteCard.ThemeName = "Fluent";
            // 
            // iconCliente
            // 
            this.iconCliente.Font = new System.Drawing.Font("Segoe UI Symbol", 14F);
            this.iconCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.iconCliente.Location = new System.Drawing.Point(20, 30);
            this.iconCliente.Name = "iconCliente";
            this.iconCliente.Size = new System.Drawing.Size(28, 29);
            this.iconCliente.TabIndex = 0;
            this.iconCliente.Text = "👤";
            // 
            // lblCliente
            // 
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblCliente.Location = new System.Drawing.Point(50, 30);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(65, 23);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Cliente: ";
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblEmail.Location = new System.Drawing.Point(50, 55);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(59, 21);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "📧 Email: ";
            // 
            // lblTelefone
            // 
            this.lblTelefone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTelefone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblTelefone.Location = new System.Drawing.Point(450, 55);
            this.lblTelefone.Name = "lblTelefone";
            this.lblTelefone.Size = new System.Drawing.Size(77, 21);
            this.lblTelefone.TabIndex = 3;
            this.lblTelefone.Text = "📞 Telefone: ";
            // 
            // lblEndereco
            // 
            this.lblEndereco.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEndereco.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblEndereco.Location = new System.Drawing.Point(50, 80);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(83, 21);
            this.lblEndereco.TabIndex = 4;
            this.lblEndereco.Text = "🏠 Endereço: ";
            // 
            // cabecalhoCard
            // 
            this.cabecalhoCard.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.cabecalhoCard.Controls.Add(this.lblNumeroOrcamento);
            this.cabecalhoCard.Controls.Add(this.lblDataOrcamento);
            this.cabecalhoCard.Controls.Add(this.iconStatus);
            this.cabecalhoCard.Controls.Add(this.lblStatus);
            this.cabecalhoCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.cabecalhoCard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.cabecalhoCard.HeaderMargin = new System.Windows.Forms.Padding(1);
            this.cabecalhoCard.HeaderText = "📊 Informações do Orçamento";
            this.cabecalhoCard.Location = new System.Drawing.Point(25, 20);
            this.cabecalhoCard.Name = "cabecalhoCard";
            this.cabecalhoCard.Padding = new System.Windows.Forms.Padding(20);
            this.cabecalhoCard.Size = new System.Drawing.Size(1095, 106);
            this.cabecalhoCard.TabIndex = 0;
            this.cabecalhoCard.Text = "📊 Informações do Orçamento";
            this.cabecalhoCard.ThemeName = "Fluent";
            // 
            // lblNumeroOrcamento
            // 
            this.lblNumeroOrcamento.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblNumeroOrcamento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblNumeroOrcamento.Location = new System.Drawing.Point(20, 30);
            this.lblNumeroOrcamento.Name = "lblNumeroOrcamento";
            this.lblNumeroOrcamento.Size = new System.Drawing.Size(149, 29);
            this.lblNumeroOrcamento.TabIndex = 0;
            this.lblNumeroOrcamento.Text = "Orçamento Nº: ";
            // 
            // lblDataOrcamento
            // 
            this.lblDataOrcamento.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDataOrcamento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblDataOrcamento.Location = new System.Drawing.Point(20, 63);
            this.lblDataOrcamento.Name = "lblDataOrcamento";
            this.lblDataOrcamento.Size = new System.Drawing.Size(46, 23);
            this.lblDataOrcamento.TabIndex = 1;
            this.lblDataOrcamento.Text = "Data: ";
            // 
            // iconStatus
            // 
            this.iconStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iconStatus.Font = new System.Drawing.Font("Segoe UI Symbol", 16F);
            this.iconStatus.Location = new System.Drawing.Point(759, 11);
            this.iconStatus.Name = "iconStatus";
            this.iconStatus.Size = new System.Drawing.Size(23, 33);
            this.iconStatus.TabIndex = 2;
            this.iconStatus.Text = "⏳";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(788, 19);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(65, 25);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status: ";
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.headerPanel.Controls.Add(this.iconPrincipal);
            this.headerPanel.Controls.Add(this.lblTitulo);
            this.headerPanel.Controls.Add(this.lblSubtitulo);
            this.headerPanel.Controls.Add(this.progressBar);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.ForeColor = System.Drawing.Color.White;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(25, 20, 25, 20);
            this.headerPanel.Size = new System.Drawing.Size(1145, 90);
            this.headerPanel.TabIndex = 0;
            // 
            // iconPrincipal
            // 
            this.iconPrincipal.Font = new System.Drawing.Font("Segoe UI Symbol", 22F);
            this.iconPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.iconPrincipal.Location = new System.Drawing.Point(25, 25);
            this.iconPrincipal.Name = "iconPrincipal";
            this.iconPrincipal.Size = new System.Drawing.Size(42, 45);
            this.iconPrincipal.TabIndex = 0;
            this.iconPrincipal.Text = "📋";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(70, 22);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(258, 37);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Visualizar Orçamento";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(70, 55);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(321, 23);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Detalhes completos do orçamento selecionado";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.BackColor = System.Drawing.Color.Transparent;
            this.progressBar.Location = new System.Drawing.Point(895, 40);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(225, 8);
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
            this.footerPanel.Controls.Add(this.resumoCard);
            this.footerPanel.Controls.Add(this.btnSalvarPDF);
            this.footerPanel.Controls.Add(this.btnImprimir);
            this.footerPanel.Controls.Add(this.btnFechar);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 629);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Padding = new System.Windows.Forms.Padding(25, 15, 25, 15);
            this.footerPanel.Size = new System.Drawing.Size(1145, 90);
            this.footerPanel.TabIndex = 2;
            // 
            // resumoCard
            // 
            this.resumoCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.resumoCard.Controls.Add(this.lblSubtotal);
            this.resumoCard.Controls.Add(this.iconFinanceiro);
            this.resumoCard.Controls.Add(this.lblDesconto);
            this.resumoCard.Controls.Add(this.lblValorTotal);
            this.resumoCard.Location = new System.Drawing.Point(25, 15);
            this.resumoCard.Name = "resumoCard";
            this.resumoCard.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.resumoCard.Size = new System.Drawing.Size(610, 60);
            this.resumoCard.TabIndex = 0;
            this.resumoCard.ThemeName = "Fluent";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblSubtotal.Location = new System.Drawing.Point(256, 22);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(130, 25);
            this.lblSubtotal.TabIndex = 1;
            this.lblSubtotal.Text = "Subtotal: R$ 0,00";
            this.lblSubtotal.Visible = false;
            // 
            // iconFinanceiro
            // 
            this.iconFinanceiro.Font = new System.Drawing.Font("Segoe UI Symbol", 16F);
            this.iconFinanceiro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.iconFinanceiro.Location = new System.Drawing.Point(10, 17);
            this.iconFinanceiro.Name = "iconFinanceiro";
            this.iconFinanceiro.Size = new System.Drawing.Size(32, 33);
            this.iconFinanceiro.TabIndex = 0;
            this.iconFinanceiro.Text = "💰";
            // 
            // lblDesconto
            // 
            this.lblDesconto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesconto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblDesconto.Location = new System.Drawing.Point(437, 20);
            this.lblDesconto.Name = "lblDesconto";
            this.lblDesconto.Size = new System.Drawing.Size(138, 25);
            this.lblDesconto.TabIndex = 2;
            this.lblDesconto.Text = "Desconto: R$ 0,00";
            this.lblDesconto.Visible = false;
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblValorTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblValorTotal.Location = new System.Drawing.Point(41, 18);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(133, 29);
            this.lblValorTotal.TabIndex = 3;
            this.lblValorTotal.Text = "Total: R$ 0,00";
            // 
            // btnSalvarPDF
            // 
            this.btnSalvarPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvarPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnSalvarPDF.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSalvarPDF.ForeColor = System.Drawing.Color.White;
            this.btnSalvarPDF.Location = new System.Drawing.Point(748, 25);
            this.btnSalvarPDF.Name = "btnSalvarPDF";
            this.btnSalvarPDF.Size = new System.Drawing.Size(130, 40);
            this.btnSalvarPDF.TabIndex = 1;
            this.btnSalvarPDF.Text = "📄 Salvar PDF";
            this.btnSalvarPDF.ThemeName = "Fluent";
            this.btnSalvarPDF.Click += new System.EventHandler(this.btnSalvarPDF_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(888, 25);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(120, 40);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "🖨️ Imprimir";
            this.btnImprimir.ThemeName = "Fluent";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(1018, 25);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(100, 40);
            this.btnFechar.TabIndex = 3;
            this.btnFechar.Text = "🚪 Fechar";
            this.btnFechar.ThemeName = "Fluent";
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // VisualizarOrcamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 719);
            this.Controls.Add(this.mainContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "VisualizarOrcamento";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.ThemeName = "Fluent";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.VisualizarOrcamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).EndInit();
            this.mainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contentPanel)).EndInit();
            this.contentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itensCard)).EndInit();
            this.itensCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteCard)).EndInit();
            this.clienteCard.ResumeLayout(false);
            this.clienteCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEndereco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cabecalhoCard)).EndInit();
            this.cabecalhoCard.ResumeLayout(false);
            this.cabecalhoCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblNumeroOrcamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDataOrcamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubtitulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.footerPanel)).EndInit();
            this.footerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resumoCard)).EndInit();
            this.resumoCard.ResumeLayout(false);
            this.resumoCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubtotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconFinanceiro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDesconto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValorTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalvarPDF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImprimir)).EndInit();
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
        private Telerik.WinControls.UI.RadPanel resumoCard;

        // CARDS
        private Telerik.WinControls.UI.RadGroupBox cabecalhoCard;
        private Telerik.WinControls.UI.RadGroupBox clienteCard;
        private Telerik.WinControls.UI.RadGroupBox itensCard;

        // CONTROLES DE INTERFACE
        private Telerik.WinControls.UI.RadLabel iconPrincipal;
        private Telerik.WinControls.UI.RadLabel lblTitulo;
        private Telerik.WinControls.UI.RadLabel lblSubtitulo;

        // INFORMAÇÕES DO ORÇAMENTO
        private Telerik.WinControls.UI.RadLabel lblNumeroOrcamento;
        private Telerik.WinControls.UI.RadLabel lblDataOrcamento;
        private Telerik.WinControls.UI.RadLabel iconStatus;
        private Telerik.WinControls.UI.RadLabel lblStatus;

        // DADOS DO CLIENTE
        private Telerik.WinControls.UI.RadLabel iconCliente;
        private Telerik.WinControls.UI.RadLabel lblCliente;
        private Telerik.WinControls.UI.RadLabel lblEmail;
        private Telerik.WinControls.UI.RadLabel lblTelefone;
        private Telerik.WinControls.UI.RadLabel lblEndereco;

        // GRID
        private Telerik.WinControls.UI.RadGridView dgvItens;

        // RESUMO FINANCEIRO
        private Telerik.WinControls.UI.RadLabel iconFinanceiro;
        private Telerik.WinControls.UI.RadLabel lblSubtotal;
        private Telerik.WinControls.UI.RadLabel lblDesconto;
        private Telerik.WinControls.UI.RadLabel lblValorTotal;

        // BOTÕES
        private Telerik.WinControls.UI.RadButton btnSalvarPDF;
        private Telerik.WinControls.UI.RadButton btnImprimir;
        private Telerik.WinControls.UI.RadButton btnFechar;

        // PROGRESS BAR
        private Telerik.WinControls.UI.RadWaitingBar progressBar;
        private Telerik.WinControls.UI.DotsLineWaitingBarIndicatorElement dotsIndicator;

        #endregion
              

        private DotsLineWaitingBarIndicatorElement dotsLineWaitingBarIndicatorElement1;
    }
}
