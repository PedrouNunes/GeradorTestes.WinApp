using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GeradorTestes.Dominio.ModuloDisciplina;
using GeradorTestes.WinApp.Compartilhado;

namespace GeradorTestes.WinApp.ModuloDisciplina
{
    public partial class TabelaDisciplinasControl : UserControl
    {
        public TabelaDisciplinasControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

             
           };

            return colunas;
        }

        internal void AtualizarRegistros(List<Disciplina> disciplinas)
        {
            grid.Rows.Clear();

            foreach (Disciplina disciplina in disciplinas)
            {
                grid.Rows.Add(disciplina.Numero, disciplina.Nome);
            }
        }

        internal int ObtemNumeroDisciplinaSelecionada()
        {
            return grid.SelecionarNumero<int>();
        }
    }
}
