using exercicio2.Features.Livros;
using Projeto_loterica.Infra;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio2.Infra.Data
{
    public class LivroSqlRepositorio : ILivroRepositorio
    {
        #region Queries
        //Comando para inserir e atualizar
        public const string SqlInsert = @"Insert Into TBLivro(Titulo,Tema,Autor,Disponivel,DataPublicacao,Volume)
                                          values(@Titulo,@Tema,@Autor,@Disponivel,@DataPublicacao,@Volume)";
        public const string SqlUpdate = @"Update TBLivro set Tema = @Tema, Autor = @Autor, Disponivel = @Disponivel,
                                          DataPublicacao = @DataPublicacao, Volume = @Volume";
        //Comando para deletar 
        public const string SqlDelete = @"Delete from TBLivro where Id = @Id";
        //Comando para Buscar um Registro um banco ou todos os registros
        public const string SqlGetById = @"Select * from TBLivro where Id = @Id";
        public const string SqlGetAll =  @"Select * from TBLivro";
        #endregion

        public Livro Adicionar(Livro entidade)
        {
            entidade.Id =  Db.Insert(SqlInsert,Take(entidade));
            return entidade;
        }

        public Livro Atualizar(Livro entidade)
        {
            entidade.Validate();
            Db.Update(SqlUpdate,Take(entidade));
            return entidade;
        }

        public Livro BuscarPorId(long id)
        {
            return Db.Get(SqlGetById, Make, new object[] { "@Id", id });
        }

        public IList<Livro> BuscarTodos()
        {
            return Db.GetAll(SqlGetAll, Make);
        }

        public void Deletar(Livro entidade)
        {
            entidade.Validate();
            Db.Delete(SqlDelete, Take(entidade));
        }

        private object[] Take(Livro livro)
        {
            return new object[]
            {
               "@Id",livro.Id,
               "@Titulo",livro.Titulo,
               "@Tema",livro.Tema,
               "@Autor",livro.Autor,
               "@Disponivel",livro.Disponivel,
               "@DataPublicacao",livro.DataPublicação,
               "@Volume",livro.Volume
            };
        }
        private static Func<IDataReader, Livro> Make = reader =>
            new Livro
            {
                Id = Convert.ToInt64(reader["Id"]),
                DataPublicação = Convert.ToDateTime(reader["DataPublicacao"]),
                Volume = Convert.ToInt32(reader["Volume"]),
                Disponivel = Convert.ToBoolean(reader["Disponivel"]),
                Autor  = reader["Autor"].ToString(),
                Tema = reader["Tema"].ToString(),
                Titulo = reader["Titulo"].ToString()
            };
    }
}
