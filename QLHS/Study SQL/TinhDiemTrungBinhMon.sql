-- Ma Hs: 14000002
-- ma lop: 5
-- Ma mon hoc: 1

select tbldiem.mahocsinh,tblchitietchuongtrinh.mamonhoc
	,sum(tbldiem.diemso * tblhinhthucdanhgia.hesodiem)/sum(tblhinhthucdanhgia.hesodiem) as diemtrungbinh
from tblapdung
 ,tblchuongtrinh
 ,tblchitietchuongtrinh
 ,tblhinhthucdanhgia
 ,tbldiem
where
	tblchitietchuongtrinh.mamonhoc = 1
	and tbldiem.mahocsinh =N'14000002'
	and tblapdung.malop = 5
	and tblapdung.machuongtrinh=tblchuongtrinh.machuongtrinh 
	and tblchuongtrinh.machuongtrinh = tblchitietchuongtrinh.machuongtrinh 
	and tblchitietchuongtrinh.machitietchuongtrinh = tblhinhthucdanhgia.machitietchuongtrinh 
	and tblhinhthucdanhgia.mahinhthucdanhgia = tbldiem.mahinhthucdanhgia 

group by tbldiem.mahocsinh,tblchitietchuongtrinh.mamonhoc
