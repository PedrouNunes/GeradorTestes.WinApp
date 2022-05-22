using GeradorTestes.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.WinApp.ModuloTeste
{
    public class ConfiguracaoToolboxTeste : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Cadastro de Testes";

        public override string TooltipInserir { get { return "Inserir um novo teste"; } }

        public override string TooltipEditar { get { return "Editar um teste existente"; } }

        public override string TooltipExcluir { get { return "Excluir um teste existente"; } }

        public override string TooltipAgrupar { get { return "Agrupar testes"; } }

        public override bool AgruparHabilitado { get { return true; } }
    }
}
