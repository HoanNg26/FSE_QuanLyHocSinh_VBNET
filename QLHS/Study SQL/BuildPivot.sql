select t1.mshs, t1.mcttt
from
(
select tbldiem.mahocsinh as mshs, tblhinhthucdanhgia.machitietchuongtrinh as mcttt,tblhinhthucdanhgia.mahinhthucdanhgia as mhtdg , tbldiem.diemso as ds, tblhinhthucdanhgia.maloaidiem as ld, tblhinhthucdanhgia.hesodiem as hs
from tblhinhthucdanhgia
	,tbldiem
where
	tblhinhthucdanhgia.mahinhthucdanhgia = tbldiem.mahinhthucdanhgia
order by tbldiem.mahocsinh
) as t1;