using FluentValidation.Results;
using GeradorTestes.Dominio.ModuloDisciplina;
using GeradorTestes.Dominio.ModuloMateria;
using GeradorTestes.Dominio.ModuloQuestao;
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
    public partial class TelaCadastroQuestaoForm : Form
    {
        private Questao questao;
       
        public TelaCadastroQuestaoForm(List<Materia> materias, List<Disciplina> disciplinas)
        {
            InitializeComponent();

            CarregarMaterias(materias);
            CarregarDisciplinas(disciplinas);
        }

        private void CarregarMaterias(List<Materia> materias)
        {
  
            cmbMaterias.Items.Clear();
          
            foreach (var item in materias)
            {
            
                cmbMaterias.Items.Add(item);
            }
        }
        private Disciplina pegaDisciplina()
        {
            Disciplina disciplinaSelecionada = null;

            if(cmbDisciplinas.SelectedItem != null)
             disciplinaSelecionada =(Disciplina)cmbDisciplinas.SelectedItem;

            return disciplinaSelecionada;
        }

        private void CarregarDisciplinas(List<Disciplina> disciplinas)
        {
            cmbDisciplinas.Items.Clear();

            foreach (var item in disciplinas)
            {
                
                cmbDisciplinas.Items.Add(item);
            }
        }

        public Func<Questao, ValidationResult> GravarRegistro { get; set; }

        public Questao Questao
        {
            get { return questao; }
            set
            {
                questao = value;

                txtNumero.Text = questao.Numero.ToString();
                txtEnunciado.Text = questao.Enunciado;

                cmbMaterias.Enabled = questao.Materia != null;

                checkMarcarMateria.Checked = questao.Materia != null;

                cmbMaterias.SelectedItem = questao.Materia;
              
         
                cmbDisciplinas.Enabled = questao.Disciplina != null;

                checkMarcarDisciplina.Checked = questao.Disciplina == null;

                cmbDisciplinas.SelectedItem = questao.Disciplina;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            questao.Enunciado = txtEnunciado.Text;
            questao.Materia = (Materia)cmbMaterias.SelectedItem;
            questao.Disciplina = (Disciplina)cmbDisciplinas.SelectedItem;

            var resultadoValidacao = GravarRegistro(questao);


            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void TelaCadastroMateriaForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroMateriaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void checkMarcarMateria_CheckedChanged(object sender, EventArgs e)
        {
            cmbMaterias.Enabled = checkMarcarMateria.Checked;
            cmbMaterias.SelectedIndex = -1;
        }

        private void checkMarcarDisciplina_CheckedChanged(object sender, EventArgs e)
        {
            cmbDisciplinas.Enabled = checkMarcarDisciplina.Checked;
            cmbDisciplinas.SelectedIndex = -1;
        }

        private void MarcarComoCorreta(Alternativa alternativa)
        {
            if (checkMarcarAlternativaCorreta.Checked && checkMarcarAlternativaCorreta.Enabled == true)
                alternativa.estaCorreta = true;

            
        }

        private void btnAdicionarAlternativa_Click(object sender, EventArgs e)
        {
            AdicionarAlternativa();
          

            listAlternativas.Items.Clear();

            if (questao.Alternativas != null && questao.Alternativas.Count > 0)
                foreach (var alternativa in questao.Alternativas)
                    listAlternativas.Items.Add(alternativa);

          

            if (checkMarcarAlternativaCorreta.Checked == true)
            {
                checkMarcarAlternativaCorreta.Enabled = false;
                
            }
        }

        private void AdicionarAlternativa()
        {
            Alternativa alternativa = new Alternativa();

            alternativa.Descricao = txtAlternativa.Text;

            MarcarComoCorreta(alternativa);

            var resultado = questao.AdicionarAlternativa(alternativa);

        }

        
    }
}
