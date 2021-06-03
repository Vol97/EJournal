﻿CREATE PROCEDURE [dbo].[GetListStudentsInOneProjectGroup] @IdProjectGroup INT
AS
SELECT pg.Id AS ProjectGroupID
	,pg.Name
	,s.Id
	,s.Name
	,s.Surname
	,s.Phone
	,s.Email
	,s.Git
	,s.City
	,s.Ranking
	,s.AgreementNumber
	,s.IsDelete
FROM [dbo].[StudetsProjectGroup] AS spg
INNER JOIN [dbo].[ProjectGroups] pg ON pg.Id = spg.IdProjectGroup
INNER JOIN [dbo].[Students] AS s ON spg.IdStudent = s.Id
WHERE spg.IdProjectGroup = @IdProjectGroup
