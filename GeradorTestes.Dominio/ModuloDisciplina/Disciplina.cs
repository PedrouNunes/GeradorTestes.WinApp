using GeradorTestes.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Dominio.ModuloDisciplina
{
    public class Disciplina : EntidadeBase<Disciplina>
    {
        public string Nome { get; set; }

        public Disciplina()
        {
        }

        public Disciplina(string nome)
        {
            Nome = nome;
        }

        public override void atualizar(Disciplina disciplina)
        {
           this.Nome = disciplina.Nome;
        }

        public override string ToString()
        {
            return $"Número: {Numero}, Nome: {Nome}";
        }


    }
}
