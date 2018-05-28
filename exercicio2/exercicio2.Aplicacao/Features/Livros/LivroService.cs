using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercicio2.Exceptions;
using exercicio2.Features.Livros;

namespace exercicio2.Aplicacao.Features.Livros
{
    public class LivroService : ILivroService
    {
        ILivroRepositorio _repositorio;
        public LivroService(ILivroRepositorio Repositorio)
        {
            _repositorio = Repositorio;
        }
        public Livro Adicionar(Livro entidade)
        {
            ////entidade.Validate();
            entidade = _repositorio.Adicionar(entidade);
            return entidade;
        }

        public Livro Atualizar(Livro entidade)
        {
            entidade.Validate();
            entidade = _repositorio.Atualizar(entidade);
            return entidade;
        }

        public Livro BuscarPorId(long id)
        {
            if (id != 0)
                return _repositorio.BuscarPorId(id);
            else
                throw new IdentifierUndefinedException();
        }

        public IList<Livro> BuscarTodos()
        {
            return _repositorio.BuscarTodos();
        }

        public void Deletar(Livro entidade)
        {
            entidade.Validate();
            _repositorio.Deletar(entidade);
        }
    }
}
