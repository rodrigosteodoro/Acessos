using System.Drawing;
using System.Windows.Forms;

namespace Acessos
{
    partial class frmPesquisaOrcamentos
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.dgvOrcamentos = new Telerik.WinControls.UI.RadGridView();
            this.btnSelecionar = new Telerik.WinControls.UI.RadButton();
            this.btnCancelar = new Telerik.WinControls.UI.RadButton();
            this.panelBotoes = new System.Windows.Forms.Panel();
            this.txtPesquisa = new Telerik.WinControls.UI.RadTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelFiltro = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrcamentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrcamentos.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelecionar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            this.panelBotoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPesquisa)).BeginInit();
            this.panelFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrcamentos
            // 
            this.dgvOrcamentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrcamentos.Location = new System.Drawing.Point(0, 36);
            // 
            // 
            // 
            this.dgvOrcamentos.MasterTemplate.AllowAddNewRow = false;
            this.dgvOrcamentos.MasterTemplate.AllowDeleteRow = false;
            this.dgvOrcamentos.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvOrcamentos.MasterTemplate.EnableGrouping = false;
            this.dgvOrcamentos.MasterTemplate.EnablePaging = true;
            this.dgvOrcamentos.MasterTemplate.ShowRowHeaderColumn = false;
            this.dgvOrcamentos.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgvOrcamentos.Name = "dgvOrcamentos";
            this.dgvOrcamentos.ReadOnly = true;
            this.dgvOrcamentos.Size = new System.Drawing.Size(1398, 594);
            this.dgvOrcamentos.TabIndex = 0;
            this.dgvOrcamentos.ThemeName = "Material";
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelecionar.BackColor = System.Drawing.Color.Teal;
            this.btnSelecionar.ForeColor = System.Drawing.Color.White;
            this.btnSelecionar.Location = new System.Drawing.Point(1131, 8);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(108, 36);
            this.btnSelecionar.TabIndex = 1;
            this.btnSelecionar.Text = "Selecionar";
            this.btnSelecionar.ThemeName = "Material";
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.Gray;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(1269, 8);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(108, 36);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.ThemeName = "Material";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panelBotoes
            // 
            this.panelBotoes.Controls.Add(this.btnCancelar);
            this.panelBotoes.Controls.Add(this.btnSelecionar);
            this.panelBotoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotoes.Location = new System.Drawing.Point(0, 630);
            this.panelBotoes.Name = "panelBotoes";
            this.panelBotoes.Size = new System.Drawing.Size(1398, 50);
            this.panelBotoes.TabIndex = 3;
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPesquisa.BackColor = System.Drawing.Color.OldLace;
            this.txtPesquisa.Location = new System.Drawing.Point(79, 7);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.NullText = "Digite para pesquisar...";
            this.txtPesquisa.Size = new System.Drawing.Size(1316, 24);
            this.txtPesquisa.TabIndex = 4;
            this.txtPesquisa.ThemeName = "Fluent";
            this.txtPesquisa.TextChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pesquisar";
            // 
            // panelFiltro
            // 
            this.panelFiltro.Controls.Add(this.label1);
            this.panelFiltro.Controls.Add(this.txtPesquisa);
            this.panelFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltro.Location = new System.Drawing.Point(0, 0);
            this.panelFiltro.Name = "panelFiltro";
            this.panelFiltro.Size = new System.Drawing.Size(1398, 36);
            this.panelFiltro.TabIndex = 6;
            // 
            // frmPesquisaOrcamentos
            // 
            this.AcceptButton = this.btnSelecionar;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(1398, 680);
            this.Controls.Add(this.dgvOrcamentos);
            this.Controls.Add(this.panelBotoes);
            this.Controls.Add(this.panelFiltro);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(516, 349);
            this.Name = "frmPesquisaOrcamentos";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar Orçamentos";
            this.ThemeName = "Material";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrcamentos.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrcamentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelecionar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            this.panelBotoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPesquisa)).EndInit();
            this.panelFiltro.ResumeLayout(false);
            this.panelFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView dgvOrcamentos;
        private Telerik.WinControls.UI.RadButton btnSelecionar;
        private Telerik.WinControls.UI.RadButton btnCancelar;
        private System.Windows.Forms.Panel panelBotoes;
        private Telerik.WinControls.UI.RadTextBox txtPesquisa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelFiltro;
    }
}
