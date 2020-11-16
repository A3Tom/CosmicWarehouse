CREATE TABLE [dbo].[ItemStock]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[ItemId] INT NOT NULL,
	[Weight] INT NOT NULL,
	[Active] BIT NOT NULL, 

    CONSTRAINT [FK_ItemStock_Item] FOREIGN KEY ([ItemId]) REFERENCES [Item]([Id])
)
