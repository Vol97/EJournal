﻿CREATE PROCEDURE [dbo].[GetAllGroups]
   AS
   SELECT  [Id]
      ,[Name]
      ,[IdCourse]
      ,[IsFinish]
  FROM .[dbo].[Groups]
  where IsDelete = 0