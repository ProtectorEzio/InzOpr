CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [liczba_eksponatow] INT NOT NULL, 
    [liczba_gosci] INT NOT NULL, 
    [typ_wystawy] VARCHAR(50) NULL, 
    [data_rozpoczecia] VARCHAR(50) NOT NULL, 
    [godzina_rozpoczecia] INT NOT NULL, 
    [czas_trwania] INT NOT NULL
)
