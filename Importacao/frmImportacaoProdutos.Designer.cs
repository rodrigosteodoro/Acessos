using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI.Design;

namespace Acessos
{
    partial class frmImportacaoProdutos
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
            this.btnGerarTemplate = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.chkCabecalho = new System.Windows.Forms.CheckBox();
            this.btnSelecionarArquivo = new System.Windows.Forms.Button();
            this.txtArquivo = new System.Windows.Forms.TextBox();
            this.lblArquivo = new System.Windows.Forms.Label();
            this.btnExportarErros = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabProdutos = new System.Windows.Forms.TabPage();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.tabErros = new System.Windows.Forms.TabPage();
            this.lstErros = new System.Windows.Forms.ListBox();
            this.tabResumo = new System.Windows.Forms.TabPage();
            this.rtbResumo = new System.Windows.Forms.RichTextBox();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.btResolverDuplicatas = new System.Windows.Forms.Button();
            this.lblProgresso = new Telerik.WinControls.UI.RadLabel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.radFormConverter1 = new Telerik.WinControls.UI.RadFormConverter();
            this.materialTheme1 = new Telerik.WinControls.Themes.MaterialTheme();
            this.pnlSuperior.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabProdutos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.tabErros.SuspendLayout();
            this.tabResumo.SuspendLayout();
            this.pnlInferior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblProgresso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlSuperior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSuperior.Controls.Add(this.btnGerarTemplate);
            this.pnlSuperior.Controls.Add(this.btnLimpar);
            this.pnlSuperior.Controls.Add(this.btnImportar);
            this.pnlSuperior.Controls.Add(this.chkCabecalho);
            this.pnlSuperior.Controls.Add(this.btnSelecionarArquivo);
            this.pnlSuperior.Controls.Add(this.txtArquivo);
            this.pnlSuperior.Controls.Add(this.lblArquivo);
            this.pnlSuperior.Controls.Add(this.btnExportarErros);
            this.pnlSuperior.Controls.Add(this.btnSalvar);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1199, 87);
            this.pnlSuperior.TabIndex = 0;
            // 
            // btnGerarTemplate
            // 
            this.btnGerarTemplate.BackColor = System.Drawing.Color.Firebrick;
            this.btnGerarTemplate.FlatAppearance.BorderSize = 0;
            this.btnGerarTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerarTemplate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGerarTemplate.ForeColor = System.Drawing.Color.White;
            this.btnGerarTemplate.Location = new System.Drawing.Point(735, 14);
            this.btnGerarTemplate.Name = "btnGerarTemplate";
            this.btnGerarTemplate.Size = new System.Drawing.Size(86, 22);
            this.btnGerarTemplate.TabIndex = 6;
            this.btnGerarTemplate.Text = "Gerar View";
            this.btnGerarTemplate.UseVisualStyleBackColor = false;
            this.btnGerarTemplate.Click += new System.EventHandler(this.btnGerarTemplate_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnLimpar.FlatAppearance.BorderSize = 0;
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpar.ForeColor = System.Drawing.Color.White;
            this.btnLimpar.Location = new System.Drawing.Point(944, 14);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(111, 22);
            this.btnLimpar.TabIndex = 5;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.BtnLimpar_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnImportar.FlatAppearance.BorderSize = 0;
            this.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnImportar.ForeColor = System.Drawing.Color.White;
            this.btnImportar.Location = new System.Drawing.Point(529, 13);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(86, 22);
            this.btnImportar.TabIndex = 4;
            this.btnImportar.Text = "Importar";
            this.btnImportar.UseVisualStyleBackColor = false;
            this.btnImportar.Click += new System.EventHandler(this.BtnImportar_Click);
            // 
            // chkCabecalho
            // 
            this.chkCabecalho.AutoSize = true;
            this.chkCabecalho.Checked = true;
            this.chkCabecalho.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCabecalho.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkCabecalho.Location = new System.Drawing.Point(69, 43);
            this.chkCabecalho.Name = "chkCabecalho";
            this.chkCabecalho.Size = new System.Drawing.Size(162, 19);
            this.chkCabecalho.TabIndex = 3;
            this.chkCabecalho.Text = "Arquivo possui cabeçalho";
            this.chkCabecalho.UseVisualStyleBackColor = true;
            // 
            // btnSelecionarArquivo
            // 
            this.btnSelecionarArquivo.BackColor = System.Drawing.Color.Teal;
            this.btnSelecionarArquivo.FlatAppearance.BorderSize = 0;
            this.btnSelecionarArquivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecionarArquivo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSelecionarArquivo.ForeColor = System.Drawing.Color.White;
            this.btnSelecionarArquivo.Location = new System.Drawing.Point(437, 13);
            this.btnSelecionarArquivo.Name = "btnSelecionarArquivo";
            this.btnSelecionarArquivo.Size = new System.Drawing.Size(86, 22);
            this.btnSelecionarArquivo.TabIndex = 2;
            this.btnSelecionarArquivo.Text = "Selecionar";
            this.btnSelecionarArquivo.UseVisualStyleBackColor = false;
            this.btnSelecionarArquivo.Click += new System.EventHandler(this.BtnSelecionarArquivo_Click);
            // 
            // txtArquivo
            // 
            this.txtArquivo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtArquivo.Location = new System.Drawing.Point(69, 13);
            this.txtArquivo.Name = "txtArquivo";
            this.txtArquivo.ReadOnly = true;
            this.txtArquivo.Size = new System.Drawing.Size(361, 23);
            this.txtArquivo.TabIndex = 1;
            // 
            // lblArquivo
            // 
            this.lblArquivo.AutoSize = true;
            this.lblArquivo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblArquivo.Location = new System.Drawing.Point(10, 16);
            this.lblArquivo.Name = "lblArquivo";
            this.lblArquivo.Size = new System.Drawing.Size(54, 15);
            this.lblArquivo.TabIndex = 0;
            this.lblArquivo.Text = "Arquivo:";
            // 
            // btnExportarErros
            // 
            this.btnExportarErros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnExportarErros.Enabled = false;
            this.btnExportarErros.FlatAppearance.BorderSize = 0;
            this.btnExportarErros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarErros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportarErros.ForeColor = System.Drawing.Color.Black;
            this.btnExportarErros.Location = new System.Drawing.Point(827, 13);
            this.btnExportarErros.Name = "btnExportarErros";
            this.btnExportarErros.Size = new System.Drawing.Size(111, 23);
            this.btnExportarErros.TabIndex = 1;
            this.btnExportarErros.Text = "Exportar Erros";
            this.btnExportarErros.UseVisualStyleBackColor = false;
            this.btnExportarErros.Click += new System.EventHandler(this.BtnExportarErros_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnSalvar.Enabled = false;
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(621, 14);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(108, 22);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Salvar Produtos";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabProdutos);
            this.tabControl.Controls.Add(this.tabErros);
            this.tabControl.Controls.Add(this.tabResumo);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabControl.Location = new System.Drawing.Point(0, 87);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1199, 445);
            this.tabControl.TabIndex = 1;
            // 
            // tabProdutos
            // 
            this.tabProdutos.Controls.Add(this.dgvProdutos);
            this.tabProdutos.Location = new System.Drawing.Point(4, 24);
            this.tabProdutos.Name = "tabProdutos";
            this.tabProdutos.Padding = new System.Windows.Forms.Padding(3);
            this.tabProdutos.Size = new System.Drawing.Size(1191, 417);
            this.tabProdutos.TabIndex = 0;
            this.tabProdutos.Text = "Produtos Importados";
            this.tabProdutos.UseVisualStyleBackColor = true;
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.AllowUserToDeleteRows = false;
            this.dgvProdutos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvProdutos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProdutos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProdutos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvProdutos.Location = new System.Drawing.Point(3, 3);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.RowHeadersWidth = 25;
            this.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutos.Size = new System.Drawing.Size(1185, 411);
            this.dgvProdutos.TabIndex = 0;
            // 
            // tabErros
            // 
            this.tabErros.Controls.Add(this.lstErros);
            this.tabErros.Location = new System.Drawing.Point(4, 24);
            this.tabErros.Name = "tabErros";
            this.tabErros.Padding = new System.Windows.Forms.Padding(3);
            this.tabErros.Size = new System.Drawing.Size(1191, 417);
            this.tabErros.TabIndex = 1;
            this.tabErros.Text = "Erros";
            this.tabErros.UseVisualStyleBackColor = true;
            // 
            // lstErros
            // 
            this.lstErros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstErros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstErros.Font = new System.Drawing.Font("Consolas", 9F);
            this.lstErros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lstErros.FormattingEnabled = true;
            this.lstErros.ItemHeight = 14;
            this.lstErros.Location = new System.Drawing.Point(3, 3);
            this.lstErros.Name = "lstErros";
            this.lstErros.Size = new System.Drawing.Size(1185, 411);
            this.lstErros.TabIndex = 0;
            // 
            // tabResumo
            // 
            this.tabResumo.Controls.Add(this.rtbResumo);
            this.tabResumo.Location = new System.Drawing.Point(4, 24);
            this.tabResumo.Name = "tabResumo";
            this.tabResumo.Padding = new System.Windows.Forms.Padding(3);
            this.tabResumo.Size = new System.Drawing.Size(1191, 417);
            this.tabResumo.TabIndex = 2;
            this.tabResumo.Text = "Resumo";
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
            this.rtbResumo.Size = new System.Drawing.Size(1185, 411);
            this.rtbResumo.TabIndex = 0;
            this.rtbResumo.Text = "";
            // 
            // pnlInferior
            // 
            this.pnlInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlInferior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInferior.Controls.Add(this.btResolverDuplicatas);
            this.pnlInferior.Controls.Add(this.lblProgresso);
            this.pnlInferior.Controls.Add(this.lblStatus);
            this.pnlInferior.Controls.Add(this.progressBar);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(0, 532);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(1199, 70);
            this.pnlInferior.TabIndex = 2;
            // 
            // btResolverDuplicatas
            // 
            this.btResolverDuplicatas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btResolverDuplicatas.FlatAppearance.BorderSize = 0;
            this.btResolverDuplicatas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btResolverDuplicatas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btResolverDuplicatas.ForeColor = System.Drawing.Color.White;
            this.btResolverDuplicatas.Location = new System.Drawing.Point(956, 5);
            this.btResolverDuplicatas.Name = "btResolverDuplicatas";
            this.btResolverDuplicatas.Size = new System.Drawing.Size(230, 24);
            this.btResolverDuplicatas.TabIndex = 6;
            this.btResolverDuplicatas.Text = "Remover Duplicatas";
            this.btResolverDuplicatas.UseVisualStyleBackColor = false;
            this.btResolverDuplicatas.Click += new System.EventHandler(this.btResolverDuplicatas_Click);
            // 
            // lblProgresso
            // 
            this.lblProgresso.Location = new System.Drawing.Point(8, 39);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(56, 18);
            this.lblProgresso.TabIndex = 4;
            this.lblProgresso.Text = "progresso";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblStatus.Location = new System.Drawing.Point(419, 42);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(43, 15);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Pronto";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(70, 40);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(343, 17);
            this.progressBar.TabIndex = 2;
            this.progressBar.Visible = false;
            // 
            // frmImportacaoProdutos
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1199, 602);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlInferior);
            this.Controls.Add(this.pnlSuperior);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(688, 522);
            this.Name = "frmImportacaoProdutos";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importação de Produtos - CSV/Excel";
            this.ThemeName = "Material";
            this.Load += new System.EventHandler(this.FormImportacaoProdutos_Load);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabProdutos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.tabErros.ResumeLayout(false);
            this.tabResumo.ResumeLayout(false);
            this.pnlInferior.ResumeLayout(false);
            this.pnlInferior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblProgresso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblArquivo;
        private System.Windows.Forms.TextBox txtArquivo;
        private System.Windows.Forms.Button btnSelecionarArquivo;
        private System.Windows.Forms.CheckBox chkCabecalho;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabProdutos;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.TabPage tabErros;
        private System.Windows.Forms.ListBox lstErros;
        private System.Windows.Forms.TabPage tabResumo;
        private System.Windows.Forms.RichTextBox rtbResumo;
        private System.Windows.Forms.Panel pnlInferior;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnExportarErros;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnGerarTemplate;
        private Telerik.WinControls.UI.RadFormConverter radFormConverter1;
        private Telerik.WinControls.Themes.MaterialTheme materialTheme1;
        private Telerik.WinControls.UI.RadLabel lblProgresso;
        private Button btResolverDuplicatas;
    }
}
