﻿CREATE PROCEDURE [EJournal].[SearchStudentAll]
AS
	SELECT [Id]
	,[Name]
	,[Surname]
	,[Email]
	,[Phone]
	,[Git]
	,[City]
	,[Ranking]
	,[AgreementNumber]
FROM [EJournal].[Students]
WHERE IsDelete = 0