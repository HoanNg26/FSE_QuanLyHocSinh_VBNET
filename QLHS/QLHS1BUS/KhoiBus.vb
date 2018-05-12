Imports QLHS1DAL
Imports QLHS1DTO
Imports Utility

Public Class KhoiBus
    Private khDAL As KhoiDAL
    Public Sub New()
        khDAL = New KhoiDAL()
    End Sub
    Public Sub New(connectionString As String)
        khDAL = New KhoiDAL(connectionString)
    End Sub
    Public Function isValidName(kh As KhoiDTO) As Boolean

        If (kh.Khoi.Length < 1) Then
            Return False
        End If

        Return True

    End Function

    Public Function insert(kh As KhoiDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return khDAL.insert(kh)
    End Function
    Public Function update(kh As KhoiDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return khDAL.update(kh)
    End Function
    Public Function delete(maLoai As Integer) As Result
        '1. verify data here!!

        '2. insert to DB
        Return khDAL.delete(maLoai)
    End Function
    Public Function selectAll(ByRef listKhoi As List(Of KhoiDTO)) As Result
        '1. verify data here!!

        '2. insert to DB
        Return khDAL.selectALL(listKhoi)
    End Function
    Public Function getNextID(ByRef nextID As Integer) As Result
        Return khDAL.getNextID(nextID)
    End Function

    Public Function getNextTTKhoi(ByRef nextTTKhoi As Integer) As Result
        Return khDAL.getNextTTKhoi(nextTTKhoi)
    End Function
End Class
