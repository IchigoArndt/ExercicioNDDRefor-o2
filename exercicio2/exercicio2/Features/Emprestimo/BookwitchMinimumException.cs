using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio2.Features.Emprestimo
{
   public class BookwitchMinimumException : Exception
    {
        public BookwitchMinimumException() : base("O Livro não pode ser menor 1")
        {

        }


    }
}
