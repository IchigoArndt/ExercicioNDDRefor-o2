using exercicio2.Aplicacao.Features.Emprestimos;
using exercicio2.Exceptions;
using exercicio2.Features.Emprestimo;
using exercicio2.Features.Livros;
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

namespace UnitTestProject1.Features.Emprestimos
{
    [TestFixture]
    public class EmprestimoIntegracaoSistemaTeste
    {

        IEmprestimoRepositorio _IEmprestimoRepositorio;

        EmprestimoService _emprestimoService;

        [SetUp]
        public void InitializeObjects()
        {
            _IEmprestimoRepositorio = new EmprestimoSqlRepositorio();
            _emprestimoService = new EmprestimoService(_IEmprestimoRepositorio);

            BaseSqlTest.SeedDatabase();
        }

        [Test]
        public void Emprestimo_IntegracaoSistema_DeveFuncionar()
        {
            Livro livro = ObjectMother.ObterLivroValido();
            IList<Livro> ListaLivros = new List<Livro>();
            ListaLivros.Add(livro);
            Emprestimo Emprestimo = ObjectMother.ObterEmprestimoValido(ListaLivros);

            Emprestimo result = _emprestimoService.Adicionar(Emprestimo);

            result.Id.Should().BeGreaterThan(0);

            IList<Emprestimo> emprestimoList = _emprestimoService.BuscarTodos();
        }

        [Test]
        public void Emprestimo_DeleteIntegracaoSistema_DeveFuncionar()
        {
            Livro livro = ObjectMother.ObterLivroValido();
            IList<Livro> ListaLivros = new List<Livro>();
            ListaLivros.Add(livro);
            Emprestimo Emprestimo = ObjectMother.ObterEmprestimoValido(ListaLivros);

            _emprestimoService.Deletar(Emprestimo);

            Emprestimo emprestimoGetById = _emprestimoService.BuscarPorId(Emprestimo.Id);
            emprestimoGetById.Should().BeNull();

            IList<Emprestimo> emprestimoList = _emprestimoService.BuscarTodos();
            emprestimoList.Count().Should().Be(0);
        }

        [Test]
        public void Emprestimo_ObterPorIdIntegracaoSistema_DeveFuncionar()
        {
            Livro livro = ObjectMother.ObterLivroValido();
            IList<Livro> ListaLivros = new List<Livro>();
            ListaLivros.Add(livro);
            Emprestimo Emprestimo = ObjectMother.ObterEmprestimoValido(ListaLivros);

            Emprestimo emprestimoGetById = _emprestimoService.BuscarPorId(Emprestimo.Id);

            emprestimoGetById.Should().NotBeNull();

            emprestimoGetById.Id.Should().Be(Emprestimo.Id);
        }

        [Test]
        public void Emprestimo_ObterTodosIntegracaoSistema_DeveFuncionar()
        {
            IList<Emprestimo> emprestimolist = _emprestimoService.BuscarTodos();

            emprestimolist.Count.Should().Be(1);
            emprestimolist.First().Id.Should().Be(1);
        }


        [Test]
        public void Emprestimo_UpdateIdVazioSistema_DeveFalhar()
        {
            Livro livro = ObjectMother.ObterLivroValido();
            IList<Livro> ListaLivros = new List<Livro>();
            ListaLivros.Add(livro);
            Emprestimo Emprestimo = ObjectMother.ObterEmprestimoValido(ListaLivros);
            Emprestimo.Id = 0;

            Action act = () => { _emprestimoService.Atualizar(Emprestimo); };

            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Emprestimo_DeleteIntegracaoSistema_DeveFalhar()
        {
            Livro livro = ObjectMother.ObterLivroValido();
            IList<Livro> ListaLivros = new List<Livro>();
            ListaLivros.Add(livro);
            Emprestimo Emprestimo = ObjectMother.ObterEmprestimoValido(ListaLivros);

            Emprestimo.Id = 0;

            Action act = () => { _emprestimoService.Deletar(Emprestimo); };
            act.Should().Throw<IdentifierUndefinedException>();

            IList<Emprestimo> emprestimoList = _emprestimoService.BuscarTodos();
            emprestimoList.Count().Should().Be(1);
        }

        [Test]
        public void Emprestimo_GetEmprestimoIdNull_shouldFail()
        {
            Livro livro = ObjectMother.ObterLivroValido();
            IList<Livro> ListaLivros = new List<Livro>();
            ListaLivros.Add(livro);
            Emprestimo Emprestimo = ObjectMother.ObterEmprestimoValido(ListaLivros);

            Emprestimo.Id = 0;

            Action act = () => { _emprestimoService.BuscarPorId(Emprestimo.Id); };
            act.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
