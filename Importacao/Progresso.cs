using System;
using System.Drawing;
using System.Windows.Forms;

namespace Acessos
{ 
    public partial class Progresso : Form
    {
        private int _valorMaximo;
        private Telerik.WinControls.UI.RadFormConverter radFormConverter1;
        private int _valorAtual;

        public Progresso(string titulo, int maximo)
        {
            InitializeComponent();
            this.Text = titulo;
            _valorMaximo = maximo;
            progressBar.Maximum = maximo;
            lblStatus.Text = titulo;
        }

        public void AtualizarProgresso(int valor)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int>(AtualizarProgresso), valor);
                return;
            }

            _valorAtual = valor;
            progressBar.Value = Math.Min(valor, _valorMaximo);
            lblProgresso.Text = $"{valor} de {_valorMaximo}";

            var percentual = (double)valor / _valorMaximo * 100;
            lblPercentual.Text = $"{percentual:F1}%";

            Application.DoEvents();
        }

        private void InitializeComponent()
        {
            progressBar = new ProgressBar();
            lblStatus = new Label();
            lblProgresso = new Label();
            lblPercentual = new Label();
            radFormConverter1 = new Telerik.WinControls.UI.RadFormConverter();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(20, 50);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(360, 25);
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(20, 20);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(360, 20);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Processando...";
            // 
            // lblProgresso
            // 
            lblProgresso.Location = new Point(20, 85);
            lblProgresso.Name = "lblProgresso";
            lblProgresso.Size = new Size(180, 20);
            lblProgresso.TabIndex = 2;
            lblProgresso.Text = "0 de 0";
            // 
            // lblPercentual
            // 
            lblPercentual.Location = new Point(200, 85);
            lblPercentual.Name = "lblPercentual";
            lblPercentual.Size = new Size(180, 20);
            lblPercentual.TabIndex = 3;
            lblPercentual.Text = "0%";
            lblPercentual.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Progresso
            // 
            ClientSize = new Size(400, 120);
            Controls.Add(progressBar);
            Controls.Add(lblStatus);
            Controls.Add(lblProgresso);
            Controls.Add(lblPercentual);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Progresso";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Progresso";
            ResumeLayout(false);
        }

        private ProgressBar progressBar;
        private Label lblStatus;
        private Label lblProgresso;
        private Label lblPercentual;
    }
}
