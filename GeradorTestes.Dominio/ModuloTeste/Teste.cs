using GeradorTestes.Dominio.Compartilhado;
using GeradorTestes.Dominio.ModuloDisciplina;
using GeradorTestes.Dominio.ModuloMateria;
using GeradorTestes.Dominio.ModuloQuestao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Dominio.ModuloTeste
{
    [Serializable]
    public class Teste : EntidadeBase<Teste>
    {
        public string Titulo { get; set; }
        public Disciplina Disciplina { get; set; }
        public DateTime Data { get; set; }
        public Materia Materia { get; set; }
        
        public List<Questao> questoes = new List<Questao>();

        public int qtdQuestoes;

        public Teste()
        {
            Data = DateTime.Now;
        }

        public override void atualizar(Teste teste)
        {
            this.Titulo = teste.Titulo; 
            this.Disciplina = teste.Disciplina;
            this.Materia = teste.Materia;
            this.questoes = teste.questoes;
            this.qtdQuestoes = teste.qtdQuestoes;
            
        }

        public override string ToString()
        {
            return $"Número: {Numero} - Título: {Titulo} -  Disciplina: {Disciplina.Nome} - Materia: {Materia.Nome} - Questões: {qtdQuestoes} - Data: {Data.Date} ";
        }
    }
}
