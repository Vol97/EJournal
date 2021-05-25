﻿CREATE TABLE [dbo].[Students] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (100) NOT NULL,
    [Surname]         NVARCHAR (100) NOT NULL,
    [Email]           NVARCHAR (100) NOT NULL,
    [Phone]           NVARCHAR (16)  NOT NULL,
    [Git]             NVARCHAR (100) NULL,
    [AgreementNumber] NVARCHAR (50)  NOT NULL,
    [IsDelete]        BIT            CONSTRAINT [DF__Students__IsDele__239E4DCF] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_STUDENTS] PRIMARY KEY CLUSTERED ([Id] ASC)
);