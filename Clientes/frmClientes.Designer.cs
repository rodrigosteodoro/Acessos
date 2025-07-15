using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Acessos
{
    partial class frmClientes
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
            this.GridClientes = new System.Windows.Forms.DataGridView();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnInativar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.txtCEP = new System.Windows.Forms.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.txtIBGE = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRegiao = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
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
            this.lbTotalClientes = new System.Windows.Forms.Label();
            this.txtRenda = new System.Windows.Forms.TextBox();
            this.txtCPFCNPJ = new System.Windows.Forms.MaskedTextBox();
            this.dtpDataNascimento = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridClientes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridClientes
            // 
            this.GridClientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GridClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridClientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.GridClientes.BackgroundColor = System.Drawing.Color.White;
            this.GridClientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GridClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridClientes.Location = new System.Drawing.Point(12, 12);
            this.GridClientes.MultiSelect = false;
            this.GridClientes.Name = "GridClientes";
            this.GridClientes.ReadOnly = true;
            this.GridClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridClientes.Size = new System.Drawing.Size(599, 612);
            this.GridClientes.TabIndex = 2;
            this.GridClientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridClientes_CellDoubleClick);
            this.GridClientes.SelectionChanged += new System.EventHandler(this.GridClientes_SelectionChanged);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSalvar.Enabled = false;
            this.btnSalvar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalvar.Location = new System.Drawing.Point(912, 579);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(115, 45);
            this.btnSalvar.TabIndex = 11;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAtualizar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAtualizar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAtualizar.Location = new System.Drawing.Point(1033, 579);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(115, 45);
            this.btnAtualizar.TabIndex = 12;
            this.btnAtualizar.Text = "&Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnInativar
            // 
            this.btnInativar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInativar.BackColor = System.Drawing.Color.Coral;
            this.btnInativar.Enabled = false;
            this.btnInativar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnInativar.Location = new System.Drawing.Point(1154, 579);
            this.btnInativar.Name = "btnInativar";
            this.btnInativar.Size = new System.Drawing.Size(115, 45);
            this.btnInativar.TabIndex = 13;
            this.btnInativar.Text = "&Inativar";
            this.btnInativar.UseVisualStyleBackColor = false;
            this.btnInativar.Click += new System.EventHandler(this.btnInativar_Click);
            // 
            // btnSair
            // 
            this.btnSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSair.BackColor = System.Drawing.Color.DarkGray;
            this.btnSair.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSair.Location = new System.Drawing.Point(1275, 579);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(115, 45);
            this.btnSair.TabIndex = 14;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovo.BackColor = System.Drawing.Color.Teal;
            this.btnNovo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNovo.Location = new System.Drawing.Point(796, 579);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(110, 45);
            this.btnNovo.TabIndex = 10;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.BackColor = System.Drawing.Color.DarkOrange;
            this.btnEditar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEditar.Location = new System.Drawing.Point(680, 579);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(110, 45);
            this.btnEditar.TabIndex = 54;
            this.btnEditar.Text = "&Edição";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.ClientSizeChanged += new System.EventHandler(this.btnEditar_Click);
            // 
            // txtCEP
            // 
            this.txtCEP.BackColor = System.Drawing.Color.Linen;
            this.txtCEP.Font = new System.Drawing.Font("Arial", 9F);
            this.txtCEP.Location = new System.Drawing.Point(10, 40);
            this.txtCEP.Mask = "00000-000";
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(227, 21);
            this.txtCEP.TabIndex = 55;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century", 9.75F);
            this.label15.ForeColor = System.Drawing.Color.DimGray;
            this.label15.Location = new System.Drawing.Point(10, 182);
            this.label15.Margin = new System.Windows.Forms.Padding(1);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 16);
            this.label15.TabIndex = 73;
            this.label15.Text = "Complemento:";
            // 
            // txtComplemento
            // 
            this.txtComplemento.BackColor = System.Drawing.Color.Linen;
            this.txtComplemento.Font = new System.Drawing.Font("Arial", 9F);
            this.txtComplemento.Location = new System.Drawing.Point(8, 203);
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(290, 21);
            this.txtComplemento.TabIndex = 57;
            // 
            // txtIBGE
            // 
            this.txtIBGE.BackColor = System.Drawing.Color.Linen;
            this.txtIBGE.Font = new System.Drawing.Font("Arial", 9F);
            this.txtIBGE.Location = new System.Drawing.Point(537, 145);
            this.txtIBGE.Name = "txtIBGE";
            this.txtIBGE.ReadOnly = true;
            this.txtIBGE.Size = new System.Drawing.Size(101, 21);
            this.txtIBGE.TabIndex = 71;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century", 9.75F);
            this.label14.ForeColor = System.Drawing.Color.DimGray;
            this.label14.Location = new System.Drawing.Point(537, 124);
            this.label14.Margin = new System.Windows.Forms.Padding(1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 16);
            this.label14.TabIndex = 72;
            this.label14.Text = "IBGE";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century", 9.75F);
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(304, 124);
            this.label13.Margin = new System.Windows.Forms.Padding(1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 16);
            this.label13.TabIndex = 70;
            this.label13.Text = "Região:";
            // 
            // txtRegiao
            // 
            this.txtRegiao.BackColor = System.Drawing.Color.Linen;
            this.txtRegiao.Font = new System.Drawing.Font("Arial", 9F);
            this.txtRegiao.Location = new System.Drawing.Point(304, 145);
            this.txtRegiao.Name = "txtRegiao";
            this.txtRegiao.ReadOnly = true;
            this.txtRegiao.Size = new System.Drawing.Size(227, 21);
            this.txtRegiao.TabIndex = 69;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century", 9.75F);
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(71, 124);
            this.label12.Margin = new System.Windows.Forms.Padding(1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 16);
            this.label12.TabIndex = 68;
            this.label12.Text = "Estado:";
            // 
            // txtEstado
            // 
            this.txtEstado.BackColor = System.Drawing.Color.Linen;
            this.txtEstado.Font = new System.Drawing.Font("Arial", 9F);
            this.txtEstado.Location = new System.Drawing.Point(71, 145);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(227, 21);
            this.txtEstado.TabIndex = 67;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century", 9.75F);
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(9, 124);
            this.label11.Margin = new System.Windows.Forms.Padding(1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 16);
            this.label11.TabIndex = 66;
            this.label11.Text = "UF:";
            // 
            // txtUF
            // 
            this.txtUF.BackColor = System.Drawing.Color.Linen;
            this.txtUF.Font = new System.Drawing.Font("Arial", 9F);
            this.txtUF.Location = new System.Drawing.Point(9, 145);
            this.txtUF.Name = "txtUF";
            this.txtUF.ReadOnly = true;
            this.txtUF.Size = new System.Drawing.Size(56, 21);
            this.txtUF.TabIndex = 65;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century", 9.75F);
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(244, 68);
            this.label10.Margin = new System.Windows.Forms.Padding(1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 16);
            this.label10.TabIndex = 64;
            this.label10.Text = "Bairro:";
            // 
            // txtBairro
            // 
            this.txtBairro.BackColor = System.Drawing.Color.Linen;
            this.txtBairro.Font = new System.Drawing.Font("Arial", 9F);
            this.txtBairro.Location = new System.Drawing.Point(242, 89);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.ReadOnly = true;
            this.txtBairro.Size = new System.Drawing.Size(227, 21);
            this.txtBairro.TabIndex = 63;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century", 9.75F);
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(475, 68);
            this.label9.Margin = new System.Windows.Forms.Padding(1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 16);
            this.label9.TabIndex = 62;
            this.label9.Text = "Localidade:";
            // 
            // txtLocalidade
            // 
            this.txtLocalidade.BackColor = System.Drawing.Color.Linen;
            this.txtLocalidade.Font = new System.Drawing.Font("Arial", 9F);
            this.txtLocalidade.Location = new System.Drawing.Point(475, 89);
            this.txtLocalidade.Name = "txtLocalidade";
            this.txtLocalidade.ReadOnly = true;
            this.txtLocalidade.Size = new System.Drawing.Size(227, 21);
            this.txtLocalidade.TabIndex = 61;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century", 9.75F);
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(10, 68);
            this.label8.Margin = new System.Windows.Forms.Padding(1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 16);
            this.label8.TabIndex = 60;
            this.label8.Text = "Logradouro:";
            // 
            // txtLogradouro
            // 
            this.txtLogradouro.BackColor = System.Drawing.Color.Linen;
            this.txtLogradouro.Font = new System.Drawing.Font("Arial", 9F);
            this.txtLogradouro.Location = new System.Drawing.Point(9, 89);
            this.txtLogradouro.Name = "txtLogradouro";
            this.txtLogradouro.ReadOnly = true;
            this.txtLogradouro.Size = new System.Drawing.Size(227, 21);
            this.txtLogradouro.TabIndex = 59;
            // 
            // btnBuscarCEP
            // 
            this.btnBuscarCEP.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnBuscarCEP.ForeColor = System.Drawing.Color.White;
            this.btnBuscarCEP.Location = new System.Drawing.Point(244, 40);
            this.btnBuscarCEP.Name = "btnBuscarCEP";
            this.btnBuscarCEP.Size = new System.Drawing.Size(84, 24);
            this.btnBuscarCEP.TabIndex = 56;
            this.btnBuscarCEP.Text = "Buscar";
            this.btnBuscarCEP.UseVisualStyleBackColor = false;
            this.btnBuscarCEP.Click += new System.EventHandler(this.btnBuscarCEP_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century", 9.75F);
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(11, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 16);
            this.label7.TabIndex = 58;
            this.label7.Text = "CEP";
            // 
            // lbDataCriacao
            // 
            this.lbDataCriacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDataCriacao.AutoSize = true;
            this.lbDataCriacao.BackColor = System.Drawing.Color.Transparent;
            this.lbDataCriacao.Font = new System.Drawing.Font("Century", 9.75F);
            this.lbDataCriacao.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbDataCriacao.Location = new System.Drawing.Point(1162, 498);
            this.lbDataCriacao.Margin = new System.Windows.Forms.Padding(1);
            this.lbDataCriacao.Name = "lbDataCriacao";
            this.lbDataCriacao.Size = new System.Drawing.Size(97, 16);
            this.lbDataCriacao.TabIndex = 76;
            this.lbDataCriacao.Text = "Cliente desde: -";
            // 
            // lbMod
            // 
            this.lbMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMod.AutoSize = true;
            this.lbMod.BackColor = System.Drawing.Color.Transparent;
            this.lbMod.Font = new System.Drawing.Font("Century", 9.75F);
            this.lbMod.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbMod.Location = new System.Drawing.Point(847, 498);
            this.lbMod.Margin = new System.Windows.Forms.Padding(1);
            this.lbMod.Name = "lbMod";
            this.lbMod.Size = new System.Drawing.Size(135, 16);
            this.lbMod.TabIndex = 75;
            this.lbMod.Text = "Última Modificação: -";
            // 
            // lbTotalClientes
            // 
            this.lbTotalClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTotalClientes.AutoSize = true;
            this.lbTotalClientes.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalClientes.Font = new System.Drawing.Font("Century", 9.75F);
            this.lbTotalClientes.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbTotalClientes.Location = new System.Drawing.Point(621, 498);
            this.lbTotalClientes.Margin = new System.Windows.Forms.Padding(1);
            this.lbTotalClientes.Name = "lbTotalClientes";
            this.lbTotalClientes.Size = new System.Drawing.Size(122, 16);
            this.lbTotalClientes.TabIndex = 74;
            this.lbTotalClientes.Text = "Total de Clientes: 0";
            // 
            // txtRenda
            // 
            this.txtRenda.BackColor = System.Drawing.Color.Linen;
            this.txtRenda.Font = new System.Drawing.Font("Arial", 9F);
            this.txtRenda.Location = new System.Drawing.Point(11, 204);
            this.txtRenda.Name = "txtRenda";
            this.txtRenda.Size = new System.Drawing.Size(134, 21);
            this.txtRenda.TabIndex = 55;
            // 
            // txtCPFCNPJ
            // 
            this.txtCPFCNPJ.BackColor = System.Drawing.Color.Linen;
            this.txtCPFCNPJ.Font = new System.Drawing.Font("Arial", 9F);
            this.txtCPFCNPJ.Location = new System.Drawing.Point(413, 104);
            this.txtCPFCNPJ.Name = "txtCPFCNPJ";
            this.txtCPFCNPJ.Size = new System.Drawing.Size(194, 21);
            this.txtCPFCNPJ.TabIndex = 49;
            this.txtCPFCNPJ.TextChanged += new System.EventHandler(this.txtCPFCNPJ_TextChanged);
            // 
            // dtpDataNascimento
            // 
            this.dtpDataNascimento.BackColor = System.Drawing.Color.Linen;
            this.dtpDataNascimento.Font = new System.Drawing.Font("Arial", 9F);
            this.dtpDataNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataNascimento.Location = new System.Drawing.Point(613, 104);
            this.dtpDataNascimento.Margin = new System.Windows.Forms.Padding(1);
            this.dtpDataNascimento.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpDataNascimento.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpDataNascimento.Name = "dtpDataNascimento";
            this.dtpDataNascimento.ShowCheckBox = true;
            this.dtpDataNascimento.Size = new System.Drawing.Size(156, 21);
            this.dtpDataNascimento.TabIndex = 50;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century", 9.75F);
            this.label16.ForeColor = System.Drawing.Color.DimGray;
            this.label16.Location = new System.Drawing.Point(11, 183);
            this.label16.Margin = new System.Windows.Forms.Padding(1);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(112, 16);
            this.label16.TabIndex = 59;
            this.label16.Text = "Renda Declarada:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century", 9.75F);
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(613, 83);
            this.label6.Margin = new System.Windows.Forms.Padding(1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 16);
            this.label6.TabIndex = 58;
            this.label6.Text = "Data de Nascimento:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century", 9.75F);
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(413, 139);
            this.label5.Margin = new System.Windows.Forms.Padding(1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 16);
            this.label5.TabIndex = 57;
            this.label5.Text = "Numero:";
            // 
            // txtNumero
            // 
            this.txtNumero.BackColor = System.Drawing.Color.Linen;
            this.txtNumero.Font = new System.Drawing.Font("Arial", 9F);
            this.txtNumero.Location = new System.Drawing.Point(413, 159);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(99, 21);
            this.txtNumero.TabIndex = 54;
            // 
            // txtEndereco
            // 
            this.txtEndereco.BackColor = System.Drawing.Color.Linen;
            this.txtEndereco.Font = new System.Drawing.Font("Arial", 9F);
            this.txtEndereco.Location = new System.Drawing.Point(9, 158);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(398, 21);
            this.txtEndereco.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century", 9.75F);
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(20, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 56;
            this.label3.Text = "CÓDIGO";
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.Khaki;
            this.txtCode.Location = new System.Drawing.Point(6, 49);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(105, 23);
            this.txtCode.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 9.75F);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(413, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 53;
            this.label2.Text = "CPF/CNPJ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century", 9.75F);
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(7, 138);
            this.label4.Margin = new System.Windows.Forms.Padding(1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 77;
            this.label4.Text = "Endereço:";
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.Linen;
            this.txtNome.Font = new System.Drawing.Font("Arial", 9F);
            this.txtNome.Location = new System.Drawing.Point(9, 103);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(398, 21);
            this.txtNome.TabIndex = 78;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century", 9.75F);
            this.label17.ForeColor = System.Drawing.Color.DimGray;
            this.label17.Location = new System.Drawing.Point(9, 83);
            this.label17.Margin = new System.Windows.Forms.Padding(1);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(46, 16);
            this.label17.TabIndex = 79;
            this.label17.Text = "Nome:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTelefone);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEndereco);
            this.groupBox1.Controls.Add(this.txtRenda);
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCPFCNPJ);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.dtpDataNascimento);
            this.groupBox1.Location = new System.Drawing.Point(617, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(820, 235);
            this.groupBox1.TabIndex = 80;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados Básicos";
            // 
            // txtTelefone
            // 
            this.txtTelefone.BackColor = System.Drawing.Color.Linen;
            this.txtTelefone.Font = new System.Drawing.Font("Arial", 9F);
            this.txtTelefone.Location = new System.Drawing.Point(518, 159);
            this.txtTelefone.Mask = "(99) 00000-0000";
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(194, 21);
            this.txtTelefone.TabIndex = 82;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 9.75F);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(518, 139);
            this.label1.Margin = new System.Windows.Forms.Padding(1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 81;
            this.label1.Text = "Telefone:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCEP);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnBuscarCEP);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtLogradouro);
            this.groupBox2.Controls.Add(this.txtComplemento);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtIBGE);
            this.groupBox2.Controls.Add(this.txtLocalidade);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtBairro);
            this.groupBox2.Controls.Add(this.txtRegiao);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtUF);
            this.groupBox2.Controls.Add(this.txtEstado);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(617, 253);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(820, 236);
            this.groupBox2.TabIndex = 81;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Endereço";
            // 
            // frmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1461, 637);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbDataCriacao);
            this.Controls.Add(this.lbMod);
            this.Controls.Add(this.lbTotalClientes);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnInativar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.GridClientes);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClientes";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Clientes";
            this.Load += new System.EventHandler(this.frmClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridClientes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView GridClientes;
        private Button btnSalvar;
        private Button btnAtualizar;
        private Button btnInativar;
        private Button btnSair;
        private Button btnNovo;
        private Button btnEditar;
        private TextBox txtRenda;
        private MaskedTextBox txtCPFCNPJ;
        private DateTimePicker dtpDataNascimento;
        private Label label16;
        private Label label6;
        private Label label5;
        private TextBox txtNumero;
        private TextBox txtEndereco;
        private Label label3;
        private TextBox txtCode;
        private Label label2;
        private MaskedTextBox txtCEP;
        private Label label15;
        private TextBox txtComplemento;
        private TextBox txtIBGE;
        private Label label14;
        private Label label13;
        private TextBox txtRegiao;
        private Label label12;
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
        private Label lbTotalClientes;
        private Label label4;
        private TextBox txtNome;
        private Label label17;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private MaskedTextBox txtTelefone;
        private Label label1;
    }
}
