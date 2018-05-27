using exercicio2.Base;
using exercicio2.Exceptions;
using exercicio2.Features.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio2.Features.Livros
{
    public class Livro : Entidade
    {
        public string Titulo { get; set; }
        public string Tema { get; set; }
        public string Autor { get; set; }
        public int Volume { get; set; }
        public DateTime? DataPublicação { get; set; }
        public bool Disponivel { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(this.Autor))
                throw new StringIsNullOrEmptyException("Nome do autor");
            if (string.IsNullOrEmpty(this.Titulo))
                throw new StringIsNullOrEmptyException("Titulo do livro");
            if (string.IsNullOrEmpty(this.Tema))
                throw new StringIsNullOrEmptyException("Tema do livro");
            //Validações de nomes com caracteres abaixo do minimo
            if (this.Autor.Length < 4)
                throw new NameWithMinimumCharacterException("Nome Autor");
            if (this.Tema.Length < 4)
                throw new NameWithMinimumCharacterException("Tema do Livro");
            if (this.Titulo.Length < 4)
                throw new NameWithMinimumCharacterException("Titulo do livro");
            //Validações de nomes com caracteres acima do maximo
            if (this.Autor.Length > 50)
                throw new NameWithmaximumCharacterException("Nome Autor");
            if (this.Tema.Length > 50)
                throw new NameWithmaximumCharacterException("Tema do Livro");
            if (this.Titulo.Length > 50)
                throw new NameWithmaximumCharacterException("Titulo do livro");
            //Validações iguais a zero
            if (this.Id == 0)
                throw new IdentifierUndefinedException();
            if (this.Volume == 0)
                throw new VolumeUndefinedException();
            //Data nula
            if (this.DataPublicação == null)
                throw new NulloFieldException("Data");
        }
    }
}
