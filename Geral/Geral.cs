using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Acessos.Usuarios;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Acessos
{
    public partial class Geral : Telerik.WinControls.UI.RadForm
    {
        private readonly string usuario = SessaoUsuario.UsuarioAtual.Nome;
        private readonly string cargo = SessaoUsuario.UsuarioAtual.Cargo;
        private readonly int nivelAcesso = SessaoUsuario.UsuarioAtual.NivelAcesso;
        private RelatorioMsg relatorioMsg;
        // Timer para atualizar automaticamente a cada 5 minutos
        private Timer timerAtualizacao;

        //
        AuditoriaAcesso auditoria;


        public Geral()
        {
            InitializeComponent();
            relatorioMsg = new RelatorioMsg(ConnectionManager.GetConnectionString("Admin"));                   
        }
      
        private void Geral_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = RadMessageBox.Show(
                "Deseja realmente sair?",
                "Sair",
                MessageBoxButtons.YesNo,
                RadMessageIcon.Question
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Cancela o fechamento
            }

        }

        private void btLogout_Click(object sender, EventArgs e)
        {
            // Auditoria de logout
            auditoria.InserirAuditoria(new AuditoriaAcesso
            {
                UsuarioID = SessaoUsuario.UsuarioAtual.UsuarioID,
                Acao = "Logout",
                DataHora = DateTime.Now,
                UsuarioAplicacao = SessaoUsuario.UsuarioAtual.Nome,
                Detalhes = "Usuário fez logout."
            });

            // Limpa sessão do usuário
            SessaoUsuario.UsuarioAtual = null;
            this.Hide();
            var loginForm = new Loginfrm();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
            else
            {
                Application.ExitThread();
            }

        }

        private async void Geral_Load(object sender, EventArgs e)
        {
            lbusuario.Text = "Usuário:  " + usuario;
            auditoria = new AuditoriaAcesso();
            auditoria.InserirAuditoria(new AuditoriaAcesso
            {
                UsuarioID = SessaoUsuario.UsuarioAtual.UsuarioID,
                Acao = "Menu principal",
                DataHora = DateTime.Now,
                UsuarioAplicacao = SessaoUsuario.UsuarioAtual.Nome,
                Detalhes = "observando ações."
            });
            // eventos de mouse para os botões
            bt1.MouseHover += MouseEnterHandler;
            bt1.MouseLeave += MouseLeaveHandler;
            bt2.MouseHover += MouseEnterHandler;
            bt2.MouseLeave += MouseLeaveHandler;
            bt3.MouseHover += MouseEnterHandler;
            bt3.MouseLeave += MouseLeaveHandler;
            bt4.MouseHover += MouseEnterHandler;
            bt4.MouseLeave += MouseLeaveHandler;
            btLogout.MouseHover += MouseEnterHandler;
            btLogout.MouseLeave += MouseLeaveHandler;
            btOrcamentos.MouseHover += MouseEnterHandler;
            btOrcamentos.MouseLeave += MouseLeaveHandler;
            btVendas.MouseHover += MouseEnterHandler;
            btVendas.MouseLeave += MouseLeaveHandler;
            //      
           
            await CarregarDashboardAsync();          
            IniciarAtualizacaoAutomatica(); // Opcional
        }
        private async Task CarregarDashboardAsync()
        {
            try
            {
                // Mostrar indicador de carregamento
                MostrarCarregando(true);

                // Obter dados do relatório
                var dadosRelatorio = await relatorioMsg.GetRelatorioCompletoAsync();

                // Atualizar apenas as labels com cores e efeitos
                AtualizarLabelsComCores(dadosRelatorio);

                // Ocultar indicador de carregamento
                MostrarCarregando(false);
            }
            catch (Exception ex)
            {
                MostrarCarregando(false);
                MessageBox.Show($"Erro ao carregar dashboard: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarLabelsComCores(RelatorioData dados)
        {
            // Produtos em Estoque
            if (ProdEstoq != null)
            {
                ProdEstoq.Text = $"📦 {dados.QuantidadeProdutosEstoque}";
                ProdEstoq.ForeColor = dados.QuantidadeProdutosEstoque == 0 ? System.Drawing.Color.Red :
                                     dados.QuantidadeProdutosEstoque < 10 ? System.Drawing.Color.Orange :
                                     System.Drawing.Color.Green;

                // Efeito de borda baseado no status
                if (dados.QuantidadeProdutosEstoque == 0)
                {
                    IniciarEfeitoPulsante(ProdEstoq, System.Drawing.Color.Red);
                }
            }

            // Fornecedores
            if (QuantForn != null)
            {
                QuantForn.Text = $"🏢 {dados.QuantidadeFornecedores}";
                QuantForn.ForeColor = dados.QuantidadeFornecedores == 0 ? System.Drawing.Color.Red :
                                     System.Drawing.Color.DarkBlue;
            }

            // Total de Vendas Hoje
            if (TotalVendasHj != null)
            {
                TotalVendasHj.Text = $"💰 {dados.TotalVendasHoje:C}";
                TotalVendasHj.ForeColor = dados.TotalVendasHoje == 0 ? System.Drawing.Color.Red :
                                         dados.TotalVendasHoje > 1000 ? System.Drawing.Color.Green :
                                         dados.TotalVendasHoje > 500 ? System.Drawing.Color.Orange :
                                         System.Drawing.Color.DarkBlue;

                // Efeito especial para vendas altas
                if (dados.TotalVendasHoje > 1000)
                {
                    IniciarEfeitoBrilho(TotalVendasHj, System.Drawing.Color.Gold);
                }
            }

            // Valor Total do Estoque
            if (ValorEstq != null)
            {
                ValorEstq.Text = $"💎 {dados.ValorTotalEstoque:C}";
                ValorEstq.ForeColor = dados.ValorTotalEstoque == 0 ? System.Drawing.Color.Red :
                                     dados.ValorTotalEstoque > 50000 ? System.Drawing.Color.Green :
                                     dados.ValorTotalEstoque > 20000 ? System.Drawing.Color.Orange :
                                     System.Drawing.Color.DarkBlue;
            }

            // Orçamentos em Espera
            if (OrcEspera != null)
            {
                OrcEspera.Text = $"⏳ {dados.OrcamentosEmEspera}";
                OrcEspera.ForeColor = dados.OrcamentosEmEspera > 20 ? System.Drawing.Color.Red :
                                     dados.OrcamentosEmEspera > 10 ? System.Drawing.Color.Orange :
                                     System.Drawing.Color.Blue;

                // Piscar se muitos orçamentos em espera
                if (dados.OrcamentosEmEspera > 20)
                {
                    IniciarPiscaLabel(OrcEspera, System.Drawing.Color.Red, System.Drawing.Color.White);
                }
            }

            // Orçamentos Aprovados
            if (OrcYes != null)
            {
                OrcYes.Text = $"✅ {dados.OrcamentosAprovados}";
                OrcYes.ForeColor = dados.OrcamentosAprovados == 0 ? System.Drawing.Color.Gray :
                                  System.Drawing.Color.Green;
            }

            // Orçamentos Rejeitados
            if (OrcNo != null)
            {
                OrcNo.Text = $"❌ {dados.OrcamentosNaoAprovados}";
                OrcNo.ForeColor = dados.OrcamentosNaoAprovados == 0 ? System.Drawing.Color.Gray :
                                 dados.OrcamentosNaoAprovados > 10 ? System.Drawing.Color.Red :
                                 System.Drawing.Color.Orange;
            }

            // Itens Vencendo - CRÍTICO
            if (ItensVencendo != null)
            {
                ItensVencendo.Text = $"⚠️ Vencendo (7 dias): {dados.ItensVencendoEstaSemana}";
                ItensVencendo.ForeColor = dados.ItensVencendoEstaSemana > 0 ? System.Drawing.Color.Red :
                                         System.Drawing.Color.Green;

                // Piscar URGENTE se houver itens vencendo
                if (dados.ItensVencendoEstaSemana > 0)
                {
                    IniciarPiscaUrgente(ItensVencendo);
                }
            }

            // Itens em Promoção
            if (ItensPromo != null)
            {
                ItensPromo.Text = $"🎉 {dados.ItensEmPromocao}";
                ItensPromo.ForeColor = dados.ItensEmPromocao == 0 ? System.Drawing.Color.Gray :
                                      System.Drawing.Color.Purple;

                // Efeito especial para promoções
                if (dados.ItensEmPromocao > 0)
                {
                    IniciarEfeitoPromocao(ItensPromo);
                }
            }

            // Total de Gastos (placeholder)
            if (TotalGast != null)
            {
                TotalGast.Text = "🏦 Não implementado";
                TotalGast.ForeColor = System.Drawing.Color.Gray;
            }
        }

        // Efeito de piscar padrão
        private void IniciarPiscaLabel(Bunifu.UI.WinForms.BunifuLabel label, System.Drawing.Color cor1, System.Drawing.Color cor2)
        {
            var timer = new Timer();
            timer.Interval = 500;

            bool alternar = true;
            int contador = 0;

            timer.Tick += (s, e) =>
            {
                label.ForeColor = alternar ? cor1 : cor2;
                alternar = !alternar;
                contador++;

                if (contador >= 20) // Para após 10 segundos
                {
                    timer.Stop();
                    timer.Dispose();
                    label.ForeColor = cor1;
                }
            };

            timer.Start();
        }

        // Efeito de piscar URGENTE (mais rápido)
        private void IniciarPiscaUrgente(Bunifu.UI.WinForms.BunifuLabel label)
        {
            var timer = new Timer();
            timer.Interval = 250; // Mais rápido

            bool alternar = true;
            var cores = new[] { System.Drawing.Color.Red, System.Drawing.Color.Yellow, System.Drawing.Color.White };
            int corIndex = 0;
            int contador = 0;

            timer.Tick += (s, e) =>
            {
                label.ForeColor = cores[corIndex];
                corIndex = (corIndex + 1) % cores.Length;
                contador++;

                if (contador >= 40) // Para após 10 segundos
                {
                    timer.Stop();
                    timer.Dispose();
                    label.ForeColor = System.Drawing.Color.Red;
                }
            };

            timer.Start();
        }

        // Efeito pulsante para valores críticos
        private void IniciarEfeitoPulsante(Bunifu.UI.WinForms.BunifuLabel label, System.Drawing.Color cor)
        {
            var timer = new Timer();
            timer.Interval = 100;

            var fonteOriginal = label.Font;
            var fonteGrande = new System.Drawing.Font(fonteOriginal.FontFamily, fonteOriginal.Size + 2, System.Drawing.FontStyle.Bold);

            bool expandir = true;
            int contador = 0;

            timer.Tick += (s, e) =>
            {
                label.Font = expandir ? fonteGrande : fonteOriginal;
                expandir = !expandir;
                contador++;

                if (contador >= 30) // Para após 3 segundos
                {
                    timer.Stop();
                    timer.Dispose();
                    label.Font = fonteOriginal;
                }
            };

            timer.Start();
        }

        // Efeito de brilho para valores positivos
        private void IniciarEfeitoBrilho(Bunifu.UI.WinForms.BunifuLabel label, System.Drawing.Color cor)
        {
            var timer = new Timer();
            timer.Interval = 200;

            var coresBrilho = new[] {
        System.Drawing.Color.Gold,
        System.Drawing.Color.Yellow,
        System.Drawing.Color.Orange,
        System.Drawing.Color.Green
    };

            int corIndex = 0;
            int contador = 0;

            timer.Tick += (s, e) =>
            {
                label.ForeColor = coresBrilho[corIndex];
                corIndex = (corIndex + 1) % coresBrilho.Length;
                contador++;

                if (contador >= 15) // Para após 3 segundos
                {
                    timer.Stop();
                    timer.Dispose();
                    label.ForeColor = System.Drawing.Color.Green;
                }
            };

            timer.Start();
        }

        // Efeito especial para promoções
        private void IniciarEfeitoPromocao(Bunifu.UI.WinForms.BunifuLabel label)
        {
            var timer = new Timer();
            timer.Interval = 300;

            var coresPromo = new[] {
        System.Drawing.Color.Purple,
        System.Drawing.Color.Magenta,
        System.Drawing.Color.Blue,
        System.Drawing.Color.DarkViolet
    };

            int corIndex = 0;
            int contador = 0;

            timer.Tick += (s, e) =>
            {
                label.ForeColor = coresPromo[corIndex];
                corIndex = (corIndex + 1) % coresPromo.Length;
                contador++;

                if (contador >= 12) // Para após 3.6 segundos
                {
                    timer.Stop();
                    timer.Dispose();
                    label.ForeColor = System.Drawing.Color.Purple;
                }
            };

            timer.Start();
        }

        // Indicador de carregamento simples
        private void MostrarCarregando(bool mostrar)
        {
            if (mostrar)
            {
                // Você pode usar uma label específica para mostrar "Carregando..."
                if (lblStatus != null)
                {
                    lblStatus.Text = "⏳ Carregando dados...";
                    lblStatus.ForeColor = System.Drawing.Color.Blue;
                    lblStatus.Visible = true;
                }
            }
            else
            {
                if (lblStatus != null)
                {
                    lblStatus.Visible = false;
                }
            }
        }

        // Método para parar todos os timers ativos
        private readonly List<Timer> timersAtivos = new List<Timer>();

        private void PararTodosEfeitos()
        {
            foreach (var timer in timersAtivos.ToList())
            {
                timer?.Stop();
                timer?.Dispose();
            }
            timersAtivos.Clear();
        }

        // Limpar recursos quando necessário
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            PararTodosEfeitos();
            timerAtualizacao?.Stop();
            timerAtualizacao?.Dispose();
            base.OnFormClosed(e);
        }


        private void IniciarAtualizacaoAutomatica()
        {
            timerAtualizacao = new Timer();
            timerAtualizacao.Interval = 300000; // 5 minutos
            timerAtualizacao.Tick += async (s, e) => await CarregarDashboardAsync();
            timerAtualizacao.Start();
        }

        // Método alternativo para exibir em formato de lista detalhada
      

        // Métodos auxiliares para determinar status
        private string GetStatusEstoque(int quantidade)
        {
            if (quantidade == 0) return "Crítico";
            if (quantidade < 10) return "Atenção";
            return "Normal";
        }

        private string GetStatusVendas(decimal valor)
        {
            if (valor == 0) return "Sem vendas";
            if (valor > 1000) return "Excelente";
            if (valor > 500) return "Bom";
            return "Normal";
        }

        private string GetStatusOrcamentos(int quantidade)
        {
            if (quantidade > 20) return "Atenção";
            if (quantidade > 10) return "Moderado";
            return "Normal";
        }

        private string GetStatusVencimento(int quantidade)
        {
            if (quantidade > 0) return "Crítico";
            return "Normal";
        }

        // Limpar recursos quando o form for fechado
        private void frmDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            timerAtualizacao?.Stop();
            timerAtualizacao?.Dispose();
        }
    
        internal bool VerificarPermissao(Cargo cargo, int nivelAcesso, Acao acao)
        {
            switch (cargo)
            {
                case Cargo.Admin:
                    return nivelAcesso >= 5; // Admin tem todas as permissões

                case Cargo.Gerente:
                    // Gerente pode tudo, exceto excluir usuários (ajuste conforme sua regra)
                    if (nivelAcesso == 4)
                        return acao != Acao.Excluir;
                    break;

                case Cargo.Supervisor:
                    // Supervisor pode visualizar e editar
                    if (nivelAcesso == 3)
                        return acao == Acao.Visualizar || acao == Acao.Editar;
                    break;

                case Cargo.Encarregado:
                    // Encarregado pode visualizar
                    if (nivelAcesso == 2)
                        return acao == Acao.Visualizar;
                    break;

                case Cargo.Comum:
                    // Comum pode tudo menos excluir
                    return acao != Acao.Excluir;
            }
            return false; // Não permitido por padrão
        }

        private void btUsuarios_Click(object sender, EventArgs e) => FormManager.ShowForm<Usuariosfrm>();
       
        private void btFornecedores_Click(object sender, EventArgs e) => FormManager.ShowForm<frmFornecedores>();
        
        private void btProdutos_Click(object sender, EventArgs e) => FormManager.ShowForm<frmProdutos>();    
        
        private void btClientes_Click(object sender, EventArgs e) => FormManager.ShowForm<frmClientes>();

        private void btOrcamentos_Click(object sender, EventArgs e) => FormManager.ShowForm<frmOrcamentos>();

        private void btAprovarOrcamentos_Click(object sender, EventArgs e) => FormManager.ShowForm<frmAprovacoesOrcamentos>();

        private void MouseLeaveHandler(object sender, EventArgs e)
        {
            lbMsg.Visible = false;
            lbMsg2.Visible = false;
        }

        private void MouseEnterHandler(object sender, EventArgs e)
        {
            lbMsg.Visible = false;
            lbMsg2.Visible = false;

            if (sender == bt1)
            {
                lbMsg.Text = "módulo de Usuários.";
                lbMsg.Visible = true;
            }
            else if (sender == bt2)
            {
                lbMsg.Text = "módulo de Fornecedores.";
                lbMsg.Visible = true;
            }
            else if (sender == bt3)
            {
                lbMsg.Text = "módulo de Produtos.";
                lbMsg.Visible = true;
            }
            else if (sender == bt4)
            {
                lbMsg.Text = "módulo de Clientes.";
                lbMsg.Visible = true;
            }
            else if (sender == btOrcamentos)
            {
                lbMsg2.Text = "módulo de Orçamentos.";
                lbMsg2.Visible = true;
            }
            else if (sender == btAprovarOrcamentos)
            {
                lbMsg2.Text = "módulo de Aprovações de Orçamentos.";
                lbMsg2.Visible = true;
            }
            else if (sender == btLogout)
            {
                lbMsg2.Text = "Sair do sistema.";
                lbMsg2.Visible = true;
            }
            else if (sender == btVendas)
            {
                lbMsg2.Text = "módulo de Vendas.";
                lbMsg2.Visible = true;
            }
        }

        private void btVendas_Click(object sender, EventArgs e)
        {
            RadMessageBox.Show(
                "Módulo de Vendas ainda não implementado.",
                "Atenção",
                MessageBoxButtons.OK,
                RadMessageIcon.Info
            );
        }

       

    }
}
