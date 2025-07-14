using System.Drawing;
using System.Windows.Forms;

namespace   Acessos
{ 
    partial class frmVisualizarDiferenca
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
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabComparacao = new System.Windows.Forms.TabPage();
            this.pnlComparacao = new System.Windows.Forms.Panel();
            this.grpProdutoExistente = new System.Windows.Forms.GroupBox();
            this.dgvProdutoExistente = new System.Windows.Forms.DataGridView();
            this.colCampoExistente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorExistente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpProdutoImportado = new System.Windows.Forms.GroupBox();
            this.dgvProdutoImportado = new System.Windows.Forms.DataGridView();
            this.colCampoImportado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorImportado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabDiferencas = new System.Windows.Forms.TabPage();
            this.lstDiferencas = new System.Windows.Forms.ListBox();
            this.tabResumo = new System.Windows.Forms.TabPage();
            this.rtbResumo = new System.Windows.Forms.RichTextBox();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnAplicarAcao = new System.Windows.Forms.Button();
            this.cmbAcaoRecomendada = new System.Windows.Forms.ComboBox();
            this.lblRecomendacao = new System.Windows.Forms.Label();
            this.radFormConverter1 = new Telerik.WinControls.UI.RadFormConverter();
            this.pnlSuperior.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabComparacao.SuspendLayout();
            this.pnlComparacao.SuspendLayout();
            this.grpProdutoExistente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutoExistente)).BeginInit();
            this.grpProdutoImportado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutoImportado)).BeginInit();
            this.tabDiferencas.SuspendLayout();
            this.tabResumo.SuspendLayout();
            this.pnlInferior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlSuperior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSuperior.Controls.Add(this.lblSubtitulo);
            this.pnlSuperior.Controls.Add(this.lblTitulo);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(800, 70);
            this.pnlSuperior.TabIndex = 0;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(12, 40);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(372, 15);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Compare os dados entre o produto importado e o existente no banco";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.lblTitulo.Location = new System.Drawing.Point(12, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(170, 21);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Visualizar Diferenças";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabComparacao);
            this.tabControl.Controls.Add(this.tabDiferencas);
            this.tabControl.Controls.Add(this.tabResumo);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabControl.Location = new System.Drawing.Point(0, 70);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 400);
            this.tabControl.TabIndex = 1;
            // 
            // tabComparacao
            // 
            this.tabComparacao.Controls.Add(this.pnlComparacao);
            this.tabComparacao.Location = new System.Drawing.Point(4, 24);
            this.tabComparacao.Name = "tabComparacao";
            this.tabComparacao.Padding = new System.Windows.Forms.Padding(3);
            this.tabComparacao.Size = new System.Drawing.Size(792, 372);
            this.tabComparacao.TabIndex = 0;
            this.tabComparacao.Text = "Comparação Lado a Lado";
            this.tabComparacao.UseVisualStyleBackColor = true;
            // 
            // pnlComparacao
            // 
            this.pnlComparacao.Controls.Add(this.grpProdutoExistente);
            this.pnlComparacao.Controls.Add(this.grpProdutoImportado);
            this.pnlComparacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlComparacao.Location = new System.Drawing.Point(3, 3);
            this.pnlComparacao.Name = "pnlComparacao";
            this.pnlComparacao.Size = new System.Drawing.Size(786, 366);
            this.pnlComparacao.TabIndex = 0;
            // 
            // grpProdutoExistente
            // 
            this.grpProdutoExistente.Controls.Add(this.dgvProdutoExistente);
            this.grpProdutoExistente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpProdutoExistente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpProdutoExistente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.grpProdutoExistente.Location = new System.Drawing.Point(393, 0);
            this.grpProdutoExistente.Name = "grpProdutoExistente";
            this.grpProdutoExistente.Size = new System.Drawing.Size(393, 366);
            this.grpProdutoExistente.TabIndex = 1;
            this.grpProdutoExistente.TabStop = false;
            this.grpProdutoExistente.Text = "Produto Existente no Banco";
            // 
            // dgvProdutoExistente
            // 
            this.dgvProdutoExistente.AllowUserToAddRows = false;
            this.dgvProdutoExistente.AllowUserToDeleteRows = false;
            this.dgvProdutoExistente.BackgroundColor = System.Drawing.Color.White;
            this.dgvProdutoExistente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProdutoExistente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutoExistente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCampoExistente,
            this.colValorExistente});
            this.dgvProdutoExistente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProdutoExistente.Location = new System.Drawing.Point(3, 19);
            this.dgvProdutoExistente.Name = "dgvProdutoExistente";
            this.dgvProdutoExistente.ReadOnly = true;
            this.dgvProdutoExistente.RowHeadersVisible = false;
            this.dgvProdutoExistente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutoExistente.Size = new System.Drawing.Size(387, 344);
            this.dgvProdutoExistente.TabIndex = 0;
            // 
            // colCampoExistente
            // 
            this.colCampoExistente.HeaderText = "Campo";
            this.colCampoExistente.Name = "colCampoExistente";
            this.colCampoExistente.ReadOnly = true;
            this.colCampoExistente.Width = 120;
            // 
            // colValorExistente
            // 
            this.colValorExistente.HeaderText = "Valor";
            this.colValorExistente.Name = "colValorExistente";
            this.colValorExistente.ReadOnly = true;
            this.colValorExistente.Width = 250;
            // 
            // grpProdutoImportado
            // 
            this.grpProdutoImportado.Controls.Add(this.dgvProdutoImportado);
            this.grpProdutoImportado.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpProdutoImportado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpProdutoImportado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.grpProdutoImportado.Location = new System.Drawing.Point(0, 0);
            this.grpProdutoImportado.Name = "grpProdutoImportado";
            this.grpProdutoImportado.Size = new System.Drawing.Size(393, 366);
            this.grpProdutoImportado.TabIndex = 0;
            this.grpProdutoImportado.TabStop = false;
            this.grpProdutoImportado.Text = "Produto Importado";
            // 
            // dgvProdutoImportado
            // 
            this.dgvProdutoImportado.AllowUserToAddRows = false;
            this.dgvProdutoImportado.AllowUserToDeleteRows = false;
            this.dgvProdutoImportado.BackgroundColor = System.Drawing.Color.White;
            this.dgvProdutoImportado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProdutoImportado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutoImportado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCampoImportado,
            this.colValorImportado});
            this.dgvProdutoImportado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProdutoImportado.Location = new System.Drawing.Point(3, 19);
            this.dgvProdutoImportado.Name = "dgvProdutoImportado";
            this.dgvProdutoImportado.ReadOnly = true;
            this.dgvProdutoImportado.RowHeadersVisible = false;
            this.dgvProdutoImportado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutoImportado.Size = new System.Drawing.Size(387, 344);
            this.dgvProdutoImportado.TabIndex = 0;
            // 
            // colCampoImportado
            // 
            this.colCampoImportado.HeaderText = "Campo";
            this.colCampoImportado.Name = "colCampoImportado";
            this.colCampoImportado.ReadOnly = true;
            this.colCampoImportado.Width = 120;
            // 
            // colValorImportado
            // 
            this.colValorImportado.HeaderText = "Valor";
            this.colValorImportado.Name = "colValorImportado";
            this.colValorImportado.ReadOnly = true;
            this.colValorImportado.Width = 250;
            // 
            // tabDiferencas
            // 
            this.tabDiferencas.Controls.Add(this.lstDiferencas);
            this.tabDiferencas.Location = new System.Drawing.Point(4, 24);
            this.tabDiferencas.Name = "tabDiferencas";
            this.tabDiferencas.Padding = new System.Windows.Forms.Padding(3);
            this.tabDiferencas.Size = new System.Drawing.Size(792, 372);
            this.tabDiferencas.TabIndex = 1;
            this.tabDiferencas.Text = "Diferenças Detalhadas";
            this.tabDiferencas.UseVisualStyleBackColor = true;
            // 
            // lstDiferencas
            // 
            this.lstDiferencas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstDiferencas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDiferencas.Font = new System.Drawing.Font("Consolas", 9F);
            this.lstDiferencas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.lstDiferencas.FormattingEnabled = true;
            this.lstDiferencas.ItemHeight = 14;
            this.lstDiferencas.Location = new System.Drawing.Point(3, 3);
            this.lstDiferencas.Name = "lstDiferencas";
            this.lstDiferencas.Size = new System.Drawing.Size(786, 366);
            this.lstDiferencas.TabIndex = 0;
            // 
            // tabResumo
            // 
            this.tabResumo.Controls.Add(this.rtbResumo);
            this.tabResumo.Location = new System.Drawing.Point(4, 24);
            this.tabResumo.Name = "tabResumo";
            this.tabResumo.Padding = new System.Windows.Forms.Padding(3);
            this.tabResumo.Size = new System.Drawing.Size(792, 372);
            this.tabResumo.TabIndex = 2;
            this.tabResumo.Text = "Resumo Completo";
            this.tabResumo.UseVisualStyleBackColor = true;
            // 
            // rtbResumo
            // 
            this.rtbResumo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbResumo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbResumo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rtbResumo.Location = new System.Drawing.Point(3, 3);
            this.rtbResumo.Name = "rtbResumo";
            this.rtbResumo.ReadOnly = true;
            this.rtbResumo.Size = new System.Drawing.Size(786, 366);
            this.rtbResumo.TabIndex = 0;
            this.rtbResumo.Text = "";
            // 
            // pnlInferior
            // 
            this.pnlInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlInferior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInferior.Controls.Add(this.btnFechar);
            this.pnlInferior.Controls.Add(this.btnAplicarAcao);
            this.pnlInferior.Controls.Add(this.cmbAcaoRecomendada);
            this.pnlInferior.Controls.Add(this.lblRecomendacao);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(0, 470);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(800, 60);
            this.pnlInferior.TabIndex = 2;
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnFechar.FlatAppearance.BorderSize = 0;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(700, 15);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(80, 27);
            this.btnFechar.TabIndex = 3;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.BtnFechar_Click);
            // 
            // btnAplicarAcao
            // 
            this.btnAplicarAcao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnAplicarAcao.FlatAppearance.BorderSize = 0;
            this.btnAplicarAcao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicarAcao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAplicarAcao.ForeColor = System.Drawing.Color.White;
            this.btnAplicarAcao.Location = new System.Drawing.Point(310, 15);
            this.btnAplicarAcao.Name = "btnAplicarAcao";
            this.btnAplicarAcao.Size = new System.Drawing.Size(100, 27);
            this.btnAplicarAcao.TabIndex = 2;
            this.btnAplicarAcao.Text = "Aplicar Ação";
            this.btnAplicarAcao.UseVisualStyleBackColor = false;
            this.btnAplicarAcao.Click += new System.EventHandler(this.BtnAplicarAcao_Click);
            // 
            // cmbAcaoRecomendada
            // 
            this.cmbAcaoRecomendada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAcaoRecomendada.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbAcaoRecomendada.FormattingEnabled = true;
            this.cmbAcaoRecomendada.Location = new System.Drawing.Point(140, 17);
            this.cmbAcaoRecomendada.Name = "cmbAcaoRecomendada";
            this.cmbAcaoRecomendada.Size = new System.Drawing.Size(150, 23);
            this.cmbAcaoRecomendada.TabIndex = 1;
            this.cmbAcaoRecomendada.SelectedIndexChanged += new System.EventHandler(this.CmbAcaoRecomendada_SelectedIndexChanged);
            // 
            // lblRecomendacao
            // 
            this.lblRecomendacao.AutoSize = true;
            this.lblRecomendacao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRecomendacao.Location = new System.Drawing.Point(12, 20);
            this.lblRecomendacao.Name = "lblRecomendacao";
            this.lblRecomendacao.Size = new System.Drawing.Size(119, 15);
            this.lblRecomendacao.TabIndex = 0;
            this.lblRecomendacao.Text = "Ação Recomendada:";
            // 
            // frmVisualizarDiferenca
            // 
            this.AcceptButton = this.btnFechar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnFechar;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlInferior);
            this.Controls.Add(this.pnlSuperior);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "frmVisualizarDiferenca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Visualizar Diferenças - Produtos Duplicados";
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabComparacao.ResumeLayout(false);
            this.pnlComparacao.ResumeLayout(false);
            this.grpProdutoExistente.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutoExistente)).EndInit();
            this.grpProdutoImportado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutoImportado)).EndInit();
            this.tabDiferencas.ResumeLayout(false);
            this.tabResumo.ResumeLayout(false);
            this.pnlInferior.ResumeLayout(false);
            this.pnlInferior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabComparacao;
        private System.Windows.Forms.Panel pnlComparacao;
        private System.Windows.Forms.GroupBox grpProdutoExistente;
        private System.Windows.Forms.DataGridView dgvProdutoExistente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCampoExistente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorExistente;
        private System.Windows.Forms.GroupBox grpProdutoImportado;
        private System.Windows.Forms.DataGridView dgvProdutoImportado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCampoImportado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorImportado;
        private System.Windows.Forms.TabPage tabDiferencas;
        private System.Windows.Forms.ListBox lstDiferencas;
        private System.Windows.Forms.TabPage tabResumo;
        private System.Windows.Forms.RichTextBox rtbResumo;
        private System.Windows.Forms.Panel pnlInferior;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnAplicarAcao;
        private System.Windows.Forms.ComboBox cmbAcaoRecomendada;
        private System.Windows.Forms.Label lblRecomendacao;
        private Telerik.WinControls.UI.RadFormConverter radFormConverter1;
    }
}
