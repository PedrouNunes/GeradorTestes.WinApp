using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Dominio.ModuloMateria
{
    public class Serie
    {
        public int Numero { get; set; }
        public string Descricao { get; set; }

        public Serie()
        {
           
        }

        public Serie(int numero, string descricao) 
        {
            this.Numero = numero;
            this.Descricao = descricao;
        }

        public override string ToString()
        {
            return $"Número: {Numero} - Descrição: {Descricao} - ";
        }
    }
}
