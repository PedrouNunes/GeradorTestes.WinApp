using FluentValidation;
using FluentValidation.Results;
using GeradorTestes.Dominio.ModuloMateria;
using GeradorTestes.Infra.Arquivos.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Infra.Arquivos.ModuloMateria
{
    public class RepositorioMateriaEmArquivo : RepositorioEmArquivoBase<Materia>, IRepositorioMateria
    {
        public RepositorioMateriaEmArquivo(DataContext context) : base(context)
        {
            if (context.Materias.Count > 0)
                contador = context.Materias.Max(x => x.Numero);
        }

        public override List<Materia> ObterRegistros()
        {
            return dataContext.Materias;
        }

        public override AbstractValidator<Materia> ObterValidador()
        {
            return new ValidadorMateria();
        }
        
    }
}
