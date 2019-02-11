CREATE TABLE [dbo].[Classes] (
    [ClassID]    BIGINT        NOT NULL,
    [ClassName]  NVARCHAR (50) NOT NULL,
    [ArrayIndex] INT           NOT NULL,
    CONSTRAINT [PK_Classes] PRIMARY KEY CLUSTERED ([ClassID] ASC)
);

