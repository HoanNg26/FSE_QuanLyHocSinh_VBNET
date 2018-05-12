Imports QLHS1DAL
Imports QLHS1DTO
Imports Utility

Public Class DiemBus
    Private diemDAL As DiemDAL
    Public Sub New()
        diemDAL = New DiemDAL()
    End Sub
    Public Sub New(connectionString As String)
        diemDAL = New DiemDAL(connectionString)
    End Sub

    Public Function insert(diemDTO As DiemDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return diemDAL.insert(diemDTO)
    End Function
    Public Function update(diemDTO As DiemDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return diemDAL.update(diemDTO)
    End Function
    Public Function delete(diemDTO As DiemDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return diemDAL.delete(diemDTO)
    End Function
    Public Function selectMonHoc_ByMaLop(maLop As String, listMonHoc As List(Of MonHocDTO)) As Result
        Return diemDAL.selectMonHoc_ByMaLop(maLop, listMonHoc)
    End Function
    Public Function selectDiem_LeftJoinByMaHSMaLopMaMonHoc(maHocSinh As String, maLop As Integer, maMonHoc As Integer, listDiemView As List(Of DiemViewDTO)) As Result
        Return diemDAL.selectDiem_LeftJoinByMaHSMaLopMaMonHoc(maHocSinh, maLop, maMonHoc, listDiemView)
    End Function
    Public Function selectALLHTDG_ByMaLopAndMaMonHoc(iMaLop As Integer, iMaMonHoc As Integer, listHTDG As List(Of HinhThucDanhGiaDTO)) As Result
        Return diemDAL.selectALLHTDG_ByMaLopAndMaMonHoc(iMaLop, iMaMonHoc, listHTDG)
    End Function
    Public Function selectDiem_LeftJoinByMaLopMaMonHocMaHTDG(maLop As Integer, maMonHoc As Integer, maHTDG As Integer, listDiemView As List(Of DiemViewDTO)) As Result
        Return diemDAL.selectDiem_LeftJoinByMaLopMaMonHocMaHTDG(maLop, maMonHoc, maHTDG, listDiemView)
    End Function
End Class
