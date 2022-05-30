using FluentValidation.Results;
using GeradorTestes.Dominio.ModuloDisciplina;
using GeradorTestes.Dominio.ModuloMateria;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Infra.BancoDeDados.ModuloMateria
{
    public class RepositorioMateriaEmBancoDeDados : IRepositorioMateria
    {
        public const string enderecoBanco = "Data Source=(LocalDB)\\MSSqlLocalDB;" +
            "Initial Catalog=GeradorDeTestesDB;" +
            "Integrated Security=True;Pooling=False";

        #region Declaração de strings para ação
        private const string sqlSelecionarTodos = @"SELECT
                MT.NUMERO,
                MT.NOME,
                MT.SERIE,
                MT.DISCIPLINA_NUMERO,
                D.NUMERO AS DISCIPLINA_NUMERO,
                D.NOME AS DISCIPLINA_NOME
                FROM
                TbMateria AS MT INNER JOIN 
                TbDisciplina AS D ON
                MT.Disciplina_Numero = D.Numero";

        private const string sqlInserir =
            @"INSERT INTO [TBMATERIA]
            (
                [NOME],
                [DISCIPLINA_NUMERO],
                [SERIE]
            )    
             VALUES
            (
                @NOME,
                @DISCIPLINA_Numero,
                @SERIE
            );SELECT SCOPE_IDENTITY(); SELECT SCOPE_IDENTITY";

        private const string sqlEditar =
            @"UPDATE [TBMATERIA]	
		        SET
			        [NOME] = @NOME,
                    [DISCIPLINA_NUMERO] = @DISCIPLINA,
                    [SERIE] = @SERIE
		        WHERE
			        [NUMERO] = @NUMERO";

        private const string sqlExcluir =
            @"DELETE FROM [TBMATERIA]
		        WHERE
			        [NUMERO] = @NUMERO";

        private const string sqlSelecionarPorNumero =
            @"SELECT 
		            [NUMERO], 
		            [NOME],
                    [DISCIPLINA_NUMERO],
                    [SERIE]
	            FROM 
		            [TBMATERIA]
                ON
                    MTN.UMERO = D.DISCIPLINA_NUMERO
		        WHERE
                    [NUMERO] = @NUMERO";
        #endregion


        public ValidationResult Inserir(Materia materia)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            comandoInsercao.Parameters.AddWithValue("DISCIPLINA_NUMERO", materia.Numero);

            conexaoComBanco.Open();
            var id = comandoInsercao.ExecuteNonQuery();
            materia.Numero = Convert.ToInt32(id);
            conexaoComBanco.Close();

            return new ValidationResult();
        }

        public ValidationResult Editar(Materia materia)
        {
            var validador = new ValidadorMateria();

            var resultadoValidacao = validador.Validate(materia);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            ConfigurarParametrosMateria(materia, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteScalar();
            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Materia materia)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("NUMERO", materia.Numero);

            conexaoComBanco.Open();
            int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery();

            var resultadoValidacao = new ValidationResult();

            if (numeroRegistrosExcluidos == 0)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não foi possível remover o registro"));

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public Materia SelecionarPorNumero(int numero)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorNumero, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("NUMERO", numero);

            conexaoComBanco.Open();
            SqlDataReader leitorDisciplina = comandoSelecao.ExecuteReader();

            Materia materia = null;
            if (leitorDisciplina.Read())
                materia = ConverterParaMateria(leitorDisciplina);

            conexaoComBanco.Close();

            return materia;
        }

        public List<Materia> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();

            SqlDataReader leitorMateria = comandoSelecao.ExecuteReader();

            List<Materia> materias = new List<Materia>();

            while (leitorMateria.Read())
            {
                Materia materia = ConverterParaMateria(leitorMateria);
                materias.Add(materia);
            }

            conexaoComBanco.Close();

            return materias;
        }

        private Materia ConverterParaMateria(SqlDataReader leitorMateria)
        {
            int numero = Convert.ToInt32(leitorMateria["NUMERO"]);
            string nome = Convert.ToString(leitorMateria["NOME"]);
            string serie = Convert.ToString(leitorMateria["SERIE"]);
            int numeroDisciplina = Convert.ToInt32(leitorMateria["DISCIPLINA_NUMERO"]);
            string nomeDisciplina = Convert.ToString(leitorMateria["DISCIPLINA_NOME"]);

            var materia = new Materia
            {
                Numero = numero,
                Nome = nome,
                Serie = serie,
                Disciplina = new Disciplina { 
                    Numero = numeroDisciplina, 
                    Nome = nomeDisciplina,
                }
            };

            return materia;
        }

        private void ConfigurarParametrosMateria(Materia novaMateria, SqlCommand cmdInserir)
        {
            cmdInserir.Parameters.AddWithValue("NUMERO", novaMateria.Numero);
            cmdInserir.Parameters.AddWithValue("NOME", novaMateria.Nome);
            cmdInserir.Parameters.AddWithValue("SERIE", novaMateria.Serie);

        }
    }
}
