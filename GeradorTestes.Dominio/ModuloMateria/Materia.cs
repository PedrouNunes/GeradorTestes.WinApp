using GeradorTestes.Dominio.Compartilhado;
using GeradorTestes.Dominio.ModuloDisciplina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Dominio.ModuloMateria
{
    public class Materia : EntidadeBase<Materia>
    {
        public string Nome { get; set; }
        public Disciplina Disciplina { get; set; }
        public string Serie { get; set; }

        public Materia()
        {

        }

        public Materia(string nome, Disciplina disciplina, string serie)
        {
            Nome = nome;
            Disciplina = disciplina;
            Serie = serie;
        }

        public override void atualizar(Materia registro)
        {
            this.Nome = registro.Nome;
            this.Disciplina = registro.Disciplina;
            this.Serie = registro.Serie;
        }

        public override string ToString()
        {
            return $"Número: {Numero} - Nome: {Nome} - Disciplina: {Disciplina.Nome} - Série: {Serie}";
        }
    }
}
