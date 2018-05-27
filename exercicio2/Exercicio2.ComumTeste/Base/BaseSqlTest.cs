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

        public static void SeedDatabase()
        {
            Db.Update(DELETE_LIVRO_TABLE);
            //inserts
            Db.Update(INSERT_Livro);
        }

    }
}
