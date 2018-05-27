CREATE TABLE [dbo].[TBLivro]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [Titulo] VARCHAR(50) NOT NULL, 
    [Tema] VARCHAR(50) NOT NULL, 
    [Autor] VARCHAR(50) NOT NULL, 
    [Disponivel] BIT NOT NULL, 
    [DataPublicacao] DATETIME NOT NULL, 
    [Volume] INT NOT NULL,

)
