CREATE TABLE [dbo].[Cotacoes]
(
	[Sigla] CHAR(3) NOT NULL PRIMARY KEY, 
    [NomeMoeda] VARCHAR(30) NOT NULL, 
    [UltimaCotacao] DATETIME NOT NULL, 
    [Valor] NUMERIC(18, 4) NOT NULL
)