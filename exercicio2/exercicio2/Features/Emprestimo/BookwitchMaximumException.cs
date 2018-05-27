using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio2.Features.Emprestimo
{
    public class BookwitchMaximumException : Exception
    {
        public BookwitchMaximumException() : base("a quantidade de Livros não pode ser maior que 5")
        {

        }
    }
}
