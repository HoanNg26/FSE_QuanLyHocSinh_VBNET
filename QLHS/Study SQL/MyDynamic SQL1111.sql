DECLARE @columns NVARCHAR(MAX), @sql NVARCHAR(MAX);
SET @columns = N'';
SELECT @columns+=N', p.'+QUOTENAME([Name])
FROM
(
    SELECT [mahinhthucdanhgia]  AS [Name]
    FROM [dbo].[tblhinhthucdanhgia]  AS p
    --GROUP BY [machitietchuongtrinh] 
) AS x;
SET @sql = N'
SELECT [mahocsinh], '+STUFF(@columns, 1, 2, '')+' FROM (
SELECT [mahocsinh], [diemso] AS [diemso1], [mahinhthucdanhgia] as [Name] 
    FROM [dbo].[tbldiem]) AS j PIVOT(sum(diemso1) FOR [Name] in 
	   ('+STUFF(REPLACE(@columns, ', p.[', ',['), 1, 1, '')+')) AS p;';
EXEC sp_executesql @sql