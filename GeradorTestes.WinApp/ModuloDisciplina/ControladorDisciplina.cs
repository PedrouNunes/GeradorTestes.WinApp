using GeradorTestes.Dominio.ModuloDisciplina;
using GeradorTestes.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorTestes.WinApp.ModuloDisciplina
{
    public class ControladorDisciplina : ControladorBase
    {
        private readonly IRepositorioDisciplina repositorioDisciplina;
        private TabelaDisciplinasControl tabelaDisciplinas;

        public ControladorDisciplina(IRepositorioDisciplina repositorio)
        {
            repositorioDisciplina = repositorio;
        }

        public override void Inserir()
        {
            TelaCadastroDisciplinaForm tela = new TelaCadastroDisciplinaForm();
            tela.Disciplina = new Disciplina();

            tela.GravarRegistro = repositorioDisciplina.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarDisciplinas();
            }
        }

     

        public override void Editar()
        {
            Disciplina disciplinaSelecionada = ObtemDisciplinaSelecionada();

            if (disciplinaSelecionada == null)
            {
                MessageBox.Show("Selecione uma disciplina primeiro",
                "Edição de Disciplinas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroDisciplinaForm tela = new TelaCadastroDisciplinaForm();

            tela.Disciplina = disciplinaSelecionada;

            tela.GravarRegistro = repositorioDisciplina.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarDisciplinas();
            }


        }


        public override void Excluir()
        {
            Disciplina disciplinaSelecionada = ObtemDisciplinaSelecionada();

            if (disciplinaSelecionada == null)
            {
                MessageBox.Show("Selecione uma disciplina primeiro",
                "Exclusão de Disciplinas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a disciplina?",
                "Exclusão de Disciplinas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioDisciplina.Excluir(disciplinaSelecionada);
                CarregarDisciplinas();
            }
        }

        public override UserControl ObtemListagem()
        {
           
            tabelaDisciplinas = new TabelaDisciplinasControl();

            CarregarDisciplinas();

            return tabelaDisciplinas;
        }


        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxDisciplina();
        }

        private Disciplina ObtemDisciplinaSelecionada()
        {
            var numero = tabelaDisciplinas.ObtemNumeroDisciplinaSelecionada();

            return repositorioDisciplina.SelecionarPorNumero(numero);
        }


        private void CarregarDisciplinas()
        {
            List<Disciplina> disciplinas = repositorioDisciplina.SelecionarTodos();

            tabelaDisciplinas.AtualizarRegistros(disciplinas);

        }
    }
}
