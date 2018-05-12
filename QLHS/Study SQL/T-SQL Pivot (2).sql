SELECT *
FROM
(
    SELECT [PolNumber],
           [PolType],
           [Effective Date],
           [DocName],
           [Submitted]
    FROM [dbo].[InsuranceClaims]

) AS SourceTable 
				PIVOT( AVG([Submitted]) FOR [DocName] IN([Doc A],
                                                         [Doc B],
                                                         [Doc C],
                                                         [Doc D],
                                                         [Doc E]
														 )
					) AS PivotTable;
