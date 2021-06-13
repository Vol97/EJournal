﻿CREATE TABLE [EJournal].[Comments] (
	[Id] INT IDENTITY(1, 1) NOT NULL
	,[Comment] NVARCHAR(255) NOT NULL
	,[CommentType] NVARCHAR(100) NOT NULL
	,CONSTRAINT [PK_COMMENTS] PRIMARY KEY CLUSTERED ([Id] ASC)
	,
	);
