Imports QLHS1DAL
Imports QLHS1DTO
Imports Utility

Public Class HocKyBus
    Private hkDAL As HocKyDAL
    Public Sub New()
        hkDAL = New HocKyDAL()
    End Sub
    Public Sub New(connectionString As String)
        hkDAL = New HocKyDAL(connectionString)
    End Sub
    Public Function isValidName(hk As HocKyDTO) As Boolean

        If (hk.HocKy.Length < 1) Then
            Return False
        End If

        Return True

    End Function

    Public Function insert(hk As HocKyDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return hkDAL.insert(hk)
    End Function
    Public Function update(hk As HocKyDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return hkDAL.update(hk)
    End Function
    Public Function delete(maLoai As Integer) As Result
        '1. verify data here!!

        '2. insert to DB
        Return hkDAL.delete(maLoai)
    End Function
    Public Function selectAll(ByRef listHocKy As List(Of HocKyDTO)) As Result
        '1. verify data here!!

        '2. insert to DB
        Return hkDAL.selectALL(listHocKy)
    End Function
    Public Function selectALL_ByMaNamHoc(iMaNamHoc As Integer, ByRef listHocKy As List(Of HocKyDTO)) As Result
        '1. verify data here!!

        '2. insert to DB
        Return hkDAL.selectALL_ByMaNamHoc(iMaNamHoc, listHocKy)
    End Function
    Public Function getNextID(ByRef nextID As Integer) As Result
        Return hkDAL.getNextID(nextID)
    End Function

    Public Function getNextTTHocKy(iMaNamHoc As Integer, ByRef nextTTHocKy As Integer) As Result
        Return hkDAL.getNextTTHocKy(iMaNamHoc, nextTTHocKy)
    End Function
End Class
