using FluentValidation.Results;
using GeradorTestes.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Dominio.ModuloQuestao
{
    [Serializable]
    public class Alternativa 
    {
        public string Descricao { get; set; }
        public bool estaCorreta{ get; set; }

        public Alternativa()
        {
            this.estaCorreta = false;
        }

        public Alternativa(string descricao, bool estaCorreta)
        {
            this.Descricao = descricao;
            this.estaCorreta = estaCorreta;
        }
      

        public override string ToString()
        {
            string status = estaCorreta == true ? "Resposta Correta" : "Resposta Falsa";
            return $"Alternativa: {Descricao} / {status}";
        }

        public void atualizarAlternativa(Alternativa alternativa)
        {
            this.Descricao = alternativa.Descricao;
            this.estaCorreta = alternativa.estaCorreta;
        }
    }
}
