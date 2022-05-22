using GeradorTestes.Dominio.ModuloMateria;
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

namespace GeradorTestes.WinApp.ModuloMateria
{
    public partial class TabelaMateriasControl : UserControl
    {
        public TabelaMateriasControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Serie", HeaderText = "Serie"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Disciplina", HeaderText = "Disciplina"}


           };

            return colunas;
        }


        internal void AtualizarRegistros(List<Materia> materias)
        {
            grid.Rows.Clear();

            foreach (Materia materia in materias)
            {
                grid.Rows.Add(materia.Numero, materia.Nome, materia.Serie , materia.Disciplina?.Nome);
            }
        }

        internal int ObtemNumeroMateriaSelecionada()
        {
            return grid.SelecionarNumero<int>();
        }
    }
}
