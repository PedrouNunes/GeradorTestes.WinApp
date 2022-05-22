using FluentValidation.Results;
using GeradorTestes.Dominio.Compartilhado;
using GeradorTestes.Dominio.ModuloDisciplina;
using GeradorTestes.Dominio.ModuloMateria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Dominio.ModuloQuestao
{
    [Serializable]
    public class Questao : EntidadeBase<Questao>
    {
        public string Enunciado { get; set; }

        public Materia Materia { get; set; }

        public Disciplina Disciplina { get; set; }
        public List<Alternativa> Alternativas { get; set; }

        public Questao()
        {
            this.Alternativas = new List<Alternativa>();
        }

        public Questao(string enunciado,List<Alternativa> alternativas,Disciplina disciplina, Materia materia)
        {
            Enunciado = enunciado;
            Alternativas = alternativas;
            Disciplina = disciplina;
            Materia = materia;
        }

        public ValidationResult AdicionarAlternativa(Alternativa alternativa)
        {
            var resultadoValidacao = ValidarAlternativa(alternativa);

            if (resultadoValidacao.IsValid)
            {
                Alternativas.Add(alternativa);

            }

            return resultadoValidacao;
        }

        private ValidationResult ValidarAlternativa(Alternativa alternativa)
        {
            var validador = new ValidadorAlternativa();

            var resultadoValidacao = validador.Validate(alternativa);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;


            return resultadoValidacao;
        }

     



        public override void atualizar(Questao questao)
        {
            this.Materia = questao.Materia;
            this.Enunciado = questao.Enunciado;
            this.Alternativas = questao.Alternativas;
        }

        public override string ToString()
        {
            return $"Número: {Numero} - Enunciado: {Enunciado} - Materia: {Materia.Nome}";
        }
    }
}
