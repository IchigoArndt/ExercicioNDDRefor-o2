using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio2.Exceptions
{
    public class StringIsNullOrEmptyException : Exception
    {
        public StringIsNullOrEmptyException(string campo) : base("O campo " + campo + " não pode ficar vazio")
        {

        }
    }
}
