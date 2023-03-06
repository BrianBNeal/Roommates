CREATE TABLE [dbo].[Chore] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (55) NOT NULL,
    [PointValue] INT NOT NULL DEFAULT 1, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

