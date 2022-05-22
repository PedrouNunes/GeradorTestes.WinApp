using FluentValidation;
using FluentValidation.Validators;
using System;


namespace GeradorTestes.Dominio.ModuloDisciplina
{
    public class ValidadorDisciplina : AbstractValidator<Disciplina>
    {
        public ValidadorDisciplina()
        {
            RuleFor(x => x.Nome)
                .NotNull().NotEmpty();
        }
    }
}
