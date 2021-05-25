﻿CREATE TABLE [dbo].[Groups] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [NameGroup] NVARCHAR (100) NOT NULL,
    [IdCourse]  INT            NOT NULL,
    [IsFinish]  BIT            NOT NULL,
    [IsDelete]  BIT            CONSTRAINT [DF__Groups__IsDele__239E4DCF] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_GROUPS] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Groups_CourseNames_Id] FOREIGN KEY ([IdCourse]) REFERENCES [dbo].[CourseNames] ([Id])
);