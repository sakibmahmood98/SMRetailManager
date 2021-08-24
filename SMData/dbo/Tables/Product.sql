CREATE TABLE [dbo].[Product]
(
    [Id]           INT            NOT NULL,
    [ProductName]  NVARCHAR (100) NOT NULL,
    [Description]  NVARCHAR (MAX) NOT NULL,
    [CreateDate]   DATETIME2 (7)  DEFAULT (getutcdate()) NOT NULL,
    [LastModified] DATETIME2 (7)  DEFAULT (getutcdate()) NOT NULL,
    [RetailPrice] MONEY NOT NULL, 
    [QuantityInStock] INT NOT NULL, 
    [IsTaxable] BIT NOT NULL DEFAULT 1, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


