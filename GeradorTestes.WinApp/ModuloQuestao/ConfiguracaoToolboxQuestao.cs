using GeradorTestes.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.WinApp.ModuloQuestao
{
    public class ConfiguracaoToolboxQuestao : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Cadastro de Questões";

        public override string TooltipInserir { get { return "Inserir uma nova questão"; } }

        public override string TooltipEditar { get { return "Editar uma questão existente"; } }

        public override string TooltipExcluir { get { return "Excluir uma questão existente"; } }

        public override string TooltipAgrupar { get { return "Agrupar questões"; } }

        public override bool AgruparHabilitado { get { return true; } }
    }
}
