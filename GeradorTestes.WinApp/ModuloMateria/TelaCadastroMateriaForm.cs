using FluentValidation.Results;
using GeradorTestes.Dominio.ModuloDisciplina;
using GeradorTestes.Dominio.ModuloMateria;
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
    public partial class TelaCadastroMateriaForm : Form
    {
        private Materia materia;
        public TelaCadastroMateriaForm(List<Disciplina> disciplinas)
        {
            InitializeComponent();

            CarregarDisciplinas(disciplinas);
        }

        private void CarregarDisciplinas(List<Disciplina> disciplinas)
        {
            cmbDisciplinas.Items.Clear();

            foreach (var item in disciplinas)
            {
                cmbDisciplinas.Items.Add(item);
            }
        }

        public Func<Materia, ValidationResult> GravarRegistro { get; set; }

        public Materia Materia
        {
            get { return materia; }
            set
            {
                materia = value;

                txtNumero.Text = materia.Numero.ToString();
                txtNome.Text = materia.Nome;

                cmbDisciplinas.Enabled = materia.Disciplina != null;

                checkMarcarDisciplina.Checked = materia.Disciplina != null;

                cmbDisciplinas.SelectedItem = materia.Disciplina;

                checkMarcarPrimeiraSerie.Checked = materia.Serie != null;

                checkMarcarSegundaSerie.Checked = materia.Serie != null;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            materia.Nome = txtNome.Text;
            materia.Disciplina = (Disciplina)cmbDisciplinas.SelectedItem;

            var resultadoValidacao = GravarRegistro(materia);

            if (checkMarcarPrimeiraSerie.Checked)
            {
                materia.Serie = "1 Série";
               
            }

            if (checkMarcarSegundaSerie.Checked)
            {
                materia.Serie = "2 Série";
              
            }

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void TelaCadastroDisciplinaForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroDisciplinaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }


        private void checkMarcarDisciplina_CheckedChanged(object sender, EventArgs e)
        {
            cmbDisciplinas.Enabled = checkMarcarDisciplina.Checked;
            cmbDisciplinas.SelectedIndex = -1;
        }

        private void checkMarcarPrimeiraSerie_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMarcarPrimeiraSerie.Checked == false)
            {
                checkMarcarSegundaSerie.Enabled = true;
            }
            else
            {

                checkMarcarSegundaSerie.Enabled = false;
            }
        }

        private void checkMarcarSegundaSerie_CheckedChanged(object sender, EventArgs e)
        {
            if(checkMarcarSegundaSerie.Checked == false)
            {
                checkMarcarPrimeiraSerie.Enabled = true;
            }
            else
            {
                checkMarcarPrimeiraSerie.Enabled = false;
            }
            
        }

      
    }
}
