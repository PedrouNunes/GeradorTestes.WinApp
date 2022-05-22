using GeradorTestes.Dominio.ModuloDisciplina;
using GeradorTestes.Dominio.ModuloMateria;
using GeradorTestes.Dominio.ModuloQuestao;
using GeradorTestes.Dominio.ModuloTeste;
using GeradorTestes.WinApp.Compartilhado;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorTestes.WinApp.ModuloTeste
{
    public class ControladorTeste : ControladorBase
    {
        private readonly IRepositorioTeste repositorioTeste;
        private readonly IRepositorioDisciplina repositorioDisciplina;
        private readonly IRepositorioMateria repositorioMateria;
        private readonly IRepositorioQuestao repositorioQuestao;

        private TabelaTestesControl tabelaTestes;

        public ControladorTeste(IRepositorioTeste repositorioTeste,IRepositorioDisciplina repositorioDisciplina, IRepositorioMateria repositorioMateria, IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioTeste = repositorioTeste;
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioMateria = repositorioMateria;
            this.repositorioQuestao = repositorioQuestao;
        }

        public override void Inserir()
        {
            var disciplinas = repositorioDisciplina.SelecionarTodos();
            var materias = repositorioMateria.SelecionarTodos();
            var questoes = repositorioQuestao.SelecionarTodos();

            TelaCadastroTesteForm tela = new TelaCadastroTesteForm(disciplinas, materias, questoes, repositorioQuestao);
            tela.Teste = new Teste();

            tela.GravarRegistro = repositorioTeste.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTestes();
            }
        }

        public override void Editar()
        {
            Teste testeSelecionado = ObtemTesteSelecionado();

            if (testeSelecionado == null)
            {
                MessageBox.Show("Selecione um teste primeiro",
                "Edição de Testes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var disciplinas = repositorioDisciplina.SelecionarTodos();
            var materias = repositorioMateria.SelecionarTodos();
            var questoes = repositorioQuestao.SelecionarTodos();

            TelaCadastroTesteForm tela = new TelaCadastroTesteForm(disciplinas, materias, questoes, repositorioQuestao);

            tela.Teste = testeSelecionado;

            tela.GravarRegistro = repositorioTeste.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTestes();
            }

        }


        public override void Excluir()
        {
            Teste testeSelecionado = ObtemTesteSelecionado();

            if (testeSelecionado == null)
            {
                MessageBox.Show("Selecione um teste primeiro",
                "Exclusão de Testes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o teste?",
                "Exclusão de Testes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioTeste.Excluir(testeSelecionado);
                CarregarTestes();
            }
        }

        public override UserControl ObtemListagem()
        {

            tabelaTestes = new TabelaTestesControl();

            CarregarTestes();

            return tabelaTestes;
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxTeste();
        }

        private Teste ObtemTesteSelecionado()
        {
            var numero = tabelaTestes.ObtemNumeroTesteSelecionado();

            return repositorioTeste.SelecionarPorNumero(numero);

        }


        private void CarregarTestes()
        {
            List<Teste> testes = repositorioTeste.SelecionarTodos();

            tabelaTestes.AtualizarRegistros(testes);

        }

        public override void Duplicar()
        {
            Teste testeSelecionado = ObtemTesteSelecionado();

            if (testeSelecionado == null)
            {
                MessageBox.Show("Selecione um teste primeiro",
                "Duplicar de Testes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            Teste testeClonado = new Teste();

            ClonarTeste(testeSelecionado, testeClonado);

            var disciplinas = repositorioDisciplina.SelecionarTodos();
            var materias = repositorioMateria.SelecionarTodos();
            var questoes = repositorioQuestao.SelecionarTodos();

            TelaCadastroTesteForm tela = new TelaCadastroTesteForm(disciplinas, materias, questoes, repositorioQuestao);
             
            tela.Teste = testeClonado;

            tela.GravarRegistro = repositorioTeste.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTestes();
            }
        }

        private void ClonarTeste(Teste testeSelecionado, Teste testeClonado)
        {
            testeClonado.Titulo = testeSelecionado.Titulo;

            testeClonado.Disciplina = testeSelecionado.Disciplina;

            testeClonado.Materia = testeSelecionado.Materia;

            testeClonado.qtdQuestoes = testeSelecionado.qtdQuestoes;

            testeClonado.Data = testeSelecionado.Data;
            
        }

        public override void GerarPdf()
        {
            Teste TesteSelecionado = ObtemTesteSelecionado();

            string nomeArquivo = @"C:\Windows\Temp" + @"\teste.pdf";
            FileStream arquivoPDF = new FileStream(nomeArquivo, FileMode.Create);
            Document doc = new Document(PageSize.A4);
            PdfWriter escritorPDF = PdfWriter.GetInstance(doc, arquivoPDF);

            string dados = "";

            Paragraph paragrafo = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Regular));
            paragrafo.Alignment = Element.ALIGN_CENTER;
            paragrafo.Add(TesteSelecionado.Titulo + "\n\n");
            paragrafo.Add("Disciplina: " + TesteSelecionado.Disciplina.Nome + "\n\n");
            paragrafo.Add("Assunto: " + TesteSelecionado.Materia.Nome + "\n\n");
            paragrafo.Add("Data: " + TesteSelecionado.Data.ToShortDateString() + "\n\n");

            int qtdQuestoes = TesteSelecionado.questoes.Count;

            Paragraph paragrafo2 = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Regular));
            paragrafo2.Alignment = Element.ALIGN_LEFT;

            for (int i = 0; i < qtdQuestoes; i++)
            {

                int j = i + 1;
                paragrafo2.Add("Questão " + j + " - " + TesteSelecionado.questoes[i].Enunciado + "\n\n");

                for (int k = 0; k < TesteSelecionado.questoes[i].Alternativas.Count; k++)
                {

                    paragrafo2.Add("() " + TesteSelecionado.questoes[i].Alternativas[k].Descricao + "\n\n");

                }

            }

            doc.Open();
            doc.Add(paragrafo);
            doc.Add(paragrafo2);
            doc.Close();
        }

    }
}
