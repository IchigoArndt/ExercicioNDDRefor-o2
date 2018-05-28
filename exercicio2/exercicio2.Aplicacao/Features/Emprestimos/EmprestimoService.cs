using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercicio2.Exceptions;
using exercicio2.Features.Emprestimo;

namespace exercicio2.Aplicacao.Features.Emprestimos
{
    public class EmprestimoService : IEmprestimoService
    {
        IEmprestimoRepositorio _repositorio;

        public EmprestimoService(IEmprestimoRepositorio Repositorio)
        {
            _repositorio = Repositorio;
        }

        public Emprestimo Adicionar(Emprestimo entidade)
        {
            //entidade.Validate();
            entidade =  _repositorio.Adicionar(entidade);
            return entidade;
        }

        public Emprestimo Atualizar(Emprestimo entidade)
        {
            entidade.Validate();
            entidade = _repositorio.Atualizar(entidade);
            return entidade;
        }

        public Emprestimo BuscarPorId(long id)
        {
            if (id != 0)
                return _repositorio.BuscarPorId(id);
            else
                throw new IdentifierUndefinedException();
        }

        public IList<Emprestimo> BuscarTodos()
        {
            return _repositorio.BuscarTodos();
        }

        public void Deletar(Emprestimo entidade)
        {
            entidade.Validate();
            _repositorio.Deletar(entidade);
        }
    }
}
