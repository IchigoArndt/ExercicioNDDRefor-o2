CREATE TABLE [dbo].[TBEmprestimo]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [DataDevolucao] DATETIME NOT NULL, 
    [Multa] DECIMAL NULL, 
    [NomeCliente] VARCHAR(50) NOT NULL
)
