using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Acessos
{
    partial class frmFornecedores
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
            this.GridFornecedores = new System.Windows.Forms.DataGridView();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbTipoFornecedor = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtContato = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtSite = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtNomeFantasia = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtRazaoSocial = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCNPJ = new System.Windows.Forms.MaskedTextBox();
            this.txtCEP = new System.Windows.Forms.MaskedTextBox();
            this.dtpDataFundacao = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIBGE = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.txtRegiao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUF = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLocalidade = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLogradouro = new System.Windows.Forms.TextBox();
            this.btnBuscarCEP = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lbDataCriacao = new System.Windows.Forms.Label();
            this.lbMod = new System.Windows.Forms.Label();
            this.lbTotalFornecedores = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnInativar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridFornecedores)).BeginInit();
            this.SuspendLayout();
            // 
            // GridFornecedores
            // 
            this.GridFornecedores.AllowUserToAddRows = false;
            this.GridFornecedores.AllowUserToDeleteRows = false;
            this.GridFornecedores.AllowUserToResizeRows = false;
            this.GridFornecedores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridFornecedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridFornecedores.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.GridFornecedores.BackgroundColor = System.Drawing.Color.White;
            this.GridFornecedores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GridFornecedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridFornecedores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GridFornecedores.Location = new System.Drawing.Point(12, 12);
            this.GridFornecedores.MultiSelect = false;
            this.GridFornecedores.Name = "GridFornecedores";
            this.GridFornecedores.ReadOnly = true;
            this.GridFornecedores.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.GridFornecedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridFornecedores.ShowCellErrors = false;
            this.GridFornecedores.ShowEditingIcon = false;
            this.GridFornecedores.Size = new System.Drawing.Size(1470, 227);
            this.GridFornecedores.TabIndex = 2;
            this.GridFornecedores.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridFornecedores_CellDoubleClick);
            this.GridFornecedores.SelectionChanged += new System.EventHandler(this.GridFornecedores_SelectionChanged);
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.BackColor = System.Drawing.Color.Linen;
            this.txtObservacoes.Font = new System.Drawing.Font("Arial", 9F);
            this.txtObservacoes.Location = new System.Drawing.Point(852, 368);
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacoes.Size = new System.Drawing.Size(630, 212);
            this.txtObservacoes.TabIndex = 164;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Century", 9.75F);
            this.label24.ForeColor = System.Drawing.Color.DimGray;
            this.label24.Location = new System.Drawing.Point(856, 347);
            this.label24.Margin = new System.Windows.Forms.Padding(1);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(84, 16);
            this.label24.TabIndex = 203;
            this.label24.Text = "Observações:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.Color.Linen;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Arial", 9F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Ativo",
            "Inativo",
            "Suspenso",
            "Bloqueado"});
            this.cmbStatus.Location = new System.Drawing.Point(1222, 309);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(120, 23);
            this.cmbStatus.TabIndex = 163;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Century", 9.75F);
            this.label23.ForeColor = System.Drawing.Color.DimGray;
            this.label23.Location = new System.Drawing.Point(1222, 288);
            this.label23.Margin = new System.Windows.Forms.Padding(1);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(50, 16);
            this.label23.TabIndex = 202;
            this.label23.Text = "Status:";
            // 
            // cmbTipoFornecedor
            // 
            this.cmbTipoFornecedor.BackColor = System.Drawing.Color.Linen;
            this.cmbTipoFornecedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoFornecedor.Font = new System.Drawing.Font("Arial", 9F);
            this.cmbTipoFornecedor.FormattingEnabled = true;
            this.cmbTipoFornecedor.Items.AddRange(new object[] {
            "Produtos",
            "Serviços",
            "Produtos e Serviços",
            "Matéria Prima",
            "Equipamentos"});
            this.cmbTipoFornecedor.Location = new System.Drawing.Point(1062, 309);
            this.cmbTipoFornecedor.Name = "cmbTipoFornecedor";
            this.cmbTipoFornecedor.Size = new System.Drawing.Size(150, 23);
            this.cmbTipoFornecedor.TabIndex = 162;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Century", 9.75F);
            this.label22.ForeColor = System.Drawing.Color.DimGray;
            this.label22.Location = new System.Drawing.Point(1062, 288);
            this.label22.Margin = new System.Windows.Forms.Padding(1);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(107, 16);
            this.label22.TabIndex = 201;
            this.label22.Text = "Tipo Fornecedor:";
            // 
            // txtContato
            // 
            this.txtContato.BackColor = System.Drawing.Color.Linen;
            this.txtContato.Font = new System.Drawing.Font("Arial", 9F);
            this.txtContato.Location = new System.Drawing.Point(852, 309);
            this.txtContato.Name = "txtContato";
            this.txtContato.Size = new System.Drawing.Size(200, 21);
            this.txtContato.TabIndex = 161;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Century", 9.75F);
            this.label21.ForeColor = System.Drawing.Color.DimGray;
            this.label21.Location = new System.Drawing.Point(852, 288);
            this.label21.Margin = new System.Windows.Forms.Padding(1);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(57, 16);
            this.label21.TabIndex = 200;
            this.label21.Text = "Contato:";
            // 
            // txtSite
            // 
            this.txtSite.BackColor = System.Drawing.Color.Linen;
            this.txtSite.Font = new System.Drawing.Font("Arial", 9F);
            this.txtSite.Location = new System.Drawing.Point(536, 421);
            this.txtSite.Name = "txtSite";
            this.txtSite.Size = new System.Drawing.Size(278, 21);
            this.txtSite.TabIndex = 156;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Century", 9.75F);
            this.label20.ForeColor = System.Drawing.Color.DimGray;
            this.label20.Location = new System.Drawing.Point(536, 400);
            this.label20.Margin = new System.Windows.Forms.Padding(1);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(34, 16);
            this.label20.TabIndex = 199;
            this.label20.Text = "Site:";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.Linen;
            this.txtEmail.Font = new System.Drawing.Font("Arial", 9F);
            this.txtEmail.Location = new System.Drawing.Point(616, 368);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(196, 21);
            this.txtEmail.TabIndex = 155;
            this.txtEmail.Leave += new System.EventHandler(this.TxtEmail_Leave);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Century", 9.75F);
            this.label19.ForeColor = System.Drawing.Color.DimGray;
            this.label19.Location = new System.Drawing.Point(616, 347);
            this.label19.Margin = new System.Windows.Forms.Padding(1);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 16);
            this.label19.TabIndex = 198;
            this.label19.Text = "Email:";
            // 
            // txtTelefone
            // 
            this.txtTelefone.BackColor = System.Drawing.Color.Linen;
            this.txtTelefone.Font = new System.Drawing.Font("Arial", 9F);
            this.txtTelefone.Location = new System.Drawing.Point(416, 368);
            this.txtTelefone.Mask = "(00) 00000-0000";
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(194, 21);
            this.txtTelefone.TabIndex = 154;
            this.txtTelefone.Leave += new System.EventHandler(this.TxtTelefone_Leave);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century", 9.75F);
            this.label18.ForeColor = System.Drawing.Color.DimGray;
            this.label18.Location = new System.Drawing.Point(416, 347);
            this.label18.Margin = new System.Windows.Forms.Padding(1);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 16);
            this.label18.TabIndex = 197;
            this.label18.Text = "Telefone:";
            // 
            // txtNomeFantasia
            // 
            this.txtNomeFantasia.BackColor = System.Drawing.Color.Linen;
            this.txtNomeFantasia.Font = new System.Drawing.Font("Arial", 9F);
            this.txtNomeFantasia.Location = new System.Drawing.Point(12, 368);
            this.txtNomeFantasia.Name = "txtNomeFantasia";
            this.txtNomeFantasia.Size = new System.Drawing.Size(398, 21);
            this.txtNomeFantasia.TabIndex = 153;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century", 9.75F);
            this.label17.ForeColor = System.Drawing.Color.DimGray;
            this.label17.Location = new System.Drawing.Point(12, 347);
            this.label17.Margin = new System.Windows.Forms.Padding(1);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(103, 16);
            this.label17.TabIndex = 196;
            this.label17.Text = "Nome Fantasia:";
            // 
            // txtRazaoSocial
            // 
            this.txtRazaoSocial.BackColor = System.Drawing.Color.Linen;
            this.txtRazaoSocial.Font = new System.Drawing.Font("Arial", 9F);
            this.txtRazaoSocial.Location = new System.Drawing.Point(12, 308);
            this.txtRazaoSocial.Name = "txtRazaoSocial";
            this.txtRazaoSocial.Size = new System.Drawing.Size(398, 21);
            this.txtRazaoSocial.TabIndex = 150;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century", 9.75F);
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(14, 400);
            this.label4.Margin = new System.Windows.Forms.Padding(1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 195;
            this.label4.Text = "Endereço:";
            // 
            // txtCNPJ
            // 
            this.txtCNPJ.BackColor = System.Drawing.Color.Linen;
            this.txtCNPJ.Font = new System.Drawing.Font("Arial", 9F);
            this.txtCNPJ.Location = new System.Drawing.Point(416, 309);
            this.txtCNPJ.Name = "txtCNPJ";
            this.txtCNPJ.Size = new System.Drawing.Size(194, 21);
            this.txtCNPJ.TabIndex = 151;
            this.txtCNPJ.Click += new System.EventHandler(this.txtCNPJ_TextChanged);
            this.txtCNPJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCNPJ_KeyPress);
            this.txtCNPJ.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCNPJ_KeyUp);
            // 
            // txtCEP
            // 
            this.txtCEP.BackColor = System.Drawing.Color.Linen;
            this.txtCEP.Font = new System.Drawing.Font("Arial", 9F);
            this.txtCEP.Location = new System.Drawing.Point(17, 474);
            this.txtCEP.Mask = "00000-000";
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(120, 21);
            this.txtCEP.TabIndex = 159;
            this.txtCEP.Leave += new System.EventHandler(this.TxtCEP_Leave);
            // 
            // dtpDataFundacao
            // 
            this.dtpDataFundacao.BackColor = System.Drawing.Color.Linen;
            this.dtpDataFundacao.Font = new System.Drawing.Font("Arial", 9F);
            this.dtpDataFundacao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataFundacao.Location = new System.Drawing.Point(616, 309);
            this.dtpDataFundacao.Margin = new System.Windows.Forms.Padding(1);
            this.dtpDataFundacao.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpDataFundacao.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpDataFundacao.Name = "dtpDataFundacao";
            this.dtpDataFundacao.ShowCheckBox = true;
            this.dtpDataFundacao.Size = new System.Drawing.Size(196, 21);
            this.dtpDataFundacao.TabIndex = 152;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century", 9.75F);
            this.label15.ForeColor = System.Drawing.Color.DimGray;
            this.label15.Location = new System.Drawing.Point(13, 622);
            this.label15.Margin = new System.Windows.Forms.Padding(1);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 16);
            this.label15.TabIndex = 191;
            this.label15.Text = "Complemento:";
            // 
            // txtComplemento
            // 
            this.txtComplemento.BackColor = System.Drawing.Color.Linen;
            this.txtComplemento.Font = new System.Drawing.Font("Arial", 9F);
            this.txtComplemento.Location = new System.Drawing.Point(11, 643);
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(290, 21);
            this.txtComplemento.TabIndex = 165;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century", 9.75F);
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(616, 288);
            this.label6.Margin = new System.Windows.Forms.Padding(1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 16);
            this.label6.TabIndex = 175;
            this.label6.Text = "Data de Fundação:";
            // 
            // txtIBGE
            // 
            this.txtIBGE.BackColor = System.Drawing.Color.Linen;
            this.txtIBGE.Font = new System.Drawing.Font("Arial", 9F);
            this.txtIBGE.Location = new System.Drawing.Point(540, 585);
            this.txtIBGE.Name = "txtIBGE";
            this.txtIBGE.ReadOnly = true;
            this.txtIBGE.Size = new System.Drawing.Size(101, 21);
            this.txtIBGE.TabIndex = 189;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century", 9.75F);
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(418, 400);
            this.label5.Margin = new System.Windows.Forms.Padding(1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 16);
            this.label5.TabIndex = 174;
            this.label5.Text = "Número:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century", 9.75F);
            this.label14.ForeColor = System.Drawing.Color.DimGray;
            this.label14.Location = new System.Drawing.Point(540, 564);
            this.label14.Margin = new System.Windows.Forms.Padding(1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 16);
            this.label14.TabIndex = 190;
            this.label14.Text = "IBGE";
            // 
            // txtNumero
            // 
            this.txtNumero.BackColor = System.Drawing.Color.Linen;
            this.txtNumero.Font = new System.Drawing.Font("Arial", 9F);
            this.txtNumero.Location = new System.Drawing.Point(416, 421);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(114, 21);
            this.txtNumero.TabIndex = 158;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century", 9.75F);
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(307, 564);
            this.label13.Margin = new System.Windows.Forms.Padding(1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 16);
            this.label13.TabIndex = 188;
            this.label13.Text = "Região:";
            // 
            // txtEndereco
            // 
            this.txtEndereco.BackColor = System.Drawing.Color.Linen;
            this.txtEndereco.Font = new System.Drawing.Font("Arial", 9F);
            this.txtEndereco.Location = new System.Drawing.Point(14, 421);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(398, 21);
            this.txtEndereco.TabIndex = 157;
            // 
            // txtRegiao
            // 
            this.txtRegiao.BackColor = System.Drawing.Color.Linen;
            this.txtRegiao.Font = new System.Drawing.Font("Arial", 9F);
            this.txtRegiao.Location = new System.Drawing.Point(307, 585);
            this.txtRegiao.Name = "txtRegiao";
            this.txtRegiao.ReadOnly = true;
            this.txtRegiao.Size = new System.Drawing.Size(227, 21);
            this.txtRegiao.TabIndex = 187;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century", 9.75F);
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(14, 247);
            this.label3.Margin = new System.Windows.Forms.Padding(1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 173;
            this.label3.Text = "CÓDIGO";
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.Linen;
            this.txtCode.Location = new System.Drawing.Point(76, 245);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(105, 23);
            this.txtCode.TabIndex = 170;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century", 9.75F);
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(74, 564);
            this.label12.Margin = new System.Windows.Forms.Padding(1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 16);
            this.label12.TabIndex = 186;
            this.label12.Text = "Estado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 9.75F);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(416, 288);
            this.label2.Margin = new System.Windows.Forms.Padding(1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 172;
            this.label2.Text = "CNPJ:";
            // 
            // txtEstado
            // 
            this.txtEstado.BackColor = System.Drawing.Color.Linen;
            this.txtEstado.Font = new System.Drawing.Font("Arial", 9F);
            this.txtEstado.Location = new System.Drawing.Point(74, 585);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(227, 21);
            this.txtEstado.TabIndex = 185;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century", 9.75F);
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(12, 564);
            this.label11.Margin = new System.Windows.Forms.Padding(1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 16);
            this.label11.TabIndex = 184;
            this.label11.Text = "UF:";
            // 
            // txtUF
            // 
            this.txtUF.BackColor = System.Drawing.Color.Linen;
            this.txtUF.Font = new System.Drawing.Font("Arial", 9F);
            this.txtUF.Location = new System.Drawing.Point(12, 585);
            this.txtUF.Name = "txtUF";
            this.txtUF.ReadOnly = true;
            this.txtUF.Size = new System.Drawing.Size(56, 21);
            this.txtUF.TabIndex = 183;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(240, 506);
            this.label10.Margin = new System.Windows.Forms.Padding(1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 17);
            this.label10.TabIndex = 182;
            this.label10.Text = "Bairro:";
            // 
            // txtBairro
            // 
            this.txtBairro.BackColor = System.Drawing.Color.Linen;
            this.txtBairro.Font = new System.Drawing.Font("Arial", 9F);
            this.txtBairro.Location = new System.Drawing.Point(245, 529);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.ReadOnly = true;
            this.txtBairro.Size = new System.Drawing.Size(227, 21);
            this.txtBairro.TabIndex = 181;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(471, 506);
            this.label9.Margin = new System.Windows.Forms.Padding(1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 17);
            this.label9.TabIndex = 180;
            this.label9.Text = "Localidade:";
            // 
            // txtLocalidade
            // 
            this.txtLocalidade.BackColor = System.Drawing.Color.Linen;
            this.txtLocalidade.Font = new System.Drawing.Font("Arial", 9F);
            this.txtLocalidade.Location = new System.Drawing.Point(478, 529);
            this.txtLocalidade.Name = "txtLocalidade";
            this.txtLocalidade.ReadOnly = true;
            this.txtLocalidade.Size = new System.Drawing.Size(227, 21);
            this.txtLocalidade.TabIndex = 179;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(13, 508);
            this.label8.Margin = new System.Windows.Forms.Padding(1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 17);
            this.label8.TabIndex = 178;
            this.label8.Text = "Logradouro:";
            // 
            // txtLogradouro
            // 
            this.txtLogradouro.BackColor = System.Drawing.Color.Linen;
            this.txtLogradouro.Font = new System.Drawing.Font("Arial", 9F);
            this.txtLogradouro.Location = new System.Drawing.Point(12, 529);
            this.txtLogradouro.Name = "txtLogradouro";
            this.txtLogradouro.ReadOnly = true;
            this.txtLogradouro.Size = new System.Drawing.Size(227, 21);
            this.txtLogradouro.TabIndex = 177;
            // 
            // btnBuscarCEP
            // 
            this.btnBuscarCEP.AutoSize = true;
            this.btnBuscarCEP.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnBuscarCEP.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBuscarCEP.ForeColor = System.Drawing.Color.White;
            this.btnBuscarCEP.Location = new System.Drawing.Point(143, 472);
            this.btnBuscarCEP.Name = "btnBuscarCEP";
            this.btnBuscarCEP.Size = new System.Drawing.Size(78, 25);
            this.btnBuscarCEP.TabIndex = 160;
            this.btnBuscarCEP.Text = "Buscar";
            this.btnBuscarCEP.UseVisualStyleBackColor = false;
            this.btnBuscarCEP.Click += new System.EventHandler(this.btnBuscarCEP_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century", 9.75F);
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(17, 453);
            this.label7.Margin = new System.Windows.Forms.Padding(1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 16);
            this.label7.TabIndex = 176;
            this.label7.Text = "CEP";
            // 
            // lbDataCriacao
            // 
            this.lbDataCriacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDataCriacao.AutoSize = true;
            this.lbDataCriacao.BackColor = System.Drawing.Color.Transparent;
            this.lbDataCriacao.Font = new System.Drawing.Font("Century", 9.75F);
            this.lbDataCriacao.ForeColor = System.Drawing.Color.DimGray;
            this.lbDataCriacao.Location = new System.Drawing.Point(907, 247);
            this.lbDataCriacao.Margin = new System.Windows.Forms.Padding(1);
            this.lbDataCriacao.Name = "lbDataCriacao";
            this.lbDataCriacao.Size = new System.Drawing.Size(121, 16);
            this.lbDataCriacao.TabIndex = 194;
            this.lbDataCriacao.Text = "Fornecedor desde: -";
            // 
            // lbMod
            // 
            this.lbMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMod.AutoSize = true;
            this.lbMod.BackColor = System.Drawing.Color.Transparent;
            this.lbMod.Font = new System.Drawing.Font("Century", 9.75F);
            this.lbMod.ForeColor = System.Drawing.Color.DimGray;
            this.lbMod.Location = new System.Drawing.Point(474, 247);
            this.lbMod.Margin = new System.Windows.Forms.Padding(1);
            this.lbMod.Name = "lbMod";
            this.lbMod.Size = new System.Drawing.Size(135, 16);
            this.lbMod.TabIndex = 193;
            this.lbMod.Text = "Última Modificação: -";
            // 
            // lbTotalFornecedores
            // 
            this.lbTotalFornecedores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTotalFornecedores.AutoSize = true;
            this.lbTotalFornecedores.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalFornecedores.Font = new System.Drawing.Font("Century", 9.75F);
            this.lbTotalFornecedores.ForeColor = System.Drawing.Color.DimGray;
            this.lbTotalFornecedores.Location = new System.Drawing.Point(204, 247);
            this.lbTotalFornecedores.Margin = new System.Windows.Forms.Padding(1);
            this.lbTotalFornecedores.Name = "lbTotalFornecedores";
            this.lbTotalFornecedores.Size = new System.Drawing.Size(152, 16);
            this.lbTotalFornecedores.TabIndex = 192;
            this.lbTotalFornecedores.Text = "Total de Fornecedores: 0";
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.BackColor = System.Drawing.Color.DarkOrange;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEditar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEditar.Location = new System.Drawing.Point(891, 631);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(110, 45);
            this.btnEditar.TabIndex = 166;
            this.btnEditar.Text = "&Edição";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovo.BackColor = System.Drawing.Color.Teal;
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNovo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNovo.Location = new System.Drawing.Point(775, 631);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(110, 45);
            this.btnNovo.TabIndex = 167;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAtualizar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAtualizar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAtualizar.Location = new System.Drawing.Point(1128, 631);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(115, 45);
            this.btnAtualizar.TabIndex = 169;
            this.btnAtualizar.Text = "&Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSalvar.Enabled = false;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSalvar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalvar.Location = new System.Drawing.Point(1007, 631);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(115, 45);
            this.btnSalvar.TabIndex = 168;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 9.75F);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(12, 288);
            this.label1.Margin = new System.Windows.Forms.Padding(1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 171;
            this.label1.Text = "Razão Social:";
            // 
            // btnSair
            // 
            this.btnSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSair.BackColor = System.Drawing.Color.DarkGray;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSair.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSair.Location = new System.Drawing.Point(1370, 631);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(115, 45);
            this.btnSair.TabIndex = 149;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnInativar
            // 
            this.btnInativar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInativar.BackColor = System.Drawing.Color.Coral;
            this.btnInativar.Enabled = false;
            this.btnInativar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnInativar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnInativar.Location = new System.Drawing.Point(1249, 631);
            this.btnInativar.Name = "btnInativar";
            this.btnInativar.Size = new System.Drawing.Size(115, 45);
            this.btnInativar.TabIndex = 148;
            this.btnInativar.Text = "&Inativar";
            this.btnInativar.UseVisualStyleBackColor = false;
            this.btnInativar.Click += new System.EventHandler(this.btnInativar_Click);
            // 
            // frmFornecedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1494, 688);
            this.ControlBox = false;
            this.Controls.Add(this.txtObservacoes);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.cmbTipoFornecedor);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtContato);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtSite);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtNomeFantasia);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtRazaoSocial);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCNPJ);
            this.Controls.Add(this.txtCEP);
            this.Controls.Add(this.dtpDataFundacao);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtComplemento);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtIBGE);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.txtRegiao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtUF);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtBairro);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtLocalidade);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtLogradouro);
            this.Controls.Add(this.btnBuscarCEP);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbDataCriacao);
            this.Controls.Add(this.lbMod);
            this.Controls.Add(this.lbTotalFornecedores);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnInativar);
            this.Controls.Add(this.GridFornecedores);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFornecedores";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Fornecedores";
            this.Load += new System.EventHandler(this.frmFornecedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridFornecedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView GridFornecedores;
        private TextBox txtObservacoes;
        private Label label24;
        private ComboBox cmbStatus;
        private Label label23;
        private ComboBox cmbTipoFornecedor;
        private Label label22;
        private TextBox txtContato;
        private Label label21;
        private TextBox txtSite;
        private Label label20;
        private TextBox txtEmail;
        private Label label19;
        private MaskedTextBox txtTelefone;
        private Label label18;
        private TextBox txtNomeFantasia;
        private Label label17;
        private TextBox txtRazaoSocial;
        private Label label4;
        private MaskedTextBox txtCNPJ;
        private MaskedTextBox txtCEP;
        private DateTimePicker dtpDataFundacao;
        private Label label15;
        private TextBox txtComplemento;
        private Label label6;
        private TextBox txtIBGE;
        private Label label5;
        private Label label14;
        private TextBox txtNumero;
        private Label label13;
        private TextBox txtEndereco;
        private TextBox txtRegiao;
        private Label label3;
        private TextBox txtCode;
        private Label label12;
        private Label label2;
        private TextBox txtEstado;
        private Label label11;
        private TextBox txtUF;
        private Label label10;
        private TextBox txtBairro;
        private Label label9;
        private TextBox txtLocalidade;
        private Label label8;
        private TextBox txtLogradouro;
        private Button btnBuscarCEP;
        private Label label7;
        private Label lbDataCriacao;
        private Label lbMod;
        private Label lbTotalFornecedores;
        private Button btnEditar;
        private Button btnNovo;
        private Button btnAtualizar;
        private Button btnSalvar;
        private Label label1;
        private Button btnSair;
        private Button btnInativar;
        private System.Windows.Forms.TabControl tabControlPrincipal;
        private System.Windows.Forms.TabPage tabListagem;
        private System.Windows.Forms.TabPage tabCadastro;
        private System.Windows.Forms.TabPage tabBusca;
        private System.Windows.Forms.TabPage tabRelatorios;

    }
}
