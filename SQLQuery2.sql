WITH a AS(
SELECT dm.Id, dm.Name dName, dm.Path, fm.Name
FROM DirectoryModels dm
LEFT JOIN FileModels fm on fm.DirectoryId = dm.Id
WHERE fm.Name IS NULL
)
SELECT *
--DELETE 
FROM DirectoryModels
WHERE Id in (SELECT Id FROM a)



--UPDATE FileModels
--SET Size = ROUND((Size / 1024) / 1024, 2)

select * from FileModels

