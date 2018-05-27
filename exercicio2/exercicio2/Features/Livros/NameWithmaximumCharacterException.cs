using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio2.Features.Livros
{
    public class NameWithmaximumCharacterException : Exception
    {
        public NameWithmaximumCharacterException(string campo) : base("O campo " + campo + " não pode conter menos que 50 caracteres")
        {

        }
    }
}
