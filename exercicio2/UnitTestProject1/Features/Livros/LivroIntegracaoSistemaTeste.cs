using exercicio2.Aplicacao.Features.Livros;
using exercicio2.Exceptions;
using exercicio2.Features.Livros;
using exercicio2.Infra.Data;
using Exercicio2.ComumTeste;
using Exercicio2.ComumTeste.Base;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Features.Livros
{
    [TestFixture]
    public class LivroIntegracaoSistemaTeste
    {

        ILivroRepositorio _ILivroRepositorio;

        LivroService _livroService;

        [SetUp]
        public void InitializeObjects()
        {
            _ILivroRepositorio = new LivroSqlRepositorio();
            _livroService = new LivroService(_ILivroRepositorio);

            BaseSqlTest.SeedDatabase();
        }

        [Test]
        public void Livro_IntegracaoSistema_DeveFuncionar()
        {
            Livro livro = ObjectMother.ObterLivroValido();

            Livro result = _livroService.Adicionar(livro);

            result.Id.Should().BeGreaterThan(0);

            IList<Livro> livroList = _livroService.BuscarTodos();
        }

        [Test]
        public void Livro_DeleteIntegracaoSistema_DeveFuncionar()
        {
            Livro livro = ObjectMother.ObterLivroValido();

            _livroService.Deletar(livro);

            Livro livroGetById = _livroService.BuscarPorId(livro.Id);
            livroGetById.Should().BeNull();

            IList<Livro> livroList = _livroService.BuscarTodos();
            livroList.Count().Should().Be(0);
        }

        [Test]
        public void Livro_ObterPorIdIntegracaoSistema_DeveFuncionar()
        {
            Livro livro = ObjectMother.ObterLivroValido();

            Livro livroGetById = _livroService.BuscarPorId(livro.Id);

            livroGetById.Should().NotBeNull();

            livroGetById.Id.Should().Be(livro.Id);
        }

        [Test]
        public void Livro_ObterTodosIntegracaoSistema_DeveFuncionar()
        {
            IList<Livro> livrolist = _livroService.BuscarTodos();

            livrolist.Count.Should().Be(1);
            livrolist.First().Id.Should().Be(1);
        }

     
        [Test]
        public void Livro_UpdateIdVazioSistema_DeveFalhar()
        {
            Livro livro = ObjectMother.ObterLivroValido();
            livro.Id = 0;

            Action act = () => { _livroService.Atualizar(livro); };

            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Livro_DeleteIntegracaoSistema_DeveFalhar()
        {
            Livro livro = ObjectMother.ObterLivroValido();

            livro.Id = 0;

            Action act = () => { _livroService.Deletar(livro); };
            act.Should().Throw<IdentifierUndefinedException>();

            IList<Livro> livroList = _livroService.BuscarTodos();
            livroList.Count().Should().Be(1);
        }

        [Test]
        public void Livro_GetLivroIdNull_shouldFail()
        {
            Livro livro = ObjectMother.ObterLivroValido();

            livro.Id = 0;

            Action act = () => { _livroService.BuscarPorId(livro.Id); };
            act.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
