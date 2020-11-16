CREATE TABLE [dbo].[Location]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[WarehouseId] INT NOT NULL,

	[Name] NVARCHAR(256) NOT NULL,
	[Description] NVARCHAR(MAX), 

    CONSTRAINT [FK_Location_Warehouse] FOREIGN KEY ([WarehouseId]) REFERENCES [Warehouse]([Id])
)
