CREATE TABLE [dbo].[TBLivro_Emprestimo]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [IdLivro] INT NOT NULL, 
    [IdEmprestimo] INT NOT NULL
)
