CREATE PROCEDURE HardDeleteAllProjects
AS
DELETE FROM [Projects]
DBCC CHECKIDENT ([Projects], RESEED, 0)