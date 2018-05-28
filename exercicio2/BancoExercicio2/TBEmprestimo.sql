CREATE TABLE [dbo].[TBEmprestimo]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [DataDevolucao] DATETIME NOT NULL, 
    [Multa] DECIMAL(18, 2) NULL, 
    [NomeCliente] VARCHAR(50) NOT NULL
)
