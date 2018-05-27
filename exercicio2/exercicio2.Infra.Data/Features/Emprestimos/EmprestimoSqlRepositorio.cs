using exercicio2.Features.Emprestimo;
using exercicio2.Features.Livros;
using Projeto_loterica.Infra;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio2.Infra.Data.Features.Emprestimos
{
    public class EmprestimoSqlRepositorio : IEmprestimoRepositorio
    {
        #region Queries
        public const string SqlInsert = @"Insert into TBEmprestimo(NomeCliente,DataDevolucao,Multa) values (@Nome,@DataDevolucao,@Multa)";
        public const string SqlUpdate = @"Update TBEmprestimo set DataDevolucao = @DataDevolucao, Multa = @Multa, NomeCliente = @Nome";
        public const string SqlDelete = @"Delete from TBEmprestimo where Id = @Id";
        public const string SqlGetById = @"Select * from TBEmprestimo as tbe where tbe.id = @Id ";
        public const string SqlGetAll =  @"Select * from TBEmprestimo";
        ///Comandos Table Secundaria
        public const string SqlDeleteSecundaria = @"Delete from TBLivro_Emprestimo where IdEmprestimo = @Id";
        public const string SqlInsertSecundaria = @"Insert into (IdEmprestimo,IdLivro) values (@Id,@IdLivro)";
    
        #endregion 
        public Emprestimo Adicionar(Emprestimo entidade)
        {
            entidade.Id = Db.Insert(SqlInsert, Take(entidade));
            foreach (var item in entidade.Livros)
            {
                Db.Insert(SqlInsertSecundaria, TakeSecundario(entidade, item));
            }
            return entidade;
        } 

        public Emprestimo Atualizar(Emprestimo entidade)
        {
            entidade.Validate();
            Db.Update(SqlUpdate, Take(entidade));
            return entidade;
        }
        public IList<Emprestimo> BuscarTodos()
        {
           return Db.GetAll(SqlGetAll, Make);
        }

        public void Deletar(Emprestimo entidade)
        {
            entidade.Validate();
            if (entidade.Livros.Count > 1)
            {
                foreach (var item in entidade.Livros)
                {
                    Db.Delete(SqlDeleteSecundaria, TakeSecundario(entidade, item));
                }
                Db.Delete(SqlDeleteSecundaria, Take(entidade));
            }
        }
        private object[] Take(Emprestimo emprestimo)
        {
            return new object[]
            {
               "@Id",emprestimo.Id,
               "@Multa",emprestimo.Multa,
               "@DataDevolucao",emprestimo.DataDevolucao,
               "@Nome",emprestimo.NomeCliente
            };
        }

        private object[] TakeSecundario(Emprestimo emprestimo,Livro Livro)
        {
            return new object[]
            {
               "@IdLivro",Livro.Id,
               "@IdEmprestimo",emprestimo.Id
            };
        }

        public Emprestimo BuscarPorId(long id)
        {
            return Db.Get(SqlGetById, Make);
        }

        private static Func<IDataReader, Emprestimo> Make = reader =>
            new Emprestimo
            {
                Id = Convert.ToInt32(reader["Id"]),
                DataDevolucao = Convert.ToDateTime(reader["DataDevolucao"]),
                Multa = Convert.ToDouble(reader["Multa"]),
                NomeCliente = Convert.ToString(reader["NomeCliente"]), 
            };
    }
}
    