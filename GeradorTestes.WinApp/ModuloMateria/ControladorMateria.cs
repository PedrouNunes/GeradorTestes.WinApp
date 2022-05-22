using GeradorTestes.Dominio.ModuloDisciplina;
using GeradorTestes.Dominio.ModuloMateria;
using GeradorTestes.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorTestes.WinApp.ModuloMateria
{
    public class ControladorMateria : ControladorBase
    {
        private readonly IRepositorioMateria repositorioMateria;
        private readonly IRepositorioDisciplina repositorioDisciplina;


        private TabelaMateriasControl tabelaMaterias;


        public ControladorMateria(IRepositorioMateria repositorioMateria, IRepositorioDisciplina repositorioDisciplina)
        {
            this.repositorioMateria = repositorioMateria;
            this.repositorioDisciplina = repositorioDisciplina;
        }

        public override void Inserir()
        {
            var disciplinas = repositorioDisciplina.SelecionarTodos();

            TelaCadastroMateriaForm tela = new TelaCadastroMateriaForm(disciplinas);
            tela.Materia = new Materia();

            tela.GravarRegistro = repositorioMateria.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarMaterias();
            }
        }


        public override void Editar()
        {
            Materia materiaSelecionada = ObtemMateriaSelecionada();

            if (materiaSelecionada == null)
            {
                MessageBox.Show("Selecione uma materia primeiro",
                "Edição de Materias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var disciplinas = repositorioDisciplina.SelecionarTodos();

            TelaCadastroMateriaForm tela = new TelaCadastroMateriaForm(disciplinas);

            tela.Materia = materiaSelecionada;

            tela.GravarRegistro = repositorioMateria.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarMaterias();
            }


        }


        public override void Excluir()
        {
            Materia materiaSelecionada = ObtemMateriaSelecionada();

            if (materiaSelecionada == null)
            {
                MessageBox.Show("Selecione uma materia primeiro",
                "Exclusão de Materias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a materia?",
                "Exclusão de Materias", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioMateria.Excluir(materiaSelecionada);
                CarregarMaterias();
            }
        }


        public override UserControl ObtemListagem()
        {
            if(tabelaMaterias == null)
            {
                tabelaMaterias = new TabelaMateriasControl();
            }

           // tabelaMaterias = new TabelaMateriasControl();

            CarregarMaterias();

            return tabelaMaterias;
        }


        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxMateria();
        }

        private Materia ObtemMateriaSelecionada()
        {
            var numero = tabelaMaterias.ObtemNumeroMateriaSelecionada();

            return repositorioMateria.SelecionarPorNumero(numero);
        }


        private void CarregarMaterias()
        {
            List<Materia> materias = repositorioMateria.SelecionarTodos();

            tabelaMaterias.AtualizarRegistros(materias);

        }
    }
}
