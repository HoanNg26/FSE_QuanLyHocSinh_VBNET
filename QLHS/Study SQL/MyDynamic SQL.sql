DECLARE @columns NVARCHAR(MAX), @sql NVARCHAR(MAX);
SET @columns = N'';
SELECT @columns+=N', p.'+QUOTENAME([Name])
FROM
(
    SELECT [mamonhoc] AS [Name]
    FROM [dbo].[tblchitietchuongtrinh] AS p
    --GROUP BY [mamonhoc]
) AS x;
SET @sql = N'
SELECT [machitietchuongtrinh], '+STUFF(@columns, 1, 2, '')+' FROM (
SELECT [machitietchuongtrinh], [hesomon] AS [hesomon1], [mamonhoc] as [Name] 
    FROM [dbo].[tblchitietchuongtrinh]) AS j PIVOT(sum(hesomon1) FOR [Name] in 
	   ('+STUFF(REPLACE(@columns, ', p.[', ',['), 1, 1, '')+')) AS p;';
EXEC sp_executesql @sql