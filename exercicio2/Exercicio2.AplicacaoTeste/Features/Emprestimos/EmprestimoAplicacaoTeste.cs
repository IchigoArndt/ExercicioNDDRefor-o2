using exercicio2.Aplicacao.Features.Emprestimos;
using exercicio2.Exceptions;
using exercicio2.Features.Emprestimo;
using exercicio2.Features.Livros;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercicio2.ComumTeste;

namespace Exercicio2.AplicacaoTeste.Features.Emprestimos
{
    [TestFixture]
    public class EmprestimoAplicacaoTeste
    {
        EmprestimoService emprestimoService;
        Mock<IEmprestimoRepositorio> mockRepositorio;

        [SetUp]
        public void InitializeObjects()
        {
            mockRepositorio = new Mock<IEmprestimoRepositorio>();
            emprestimoService = new EmprestimoService(mockRepositorio.Object);
        }
        [Test]
        public void EmprestimoService_CriarRepositorio_DeveFuncionar()
        {
            Livro livro = ObjectMother.ObterLivroValido();
            IList<Livro> ListaLivros = new List<Livro>();
            ListaLivros.Add(livro);
            Emprestimo Emprestimo = ObjectMother.ObterEmprestimoValido(ListaLivros);
            Emprestimo.Id = 0;
            mockRepositorio.Setup(m => m.Adicionar(Emprestimo)).Returns(new Emprestimo { Id = 1 });

            Emprestimo result = emprestimoService.Adicionar(Emprestimo);

            result.Id.Should().BeGreaterThan(0);
            mockRepositorio.Verify(m => m.Adicionar(Emprestimo));
        }

        [Test]
        public void EmprestimoService_BuscaTodos_DeveFuncionar()
        {
            Livro livro = ObjectMother.ObterLivroValido();
            IList<Livro> ListaLivros = new List<Livro>();
            ListaLivros.Add(livro);
            Emprestimo Emprestimo = ObjectMother.ObterEmprestimoValido(ListaLivros);

            IList<Emprestimo> ListaEmprestimo = new List<Emprestimo>();
            ListaEmprestimo.Add(Emprestimo);
            mockRepositorio.Setup(m => m.BuscarTodos()).Returns(ListaEmprestimo);

            IList<Emprestimo> Result = emprestimoService.BuscarTodos();

            Result.First().Id.Should().Be(1);
            Result.Count().Should().Be(1);

            mockRepositorio.Verify(m => m.BuscarTodos());
        }

        [Test]
        public void EmprestimoService_BuscaPorId_DeveFuncionar()
        {
            Livro livro = ObjectMother.ObterLivroValido();
            IList<Livro> ListaLivros = new List<Livro>();
            ListaLivros.Add(livro);
            Emprestimo Emprestimo = ObjectMother.ObterEmprestimoValido(ListaLivros);

            mockRepositorio.Setup(m => m.BuscarPorId(Emprestimo.Id)).Returns(Emprestimo);

            Emprestimo result = emprestimoService.BuscarPorId(Emprestimo.Id);

            result.Should().NotBeNull();
            result.Id.Should().Be(1);

            mockRepositorio.Verify(m => m.BuscarPorId(Emprestimo.Id));
        }

        [Test]
        public void EmprestimoService_BuscaPorId_DeveFalhar()
        {
            Livro livro = ObjectMother.ObterLivroValido();
            IList<Livro> ListaLivros = new List<Livro>();
            ListaLivros.Add(livro);
            Emprestimo Emprestimo = ObjectMother.ObterEmprestimoValido(ListaLivros);
            Emprestimo.Id = 0;
            Action act = () => { emprestimoService.BuscarPorId(Emprestimo.Id); };

            act.Should().Throw<IdentifierUndefinedException>();

            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void EmprestimoService_Deletar_DeveFalhar()
        {
            Livro livro = ObjectMother.ObterLivroValido();
            IList<Livro> ListaLivros = new List<Livro>();
            ListaLivros.Add(livro);
            Emprestimo Emprestimo = ObjectMother.ObterEmprestimoValido(ListaLivros);
            Emprestimo.Id = 0;

            Action act = () => { emprestimoService.Deletar(Emprestimo); };

            act.Should().Throw<IdentifierUndefinedException>();

            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void EmprestimoService_Update_DeveFuncionar()
        {
            Livro livro = ObjectMother.ObterLivroValido();
            IList<Livro> ListaLivros = new List<Livro>();
            ListaLivros.Add(livro);
            Emprestimo Emprestimo = ObjectMother.ObterEmprestimoValido(ListaLivros);
            Emprestimo.NomeCliente = "Joao";

            Emprestimo result = emprestimoService.Atualizar(Emprestimo);

            mockRepositorio.Verify(m => m.Atualizar(Emprestimo));
        }

        [Test]
        public void EmprestimoService_Update_DeveFalhar()
        {
            Livro livro = ObjectMother.ObterLivroValido();
            IList<Livro> ListaLivros = new List<Livro>();
            ListaLivros.Add(livro);
            Emprestimo Emprestimo = ObjectMother.ObterEmprestimoValido(ListaLivros);

            Emprestimo.Id = 0;

            Action act = () => { emprestimoService.Atualizar(Emprestimo); };

            act.Should().Throw<IdentifierUndefinedException>();

            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void EmprestimoService_Delete_DeveFuncionar()
        {
            Livro livro = ObjectMother.ObterLivroValido();
            IList<Livro> ListaLivros = new List<Livro>();
            ListaLivros.Add(livro);
            Emprestimo Emprestimo = ObjectMother.ObterEmprestimoValido(ListaLivros);

            mockRepositorio.Setup(m => m.Deletar(Emprestimo));
            emprestimoService.Deletar(Emprestimo);
            mockRepositorio.Verify(m => m.Deletar(Emprestimo));
        }
    }
}
