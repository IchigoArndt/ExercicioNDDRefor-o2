using exercicio2.Exceptions;
using exercicio2.Features.Livros;
using Exercicio2.ComumTeste;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio2.Test.Features.Livros
{
    [TestClass]
    public class LivroDominioTeste
    {
        [Test]
        public void CriarLivroValido_DeveFuncionar()
        {
            Livro livro = ObjectMother.ObterLivroValido();
            livro.Validate();
            livro.Id.Should().Be(1);
        }

        [Test]
        public void Livro_DataPublicacaoVazia_NaoDeveFuncionar()
        {
            Livro Livro = ObjectMother.ObterLivroInvalidoDataNulla();
            Action act = Livro.Validate;
            act.Should().Throw<NulloFieldException>("Data");
        }

        [Test]
        public void Livro_IdZerado_NaoDeveFuncionar()
        {
            Livro Livro = ObjectMother.ObterLivroInvalidoId();
            Action act = Livro.Validate;
            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Livro_AutorMinimoCaracter_NaoDeveFuncionar()
        {
            Livro Livro = ObjectMother.ObterLivroInvalidoAutorMinimoCaracter();
            Action act = Livro.Validate;
            act.Should().Throw<NameWithMinimumCharacterException>();
        }

        [Test]
        public void Livro_TituloMinimoCaracter_NaoDeveFuncionar()
        {
            Livro Livro = ObjectMother.ObterLivroInvalidoTituloMinimoCaracter();
            Action act = Livro.Validate;
            act.Should().Throw<NameWithMinimumCharacterException>();
        }

        [Test]
        public void Livro_TemaMinimoCaracter_NaoDeveFuncionar()
        {
            Livro Livro = ObjectMother.ObterLivroInvalidoTemaMinimoCaracter();
            Action act = Livro.Validate;
            act.Should().Throw<NameWithMinimumCharacterException>();
        }

        [Test]
        public void Livro_TemaMaximoCaracter_NaoDeveFuncionar()
        {
            Livro Livro = ObjectMother.ObterLivroInvalidoTemaMaximoCaracter();
            Action act = Livro.Validate;
            act.Should().Throw<NameWithmaximumCharacterException>();
        }

        [Test]
        public void Livro_TituloMaximoCaracter_NaoDeveFuncionar()
        {
            Livro Livro = ObjectMother.ObterLivroInvalidoTituloMaximoCaracter();
            Action act = Livro.Validate;
            act.Should().Throw<NameWithmaximumCharacterException>();
        }

        [Test]
        public void Livro_AutorMaximoCaracter_NaoDeveFuncionar()
        {
            Livro Livro = ObjectMother.ObterLivroInvalidoAutorMaximoCaracter();
            Action act = Livro.Validate;
            act.Should().Throw<NameWithmaximumCharacterException>();
        }

        [Test]
        public void Livro_VolumeZerado_NaoDeveFuncionar()
        {
            Livro Livro = ObjectMother.ObterLivroInvalidoVolumeZerado();
            Action act = Livro.Validate;
            act.Should().Throw<VolumeUndefinedException>();
        }

        [Test]
        public void Livro_AutorVazio_NaoDeveFuncionar()
        {
            Livro Livro = ObjectMother.ObterLivroInvalidoAutorZerado();
            Action act = Livro.Validate;
            act.Should().Throw<StringIsNullOrEmptyException>();
        }

        [Test]
        public void Livro_TituloVazio_NaoDeveFuncionar()
        {
            Livro Livro = ObjectMother.ObterLivroInvalidoTituloVazio();
            Action act = Livro.Validate;
            act.Should().Throw<StringIsNullOrEmptyException>();
        }

        [Test]
        public void Livro_TemaVazio_NaoDeveFuncionar()
        {
            Livro Livro = ObjectMother.ObterLivroInvalidoTemaVazio();
            Action act = Livro.Validate;
            act.Should().Throw<StringIsNullOrEmptyException>();
        }
    }

 }
