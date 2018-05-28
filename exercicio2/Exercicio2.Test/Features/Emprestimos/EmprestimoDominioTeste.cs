using exercicio2.Exceptions;
using exercicio2.Features.Emprestimo;
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

namespace Exercicio2.Test.Features.Emprestimos
{
    [TestFixture]
    public class EmprestimoDominioTeste
    {
        Mock<Livro> LivroMock;

        [SetUp]
        public void InitializeObjects()
        {
            LivroMock = new Mock<Livro>();
            LivroMock.Object.Id = 1;
        }

        [Test]
        public void CriarEmprestimoValido_DeveFuncionar()
        {
            IList<Livro> ListaLivros = new List<Livro>();
            ListaLivros.Add(LivroMock.Object);
            Emprestimo emprestimo = ObjectMother.ObterEmprestimoValido(ListaLivros);
            emprestimo.Validate();
            emprestimo.Id.Should().Be(1);
        }

        [Test]
        public void Emprestimo_DataDevolucaoNula_NaoDeveFuncionar()
        {
            Emprestimo Emprestimo = ObjectMother.ObterEmprestimoInvalidoData();
            Action act = Emprestimo.Validate;
            act.Should().Throw<NulloFieldException>("Data");
        }

        [Test]
        public void Emprestimo_IdZerado_NaoDeveFuncionar()
        {
            Emprestimo Emprestimo = ObjectMother.ObterEmprestimoInvalidoNome();
            Emprestimo.Id = 0;
            Action act = Emprestimo.Validate;
            act.Should().Throw<IdentifierUndefinedException>();
        }
        [Test]
        public void Emprestimo_NomeClienteVazio_NaoDeveFuncionar()
        {
            Emprestimo Emprestimo = ObjectMother.ObterEmprestimoInvalidoNome();
            Action act = Emprestimo.Validate;
            act.Should().Throw<StringIsNullOrEmptyException>();
        }
        [Test]
        public void CriarEmprestimoInvalidoQuantidadeMaximaLivros_DeveFalhar()
        {
            IList<Livro> ListaLivros = new List<Livro>();
            ListaLivros.Add(LivroMock.Object);
            ListaLivros.Add(LivroMock.Object);
            ListaLivros.Add(LivroMock.Object);
            ListaLivros.Add(LivroMock.Object);
            ListaLivros.Add(LivroMock.Object);
            ListaLivros.Add(LivroMock.Object);
            Emprestimo emprestimo = ObjectMother.ObterEmprestimoValido(ListaLivros);
            Action act = () => emprestimo.Validate();
            act.Should().Throw<BookwitchMaximumException>();
        }

        [Test]
        public void CriarEmprestimoInvalidoQuantidadeMinimaLivros_DeveFalhar()
        {
            IList<Livro> ListaLivros = new List<Livro>();
            ListaLivros.Add(LivroMock.Object);
            Emprestimo emprestimo = ObjectMother.ObterEmprestimoValido(ListaLivros);
            emprestimo.Livros.Clear();
            Action act = () => emprestimo.Validate();
            act.Should().Throw<BookwitchMinimumException>();
        }

        [Test]
        public void Emprestimo_CalcularMulta_DeveFuncionar()
        {
            IList<Livro> ListaLivros = new List<Livro>();
            ListaLivros.Add(LivroMock.Object);
            Emprestimo emprestimo = ObjectMother.ObterEmprestimoValido(ListaLivros);
            emprestimo.CalcularMulta(DateTime.Now.AddDays(-5));
            emprestimo.Multa.Should().BeGreaterThan(0);
        }

    }
}
