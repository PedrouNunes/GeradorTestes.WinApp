using FluentValidation.Results;
using GeradorTestes.Dominio.ModuloQuestao;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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


        #region Queries
        private const string sqlInserirQuestao =
            @"INSERT INTO [TBQUESTAO]
            (
                [ENUNCIADO],
                [MATERIA_MATERIA],
                [DISCIPLINA_DISCIPLINA]
            )    
             VALUES
            (
               @ENUNCIADO,
               @MATERIA_MATERIA,
               @DISCIPLINA_DISCIPLINA
            );SELECT SCOPE_IDENTITY();";

        private const string sqlInserirAlternativa =
            @"INSERT INTO [TBALTERNATIVA]
            (
                [DESCRICAO],
                [RESPOSTA],
                [QUESTAO_NUMERO]
            )    
             VALUES
            (
               @DESCRICAO,
               @RESPOSTA,
               @QUESTAO_NUMERO
            );SELECT SCOPE_IDENTITY();";


        private const string sqlEditarQuestao = @"UPDATE [TBQUESTAO]	
		        SET
			        [ENUNCIADO] = @ENUNCIADO,
                    [MATERIA_MATERIA] = @MATERIA_MATERIA,
                    [DISCIPLINA_DISCIPLINA] = @DISCIPLINA_DISCIPLINA
		        WHERE
			        [NUMERO] = @NUMERO";

        private const string sqlEditarAlternativa =
            @"UPDATE TBALTERNATIVA
                SET
                    [DESCRICAO] = @DESCRICAO,
                    [RESPOSTA] = @RESPOSTA,
                    [QUESTAO_NUMERO] = @QUESTAO_NUMERO
                WHERE
                    [NUMERO] = @NUMERO";

        private const string sqlExcluirQuestao =
           @"DELETE FROM [TBQUESTAO]
                WHERE
                    [NUMERO] = @NUMERO";

        private const string sqlExcluirAlternativa =
            @"DELETE FROM TBALTERNATIVA
                WHERE
                    [QUESTAO_NUMERO] = @NUMERO";


        #endregion

        public ValidationResult Inserir(Questao questao)
        {
            var validador = new ValidadorQuestao();

            var resultado = validador.Validate(questao);

            if (!resultado.IsValid)
                return resultado;

            SqlConnection conexaoComBanco = new(enderecoBanco);

            SqlCommand comandoInsercaoQuestao = new(sqlInserirQuestao, conexaoComBanco);

            ConfigurarParametrosQuestao(questao, comandoInsercaoQuestao);

            conexaoComBanco.Open();

            var idQuestao = comandoInsercaoQuestao.ExecuteScalar();
            questao.Numero = Convert.ToInt32(idQuestao);

            SqlCommand comandoInsercaoAlternativa = new(sqlInserirAlternativa, conexaoComBanco);

            int i = 0;
            foreach (var alternativa in questao.Alternativas)
            {
                comandoInsercaoAlternativa.Parameters.Clear();
                ConfirugarParametrosAlternativas(alternativa, questao, comandoInsercaoAlternativa);
                var idAlternativa = comandoInsercaoAlternativa.ExecuteScalar();
                //questao.Alternativas[i].Numero = Convert.ToInt32(idAlternativa);

                i++;
            }
            conexaoComBanco.Close();

            return resultado;
        }

        private void ConfirugarParametrosAlternativas(Alternativa alternativa, Questao questao, SqlCommand comandoInsercaoAlternativa)
        {
            //comandoInsercaoAlternativa.Parameters.AddWithValue("NUMERO", alternativa.Numero);
            comandoInsercaoAlternativa.Parameters.AddWithValue("DESCRICAO", alternativa.Descricao);
            comandoInsercaoAlternativa.Parameters.AddWithValue("CORRETA", alternativa.estaCorreta);
            comandoInsercaoAlternativa.Parameters.AddWithValue("QUESTAO_NUMERO", questao.Numero);
        }

        private void ConfigurarParametrosQuestao(Questao questao, SqlCommand comandoInsercaoQuestao)
        {
            comandoInsercaoQuestao.Parameters.AddWithValue("NUMERO", questao.Numero);
            comandoInsercaoQuestao.Parameters.AddWithValue("ENUNCIADO", questao.Enunciado);
            comandoInsercaoQuestao.Parameters.AddWithValue("MATERIA_MATERIA", questao.Materia.Numero);
            comandoInsercaoQuestao.Parameters.AddWithValue("DISCIPLINA_DISCIPLINA", questao.Disciplina.Numero);
        }

        public ValidationResult Editar(Questao registro)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Excluir(Questao registro)
        {
            throw new NotImplementedException();
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
