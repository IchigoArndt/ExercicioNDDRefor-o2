using Projeto_loterica.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio2.ComumTeste.Base
{
    public static class BaseSqlTest
    {
        private const string DELETE_LIVRO_TABLE = "DELETE FROM [dbo].[TBLivro] DBCC CHECKIDENT('[dbo].[TBLivro]', RESEED, 0)";
        private const string INSERT_Livro = "INSERT INTO TBLivro(Titulo,Tema,Autor,Disponivel,DataPublicacao,Volume) VALUES ('Lobos de Calla','Romance/Terror','Stephen King',1,GETDATE(),1)";
        private const string Delete_Emprestimo_Table = "DELETE FROM [dbo].[TBEmprestimo] DBCC CHECKIDENT('[dbo].[TBEmprestimo]', RESEED, 0)";
        private const string Insert_Emprestimo_Table = "Insert into TBEmprestimo(DataDevolucao,Multa,NomeCliente) values (GETDATE(),12.50,'Luiz')";
        private const string Delete_Emprestimo_Livro_Table = "Delete TBLivro_Emprestimo DBCC CHECKIDENT('[dbo].[TBLivro_Emprestimo]', RESEED, 0)";
        private const string Insert_Livro_Emprestimo = "Insert into TBLivro_Emprestimo(IdEmprestimo,IdLivro) values (1,1)";
        public static void SeedDatabase()
        {
            Db.Update(DELETE_LIVRO_TABLE);
            Db.Update(Delete_Emprestimo_Table);
            Db.Update(Delete_Emprestimo_Livro_Table);
            //inserts
            Db.Update(INSERT_Livro);
            Db.Update(Insert_Emprestimo_Table);
            Db.Update(Insert_Livro_Emprestimo);
        }

    }
}
