using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio2.Features.Livros
{
    public class NameWithMinimumCharacterException : Exception
    {
        public NameWithMinimumCharacterException(string campo) : base("O campo " + campo + " não pode conter menos que 4 caracteres")
        {

        }
    }
}
