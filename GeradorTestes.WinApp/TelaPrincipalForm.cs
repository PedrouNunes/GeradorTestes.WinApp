using GeradorDeTestes.Infra.BancoDeDados.ModuloDisciplina;
using GeradorDeTestes.Infra.BancoDeDados.ModuloMateria;
using GeradorTestes.Infra.Arquivos.Compartilhado;
using GeradorTestes.Infra.Arquivos.ModuloDisciplina;
using GeradorTestes.Infra.Arquivos.ModuloMateria;
using GeradorTestes.Infra.Arquivos.ModuloQuestao;
using GeradorTestes.Infra.Arquivos.ModuloTeste;
using GeradorTestes.WinApp.Compartilhado;
using GeradorTestes.WinApp.ModuloDisciplina;
using GeradorTestes.WinApp.ModuloMateria;
using GeradorTestes.WinApp.ModuloQuestao;
using GeradorTestes.WinApp.ModuloTeste;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorTestes.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase controlador;
        private Dictionary<string, ControladorBase> controladores;
        private DataContext contextoDados;

        public TelaPrincipalForm(DataContext contextoDados)
        {
            InitializeComponent();

            Instancia = this;

            labelRodape.Text = string.Empty;
            labelTipoCadastro.Text = string.Empty;
            
            this.contextoDados = contextoDados;

            InicializarControladores();
        }

        public static TelaPrincipalForm Instancia
        {
            get;
            private set;
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }


        private void disciplinasMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void questõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void testesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (controlador == null)
            {
                MessageBox.Show("Selecione uma tela de cadastro primeiro",
                "Menu Principal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (controlador == null)
            {
                MessageBox.Show("Selecione uma tela de cadastro primeiro",
                "Menu Principal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (controlador == null)
            {
                MessageBox.Show("Selecione uma tela de cadastro primeiro",
                "Menu Principal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            controlador.Excluir();
        }

        private void ConfigurarBotoes(ConfiguracaoToolBoxBase configuracao)
        {
            btnInserir.Enabled = configuracao.InserirHabilitado;
            btnEditar.Enabled = configuracao.EditarHabilitado;
            btnExcluir.Enabled = configuracao.ExcluirHabilitado;
           
        }

        private void ConfigurarTooltips(ConfiguracaoToolBoxBase configuracao)
        {
            btnInserir.ToolTipText = configuracao.TooltipInserir;
            btnEditar.ToolTipText = configuracao.TooltipEditar;
            btnExcluir.ToolTipText = configuracao.TooltipExcluir;
          
        }

        private void ConfigurarTelaPrincipal(ToolStripMenuItem opcaoSelecionada)
        {
            var tipo = opcaoSelecionada.Text;

            controlador = controladores[tipo];

            ConfigurarToolbox();

            ConfigurarListagem();
        }

        private void ConfigurarToolbox()
        {
            ConfiguracaoToolBoxBase configuracao = controlador.ObtemConfiguracaoToolbox();

            if (configuracao != null)
            {
                toolbox.Enabled = true;

                labelTipoCadastro.Text = configuracao.TipoCadastro;

                ConfigurarTooltips(configuracao);

                ConfigurarBotoes(configuracao);
            }
        }

        private void ConfigurarListagem()
        {
            AtualizarRodape("");

            var listagemControl = controlador.ObtemListagem();

            panelRegistros.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            panelRegistros.Controls.Add(listagemControl);
        }

        private void InicializarControladores()
        {
            var repositorioDisciplina = new RepositorioDisciplinaEmBancoDeDados();
            var repositorioMateria = new RepositorioMateriaEmBancoDeDados();

            var repositorioQuestao = new RepositorioQuestaoEmArquivo(contextoDados);
            var repositorioTeste = new RepositorioTesteEmArquivo(contextoDados);

            controladores = new Dictionary<string, ControladorBase>();

            controladores.Add("Disciplinas", new ControladorDisciplina(repositorioDisciplina));
            controladores.Add("Materias", new ControladorMateria(repositorioMateria, repositorioDisciplina));
            controladores.Add("Questões", new ControladorQuestao(repositorioQuestao, repositorioMateria, repositorioDisciplina));
            controladores.Add("Testes", new ControladorTeste(repositorioTeste, repositorioDisciplina, repositorioMateria, repositorioQuestao));
        }

        private void btnGerarPdf_Click(object sender, EventArgs e)
        {
            controlador.GerarPdf();
        }

        private void btnDuplicar_Click(object sender, EventArgs e)
        {
            controlador.Duplicar();
        }
    }
}
