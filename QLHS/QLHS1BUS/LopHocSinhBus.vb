Imports QLHS1DAL
Imports QLHS1DTO
Imports Utility

Public Class LopHocSinhBus
    Private lopHocSinhDAL As LopHocSinhDAL
    Public Sub New()
        lopHocSinhDAL = New LopHocSinhDAL()
    End Sub
    Public Sub New(connectionString As String)
        lopHocSinhDAL = New LopHocSinhDAL(connectionString)
    End Sub


    Public Function insert(lhs As LopHocSinhDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return lopHocSinhDAL.insert(lhs)
    End Function
    Public Function update(lhs As LopHocSinhDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return lopHocSinhDAL.update(lhs)
    End Function
    Public Function delete(lhs As LopHocSinhDTO) As Result
        '1. verify data here!!

        '2. insert to DB

        Return lopHocSinhDAL.delete(lhs)
    End Function

    Public Function selectAll(ByRef listLopHocSinh As List(Of LopHocSinhDTO)) As Result
        '1. verify data here!!

        '2. insert to DB
        Return lopHocSinhDAL.selectALL(listLopHocSinh)
    End Function
    Public Function selectALL_ByMaLop(iMaLop As Integer, ByRef listLopHocSinh As List(Of LopHocSinhDTO)) As Result
        '1. verify data here!!

        '2. insert to DB
        Return lopHocSinhDAL.selectALL_ByMaLop(iMaLop, listLopHocSinh)
    End Function
    'Public Function selectALL_ByMaLopAndMaHocKy(iMaLop As Integer, iMaHocKy As Integer, ByRef listLopHocSinh As List(Of LopHocSinhDTO)) As Result
    '    '1. verify data here!!

    '    '2. insert to DB
    '    Return lopHocSinhDAL.selectALL_ByMaLopAndMaHocKy(iMaLop, iMaHocKy, listLopHocSinh)
    'End Function
End Class
