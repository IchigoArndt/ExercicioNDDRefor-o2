using exercicio2.Base;
using exercicio2.Exceptions;
using exercicio2.Features.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio2.Features.Emprestimo
{
    public class Emprestimo : Entidade
    {
        public string NomeCliente { get; set; }
        public IList<Livro> Livros { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public double Multa { get; set; }
        public double PrecoMulta { get { return 2.50; }}
        public void Validate()
        {
            if (this.Id == 0)
                throw new IdentifierUndefinedException();
            if (string.IsNullOrEmpty(NomeCliente))
                throw new StringIsNullOrEmptyException("Nome Cliente");
            if (this.DataDevolucao == null)
                throw new NulloFieldException("Data de Devolução");
            if (this.Livros.Count() < 1 || this.Livros == null)
                throw new BookwitchMinimumException();
            if (this.Livros.Count() > 5)
                throw new BookwitchMaximumException();
        }

        public void CalcularMulta(DateTime DataDevolucao)
        {
            double TotalDeDias = (int)DataDevolucao.Subtract(DateTime.Now).TotalDays;

            this.Multa = TotalDeDias * PrecoMulta;
            if (this.Multa < 0)
                this.Multa = this.Multa * -1;
        }
    }
}
