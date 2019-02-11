CREATE TABLE [dbo].[ClassProps] (
    [ClassPropID] BIGINT          NOT NULL,
    [ClassID]     BIGINT          NOT NULL,
    [PropName]    NVARCHAR (50)   NOT NULL,
    [ArrayIndex]  INT             NOT NULL,
    [Encrypt_ID]  VARBINARY (255) NULL,
    CONSTRAINT [PK_ClassProps] PRIMARY KEY CLUSTERED ([ClassPropID] ASC),
    CONSTRAINT [FK_ClassProps_Class] FOREIGN KEY ([ClassID]) REFERENCES [dbo].[Classes] ([ClassID])
);





