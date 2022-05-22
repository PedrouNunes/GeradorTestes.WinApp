using GeradorTestes.Dominio.ModuloQuestao;
using GeradorTestes.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorTestes.WinApp.ModuloQuestao
{
    public partial class TabelaQuestoesControl : UserControl
    {
        public TabelaQuestoesControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
           {
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Enunciado", HeaderText = "Enunciado"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Disciplina", HeaderText = "Disciplina"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Materia", HeaderText = "Matéria"},

           };

            return colunas;
        }


        internal void AtualizarRegistros(List<Questao> questoes)
        {
            grid.Rows.Clear();

            foreach (Questao questao in questoes)
            {
                grid.Rows.Add(questao.Numero, questao.Enunciado, questao.Disciplina.Nome, questao.Materia.Nome);
            }
        }

        internal int ObtemNumeroQuestaoSelecionada()
        {
            return grid.SelecionarNumero<int>();
        }
    }
}
