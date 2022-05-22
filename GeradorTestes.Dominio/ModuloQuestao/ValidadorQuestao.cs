using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Dominio.ModuloQuestao
{
    public class ValidadorQuestao : AbstractValidator<Questao>
    {
        public ValidadorQuestao()
        {
            RuleFor(x => x.Enunciado)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Materia)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Disciplina)
               .NotNull()
               .NotEmpty();
        }

        }
}
