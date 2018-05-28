using exercicio2.Features.Emprestimo;
using exercicio2.Features.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio2.ComumTeste
{
    public static partial class ObjectMother
    {
        public static Emprestimo ObterEmprestimoValido(IList<Livro> livros)
        {
            return new Emprestimo
            {
                Id = 1,
                Livros = livros,
                DataDevolucao = DateTime.Now.AddDays(1),
                Multa = 0,
                NomeCliente = "Luiz"
            };
        }

        public static Emprestimo ObterEmprestimoInvalidoData()
        {
            return new Emprestimo
            {
                Id = 1,
                Livros = null,
                DataDevolucao = null,
                Multa = 0,
                NomeCliente = "Luiz"
            };
        }
        public static Emprestimo ObterEmprestimoInvalidoNome()
        {
            return new Emprestimo
            {
                Id = 1,
                Livros = null,
                DataDevolucao = null,
                Multa = 0,
                NomeCliente = ""
            };
        }
    }
}
