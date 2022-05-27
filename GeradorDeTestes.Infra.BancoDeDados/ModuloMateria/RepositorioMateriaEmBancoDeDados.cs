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

        private const string sqlSelecionarTodos = @"SELECT
                MT.NUMERO,
                MT.NOME,
                MT.SERIE,
                MT.DISCIPLINA_NUMERO,
                D.NOME
                FROM
                TbMateria AS MT INNER JOIN 
                TbDisciplina AS D ON
                MT.Disciplina_Numero = D.Numero";

        private const string sqlInserir =
            @"INSERT INTO [TBMATERIA]
            (
                [NOME]
                [DISCIPLINA]
                [SERIE]
            )    
             VALUES
            (
                @NOME
                @DISCIPLINA
                @SERIE
            );SELECT SCOPE_IDENTITY();";

        private const string sqlEditar =
            @"UPDATE [TBMATERIA]	
		        SET
			        [NOME] = @NOME
                    [DISCIPLINA] = @DISCIPLINA
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
                    [DISCIPLINA],
                    [SERIE]
	            FROM 
		            [TBMATERIA]
		        WHERE
                    [NUMERO] = @NUMERO";


        public ValidationResult Editar(Materia registro)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Excluir(Materia registro)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Inserir(Materia novaMateria)
        {
            var validador = new ValidadorMateria();
            var resultadoValidacao = validador.Validate(novaMateria);
            if (resultadoValidacao.IsValid == false)
            {
                return resultadoValidacao;
            }
            else
            {
                SqlConnection conexao = new SqlConnection(enderecoBanco);
                SqlCommand cmdInserir = new SqlCommand(sqlInserir, conexao);

                ConfigurarParametrosMateria(novaMateria, cmdInserir);
                conexao.Open();

                var numero = cmdInserir.ExecuteScalar();

                novaMateria.Numero = Convert.ToInt32(numero);
                conexao.Close();
                return resultadoValidacao;
            }
        }

        public Materia SelecionarPorNumero(int numero)
        {
            throw new NotImplementedException();
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
