using FluentValidation.Results;
using GeradorTestes.Dominio.ModuloQuestao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Infra.BancoDeDados.ModuloQuestão
{
    internal class RepositorioQuestaoEmBancoDeDados : IRepositorioQuestao
    {
        public const string enderecoBanco = "Data Source=(LocalDB)\\MSSqlLocalDB;" +
            "Initial Catalog=GeradorDeTestesDB;" +
            "Integrated Security=True;Pooling=False";

        private const string sqlSelecionarTodos = @"SELECT
                TQ.NUMERO,
                TQ.ENUNCIADO,
                TQ.MATERIA_MATERIA,
                TQ.DISCIPLINA_DISCIPLINA,
                TQ.ALTERNATIVAS,
                MT.NUMERO AS MATERIA_MATERIA
                
                FROM
                TbQuestao AS TQ INNER JOIN 
                TbMateria AS TM ON
                TQ.MATERIA_MATERIA = MT.Numero";

        private const string sqlInserir =
            @"INSERT INTO [TBQUESTAO]
            (
                [ENUNCIADO],
                [MATERIA_MATERIA],
                [DISCIPLINA_DISCIPLINA],
                [ALTERNATIVAS]
            )    
             VALUES
            (
               @ENUNCIADO,
               @MATERIA_MATERIA,
               @DISCIPLINA_DISCIPLINA,
               @ALTERNATIVAS
            );SELECT SCOPE_IDENTITY(); SELECT SCOPE_IDENTITY";

        public ValidationResult Editar(Questao registro)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Excluir(Questao registro)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Inserir(Questao questao)
        {
            var validador = new ValidadorDisciplina();
            var resultadoValidacao = validador.Validate(novaDisciplina);
            if (resultadoValidacao.IsValid == false)
            {
                return resultadoValidacao;
            }
            else
            {
                SqlConnection conexao = new SqlConnection(enderecoBanco);
                SqlCommand cmdInserir = new SqlCommand(sqlInserir, conexao);

                ConfigurarParametrosDisciplina(novaDisciplina, cmdInserir);
                conexao.Open();

                var numero = cmdInserir.ExecuteScalar();

                novaDisciplina.Numero = Convert.ToInt32(numero);
                conexao.Close();
                return resultadoValidacao;
            }

        public Questao SelecionarPorNumero(int numero)
        {
            throw new NotImplementedException();
        }

        public List<Questao> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
