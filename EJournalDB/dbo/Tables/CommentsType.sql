﻿CREATE TABLE [dbo].[CommentTypes] (
	[Id] INT IDENTITY(1, 1) NOT NULL
	,[Type] NVARCHAR(50) NOT NULL
	,CONSTRAINT [PK_COMMENTTYPES] PRIMARY KEY CLUSTERED ([Id] ASC)
	);