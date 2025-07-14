using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Acessos
{
    partial class frmEdicaoP
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelBusca = new System.Windows.Forms.Panel();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblBusca = new System.Windows.Forms.Label();
            this.groupBoxIdentificacao = new System.Windows.Forms.GroupBox();
            this.txtCodigoProduto = new System.Windows.Forms.TextBox();
            this.txtCodigoBarras = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxClassificacao = new System.Windows.Forms.GroupBox();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.txtSubcategoria = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.cmbFornecedor = new System.Windows.Forms.ComboBox();
            this.cmbUnidadeMedida = new System.Windows.Forms.ComboBox();
            this.cmbTipoProduto = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBoxEstoque = new System.Windows.Forms.GroupBox();
            this.numQuantidadeAtual = new System.Windows.Forms.NumericUpDown();
            this.numEstoqueMinimo = new System.Windows.Forms.NumericUpDown();
            this.numEstoqueMaximo = new System.Windows.Forms.NumericUpDown();
            this.txtLocalizacaoEstoque = new System.Windows.Forms.TextBox();
            this.chkPermiteEstoqueNegativo = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBoxPrecos = new System.Windows.Forms.GroupBox();
            this.numPrecoCusto = new System.Windows.Forms.NumericUpDown();
            this.numPrecoVenda = new System.Windows.Forms.NumericUpDown();
            this.numMargemLucro = new System.Windows.Forms.NumericUpDown();
            this.chkPromocaoAtiva = new System.Windows.Forms.CheckBox();
            this.numPrecoPromocional = new System.Windows.Forms.NumericUpDown();
            this.dtpInicioPromocao = new System.Windows.Forms.DateTimePicker();
            this.dtpFimPromocao = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBoxTributacao = new System.Windows.Forms.GroupBox();
            this.cmbOrigemProduto = new System.Windows.Forms.ComboBox();
            this.txtNCM = new System.Windows.Forms.TextBox();
            this.txtCFOP = new System.Windows.Forms.TextBox();
            this.txtCSTCSOSN = new System.Windows.Forms.TextBox();
            this.numICMS = new System.Windows.Forms.NumericUpDown();
            this.numPIS = new System.Windows.Forms.NumericUpDown();
            this.numCOFINS = new System.Windows.Forms.NumericUpDown();
            this.numIPI = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.groupBoxImagem = new System.Windows.Forms.GroupBox();
            this.pictureBoxProduto = new System.Windows.Forms.PictureBox();
            this.btnCarregarImagem = new System.Windows.Forms.Button();
            this.btnRemoverImagem = new System.Windows.Forms.Button();
            this.groupBoxComplementares = new System.Windows.Forms.GroupBox();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.txtSKU = new System.Windows.Forms.TextBox();
            this.lblDataCadastro = new System.Windows.Forms.Label();
            this.lblUltimaAlteracao = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.dgvProdutos = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.btImportar = new System.Windows.Forms.Button();
            this.panelBusca.SuspendLayout();
            this.groupBoxIdentificacao.SuspendLayout();
            this.groupBoxClassificacao.SuspendLayout();
            this.groupBoxEstoque.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidadeAtual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEstoqueMinimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEstoqueMaximo)).BeginInit();
            this.groupBoxPrecos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoCusto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoVenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMargemLucro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoPromocional)).BeginInit();
            this.groupBoxTributacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numICMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPIS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCOFINS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIPI)).BeginInit();
            this.groupBoxImagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduto)).BeginInit();
            this.groupBoxComplementares.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBusca
            // 
            this.panelBusca.Controls.Add(this.txtBusca);
            this.panelBusca.Controls.Add(this.btnBuscar);
            this.panelBusca.Controls.Add(this.lblBusca);
            this.panelBusca.Location = new System.Drawing.Point(12, 10);
            this.panelBusca.Name = "panelBusca";
            this.panelBusca.Size = new System.Drawing.Size(819, 35);
            this.panelBusca.TabIndex = 1;
            // 
            // txtBusca
            // 
            this.txtBusca.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBusca.Location = new System.Drawing.Point(52, 7);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(669, 23);
            this.txtBusca.TabIndex = 1;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(727, 8);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(64, 22);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblBusca
            // 
            this.lblBusca.AutoSize = true;
            this.lblBusca.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBusca.Location = new System.Drawing.Point(3, 9);
            this.lblBusca.Name = "lblBusca";
            this.lblBusca.Size = new System.Drawing.Size(58, 19);
            this.lblBusca.TabIndex = 0;
            this.lblBusca.Text = "Buscar:";
            // 
            // groupBoxIdentificacao
            // 
            this.groupBoxIdentificacao.Controls.Add(this.txtCodigoProduto);
            this.groupBoxIdentificacao.Controls.Add(this.txtCodigoBarras);
            this.groupBoxIdentificacao.Controls.Add(this.txtNome);
            this.groupBoxIdentificacao.Controls.Add(this.txtDescricao);
            this.groupBoxIdentificacao.Controls.Add(this.label1);
            this.groupBoxIdentificacao.Controls.Add(this.label2);
            this.groupBoxIdentificacao.Controls.Add(this.label3);
            this.groupBoxIdentificacao.Controls.Add(this.label4);
            this.groupBoxIdentificacao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxIdentificacao.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBoxIdentificacao.Location = new System.Drawing.Point(875, 17);
            this.groupBoxIdentificacao.Name = "groupBoxIdentificacao";
            this.groupBoxIdentificacao.Size = new System.Drawing.Size(429, 104);
            this.groupBoxIdentificacao.TabIndex = 2;
            this.groupBoxIdentificacao.TabStop = false;
            this.groupBoxIdentificacao.Text = "1. Identificação do Produto";
            // 
            // txtCodigoProduto
            // 
            this.txtCodigoProduto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCodigoProduto.Location = new System.Drawing.Point(13, 35);
            this.txtCodigoProduto.Name = "txtCodigoProduto";
            this.txtCodigoProduto.ReadOnly = true;
            this.txtCodigoProduto.Size = new System.Drawing.Size(103, 23);
            this.txtCodigoProduto.TabIndex = 1;
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCodigoBarras.Location = new System.Drawing.Point(129, 35);
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.Size = new System.Drawing.Size(129, 23);
            this.txtCodigoBarras.TabIndex = 2;
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNome.Location = new System.Drawing.Point(274, 35);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(146, 23);
            this.txtNome.TabIndex = 3;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescricao.Location = new System.Drawing.Point(13, 74);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(408, 20);
            this.txtDescricao.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código do Produto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(129, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Código de Barras";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(274, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nome";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(13, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Descrição";
            // 
            // groupBoxClassificacao
            // 
            this.groupBoxClassificacao.Controls.Add(this.txtCategoria);
            this.groupBoxClassificacao.Controls.Add(this.txtSubcategoria);
            this.groupBoxClassificacao.Controls.Add(this.txtMarca);
            this.groupBoxClassificacao.Controls.Add(this.cmbFornecedor);
            this.groupBoxClassificacao.Controls.Add(this.cmbUnidadeMedida);
            this.groupBoxClassificacao.Controls.Add(this.cmbTipoProduto);
            this.groupBoxClassificacao.Controls.Add(this.label5);
            this.groupBoxClassificacao.Controls.Add(this.label6);
            this.groupBoxClassificacao.Controls.Add(this.label7);
            this.groupBoxClassificacao.Controls.Add(this.label8);
            this.groupBoxClassificacao.Controls.Add(this.label9);
            this.groupBoxClassificacao.Controls.Add(this.label10);
            this.groupBoxClassificacao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxClassificacao.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBoxClassificacao.Location = new System.Drawing.Point(875, 128);
            this.groupBoxClassificacao.Name = "groupBoxClassificacao";
            this.groupBoxClassificacao.Size = new System.Drawing.Size(429, 104);
            this.groupBoxClassificacao.TabIndex = 3;
            this.groupBoxClassificacao.TabStop = false;
            this.groupBoxClassificacao.Text = "2. Classificação";
            // 
            // txtCategoria
            // 
            this.txtCategoria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCategoria.Location = new System.Drawing.Point(13, 35);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(103, 23);
            this.txtCategoria.TabIndex = 5;
            // 
            // txtSubcategoria
            // 
            this.txtSubcategoria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSubcategoria.Location = new System.Drawing.Point(129, 35);
            this.txtSubcategoria.Name = "txtSubcategoria";
            this.txtSubcategoria.Size = new System.Drawing.Size(103, 23);
            this.txtSubcategoria.TabIndex = 6;
            // 
            // txtMarca
            // 
            this.txtMarca.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMarca.Location = new System.Drawing.Point(244, 35);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(103, 23);
            this.txtMarca.TabIndex = 7;
            // 
            // cmbFornecedor
            // 
            this.cmbFornecedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFornecedor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFornecedor.FormattingEnabled = true;
            this.cmbFornecedor.Location = new System.Drawing.Point(13, 74);
            this.cmbFornecedor.Name = "cmbFornecedor";
            this.cmbFornecedor.Size = new System.Drawing.Size(129, 23);
            this.cmbFornecedor.TabIndex = 8;
            // 
            // cmbUnidadeMedida
            // 
            this.cmbUnidadeMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnidadeMedida.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbUnidadeMedida.FormattingEnabled = true;
            this.cmbUnidadeMedida.Items.AddRange(new object[] {
            "un",
            "kg",
            "g",
            "L",
            "mL",
            "m",
            "cm",
            "m²",
            "m³",
            "cx",
            "pç",
            "par",
            "dz"});
            this.cmbUnidadeMedida.Location = new System.Drawing.Point(154, 74);
            this.cmbUnidadeMedida.Name = "cmbUnidadeMedida";
            this.cmbUnidadeMedida.Size = new System.Drawing.Size(78, 23);
            this.cmbUnidadeMedida.TabIndex = 9;
            // 
            // cmbTipoProduto
            // 
            this.cmbTipoProduto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoProduto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTipoProduto.FormattingEnabled = true;
            this.cmbTipoProduto.Items.AddRange(new object[] {
            "Revenda",
            "Consumo",
            "Matéria-Prima",
            "Serviço"});
            this.cmbTipoProduto.Location = new System.Drawing.Point(244, 74);
            this.cmbTipoProduto.Name = "cmbTipoProduto";
            this.cmbTipoProduto.Size = new System.Drawing.Size(103, 23);
            this.cmbTipoProduto.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(13, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Categoria";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(129, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Subcategoria";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(244, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Marca";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(13, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Fornecedor";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(154, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Un. Medida";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(244, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "Tipo de Produto";
            // 
            // groupBoxEstoque
            // 
            this.groupBoxEstoque.Controls.Add(this.numQuantidadeAtual);
            this.groupBoxEstoque.Controls.Add(this.numEstoqueMinimo);
            this.groupBoxEstoque.Controls.Add(this.numEstoqueMaximo);
            this.groupBoxEstoque.Controls.Add(this.txtLocalizacaoEstoque);
            this.groupBoxEstoque.Controls.Add(this.chkPermiteEstoqueNegativo);
            this.groupBoxEstoque.Controls.Add(this.label11);
            this.groupBoxEstoque.Controls.Add(this.label12);
            this.groupBoxEstoque.Controls.Add(this.label13);
            this.groupBoxEstoque.Controls.Add(this.label14);
            this.groupBoxEstoque.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxEstoque.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBoxEstoque.Location = new System.Drawing.Point(875, 239);
            this.groupBoxEstoque.Name = "groupBoxEstoque";
            this.groupBoxEstoque.Size = new System.Drawing.Size(429, 87);
            this.groupBoxEstoque.TabIndex = 4;
            this.groupBoxEstoque.TabStop = false;
            this.groupBoxEstoque.Text = "3. Estoque";
            // 
            // numQuantidadeAtual
            // 
            this.numQuantidadeAtual.DecimalPlaces = 2;
            this.numQuantidadeAtual.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numQuantidadeAtual.Location = new System.Drawing.Point(13, 35);
            this.numQuantidadeAtual.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numQuantidadeAtual.Name = "numQuantidadeAtual";
            this.numQuantidadeAtual.Size = new System.Drawing.Size(77, 23);
            this.numQuantidadeAtual.TabIndex = 11;
            // 
            // numEstoqueMinimo
            // 
            this.numEstoqueMinimo.DecimalPlaces = 2;
            this.numEstoqueMinimo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numEstoqueMinimo.Location = new System.Drawing.Point(103, 35);
            this.numEstoqueMinimo.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numEstoqueMinimo.Name = "numEstoqueMinimo";
            this.numEstoqueMinimo.Size = new System.Drawing.Size(77, 23);
            this.numEstoqueMinimo.TabIndex = 12;
            // 
            // numEstoqueMaximo
            // 
            this.numEstoqueMaximo.DecimalPlaces = 2;
            this.numEstoqueMaximo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numEstoqueMaximo.Location = new System.Drawing.Point(193, 35);
            this.numEstoqueMaximo.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numEstoqueMaximo.Name = "numEstoqueMaximo";
            this.numEstoqueMaximo.Size = new System.Drawing.Size(77, 23);
            this.numEstoqueMaximo.TabIndex = 13;
            // 
            // txtLocalizacaoEstoque
            // 
            this.txtLocalizacaoEstoque.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLocalizacaoEstoque.Location = new System.Drawing.Point(283, 35);
            this.txtLocalizacaoEstoque.Name = "txtLocalizacaoEstoque";
            this.txtLocalizacaoEstoque.Size = new System.Drawing.Size(138, 23);
            this.txtLocalizacaoEstoque.TabIndex = 14;
            // 
            // chkPermiteEstoqueNegativo
            // 
            this.chkPermiteEstoqueNegativo.AutoSize = true;
            this.chkPermiteEstoqueNegativo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkPermiteEstoqueNegativo.ForeColor = System.Drawing.Color.Black;
            this.chkPermiteEstoqueNegativo.Location = new System.Drawing.Point(13, 61);
            this.chkPermiteEstoqueNegativo.Name = "chkPermiteEstoqueNegativo";
            this.chkPermiteEstoqueNegativo.Size = new System.Drawing.Size(223, 19);
            this.chkPermiteEstoqueNegativo.TabIndex = 15;
            this.chkPermiteEstoqueNegativo.Text = "Permite venda com estoque negativo";
            this.chkPermiteEstoqueNegativo.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(13, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "Qtd. Atual";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(103, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "Est. Mínimo";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(193, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "Est. Máximo";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(283, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 15);
            this.label14.TabIndex = 0;
            this.label14.Text = "Localização";
            // 
            // groupBoxPrecos
            // 
            this.groupBoxPrecos.Controls.Add(this.numPrecoCusto);
            this.groupBoxPrecos.Controls.Add(this.numPrecoVenda);
            this.groupBoxPrecos.Controls.Add(this.numMargemLucro);
            this.groupBoxPrecos.Controls.Add(this.chkPromocaoAtiva);
            this.groupBoxPrecos.Controls.Add(this.numPrecoPromocional);
            this.groupBoxPrecos.Controls.Add(this.dtpInicioPromocao);
            this.groupBoxPrecos.Controls.Add(this.dtpFimPromocao);
            this.groupBoxPrecos.Controls.Add(this.label15);
            this.groupBoxPrecos.Controls.Add(this.label16);
            this.groupBoxPrecos.Controls.Add(this.label17);
            this.groupBoxPrecos.Controls.Add(this.label18);
            this.groupBoxPrecos.Controls.Add(this.label19);
            this.groupBoxPrecos.Controls.Add(this.label20);
            this.groupBoxPrecos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxPrecos.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBoxPrecos.Location = new System.Drawing.Point(875, 333);
            this.groupBoxPrecos.Name = "groupBoxPrecos";
            this.groupBoxPrecos.Size = new System.Drawing.Size(429, 104);
            this.groupBoxPrecos.TabIndex = 5;
            this.groupBoxPrecos.TabStop = false;
            this.groupBoxPrecos.Text = "4. Preços";
            // 
            // numPrecoCusto
            // 
            this.numPrecoCusto.DecimalPlaces = 2;
            this.numPrecoCusto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numPrecoCusto.Location = new System.Drawing.Point(13, 35);
            this.numPrecoCusto.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numPrecoCusto.Name = "numPrecoCusto";
            this.numPrecoCusto.Size = new System.Drawing.Size(86, 23);
            this.numPrecoCusto.TabIndex = 16;
            this.numPrecoCusto.ValueChanged += new System.EventHandler(this.numPrecoCusto_ValueChanged);
            // 
            // numPrecoVenda
            // 
            this.numPrecoVenda.DecimalPlaces = 2;
            this.numPrecoVenda.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numPrecoVenda.Location = new System.Drawing.Point(111, 35);
            this.numPrecoVenda.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numPrecoVenda.Name = "numPrecoVenda";
            this.numPrecoVenda.Size = new System.Drawing.Size(86, 23);
            this.numPrecoVenda.TabIndex = 17;
            this.numPrecoVenda.ValueChanged += new System.EventHandler(this.numPrecoVenda_ValueChanged);
            // 
            // numMargemLucro
            // 
            this.numMargemLucro.DecimalPlaces = 2;
            this.numMargemLucro.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numMargemLucro.Location = new System.Drawing.Point(210, 35);
            this.numMargemLucro.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numMargemLucro.Name = "numMargemLucro";
            this.numMargemLucro.Size = new System.Drawing.Size(69, 23);
            this.numMargemLucro.TabIndex = 18;
            this.numMargemLucro.ValueChanged += new System.EventHandler(this.numMargemLucro_ValueChanged);
            // 
            // chkPromocaoAtiva
            // 
            this.chkPromocaoAtiva.AutoSize = true;
            this.chkPromocaoAtiva.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkPromocaoAtiva.ForeColor = System.Drawing.Color.Black;
            this.chkPromocaoAtiva.Location = new System.Drawing.Point(291, 36);
            this.chkPromocaoAtiva.Name = "chkPromocaoAtiva";
            this.chkPromocaoAtiva.Size = new System.Drawing.Size(111, 19);
            this.chkPromocaoAtiva.TabIndex = 19;
            this.chkPromocaoAtiva.Text = "Promoção Ativa";
            this.chkPromocaoAtiva.UseVisualStyleBackColor = true;
            this.chkPromocaoAtiva.CheckedChanged += new System.EventHandler(this.chkPromocaoAtiva_CheckedChanged);
            // 
            // numPrecoPromocional
            // 
            this.numPrecoPromocional.DecimalPlaces = 2;
            this.numPrecoPromocional.Enabled = false;
            this.numPrecoPromocional.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numPrecoPromocional.Location = new System.Drawing.Point(13, 74);
            this.numPrecoPromocional.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numPrecoPromocional.Name = "numPrecoPromocional";
            this.numPrecoPromocional.Size = new System.Drawing.Size(86, 23);
            this.numPrecoPromocional.TabIndex = 20;
            // 
            // dtpInicioPromocao
            // 
            this.dtpInicioPromocao.Enabled = false;
            this.dtpInicioPromocao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpInicioPromocao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicioPromocao.Location = new System.Drawing.Point(111, 74);
            this.dtpInicioPromocao.Name = "dtpInicioPromocao";
            this.dtpInicioPromocao.Size = new System.Drawing.Size(86, 23);
            this.dtpInicioPromocao.TabIndex = 21;
            // 
            // dtpFimPromocao
            // 
            this.dtpFimPromocao.Enabled = false;
            this.dtpFimPromocao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFimPromocao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFimPromocao.Location = new System.Drawing.Point(210, 74);
            this.dtpFimPromocao.Name = "dtpFimPromocao";
            this.dtpFimPromocao.Size = new System.Drawing.Size(86, 23);
            this.dtpFimPromocao.TabIndex = 22;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(13, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "Preço de Custo";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(111, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 15);
            this.label16.TabIndex = 0;
            this.label16.Text = "Preço de Venda";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(210, 19);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(73, 15);
            this.label17.TabIndex = 0;
            this.label17.Text = "Margem (%)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(13, 58);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(108, 15);
            this.label18.TabIndex = 0;
            this.label18.Text = "Preço Promocional";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(111, 58);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(94, 15);
            this.label19.TabIndex = 0;
            this.label19.Text = "Início Promoção";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(210, 58);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(85, 15);
            this.label20.TabIndex = 0;
            this.label20.Text = "Fim Promoção";
            // 
            // groupBoxTributacao
            // 
            this.groupBoxTributacao.Controls.Add(this.cmbOrigemProduto);
            this.groupBoxTributacao.Controls.Add(this.txtNCM);
            this.groupBoxTributacao.Controls.Add(this.txtCFOP);
            this.groupBoxTributacao.Controls.Add(this.txtCSTCSOSN);
            this.groupBoxTributacao.Controls.Add(this.numICMS);
            this.groupBoxTributacao.Controls.Add(this.numPIS);
            this.groupBoxTributacao.Controls.Add(this.numCOFINS);
            this.groupBoxTributacao.Controls.Add(this.numIPI);
            this.groupBoxTributacao.Controls.Add(this.label21);
            this.groupBoxTributacao.Controls.Add(this.label22);
            this.groupBoxTributacao.Controls.Add(this.label23);
            this.groupBoxTributacao.Controls.Add(this.label24);
            this.groupBoxTributacao.Controls.Add(this.label25);
            this.groupBoxTributacao.Controls.Add(this.label26);
            this.groupBoxTributacao.Controls.Add(this.label27);
            this.groupBoxTributacao.Controls.Add(this.label28);
            this.groupBoxTributacao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxTributacao.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBoxTributacao.Location = new System.Drawing.Point(875, 444);
            this.groupBoxTributacao.Name = "groupBoxTributacao";
            this.groupBoxTributacao.Size = new System.Drawing.Size(429, 104);
            this.groupBoxTributacao.TabIndex = 6;
            this.groupBoxTributacao.TabStop = false;
            this.groupBoxTributacao.Text = "5. Tributação";
            // 
            // cmbOrigemProduto
            // 
            this.cmbOrigemProduto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrigemProduto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbOrigemProduto.FormattingEnabled = true;
            this.cmbOrigemProduto.Items.AddRange(new object[] {
            "0 - Nacional",
            "1 - Estrangeira - Importação direta",
            "2 - Estrangeira - Adquirida no mercado interno"});
            this.cmbOrigemProduto.Location = new System.Drawing.Point(13, 35);
            this.cmbOrigemProduto.Name = "cmbOrigemProduto";
            this.cmbOrigemProduto.Size = new System.Drawing.Size(103, 23);
            this.cmbOrigemProduto.TabIndex = 23;
            // 
            // txtNCM
            // 
            this.txtNCM.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNCM.Location = new System.Drawing.Point(129, 35);
            this.txtNCM.Name = "txtNCM";
            this.txtNCM.Size = new System.Drawing.Size(69, 23);
            this.txtNCM.TabIndex = 24;
            // 
            // txtCFOP
            // 
            this.txtCFOP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCFOP.Location = new System.Drawing.Point(210, 35);
            this.txtCFOP.Name = "txtCFOP";
            this.txtCFOP.Size = new System.Drawing.Size(52, 23);
            this.txtCFOP.TabIndex = 25;
            // 
            // txtCSTCSOSN
            // 
            this.txtCSTCSOSN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCSTCSOSN.Location = new System.Drawing.Point(274, 35);
            this.txtCSTCSOSN.Name = "txtCSTCSOSN";
            this.txtCSTCSOSN.Size = new System.Drawing.Size(52, 23);
            this.txtCSTCSOSN.TabIndex = 26;
            // 
            // numICMS
            // 
            this.numICMS.DecimalPlaces = 2;
            this.numICMS.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numICMS.Location = new System.Drawing.Point(13, 74);
            this.numICMS.Name = "numICMS";
            this.numICMS.Size = new System.Drawing.Size(60, 23);
            this.numICMS.TabIndex = 27;
            // 
            // numPIS
            // 
            this.numPIS.DecimalPlaces = 2;
            this.numPIS.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numPIS.Location = new System.Drawing.Point(86, 74);
            this.numPIS.Name = "numPIS";
            this.numPIS.Size = new System.Drawing.Size(60, 23);
            this.numPIS.TabIndex = 28;
            // 
            // numCOFINS
            // 
            this.numCOFINS.DecimalPlaces = 2;
            this.numCOFINS.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numCOFINS.Location = new System.Drawing.Point(159, 74);
            this.numCOFINS.Name = "numCOFINS";
            this.numCOFINS.Size = new System.Drawing.Size(60, 23);
            this.numCOFINS.TabIndex = 29;
            // 
            // numIPI
            // 
            this.numIPI.DecimalPlaces = 2;
            this.numIPI.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numIPI.Location = new System.Drawing.Point(231, 74);
            this.numIPI.Name = "numIPI";
            this.numIPI.Size = new System.Drawing.Size(60, 23);
            this.numIPI.TabIndex = 30;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(13, 19);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(47, 15);
            this.label21.TabIndex = 0;
            this.label21.Text = "Origem";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(129, 19);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 15);
            this.label22.TabIndex = 0;
            this.label22.Text = "NCM";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(210, 19);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(37, 15);
            this.label23.TabIndex = 0;
            this.label23.Text = "CFOP";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(274, 19);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(71, 15);
            this.label24.TabIndex = 0;
            this.label24.Text = "CST/CSOSN";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(13, 58);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 15);
            this.label25.TabIndex = 0;
            this.label25.Text = "ICMS (%)";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(86, 58);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(44, 15);
            this.label26.TabIndex = 0;
            this.label26.Text = "PIS (%)";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(159, 58);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(69, 15);
            this.label27.TabIndex = 0;
            this.label27.Text = "COFINS (%)";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(231, 58);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(41, 15);
            this.label28.TabIndex = 0;
            this.label28.Text = "IPI (%)";
            // 
            // groupBoxImagem
            // 
            this.groupBoxImagem.Controls.Add(this.pictureBoxProduto);
            this.groupBoxImagem.Controls.Add(this.btnCarregarImagem);
            this.groupBoxImagem.Controls.Add(this.btnRemoverImagem);
            this.groupBoxImagem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxImagem.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBoxImagem.Location = new System.Drawing.Point(1321, 17);
            this.groupBoxImagem.Name = "groupBoxImagem";
            this.groupBoxImagem.Size = new System.Drawing.Size(214, 260);
            this.groupBoxImagem.TabIndex = 7;
            this.groupBoxImagem.TabStop = false;
            this.groupBoxImagem.Text = "6. Imagem do Produto";
            // 
            // pictureBoxProduto
            // 
            this.pictureBoxProduto.BackColor = System.Drawing.Color.White;
            this.pictureBoxProduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxProduto.Location = new System.Drawing.Point(13, 22);
            this.pictureBoxProduto.Name = "pictureBoxProduto";
            this.pictureBoxProduto.Size = new System.Drawing.Size(189, 191);
            this.pictureBoxProduto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxProduto.TabIndex = 0;
            this.pictureBoxProduto.TabStop = false;
            // 
            // btnCarregarImagem
            // 
            this.btnCarregarImagem.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCarregarImagem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCarregarImagem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCarregarImagem.ForeColor = System.Drawing.Color.White;
            this.btnCarregarImagem.Location = new System.Drawing.Point(13, 221);
            this.btnCarregarImagem.Name = "btnCarregarImagem";
            this.btnCarregarImagem.Size = new System.Drawing.Size(86, 26);
            this.btnCarregarImagem.TabIndex = 31;
            this.btnCarregarImagem.Text = "Carregar";
            this.btnCarregarImagem.UseVisualStyleBackColor = false;
            this.btnCarregarImagem.Click += new System.EventHandler(this.btnCarregarImagem_Click);
            // 
            // btnRemoverImagem
            // 
            this.btnRemoverImagem.BackColor = System.Drawing.Color.Coral;
            this.btnRemoverImagem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRemoverImagem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRemoverImagem.ForeColor = System.Drawing.Color.White;
            this.btnRemoverImagem.Location = new System.Drawing.Point(116, 221);
            this.btnRemoverImagem.Name = "btnRemoverImagem";
            this.btnRemoverImagem.Size = new System.Drawing.Size(86, 26);
            this.btnRemoverImagem.TabIndex = 32;
            this.btnRemoverImagem.Text = "Remover";
            this.btnRemoverImagem.UseVisualStyleBackColor = false;
            this.btnRemoverImagem.Click += new System.EventHandler(this.btnRemoverImagem_Click);
            // 
            // groupBoxComplementares
            // 
            this.groupBoxComplementares.Controls.Add(this.chkAtivo);
            this.groupBoxComplementares.Controls.Add(this.txtObservacoes);
            this.groupBoxComplementares.Controls.Add(this.txtSKU);
            this.groupBoxComplementares.Controls.Add(this.lblDataCadastro);
            this.groupBoxComplementares.Controls.Add(this.lblUltimaAlteracao);
            this.groupBoxComplementares.Controls.Add(this.label29);
            this.groupBoxComplementares.Controls.Add(this.label30);
            this.groupBoxComplementares.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.groupBoxComplementares.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBoxComplementares.Location = new System.Drawing.Point(1321, 284);
            this.groupBoxComplementares.Name = "groupBoxComplementares";
            this.groupBoxComplementares.Size = new System.Drawing.Size(214, 257);
            this.groupBoxComplementares.TabIndex = 8;
            this.groupBoxComplementares.TabStop = false;
            this.groupBoxComplementares.Text = "7. Informações Complementares";
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Checked = true;
            this.chkAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAtivo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkAtivo.ForeColor = System.Drawing.Color.Black;
            this.chkAtivo.Location = new System.Drawing.Point(13, 22);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(100, 19);
            this.chkAtivo.TabIndex = 33;
            this.chkAtivo.Text = "Produto Ativo";
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtObservacoes.Location = new System.Drawing.Point(13, 100);
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacoes.Size = new System.Drawing.Size(189, 117);
            this.txtObservacoes.TabIndex = 35;
            // 
            // txtSKU
            // 
            this.txtSKU.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSKU.Location = new System.Drawing.Point(13, 61);
            this.txtSKU.Name = "txtSKU";
            this.txtSKU.Size = new System.Drawing.Size(189, 23);
            this.txtSKU.TabIndex = 34;
            // 
            // lblDataCadastro
            // 
            this.lblDataCadastro.AutoSize = true;
            this.lblDataCadastro.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDataCadastro.ForeColor = System.Drawing.Color.Gray;
            this.lblDataCadastro.Location = new System.Drawing.Point(6, 220);
            this.lblDataCadastro.Name = "lblDataCadastro";
            this.lblDataCadastro.Size = new System.Drawing.Size(90, 13);
            this.lblDataCadastro.TabIndex = 0;
            this.lblDataCadastro.Text = "Data Cadastro: -";
            // 
            // lblUltimaAlteracao
            // 
            this.lblUltimaAlteracao.AutoSize = true;
            this.lblUltimaAlteracao.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblUltimaAlteracao.ForeColor = System.Drawing.Color.Gray;
            this.lblUltimaAlteracao.Location = new System.Drawing.Point(6, 233);
            this.lblUltimaAlteracao.Name = "lblUltimaAlteracao";
            this.lblUltimaAlteracao.Size = new System.Drawing.Size(101, 13);
            this.lblUltimaAlteracao.TabIndex = 0;
            this.lblUltimaAlteracao.Text = "Última Alteração: -";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(13, 45);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(28, 15);
            this.label29.TabIndex = 0;
            this.label29.Text = "SKU";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Location = new System.Drawing.Point(13, 84);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(74, 15);
            this.label30.TabIndex = 0;
            this.label30.Text = "Observações";
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAtualizar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAtualizar.ForeColor = System.Drawing.Color.White;
            this.btnAtualizar.Location = new System.Drawing.Point(10, 555);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(86, 35);
            this.btnAtualizar.TabIndex = 36;
            this.btnAtualizar.Text = "&Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.Color.Teal;
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNovo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNovo.ForeColor = System.Drawing.Color.White;
            this.btnNovo.Location = new System.Drawing.Point(107, 555);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(86, 35);
            this.btnNovo.TabIndex = 37;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.Orange;
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLimpar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLimpar.ForeColor = System.Drawing.Color.White;
            this.btnLimpar.Location = new System.Drawing.Point(204, 555);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(86, 35);
            this.btnLimpar.TabIndex = 38;
            this.btnLimpar.Text = "&Limpar";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.Crimson;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnExcluir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExcluir.ForeColor = System.Drawing.Color.White;
            this.btnExcluir.Location = new System.Drawing.Point(301, 555);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(86, 35);
            this.btnExcluir.TabIndex = 39;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.DarkOrange;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(398, 555);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(86, 35);
            this.btnEditar.TabIndex = 40;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.Gray;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(1114, 555);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(86, 35);
            this.btnFechar.TabIndex = 41;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AllowCustomTheming = false;
            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.AllowUserToDeleteRows = false;
            this.dgvProdutos.AllowUserToResizeColumns = false;
            this.dgvProdutos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvProdutos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProdutos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProdutos.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dgvProdutos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProdutos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProdutos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProdutos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProdutos.ColumnHeadersHeight = 40;
            this.dgvProdutos.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.dgvProdutos.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvProdutos.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvProdutos.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.dgvProdutos.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvProdutos.CurrentTheme.BackColor = System.Drawing.Color.Teal;
            this.dgvProdutos.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.dgvProdutos.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.Teal;
            this.dgvProdutos.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dgvProdutos.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvProdutos.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.dgvProdutos.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvProdutos.CurrentTheme.Name = null;
            this.dgvProdutos.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.dgvProdutos.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvProdutos.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvProdutos.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.dgvProdutos.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProdutos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProdutos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvProdutos.EnableHeadersVisualStyles = false;
            this.dgvProdutos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.dgvProdutos.HeaderBackColor = System.Drawing.Color.Teal;
            this.dgvProdutos.HeaderBgColor = System.Drawing.Color.Empty;
            this.dgvProdutos.HeaderForeColor = System.Drawing.Color.White;
            this.dgvProdutos.Location = new System.Drawing.Point(10, 51);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.RowHeadersVisible = false;
            this.dgvProdutos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvProdutos.RowTemplate.Height = 40;
            this.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutos.Size = new System.Drawing.Size(859, 490);
            this.dgvProdutos.TabIndex = 42;
            this.dgvProdutos.TabStop = false;
            this.dgvProdutos.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Teal;
            // 
            // btImportar
            // 
            this.btImportar.BackColor = System.Drawing.Color.DarkOrange;
            this.btImportar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btImportar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btImportar.ForeColor = System.Drawing.Color.White;
            this.btImportar.Location = new System.Drawing.Point(490, 555);
            this.btImportar.Name = "btImportar";
            this.btImportar.Size = new System.Drawing.Size(86, 35);
            this.btImportar.TabIndex = 43;
            this.btImportar.Text = "Importar";
            this.btImportar.UseVisualStyleBackColor = false;
            this.btImportar.Click += new System.EventHandler(this.btImportar_Click);
            // 
            // frmEdicaoP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1547, 607);
            this.Controls.Add(this.btImportar);
            this.Controls.Add(this.dgvProdutos);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.groupBoxComplementares);
            this.Controls.Add(this.groupBoxImagem);
            this.Controls.Add(this.groupBoxTributacao);
            this.Controls.Add(this.groupBoxPrecos);
            this.Controls.Add(this.groupBoxEstoque);
            this.Controls.Add(this.groupBoxClassificacao);
            this.Controls.Add(this.groupBoxIdentificacao);
            this.Controls.Add(this.panelBusca);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEdicaoP";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edição de Produtos";
            this.Load += new System.EventHandler(this.frmEdicaoP_Load);
            this.panelBusca.ResumeLayout(false);
            this.panelBusca.PerformLayout();
            this.groupBoxIdentificacao.ResumeLayout(false);
            this.groupBoxIdentificacao.PerformLayout();
            this.groupBoxClassificacao.ResumeLayout(false);
            this.groupBoxClassificacao.PerformLayout();
            this.groupBoxEstoque.ResumeLayout(false);
            this.groupBoxEstoque.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidadeAtual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEstoqueMinimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEstoqueMaximo)).EndInit();
            this.groupBoxPrecos.ResumeLayout(false);
            this.groupBoxPrecos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoCusto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoVenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMargemLucro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoPromocional)).EndInit();
            this.groupBoxTributacao.ResumeLayout(false);
            this.groupBoxTributacao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numICMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPIS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCOFINS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIPI)).EndInit();
            this.groupBoxImagem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduto)).EndInit();
            this.groupBoxComplementares.ResumeLayout(false);
            this.groupBoxComplementares.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panelBusca;
        private TextBox txtBusca;
        private Button btnBuscar;
        private Label lblBusca;

        private GroupBox groupBoxIdentificacao;
        private GroupBox groupBoxClassificacao;
        private GroupBox groupBoxEstoque;
        private GroupBox groupBoxPrecos;
        private GroupBox groupBoxTributacao;
        private GroupBox groupBoxImagem;
        private GroupBox groupBoxComplementares;

        // Identificação
        private TextBox txtCodigoProduto;
        private TextBox txtCodigoBarras;
        private TextBox txtNome;
        private TextBox txtDescricao;

        // Classificação
        private TextBox txtCategoria;
        private TextBox txtSubcategoria;
        private TextBox txtMarca;
        private ComboBox cmbFornecedor;
        private ComboBox cmbUnidadeMedida;
        private ComboBox cmbTipoProduto;

        // Estoque
        private NumericUpDown numQuantidadeAtual;
        private NumericUpDown numEstoqueMinimo;
        private NumericUpDown numEstoqueMaximo;
        private TextBox txtLocalizacaoEstoque;
        private CheckBox chkPermiteEstoqueNegativo;

        // Preços
        private NumericUpDown numPrecoCusto;
        private NumericUpDown numPrecoVenda;
        private NumericUpDown numMargemLucro;
        private CheckBox chkPromocaoAtiva;
        private NumericUpDown numPrecoPromocional;
        private DateTimePicker dtpInicioPromocao;
        private DateTimePicker dtpFimPromocao;

        // Tributação
        private ComboBox cmbOrigemProduto;
        private TextBox txtNCM;
        private TextBox txtCFOP;
        private TextBox txtCSTCSOSN;
        private NumericUpDown numICMS;
        private NumericUpDown numPIS;
        private NumericUpDown numCOFINS;
        private NumericUpDown numIPI;

        // Imagem
        private PictureBox pictureBoxProduto;
        private Button btnCarregarImagem;
        private Button btnRemoverImagem;

        // Complementares
        private CheckBox chkAtivo;
        private TextBox txtObservacoes;
        private TextBox txtSKU;
        private Label lblDataCadastro;
        private Label lblUltimaAlteracao;

        // Botões
        private Button btnAtualizar;
        private Button btnNovo;
        private Button btnLimpar;
        private Button btnExcluir;
        private Button btnEditar;
        private Button btnFechar;

        // Labels
        private Label label1, label2, label3, label4, label5, label6, label7, label8, label9, label10;
        private Label label11, label12, label13, label14, label15, label16, label17, label18, label19, label20;
        private Label label21, label22, label23, label24, label25, label26, label27, label28, label29, label30;
        private Bunifu.UI.WinForms.BunifuDataGridView dgvProdutos;
        private Button btImportar;
    }
}
