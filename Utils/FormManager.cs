using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

public static class FormManager
{
    // Dicionário para armazenar instâncias dos formulários abertos
    private static readonly Dictionary<Type, Form> _openedForms = new Dictionary<Type, Form>();

    /// <summary>
    /// Abre um formulário do tipo T. Se já estiver aberto, traz para frente.
    /// </summary>
    public static void ShowForm<T>() where T : Form, new()
    {
        Type formType = typeof(T);

        // Verifica se o formulário já está aberto e não foi fechado/disposto
        if (_openedForms.ContainsKey(formType))
        {
            var form = _openedForms[formType];
            if (form == null || form.IsDisposed)
            {
                // Remove referência se estiver disposed
                _openedForms.Remove(formType);
            }
            else
            {
                // Traz para frente se já estiver aberto
                form.WindowState = FormWindowState.Normal;
                form.BringToFront();
                form.Focus();
                return;
            }
        }

        // Cria nova instância, registra e mostra
        var newForm = new T();
        _openedForms[formType] = newForm;

        // Remove do dicionário ao fechar
        newForm.FormClosed += (s, e) => _openedForms.Remove(formType);

        newForm.Show();
        newForm.BringToFront();
    }
    public static void ShowForm<T>(params object[] args) where T : Form
    {
        Type formType = typeof(T);

        if (_openedForms.ContainsKey(formType))
        {
            var form = _openedForms[formType];
            if (form == null || form.IsDisposed)
                _openedForms.Remove(formType);
            else
            {
                form.WindowState = FormWindowState.Normal;
                form.BringToFront();
                form.Focus();
                return;
            }
        }

        // Usa Activator para passar os parâmetros ao construtor
        var newForm = (Form)Activator.CreateInstance(formType, args);
        _openedForms[formType] = newForm;
        newForm.FormClosed += (s, e) => _openedForms.Remove(formType);
        newForm.Show();
        newForm.BringToFront();
    }

    // Armazena a instância do formulário atualmente exibido no painel
    private static Form _formAtual = null;

    public static void AlternarFormNoPainel<T>(Panel painel) where T : Form, new()
    {
        // Se já existe e é do mesmo tipo, fecha
        if (_formAtual != null && _formAtual is T && painel.Controls.Contains(_formAtual))
        {
            painel.Controls.Remove(_formAtual);
            _formAtual.Dispose();
            _formAtual = null;
            return;
        }

        // Fecha qualquer form anterior
        if (_formAtual != null)
        {
            painel.Controls.Remove(_formAtual);
            _formAtual.Dispose();
        }

        // Cria e exibe o novo form
        _formAtual = new T();
        _formAtual.TopLevel = false;
        _formAtual.FormBorderStyle = FormBorderStyle.None;
        _formAtual.Dock = DockStyle.Fill;
        painel.Controls.Add(_formAtual);
        _formAtual.Show();
    }

}
//private void btnAbrirCadastroUsuario_Click(object sender, EventArgs e)
//{
//    FormManager.ShowForm<FormCadastroUsuario>();
//}

//private void btnAbrirFecharForm2_Click(object sender, EventArgs e)
//{
//    FormManager.AlternarFormNoPainel<Form2>(panelConteudo);
//}