CREATE TABLE [dbo].[Item]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[LocationId] INT NOT NULL,

	[Name] NVARCHAR(256) NOT NULL,
	[Weight] DECIMAL NOT NULL,
	[Description] NVARCHAR(MAX), 

    CONSTRAINT [FK_Item_Location] FOREIGN KEY ([LocationId]) REFERENCES [Location]([Id])
)
