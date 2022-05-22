using GeradorTestes.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.WinApp.ModuloMateria
{
    public class ConfiguracaoToolboxMateria : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Cadastro de Materias";

        public override string TooltipInserir { get { return "Inserir uma nova materia"; } }

        public override string TooltipEditar { get { return "Editar uma materia existente"; } }

        public override string TooltipExcluir { get { return "Excluir uma materia existente"; } }

        public override string TooltipAgrupar { get { return "Agrupar materias"; } }

        public override bool AgruparHabilitado { get { return true; } }
    }
}
