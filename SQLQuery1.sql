SELECT 
COUNT(fm.Name) CountFiles, 
ROUND(SUM((fm.Size / 1024) / 1024), 2)  SizeMb, 
dm.Path 
FROM FileModels fm
JOIN DirectoryModels dm ON dm.Id = fm.DirectoryId
GROUP BY dm.Path