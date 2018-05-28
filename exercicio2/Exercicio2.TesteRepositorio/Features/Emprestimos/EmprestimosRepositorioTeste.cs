using exercicio2.Exceptions;
using exercicio2.Features.Emprestimo;
using exercicio2.Features.Livros;
using exercicio2.Infra.Data;
using exercicio2.Infra.Data.Features.Emprestimos;
using Exercicio2.ComumTeste;
using Exercicio2.ComumTeste.Base;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio2.TesteRepositorio.Features.Emprestimos
{
    [TestFixture]
    public class EmprestimosRepositorioTeste
    {
        IEmprestimoRepositorio _repositorio;
        ILivroRepositorio _repositorioLivro;
        [SetUp]
        public void InitializeObjects()
        {
            BaseSqlTest.SeedDatabase();
            _repositorio = new EmprestimoSqlRepositorio();
            _repositorioLivro = new LivroSqlRepositorio();
        }

        [Test]
        public void Emprestimo_CriarRepositorio_DeveFuncionar()
        {
            IList<Livro> ListaLivros = _repositorioLivro.BuscarTodos();
            Emprestimo Emprestimo = ObjectMother.ObterEmprestimoValido(ListaLivros);
            Emprestimo.Id = 0;

            Emprestimo = _repositorio.Adicionar(Emprestimo);

            Emprestimo.Id.Should().BeGreaterThan(0);

        }

        [Test]
        public void Emprestimo_AtualizarRepositorio_DeveFuncionar()
        {
            IList<Livro> ListaLivros = _repositorioLivro.BuscarTodos();
            Emprestimo Emprestimo = ObjectMother.ObterEmprestimoValido(ListaLivros);
            Emprestimo.NomeCliente = "João";
            Emprestimo = _repositorio.Atualizar(Emprestimo);
            Emprestimo Result = ObjectMother.ObterEmprestimoValido(ListaLivros);
            Result.NomeCliente.Should().NotBe(Emprestimo.NomeCliente);
        }

        [Test]
        public void Emprestimo_AtualizarRepositorio_DeveFalhar()
        {
            IList<Livro> ListaLivros = _repositorioLivro.BuscarTodos();
            Emprestimo Emprestimo = ObjectMother.ObterEmprestimoValido(ListaLivros);
            Emprestimo.Id = 0;
            Action act = () => Emprestimo.Validate();
            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Emprestimo_DeletarRepositorio_DeveFuncionar()
        {
            IList<Livro> ListaLivros = _repositorioLivro.BuscarTodos();
            Emprestimo Emprestimo = ObjectMother.ObterEmprestimoValido(ListaLivros);

            _repositorio.Deletar(Emprestimo);

            Emprestimo Result = _repositorio.BuscarPorId(Emprestimo.Id);

            Result.Should().BeNull();
        }

        [Test]
        public void Emprestimo_DeletarRepositorio_DeveFalhar()
        {
            IList<Livro> ListaLivros = _repositorioLivro.BuscarTodos();
            Emprestimo Emprestimo = ObjectMother.ObterEmprestimoValido(ListaLivros);

            Emprestimo.Id = 0;

            Action act = () => _repositorio.Deletar(Emprestimo);

            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Emprestimo_ObterEmprestimoRepositorio_DeveFuncionar()
        {
            Emprestimo Emprestimo = _repositorio.BuscarPorId(1);

            Emprestimo.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Emprestimo_ObterTodosRepositorios_DeveFuncionar()
        {
            IList<Emprestimo> ListaEmprestimo = _repositorio.BuscarTodos();

            ListaEmprestimo.Count().Should().Be(1);

            ListaEmprestimo.First().Id.Should().Be(1);
        }
    }
}
