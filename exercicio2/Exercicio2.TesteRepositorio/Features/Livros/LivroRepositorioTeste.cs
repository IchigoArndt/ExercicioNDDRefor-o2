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

namespace Exercicio2.TesteRepositorio.Features.Livros
{
    public class LivroRepositorioTeste
    {
     ILivroRepositorio _repositorio;

        [SetUp]
        public void InitializeObjects()
        {
            BaseSqlTest.SeedDatabase();
            _repositorio = new LivroSqlRepositorio();
        }

        [Test]
        public void Livro_CriarRepositorio_DeveFuncionar()
        {
            Livro Livro = ObjectMother.ObterLivroValido();
            Livro.Id = 0;

            Livro = _repositorio.Adicionar(Livro);

            Livro.Id.Should().BeGreaterThan(0);

        }

        [Test]
        public void Livro_AtualizarRepositorio_DeveFuncionar()
        {
            Livro Livro = ObjectMother.ObterLivroValido();

            Livro.Tema = "Terror/Suspense";

            Livro = _repositorio.Atualizar(Livro);

            Livro Result = ObjectMother.ObterLivroValido();

            Result.Tema.Should().NotBe(Livro.Tema);
        }

        [Test]
        public void Livro_AtualizarRepositorio_DeveFalhar()
        {
            Livro Livro = ObjectMother.ObterLivroValido();

            Livro.Tema = "Terror/Suspense";

            Livro.Id = 0;

            Action act = () => { _repositorio.Atualizar(Livro); };

            act.Should().Throw<IdentifierUndefinedException>();
        }


        [Test]
        public void Livro_DeletarRepositorio_DeveFuncionar()
        {
            Livro Livro = ObjectMother.ObterLivroValido();

            _repositorio.Deletar(Livro);

            Livro Result = _repositorio.BuscarPorId(Livro.Id);

            Result.Should().BeNull();
        }

        [Test]
        public void Livro_DeletarRepositorio_DeveFalhar()
        {
            Livro Livro = ObjectMother.ObterLivroValido();

            Livro.Id = 0;

            Action act = () =>_repositorio.Deletar(Livro);

            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Livro_ObterLivroRepositorio_DeveFuncionar()
        {
            Livro Livro = _repositorio.BuscarPorId(1);

            Livro.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Livro_ObterTodosRepositorios_DeveFuncionar()
        {
            Livro Livro = ObjectMother.ObterLivroValido();

            IList<Livro> ListaLivro = _repositorio.BuscarTodos();

            ListaLivro.Count().Should().Be(1);

            ListaLivro.First().Id.Should().Be(1);
        }
    }
}
