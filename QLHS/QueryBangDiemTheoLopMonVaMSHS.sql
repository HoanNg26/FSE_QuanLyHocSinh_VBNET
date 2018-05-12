select [infoloaidiem].[mahocsinh], [infoloaidiem].[mamonhoc], [infoloaidiem].[tenmonhoc],  [infoloaidiem].[mahinhthucdanhgia], [infoloaidiem].[tenloaidiem], [infoloaidiem].[maloaidiem], [infoloaidiem].[hesodiem] ,[filterdiem].[diemso] 
from
(
select [tbllophocsinh].[mahocsinh],[tblmonhoc].[tenmonhoc], [tblmonhoc].[mamonhoc] , [tblloaidiem].[tenloaidiem], [tblloaidiem].[maloaidiem], [tblhinhthucdanhgia].[hesodiem], [tblhinhthucdanhgia].[mahinhthucdanhgia]
from 
	[tblhinhthucdanhgia]
	,[tblloaidiem]
	,[tblapdung]
	,[tblchuongtrinh]
	,[tblchitietchuongtrinh]
	,[tblmonhoc]
	,[tbllophocsinh]
where
	[tblapdung].[malop] = 1
	and  [tblmonhoc].[mamonhoc] = 1
	and  [tbllophocsinh].[mahocsinh] = N'16000001'
	and  [tblapdung].[machuongtrinh] = [tblchuongtrinh].[machuongtrinh]  
	and  [tblchuongtrinh].[machuongtrinh]  = [tblchitietchuongtrinh].[machuongtrinh]
	and  [tblchitietchuongtrinh].[machitietchuongtrinh] = [tblhinhthucdanhgia].[machitietchuongtrinh]  
	and  [tblchitietchuongtrinh].[mamonhoc] =  [tblmonhoc].[mamonhoc]
	AND  [tblhinhthucdanhgia].maloaidiem = [tblloaidiem].[maloaidiem]
	and  [tbllophocsinh].[malop] =  [tblapdung].[malop] 
) as [infoloaidiem]
left join 
(
	select *
	from [tbldiem]
	where 
	[tbldiem].[mahocsinh] =  N'16000001'
) as [filterdiem]
on [infoloaidiem].[mahinhthucdanhgia]=  [filterdiem].[mahinhthucdanhgia]