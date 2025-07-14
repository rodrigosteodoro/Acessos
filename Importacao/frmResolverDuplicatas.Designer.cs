using System;

namespace Acessos
{ 
   public partial class frmResolverDuplicatas
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
            this.dgvDuplicatas = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoDuplicata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiferencas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAcao = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.btnVisualizarDiferenca = new System.Windows.Forms.Button();
            this.btnAplicarTodas = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuplicatas)).BeginInit();
            this.pnlSuperior.SuspendLayout();
            this.pnlInferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDuplicatas
            // 
            this.dgvDuplicatas.AllowUserToAddRows = false;
            this.dgvDuplicatas.AllowUserToDeleteRows = false;
            this.dgvDuplicatas.BackgroundColor = System.Drawing.Color.White;
            this.dgvDuplicatas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDuplicatas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDuplicatas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colNome,
            this.colTipoDuplicata,
            this.colDiferencas,
            this.colAcao});
            this.dgvDuplicatas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDuplicatas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDuplicatas.Location = new System.Drawing.Point(0, 80);
            this.dgvDuplicatas.MultiSelect = false;
            this.dgvDuplicatas.Name = "dgvDuplicatas";
            this.dgvDuplicatas.RowHeadersWidth = 25;
            this.dgvDuplicatas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDuplicatas.Size = new System.Drawing.Size(1000, 420);
            this.dgvDuplicatas.TabIndex = 1;
            this.dgvDuplicatas.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDuplicatas_CurrentCellDirtyStateChanged);
            this.dgvDuplicatas.SelectionChanged += new System.EventHandler(this.dgvDuplicatas_SelectionChanged);
            // 
            // colCodigo
            // 
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.Width = 80;
            // 
            // colNome
            // 
            this.colNome.HeaderText = "Nome do Produto";
            this.colNome.Name = "colNome";
            this.colNome.ReadOnly = true;
            this.colNome.Width = 200;
            // 
            // colTipoDuplicata
            // 
            this.colTipoDuplicata.HeaderText = "Tipo de Duplicata";
            this.colTipoDuplicata.Name = "colTipoDuplicata";
            this.colTipoDuplicata.ReadOnly = true;
            this.colTipoDuplicata.Width = 150;
            // 
            // colDiferencas
            // 
            this.colDiferencas.HeaderText = "Diferenças Encontradas";
            this.colDiferencas.Name = "colDiferencas";
            this.colDiferencas.ReadOnly = true;
            this.colDiferencas.Width = 350;
            // 
            // colAcao
            // 
            this.colAcao.HeaderText = "Ação a Executar";
            this.colAcao.Name = "colAcao";
            this.colAcao.Width = 150;
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
            this.pnlSuperior.Size = new System.Drawing.Size(1000, 80);
            this.pnlSuperior.TabIndex = 0;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(12, 45);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(456, 19);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Selecione como tratar cada produto duplicado encontrado na importação";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.lblTitulo.Location = new System.Drawing.Point(12, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(184, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Resolver Duplicatas";
            // 
            // pnlInferior
            // 
            this.pnlInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlInferior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInferior.Controls.Add(this.btnVisualizarDiferenca);
            this.pnlInferior.Controls.Add(this.btnAplicarTodas);
            this.pnlInferior.Controls.Add(this.btnCancelar);
            this.pnlInferior.Controls.Add(this.btnOK);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(0, 500);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(1000, 60);
            this.pnlInferior.TabIndex = 2;
            // 
            // btnVisualizarDiferenca
            // 
            this.btnVisualizarDiferenca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnVisualizarDiferenca.FlatAppearance.BorderSize = 0;
            this.btnVisualizarDiferenca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisualizarDiferenca.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnVisualizarDiferenca.ForeColor = System.Drawing.Color.Black;
            this.btnVisualizarDiferenca.Location = new System.Drawing.Point(291, 15);
            this.btnVisualizarDiferenca.Name = "btnVisualizarDiferenca";
            this.btnVisualizarDiferenca.Size = new System.Drawing.Size(140, 30);
            this.btnVisualizarDiferenca.TabIndex = 3;
            this.btnVisualizarDiferenca.Text = "Visualizar Diferença";
            this.btnVisualizarDiferenca.UseVisualStyleBackColor = false;
            this.btnVisualizarDiferenca.Click += new System.EventHandler(this.BtnVisualizarDiferenca_Click);
            // 
            // btnAplicarTodas
            // 
            this.btnAplicarTodas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnAplicarTodas.FlatAppearance.BorderSize = 0;
            this.btnAplicarTodas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicarTodas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAplicarTodas.ForeColor = System.Drawing.Color.White;
            this.btnAplicarTodas.Location = new System.Drawing.Point(152, 15);
            this.btnAplicarTodas.Name = "btnAplicarTodas";
            this.btnAplicarTodas.Size = new System.Drawing.Size(120, 30);
            this.btnAplicarTodas.TabIndex = 2;
            this.btnAplicarTodas.Text = "Aplicar a Todas";
            this.btnAplicarTodas.UseVisualStyleBackColor = false;
            this.btnAplicarTodas.Click += new System.EventHandler(this.BtnAplicarTodas_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(863, 15);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(12, 15);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(120, 30);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "Aplicar Ações";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // frmResolverDuplicatas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(1000, 560);
            this.Controls.Add(this.dgvDuplicatas);
            this.Controls.Add(this.pnlInferior);
            this.Controls.Add(this.pnlSuperior);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "frmResolverDuplicatas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Resolver Duplicatas";
            this.Load += new System.EventHandler(this.frmResolverDuplicatas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuplicatas)).EndInit();
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.pnlInferior.ResumeLayout(false);
            this.ResumeLayout(false);

        }       

        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvDuplicatas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoDuplicata;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiferencas;
        private System.Windows.Forms.DataGridViewComboBoxColumn colAcao;
        private System.Windows.Forms.Panel pnlInferior;
        private System.Windows.Forms.Button btnVisualizarDiferenca;
        private System.Windows.Forms.Button btnAplicarTodas;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnOK;
    }
}
