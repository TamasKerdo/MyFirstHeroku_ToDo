CREATE TABLE [dbo].[ToDos] (
    [Id]       BIGINT         IDENTITY (1, 1) NOT NULL,
    [IsDone]   BIT            NOT NULL,
    [IsUrgent] BIT            NOT NULL,
    [Title]    NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_ToDos] PRIMARY KEY CLUSTERED ([Id] ASC)
);

