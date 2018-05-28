using exercicio2.Aplicacao.Features.Livros;
using exercicio2.Exceptions;
using exercicio2.Features.Livros;
using Exercicio2.ComumTeste;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio2.AplicacaoTeste.Features.Livros
{
    [TestFixture]
    public class LivroAplicacaoTeste
    {
        LivroService livroService;
        Mock<ILivroRepositorio> mockRepositorio;

        [SetUp]
        public void InitializeObjects()
        {
            mockRepositorio = new Mock<ILivroRepositorio>();
            livroService = new LivroService(mockRepositorio.Object);
        }
        [Test]
        public void LivroService_CriarRepositorio_DeveFuncionar()
        {
            Livro Livro = ObjectMother.ObterLivroValido();
            Livro.Id = 0;
            mockRepositorio.Setup(m => m.Adicionar(Livro)).Returns(new Livro { Id = 1 });

            Livro result = livroService.Adicionar(Livro);

            result.Id.Should().BeGreaterThan(0);
            mockRepositorio.Verify(m => m.Adicionar(Livro));
        }

        [Test]
        public void LivroService_BuscaTodos_DeveFuncionar()
        {
            Livro Livro = ObjectMother.ObterLivroValido();

            IList<Livro> ListaLivro = new List<Livro>();
            ListaLivro.Add(Livro);
            mockRepositorio.Setup(m => m.BuscarTodos()).Returns(ListaLivro);

            IList<Livro> Result = livroService.BuscarTodos();

            Result.First().Id.Should().Be(1);
            Result.Count().Should().Be(1);

            mockRepositorio.Verify(m => m.BuscarTodos());
        }

        [Test]
        public void LivroService_BuscaPorId_DeveFuncionar()
        {
            Livro Livro = ObjectMother.ObterLivroValido(); mockRepositorio.Setup(m => m.BuscarPorId(Livro.Id)).Returns(Livro);

            Livro result = livroService.BuscarPorId(Livro.Id);

            result.Should().NotBeNull();
            result.Id.Should().Be(1);

            mockRepositorio.Verify(m => m.BuscarPorId(Livro.Id));
        }

        [Test]
        public void LivroService_BuscaPorId_DeveFalhar()
        {
            Livro Livro = ObjectMother.ObterLivroValido();
            Livro.Id = 0;
            Action act = () => { livroService.BuscarPorId(Livro.Id); };

            act.Should().Throw<IdentifierUndefinedException>();

            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void LivroService_Deletar_DeveFalhar()
        {
            Livro Livro = ObjectMother.ObterLivroValido();
            Livro.Id = 0;

            Action act = () => { livroService.Deletar(Livro); };

            act.Should().Throw<IdentifierUndefinedException>();

            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void LivroService_Update_DeveFuncionar()
        {
            Livro Livro = ObjectMother.ObterLivroValido();
            Livro.Volume = 5;

            Livro result = livroService.Atualizar(Livro);

            mockRepositorio.Verify(m => m.Atualizar(Livro));
        }

        [Test]
        public void LivroService_Update_DeveFalhar()
        {
            Livro Livro = ObjectMother.ObterLivroValido();
            Livro.Id = 0;

            Action act = () => { livroService.Atualizar(Livro); };

            act.Should().Throw<IdentifierUndefinedException>();

            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void LivroService_Delete_DeveFuncionar()
        {
            Livro Livro = ObjectMother.ObterLivroValido();
            mockRepositorio.Setup(m => m.Deletar(Livro));
            livroService.Deletar(Livro);
            mockRepositorio.Verify(m => m.Deletar(Livro));
        }
    }
}
