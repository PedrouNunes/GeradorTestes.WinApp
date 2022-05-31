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

        //private const string sqlSelecionarTodos = @"SELECT
        //        TQ.ENUNCIADO,
        //        TQ.MATERIA_MATERIA,
        //        TQ.DISCIPLINA_DISCIPLINA,
        //        TQ.ALTERNATIVAS,
        //        MT.NUMERO AS MATERIA_MATERIA

        //        FROM
        //        TbQuestao AS TQ INNER JOIN 
        //        TbMateria AS TM ON
        //        TQ.MATERIA_MATERIA = MT.Numero";

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
               @ENUNCIADO,
               @MATERIA_MATERIA,
               @QUESTAO_NUMERO
            );SELECT SCOPE_IDENTITY();";



        private const string sqlEditarQuestao = @"UPDATE [TBQUESTAO]	
		        SET
			        [ENUNCIADO] = @ENUNCIADO,
                    [MATERIA_MATERIA] = @MATERIA_MATERIA,
                    [DISCIPLINA_DISCIPLINA] = @DISCIPLINA_DISCIPLINA
		        WHERE
			        [NUMERO] = @NUMERO";

        private const string sqlExcluirQuestao =
           @"DELETE FROM [TBQUESTAO]
                WHERE
                    [NUMERO] = @NUMERO";
        #endregion

        public ValidationResult Editar(Questao registro)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Excluir(Questao registro)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Inserir(Questao novoRegistro)
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
