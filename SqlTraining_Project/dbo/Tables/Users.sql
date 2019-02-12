CREATE TABLE [dbo].[Users] (
    [Username]        NVARCHAR (50)  NOT NULL,
    [Password]        NVARCHAR (50)  NOT NULL,
    [FirstName]       NVARCHAR (50)  NOT NULL,
    [LastName]        NVARCHAR (50)  NOT NULL,
    [Settings]        NVARCHAR (500) NULL,
    [ActivityTimeout] BIGINT         DEFAULT ((0)) NOT NULL,
    [LastLogged]      DATETIME2 (7)  NULL,
    PRIMARY KEY CLUSTERED ([Username] ASC)
);

