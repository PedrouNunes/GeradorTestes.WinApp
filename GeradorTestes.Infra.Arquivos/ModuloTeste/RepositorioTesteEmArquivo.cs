using FluentValidation;
using GeradorTestes.Dominio.ModuloTeste;
using GeradorTestes.Infra.Arquivos.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Infra.Arquivos.ModuloTeste
{
    public class RepositorioTesteEmArquivo : RepositorioEmArquivoBase<Teste>, IRepositorioTeste
    {
        public RepositorioTesteEmArquivo(DataContext dataContext) : base(dataContext)
        {
            if (dataContext.Testes.Count > 0)
                contador = dataContext.Questoes.Max(x => x.Numero);
        }

        public override List<Teste> ObterRegistros()
        {
            return dataContext.Testes;
        }

        public override AbstractValidator<Teste> ObterValidador()
        {
            return new ValidadorTeste();
        }
    }
}
