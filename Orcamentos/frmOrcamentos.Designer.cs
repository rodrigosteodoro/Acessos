using System.Drawing;
using System.Windows.Forms;

namespace  Acessos
{
    partial class frmOrcamentos
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition7 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition8 = new Telerik.WinControls.UI.TableViewDefinition();
            this.btnSalvarOrcamento = new Telerik.WinControls.UI.RadButton();
            this.btnNovo = new Telerik.WinControls.UI.RadButton();
            this.btnAdicionarItem = new Telerik.WinControls.UI.RadButton();
            this.btnRemoverItem = new Telerik.WinControls.UI.RadButton();
            this.btnImprimir = new Telerik.WinControls.UI.RadButton();
            this.btnVerificarOrcamento = new Telerik.WinControls.UI.RadButton();
            this.btnBuscarCliente = new Telerik.WinControls.UI.RadButton();
            this.btnNovoCliente = new Telerik.WinControls.UI.RadButton();
            this.btnSolicitarAprovacao = new Telerik.WinControls.UI.RadButton();
            this.btnAprovarOrcamento = new Telerik.WinControls.UI.RadButton();
            this.btnRejeitarOrcamento = new Telerik.WinControls.UI.RadButton();
            this.btnVerHistorico = new Telerik.WinControls.UI.RadButton();
            this.txtCodigoOrcamento = new Telerik.WinControls.UI.RadTextBox();
            this.txtNomeCliente = new Telerik.WinControls.UI.RadTextBox();
            this.txtCPF_CNPJ = new Telerik.WinControls.UI.RadTextBox();
            this.txtTelefone = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.txtEmail = new Telerik.WinControls.UI.RadTextBox();
            this.txtDesconto = new Telerik.WinControls.UI.RadSpinEditor();
            this.txtObservacoes = new Telerik.WinControls.UI.RadTextBox();
            this.lblCodigoOrcamento = new Telerik.WinControls.UI.RadLabel();
            this.lblNomeCliente = new Telerik.WinControls.UI.RadLabel();
            this.lblCPF_CNPJ = new Telerik.WinControls.UI.RadLabel();
            this.lblTelefone = new Telerik.WinControls.UI.RadLabel();
            this.lblEmail = new Telerik.WinControls.UI.RadLabel();
            this.lblDesconto = new Telerik.WinControls.UI.RadLabel();
            this.lblObservacoes = new Telerik.WinControls.UI.RadLabel();
            this.lblTotal = new Telerik.WinControls.UI.RadLabel();
            this.lblStatusOrcamento = new Telerik.WinControls.UI.RadLabel();
            this.lblItensDisponiveis = new Telerik.WinControls.UI.RadLabel();
            this.lblItensOrcamento = new Telerik.WinControls.UI.RadLabel();
            this.dgvItensDisponiveis = new Telerik.WinControls.UI.RadGridView();
            this.dgvItensOrcamento = new Telerik.WinControls.UI.RadGridView();
            this.groupBoxCliente = new Telerik.WinControls.UI.RadGroupBox();
            this.groupBoxItens = new Telerik.WinControls.UI.RadGroupBox();
            this.groupBoxOrcamento = new Telerik.WinControls.UI.RadGroupBox();
            this.materialTheme1 = new Telerik.WinControls.Themes.MaterialTheme();
            this.headerPanel = new Telerik.WinControls.UI.RadPanel();
            this.lblSubtitulo = new Telerik.WinControls.UI.RadLabel();
            this.iconPrincipal = new Telerik.WinControls.UI.RadLabel();
            this.lblTitulo = new Telerik.WinControls.UI.RadLabel();
            this.progressBar = new Telerik.WinControls.UI.RadWaitingBar();
            this.dotsLineWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.DotsLineWaitingBarIndicatorElement();
            this.lblSubtotal = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalvarOrcamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNovo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdicionarItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemoverItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImprimir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerificarOrcamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscarCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNovoCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSolicitarAprovacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAprovarOrcamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRejeitarOrcamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerHistorico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoOrcamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNomeCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCPF_CNPJ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesconto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacoes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCodigoOrcamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNomeCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCPF_CNPJ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDesconto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblObservacoes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusOrcamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItensDisponiveis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItensOrcamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensDisponiveis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensDisponiveis.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensOrcamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensOrcamento.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxCliente)).BeginInit();
            this.groupBoxCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxItens)).BeginInit();
            this.groupBoxItens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxOrcamento)).BeginInit();
            this.groupBoxOrcamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel)).BeginInit();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubtitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubtotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvarOrcamento
            // 
            this.btnSalvarOrcamento.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSalvarOrcamento.ForeColor = System.Drawing.Color.Black;
            this.btnSalvarOrcamento.Location = new System.Drawing.Point(146, 586);
            this.btnSalvarOrcamento.Name = "btnSalvarOrcamento";
            this.btnSalvarOrcamento.Size = new System.Drawing.Size(100, 36);
            this.btnSalvarOrcamento.TabIndex = 0;
            this.btnSalvarOrcamento.Text = "Salvar";
            this.btnSalvarOrcamento.ThemeName = "Material";
            this.btnSalvarOrcamento.Click += new System.EventHandler(this.BtnSalvarOrcamento_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnNovo.ForeColor = System.Drawing.Color.Black;
            this.btnNovo.Location = new System.Drawing.Point(252, 586);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(100, 36);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "Novo";
            this.btnNovo.ThemeName = "Material";
            this.btnNovo.Click += new System.EventHandler(this.BtnNovo_Click);
            // 
            // btnAdicionarItem
            // 
            this.btnAdicionarItem.Location = new System.Drawing.Point(524, 116);
            this.btnAdicionarItem.Name = "btnAdicionarItem";
            this.btnAdicionarItem.Size = new System.Drawing.Size(86, 27);
            this.btnAdicionarItem.TabIndex = 2;
            this.btnAdicionarItem.Text = "Adicionar >>";
            this.btnAdicionarItem.Click += new System.EventHandler(this.BtnAdicionarItem_Click);
            // 
            // btnRemoverItem
            // 
            this.btnRemoverItem.Location = new System.Drawing.Point(524, 149);
            this.btnRemoverItem.Name = "btnRemoverItem";
            this.btnRemoverItem.Size = new System.Drawing.Size(86, 29);
            this.btnRemoverItem.TabIndex = 3;
            this.btnRemoverItem.Text = "<< Remover";
            this.btnRemoverItem.Click += new System.EventHandler(this.BtnRemoverItem_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.SkyBlue;
            this.btnImprimir.ForeColor = System.Drawing.Color.Black;
            this.btnImprimir.Location = new System.Drawing.Point(358, 586);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(100, 36);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.ThemeName = "Material";
            this.btnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // btnVerificarOrcamento
            // 
            this.btnVerificarOrcamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnVerificarOrcamento.ForeColor = System.Drawing.Color.Black;
            this.btnVerificarOrcamento.Location = new System.Drawing.Point(464, 586);
            this.btnVerificarOrcamento.Name = "btnVerificarOrcamento";
            this.btnVerificarOrcamento.Size = new System.Drawing.Size(100, 36);
            this.btnVerificarOrcamento.TabIndex = 5;
            this.btnVerificarOrcamento.Text = "Verificar";
            this.btnVerificarOrcamento.ThemeName = "Material";
            this.btnVerificarOrcamento.Click += new System.EventHandler(this.BtnVerificarOrcamento_Click);
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.AutoSize = true;
            this.btnBuscarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBuscarCliente.ForeColor = System.Drawing.Color.White;
            this.btnBuscarCliente.Location = new System.Drawing.Point(350, 37);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(82, 36);
            this.btnBuscarCliente.TabIndex = 6;
            this.btnBuscarCliente.Text = "Buscar";
            this.btnBuscarCliente.ThemeName = "Material";
            this.btnBuscarCliente.Click += new System.EventHandler(this.BtnBuscarCliente_Click);
            // 
            // btnNovoCliente
            // 
            this.btnNovoCliente.AutoSize = true;
            this.btnNovoCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnNovoCliente.ForeColor = System.Drawing.Color.White;
            this.btnNovoCliente.Location = new System.Drawing.Point(445, 37);
            this.btnNovoCliente.Name = "btnNovoCliente";
            this.btnNovoCliente.Size = new System.Drawing.Size(71, 36);
            this.btnNovoCliente.TabIndex = 7;
            this.btnNovoCliente.Text = "Novo";
            this.btnNovoCliente.ThemeName = "Material";
            this.btnNovoCliente.Click += new System.EventHandler(this.BtnNovoCliente_Click);
            // 
            // btnSolicitarAprovacao
            // 
            this.btnSolicitarAprovacao.BackColor = System.Drawing.Color.Yellow;
            this.btnSolicitarAprovacao.ForeColor = System.Drawing.Color.Black;
            this.btnSolicitarAprovacao.Location = new System.Drawing.Point(570, 586);
            this.btnSolicitarAprovacao.Name = "btnSolicitarAprovacao";
            this.btnSolicitarAprovacao.Size = new System.Drawing.Size(172, 36);
            this.btnSolicitarAprovacao.TabIndex = 8;
            this.btnSolicitarAprovacao.Text = "Solicitar Aprovação";
            this.btnSolicitarAprovacao.ThemeName = "Material";
            this.btnSolicitarAprovacao.Click += new System.EventHandler(this.BtnSolicitarAprovacao_Click);
            // 
            // btnAprovarOrcamento
            // 
            this.btnAprovarOrcamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAprovarOrcamento.ForeColor = System.Drawing.Color.Black;
            this.btnAprovarOrcamento.Location = new System.Drawing.Point(748, 586);
            this.btnAprovarOrcamento.Name = "btnAprovarOrcamento";
            this.btnAprovarOrcamento.Size = new System.Drawing.Size(100, 36);
            this.btnAprovarOrcamento.TabIndex = 9;
            this.btnAprovarOrcamento.Text = "Aprovar";
            this.btnAprovarOrcamento.ThemeName = "Material";
            // 
            // btnRejeitarOrcamento
            // 
            this.btnRejeitarOrcamento.BackColor = System.Drawing.Color.Red;
            this.btnRejeitarOrcamento.ForeColor = System.Drawing.Color.Black;
            this.btnRejeitarOrcamento.Location = new System.Drawing.Point(854, 586);
            this.btnRejeitarOrcamento.Name = "btnRejeitarOrcamento";
            this.btnRejeitarOrcamento.Size = new System.Drawing.Size(100, 36);
            this.btnRejeitarOrcamento.TabIndex = 10;
            this.btnRejeitarOrcamento.Text = "Rejeitar";
            this.btnRejeitarOrcamento.ThemeName = "Material";
            // 
            // btnVerHistorico
            // 
            this.btnVerHistorico.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnVerHistorico.ForeColor = System.Drawing.Color.Black;
            this.btnVerHistorico.Location = new System.Drawing.Point(960, 586);
            this.btnVerHistorico.Name = "btnVerHistorico";
            this.btnVerHistorico.Size = new System.Drawing.Size(100, 36);
            this.btnVerHistorico.TabIndex = 11;
            this.btnVerHistorico.Text = "Histórico";
            this.btnVerHistorico.ThemeName = "Material";
            this.btnVerHistorico.Click += new System.EventHandler(this.BtnVerHistorico_Click);
            // 
            // txtCodigoOrcamento
            // 
            this.txtCodigoOrcamento.Location = new System.Drawing.Point(603, 89);
            this.txtCodigoOrcamento.Name = "txtCodigoOrcamento";
            this.txtCodigoOrcamento.ReadOnly = true;
            this.txtCodigoOrcamento.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoOrcamento.TabIndex = 12;
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.Location = new System.Drawing.Point(120, 45);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(224, 20);
            this.txtNomeCliente.TabIndex = 13;
            // 
            // txtCPF_CNPJ
            // 
            this.txtCPF_CNPJ.Location = new System.Drawing.Point(120, 71);
            this.txtCPF_CNPJ.Name = "txtCPF_CNPJ";
            this.txtCPF_CNPJ.Size = new System.Drawing.Size(150, 20);
            this.txtCPF_CNPJ.TabIndex = 14;
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(120, 97);
            this.txtTelefone.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(150, 20);
            this.txtTelefone.TabIndex = 15;
            this.txtTelefone.TabStop = false;
            this.txtTelefone.Text = "____________";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(120, 123);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(224, 20);
            this.txtEmail.TabIndex = 16;
            // 
            // txtDesconto
            // 
            this.txtDesconto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesconto.Location = new System.Drawing.Point(120, 28);
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.Size = new System.Drawing.Size(100, 27);
            this.txtDesconto.TabIndex = 17;
            this.txtDesconto.TextChanged += new System.EventHandler(this.txtDesconto_TextChanged);
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.AutoScroll = true;
            this.txtObservacoes.Location = new System.Drawing.Point(120, 59);
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            // 
            // 
            // 
            this.txtObservacoes.RootElement.StretchVertically = true;
            this.txtObservacoes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacoes.Size = new System.Drawing.Size(300, 86);
            this.txtObservacoes.TabIndex = 18;
            // 
            // lblCodigoOrcamento
            // 
            this.lblCodigoOrcamento.Location = new System.Drawing.Point(552, 89);
            this.lblCodigoOrcamento.Name = "lblCodigoOrcamento";
            this.lblCodigoOrcamento.Size = new System.Drawing.Size(45, 18);
            this.lblCodigoOrcamento.TabIndex = 19;
            this.lblCodigoOrcamento.Text = "Código:";
            // 
            // lblNomeCliente
            // 
            this.lblNomeCliente.Location = new System.Drawing.Point(15, 48);
            this.lblNomeCliente.Name = "lblNomeCliente";
            this.lblNomeCliente.Size = new System.Drawing.Size(39, 18);
            this.lblNomeCliente.TabIndex = 20;
            this.lblNomeCliente.Text = "Nome:";
            // 
            // lblCPF_CNPJ
            // 
            this.lblCPF_CNPJ.Location = new System.Drawing.Point(15, 74);
            this.lblCPF_CNPJ.Name = "lblCPF_CNPJ";
            this.lblCPF_CNPJ.Size = new System.Drawing.Size(58, 18);
            this.lblCPF_CNPJ.TabIndex = 21;
            this.lblCPF_CNPJ.Text = "CPF/CNPJ:";
            // 
            // lblTelefone
            // 
            this.lblTelefone.Location = new System.Drawing.Point(15, 100);
            this.lblTelefone.Name = "lblTelefone";
            this.lblTelefone.Size = new System.Drawing.Size(52, 18);
            this.lblTelefone.TabIndex = 22;
            this.lblTelefone.Text = "Telefone:";
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(15, 126);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 18);
            this.lblEmail.TabIndex = 23;
            this.lblEmail.Text = "Email:";
            // 
            // lblDesconto
            // 
            this.lblDesconto.Location = new System.Drawing.Point(58, 35);
            this.lblDesconto.Name = "lblDesconto";
            this.lblDesconto.Size = new System.Drawing.Size(56, 18);
            this.lblDesconto.TabIndex = 24;
            this.lblDesconto.Text = "Desconto:";
            // 
            // lblObservacoes
            // 
            this.lblObservacoes.Location = new System.Drawing.Point(42, 60);
            this.lblObservacoes.Name = "lblObservacoes";
            this.lblObservacoes.Size = new System.Drawing.Size(72, 18);
            this.lblObservacoes.TabIndex = 25;
            this.lblObservacoes.Text = "Observações:";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Red;
            this.lblTotal.Location = new System.Drawing.Point(592, 164);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(227, 42);
            this.lblTotal.TabIndex = 26;
            this.lblTotal.Text = "Total: R$ 0,00";
            // 
            // lblStatusOrcamento
            // 
            this.lblStatusOrcamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatusOrcamento.Location = new System.Drawing.Point(731, 90);
            this.lblStatusOrcamento.Name = "lblStatusOrcamento";
            this.lblStatusOrcamento.Size = new System.Drawing.Size(88, 19);
            this.lblStatusOrcamento.TabIndex = 27;
            this.lblStatusOrcamento.Text = "Status: Novo";
            // 
            // lblItensDisponiveis
            // 
            this.lblItensDisponiveis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblItensDisponiveis.Location = new System.Drawing.Point(15, 24);
            this.lblItensDisponiveis.Name = "lblItensDisponiveis";
            this.lblItensDisponiveis.Size = new System.Drawing.Size(104, 17);
            this.lblItensDisponiveis.TabIndex = 28;
            this.lblItensDisponiveis.Text = "Itens Disponíveis";
            // 
            // lblItensOrcamento
            // 
            this.lblItensOrcamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblItensOrcamento.Location = new System.Drawing.Point(618, 23);
            this.lblItensOrcamento.Name = "lblItensOrcamento";
            this.lblItensOrcamento.Size = new System.Drawing.Size(119, 17);
            this.lblItensOrcamento.TabIndex = 29;
            this.lblItensOrcamento.Text = "Itens do Orçamento";
            // 
            // dgvItensDisponiveis
            // 
            this.dgvItensDisponiveis.AutoSizeRows = true;
            this.dgvItensDisponiveis.Location = new System.Drawing.Point(15, 44);
            // 
            // 
            // 
            this.dgvItensDisponiveis.MasterTemplate.AllowAddNewRow = false;
            this.dgvItensDisponiveis.MasterTemplate.AllowDeleteRow = false;
            this.dgvItensDisponiveis.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvItensDisponiveis.MasterTemplate.EnableFiltering = true;
            this.dgvItensDisponiveis.MasterTemplate.EnableGrouping = false;
            this.dgvItensDisponiveis.MasterTemplate.ViewDefinition = tableViewDefinition7;
            this.dgvItensDisponiveis.Name = "dgvItensDisponiveis";
            this.dgvItensDisponiveis.Size = new System.Drawing.Size(503, 275);
            this.dgvItensDisponiveis.TabIndex = 30;
            // 
            // dgvItensOrcamento
            // 
            this.dgvItensOrcamento.AutoSizeRows = true;
            this.dgvItensOrcamento.Location = new System.Drawing.Point(616, 44);
            // 
            // 
            // 
            this.dgvItensOrcamento.MasterTemplate.AllowAddNewRow = false;
            this.dgvItensOrcamento.MasterTemplate.AllowDeleteRow = false;
            this.dgvItensOrcamento.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvItensOrcamento.MasterTemplate.EnableFiltering = true;
            this.dgvItensOrcamento.MasterTemplate.EnableGrouping = false;
            this.dgvItensOrcamento.MasterTemplate.ViewDefinition = tableViewDefinition8;
            this.dgvItensOrcamento.Name = "dgvItensOrcamento";
            this.dgvItensOrcamento.Size = new System.Drawing.Size(503, 275);
            this.dgvItensOrcamento.TabIndex = 31;
            // 
            // groupBoxCliente
            // 
            this.groupBoxCliente.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.groupBoxCliente.Controls.Add(this.lblNomeCliente);
            this.groupBoxCliente.Controls.Add(this.txtNomeCliente);
            this.groupBoxCliente.Controls.Add(this.lblCPF_CNPJ);
            this.groupBoxCliente.Controls.Add(this.txtCPF_CNPJ);
            this.groupBoxCliente.Controls.Add(this.lblTelefone);
            this.groupBoxCliente.Controls.Add(this.txtTelefone);
            this.groupBoxCliente.Controls.Add(this.lblEmail);
            this.groupBoxCliente.Controls.Add(this.txtEmail);
            this.groupBoxCliente.Controls.Add(this.btnBuscarCliente);
            this.groupBoxCliente.Controls.Add(this.btnNovoCliente);
            this.groupBoxCliente.HeaderText = "Dados do Cliente";
            this.groupBoxCliente.Location = new System.Drawing.Point(15, 79);
            this.groupBoxCliente.Name = "groupBoxCliente";
            this.groupBoxCliente.Size = new System.Drawing.Size(530, 160);
            this.groupBoxCliente.TabIndex = 32;
            this.groupBoxCliente.Text = "Dados do Cliente";
            // 
            // groupBoxItens
            // 
            this.groupBoxItens.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.groupBoxItens.Controls.Add(this.btnAdicionarItem);
            this.groupBoxItens.Controls.Add(this.btnRemoverItem);
            this.groupBoxItens.Controls.Add(this.lblItensDisponiveis);
            this.groupBoxItens.Controls.Add(this.dgvItensDisponiveis);
            this.groupBoxItens.Controls.Add(this.lblItensOrcamento);
            this.groupBoxItens.Controls.Add(this.dgvItensOrcamento);
            this.groupBoxItens.HeaderText = "Itens";
            this.groupBoxItens.Location = new System.Drawing.Point(6, 245);
            this.groupBoxItens.Name = "groupBoxItens";
            this.groupBoxItens.Size = new System.Drawing.Size(1126, 327);
            this.groupBoxItens.TabIndex = 33;
            this.groupBoxItens.Text = "Itens";
            // 
            // groupBoxOrcamento
            // 
            this.groupBoxOrcamento.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.groupBoxOrcamento.Controls.Add(this.lblDesconto);
            this.groupBoxOrcamento.Controls.Add(this.txtDesconto);
            this.groupBoxOrcamento.Controls.Add(this.lblObservacoes);
            this.groupBoxOrcamento.Controls.Add(this.txtObservacoes);
            this.groupBoxOrcamento.HeaderText = "Resumo do Orçamento";
            this.groupBoxOrcamento.Location = new System.Drawing.Point(326, 626);
            this.groupBoxOrcamento.Name = "groupBoxOrcamento";
            this.groupBoxOrcamento.Size = new System.Drawing.Size(450, 150);
            this.groupBoxOrcamento.TabIndex = 34;
            this.groupBoxOrcamento.Text = "Resumo do Orçamento";
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.headerPanel.Controls.Add(this.lblSubtitulo);
            this.headerPanel.Controls.Add(this.iconPrincipal);
            this.headerPanel.Controls.Add(this.lblTitulo);
            this.headerPanel.Controls.Add(this.progressBar);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.ForeColor = System.Drawing.Color.White;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(25, 20, 25, 20);
            this.headerPanel.Size = new System.Drawing.Size(1144, 73);
            this.headerPanel.TabIndex = 35;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(112, 40);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(246, 21);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "orçamentos completos e com agilidade!";
            // 
            // iconPrincipal
            // 
            this.iconPrincipal.Font = new System.Drawing.Font("Segoe UI Symbol", 22F);
            this.iconPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.iconPrincipal.Location = new System.Drawing.Point(55, 11);
            this.iconPrincipal.Name = "iconPrincipal";
            this.iconPrincipal.Size = new System.Drawing.Size(42, 45);
            this.iconPrincipal.TabIndex = 0;
            this.iconPrincipal.Text = "📋";
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(103, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(284, 37);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Sistema de Orçamentos";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.BackColor = System.Drawing.Color.Transparent;
            this.progressBar.Location = new System.Drawing.Point(894, 40);
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
            this.dotsLineWaitingBarIndicatorElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.dotsLineWaitingBarIndicatorElement1.Name = "dotsLineWaitingBarIndicatorElement1";
            this.dotsLineWaitingBarIndicatorElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.dotsLineWaitingBarIndicatorElement1.UseCompatibleTextRendering = false;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.ForeColor = System.Drawing.Color.SlateBlue;
            this.lblSubtotal.Location = new System.Drawing.Point(854, 164);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(243, 36);
            this.lblSubtotal.TabIndex = 27;
            this.lblSubtotal.Text = "SubTotal: R$ 0,00";
            // 
            // frmOrcamentos
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 788);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.groupBoxOrcamento);
            this.Controls.Add(this.groupBoxItens);
            this.Controls.Add(this.groupBoxCliente);
            this.Controls.Add(this.btnVerHistorico);
            this.Controls.Add(this.btnRejeitarOrcamento);
            this.Controls.Add(this.btnAprovarOrcamento);
            this.Controls.Add(this.btnSolicitarAprovacao);
            this.Controls.Add(this.btnVerificarOrcamento);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnSalvarOrcamento);
            this.Controls.Add(this.lblStatusOrcamento);
            this.Controls.Add(this.lblCodigoOrcamento);
            this.Controls.Add(this.txtCodigoOrcamento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOrcamentos";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "";
            this.ThemeName = "Fluent";
            this.Load += new System.EventHandler(this.frmOrcamentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnSalvarOrcamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNovo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdicionarItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemoverItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImprimir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerificarOrcamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscarCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNovoCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSolicitarAprovacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAprovarOrcamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRejeitarOrcamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerHistorico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoOrcamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNomeCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCPF_CNPJ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesconto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacoes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCodigoOrcamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNomeCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCPF_CNPJ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDesconto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblObservacoes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusOrcamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItensDisponiveis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItensOrcamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensDisponiveis.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensDisponiveis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensOrcamento.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensOrcamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxCliente)).EndInit();
            this.groupBoxCliente.ResumeLayout(false);
            this.groupBoxCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxItens)).EndInit();
            this.groupBoxItens.ResumeLayout(false);
            this.groupBoxItens.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxOrcamento)).EndInit();
            this.groupBoxOrcamento.ResumeLayout(false);
            this.groupBoxOrcamento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubtitulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubtotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnSalvarOrcamento;
        private Telerik.WinControls.UI.RadButton btnNovo;
        private Telerik.WinControls.UI.RadButton btnAdicionarItem;
        private Telerik.WinControls.UI.RadButton btnRemoverItem;
        private Telerik.WinControls.UI.RadButton btnImprimir;
        private Telerik.WinControls.UI.RadButton btnVerificarOrcamento;
        private Telerik.WinControls.UI.RadButton btnBuscarCliente;
        private Telerik.WinControls.UI.RadButton btnNovoCliente;
        private Telerik.WinControls.UI.RadButton btnSolicitarAprovacao;
        private Telerik.WinControls.UI.RadButton btnAprovarOrcamento;
        private Telerik.WinControls.UI.RadButton btnRejeitarOrcamento;
        private Telerik.WinControls.UI.RadButton btnVerHistorico;

        private Telerik.WinControls.UI.RadTextBox txtCodigoOrcamento;
        private Telerik.WinControls.UI.RadTextBox txtNomeCliente;
        private Telerik.WinControls.UI.RadTextBox txtCPF_CNPJ;
        private Telerik.WinControls.UI.RadMaskedEditBox txtTelefone;
        private Telerik.WinControls.UI.RadTextBox txtEmail;
        private Telerik.WinControls.UI.RadSpinEditor txtDesconto;
        private Telerik.WinControls.UI.RadTextBox txtObservacoes;

        private Telerik.WinControls.UI.RadLabel lblCodigoOrcamento;
        private Telerik.WinControls.UI.RadLabel lblNomeCliente;
        private Telerik.WinControls.UI.RadLabel lblCPF_CNPJ;
        private Telerik.WinControls.UI.RadLabel lblTelefone;
        private Telerik.WinControls.UI.RadLabel lblEmail;
        private Telerik.WinControls.UI.RadLabel lblDesconto;
        private Telerik.WinControls.UI.RadLabel lblObservacoes;
        private Telerik.WinControls.UI.RadLabel lblTotal;
        private Telerik.WinControls.UI.RadLabel lblStatusOrcamento;
        private Telerik.WinControls.UI.RadLabel lblItensDisponiveis;
        private Telerik.WinControls.UI.RadLabel lblItensOrcamento;

        private Telerik.WinControls.UI.RadGridView dgvItensDisponiveis;
        private Telerik.WinControls.UI.RadGridView dgvItensOrcamento;

        private Telerik.WinControls.UI.RadGroupBox groupBoxCliente;
        private Telerik.WinControls.UI.RadGroupBox groupBoxItens;
        private Telerik.WinControls.UI.RadGroupBox groupBoxOrcamento;
        private Telerik.WinControls.Themes.MaterialTheme materialTheme1;
        private Telerik.WinControls.UI.RadPanel headerPanel;
        private Telerik.WinControls.UI.RadLabel iconPrincipal;
        private Telerik.WinControls.UI.RadLabel lblTitulo;
        private Telerik.WinControls.UI.RadLabel lblSubtitulo;
        private Telerik.WinControls.UI.RadWaitingBar progressBar;
        private Telerik.WinControls.UI.DotsLineWaitingBarIndicatorElement dotsLineWaitingBarIndicatorElement1;
        private Bunifu.UI.WinForms.BunifuImageButton btnSair;
        private Telerik.WinControls.UI.RadLabel lblSubtotal;
    }
}