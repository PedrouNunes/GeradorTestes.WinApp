using GeradorTestes.Dominio.ModuloTeste;
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

namespace GeradorTestes.WinApp.ModuloTeste
{
    public partial class TabelaTestesControl : UserControl
    {
        public TabelaTestesControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Titulo", HeaderText = "Titulo"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Disciplina", HeaderText = "Disciplina"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Materia", HeaderText = "Materia"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Data", HeaderText = "Data"},

                new DataGridViewTextBoxColumn {DataPropertyName = "qtdQuestoes", HeaderText = "qtdQuestoes"}
           };

            return colunas;
        }


        internal void AtualizarRegistros(List<Teste> testes)
        {
            grid.Rows.Clear();

            foreach (Teste teste in testes)
            {
                grid.Rows.Add(teste.Numero, teste.Titulo, teste.Disciplina?.Nome , teste.Materia?.Nome, teste.Data, teste.qtdQuestoes);
            }
        }

        internal int ObtemNumeroTesteSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }
    }
}
