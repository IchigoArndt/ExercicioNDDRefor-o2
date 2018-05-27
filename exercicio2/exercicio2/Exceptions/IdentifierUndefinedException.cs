using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio2.Exceptions
{
    public class IdentifierUndefinedException : Exception
    {
        public IdentifierUndefinedException() : base("O id não pode ser vazio")
        {

        }
    }
}
