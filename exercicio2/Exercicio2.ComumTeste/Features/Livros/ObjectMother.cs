using exercicio2.Features.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio2.ComumTeste.Features.Livros
{
   public static partial class ObjectMother
   {
        public static Livro ObterLivroValido()
        {
            return new Livro
            {
                Id = 1,
                DataPublicação = DateTime.Now,
                Autor = "Stephen King",
                Tema = "Romance/Terror",
                Titulo = "Lobos de Calla",
                Disponivel = false,
                Volume = 1
            };
        }

        public static Livro ObterLivroInvalidoTituloMinimoCaracter()
        {
            return new Livro
            {
                Id = 1,
                DataPublicação = DateTime.Now,
                Autor = "Stephen King",
                Tema = "Romance/Terror",
                Titulo = "L",
                Disponivel = false,
                Volume = 1
            };
        }
        public static Livro ObterLivroInvalidoTituloMaximoCaracter()
        {
            return new Livro
            {
                Id = 1,
                DataPublicação = DateTime.Now,
                Autor = "Stephen King",
                Tema = "Romance/Terror",
                Titulo = "Lobos de Calla Lobos de Calla Lobos de Calla Lobos de Calla Lobos de Calla Lobos de Calla Lobos de Calla Lobos de Calla Lobos de Calla Lobos de Calla Lobos de Calla Lobos de Calla Lobos de Calla Lobos de Calla",
                Disponivel = false,
                Volume = 1
            };
        }
        public static Livro ObterLivroInvalidoTituloVazio()
        {
            return new Livro
            {
                Id = 1,
                DataPublicação = DateTime.Now,
                Autor = "Stephen King",
                Tema = "Romance/Terror",
                Titulo = "",
                Disponivel = false,
                Volume = 1
            };
        }
        public static Livro ObterLivroInvalidoTemaMinimoCaracter()
        {
            return new Livro
            {
                Id = 1,
                DataPublicação = DateTime.Now,
                Autor = "Stephen King",
                Tema = "R",
                Titulo = "Lobos de Calla",
                Disponivel = false,
                Volume = 1
            };
        }
        public static Livro ObterLivroInvalidoTemaMaximoCaracter()
        {
            return new Livro
            {
                Id = 1,
                DataPublicação = DateTime.Now,
                Autor = "Stephen King",
                Tema = "Romance/Terror Romance/Terror Romance/Terror Romance/Terror Romance/Terror Romance/Terror Romance/Terror Romance/Terror Romance/Terror Romance/Terror Romance/Terror",
                Titulo = "Lobos de Calla",
                Disponivel = false,
                Volume = 1
            }; 
        }
        public static Livro ObterLivroInvalidoTemaVazio()
        {
            return new Livro
            {
                Id = 1,
                DataPublicação = DateTime.Now,
                Autor = "Stephen King",
                Tema = "",
                Titulo = "Lobos de Calla",
                Disponivel = false,
                Volume = 1
            };
        }
        public static Livro ObterLivroInvalidoAutorMinimoCaracter()
        {
            return new Livro
            {
                Id = 1,
                DataPublicação = DateTime.Now,
                Autor = "S",
                Tema = "Romance/Terror",
                Titulo = "Lobos de Calla",
                Disponivel = false,
                Volume = 1
            };
        }
        public static Livro ObterLivroInvalidoAutorMaximoCaracter()
        {
            return new Livro
            {
                Id = 1,
                DataPublicação = DateTime.Now,
                Autor = "Stephen King Stephen King Stephen King Stephen King Stephen King Stephen King Stephen King Stephen King Stephen King Stephen King Stephen King Stephen King Stephen King Stephen King Stephen King Stephen King Stephen King Stephen King Stephen King Stephen King Stephen King Stephen King",
                Tema = "Romance/Terror",
                Titulo = "Lobos de Calla",
                Disponivel = false,
                Volume = 1
            };
        }
        public static Livro ObterLivroInvalidoAutorZerado()
        {
            return new Livro
            {
                Id = 1,
                DataPublicação = DateTime.Now,
                Autor = "",
                Tema = "Romance/Terror",
                Titulo = "Lobos de Calla",
                Disponivel = false,
                Volume = 1
            };
        }
        public static Livro ObterLivroInvalidoId()
        {
            return new Livro
            {
                Id = 0,
                DataPublicação = DateTime.Now,
                Autor = "Stephen King",
                Tema = "Romance/Terror",
                Titulo = "Lobos de Calla",
                Disponivel = false,
                Volume = 1
            };
        }
        public static Livro ObterLivroInvalidoDataNulla()
        {
            return new Livro
            {
                Id = 1,
                DataPublicação = null,
                Autor = "Stephen King",
                Tema = "Romance/Terror",
                Titulo = "Lobos de Calla",
                Disponivel = false,
                Volume = 1
            };
        }
        public static Livro ObterLivroInvalidoVolumeZerado()
        {
            return new Livro
            {
                Id = 1,
                DataPublicação = null,
                Autor = "Stephen King",
                Tema = "Romance/Terror",
                Titulo = "Lobos de Calla",
                Disponivel = false,
                Volume = 0
            };
        }
    }
}
