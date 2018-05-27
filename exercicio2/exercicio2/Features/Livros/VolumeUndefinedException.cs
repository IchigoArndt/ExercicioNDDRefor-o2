using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio2.Features.Livros
{
    public class VolumeUndefinedException : Exception
    {
        public VolumeUndefinedException() : base("O volume não pode ser vazio")
        {

        }
    }
}
