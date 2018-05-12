Imports QLHS1DAL
Imports QLHS1DTO
Imports Utility

Public Class LopBus
    Private lopDAL As LopDAL
    Public Sub New()
        lopDAL = New LopDAL()
    End Sub
    Public Sub New(connectionString As String)
        lopDAL = New LopDAL(connectionString)
    End Sub
    Public Function isValidName(lop As LopDTO) As Boolean

        If (lop.TenLop.Length < 1) Then
            Return False
        End If

        Return True

    End Function

    Public Function insert(lop As LopDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return lopDAL.insert(lop)
    End Function
    Public Function update(lop As LopDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return lopDAL.update(lop)
    End Function
    Public Function delete(maLoai As Integer) As Result
        '1. verify data here!!

        '2. insert to DB
        Return lopDAL.delete(maLoai)
    End Function
    Public Function selectAll(ByRef listLop As List(Of LopDTO)) As Result
        '1. verify data here!!

        '2. insert to DB
        Return lopDAL.selectALL(listLop)
    End Function
    Public Function selectALL_ByMaKhoi(iMaKhoi As Integer, ByRef listLop As List(Of LopDTO)) As Result
        '1. verify data here!!

        '2. insert to DB
        Return lopDAL.selectALL_ByMaKhoi(iMaKhoi, listLop)
    End Function
    Public Function selectALL_ByMaKhoiAndMyHocKy(iMaKhoi As Integer, iMaHocKy As Integer, ByRef listLop As List(Of LopDTO)) As Result
        '1. verify data here!!

        '2. insert to DB
        Return lopDAL.selectALL_ByMaKhoiAndMaHocKy(iMaKhoi, iMaHocKy, listLop)
    End Function

    Public Function getNextID(ByRef nextID As Integer) As Result
        Return lopDAL.getNextID(nextID)
    End Function
End Class
