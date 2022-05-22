using FluentValidation.Results;
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

        private const string sqlSelecionarTodos =
            @"SELECT 
		            [NUMERO], 
		            [NOME],
                    [DISCIPLINA],
                     [SERIE]
	            FROM 
		            [TBMATERIA]";

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
            throw new NotImplementedException();
        }

        private void ConfigurarParametrosMateria(Materia novaMateria, SqlCommand cmdInserir)
        {
            cmdInserir.Parameters.AddWithValue("NUMERO", novaMateria.Numero);
            cmdInserir.Parameters.AddWithValue("NOME", novaMateria.Nome);
            cmdInserir.Parameters.AddWithValue("SERIE", novaMateria.Serie);

        }
    }
}
