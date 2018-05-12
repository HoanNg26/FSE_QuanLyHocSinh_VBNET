DECLARE @columns NVARCHAR(MAX), @sql NVARCHAR(MAX);
SET @columns = N'';
--SELECT @columns+=N', p.'+QUOTENAME([Name])
--FROM
--(
--    SELECT [DocName] AS [Name]
--    FROM [dbo].[InsuranceClaims] AS p
--    GROUP BY [DocName]
--) AS x;

SET @columns = N', p.[Doc A], p.[Doc B], p.[Doc C], p.[Doc D], p.[Doc E], p.[Doc F]';

SET @sql = N'
SELECT [PolNumber], '+STUFF(@columns, 1, 2, '')+' FROM (
SELECT [PolNumber], [Submitted] AS [Quantity], [DocName] as [Name] 
    FROM [dbo].[InsuranceClaims]) AS j PIVOT (SUM(Quantity) FOR [Name] in 
	   ('+STUFF(REPLACE(@columns, ', p.[', ',['), 1, 1, '')+')) AS p;';
EXEC sp_executesql @sql