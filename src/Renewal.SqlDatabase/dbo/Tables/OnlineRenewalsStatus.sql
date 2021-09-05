CREATE TABLE [dbo].[OnlineRenewalsStatus]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [Text] NVARCHAR(50) NULL, 
    CONSTRAINT [PK_OnlineRenewalsStatus] PRIMARY KEY ([Id])
)
