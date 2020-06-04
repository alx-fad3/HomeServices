CREATE PROCEDURE [dbo].[sp_RemoveEmptyDirectories]
AS
	WITH a AS(
	SELECT dm.Id, dm.Name dName, dm.Path, fm.Name
	FROM DirectoryModels dm
	LEFT JOIN FileModels fm on fm.DirectoryId = dm.Id
	WHERE fm.Name IS NULL
	)
	DELETE
	FROM DirectoryModels
	WHERE Id in (SELECT Id FROM a)
RETURN 0