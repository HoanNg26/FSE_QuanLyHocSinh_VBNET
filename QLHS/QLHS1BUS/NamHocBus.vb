Imports QLHS1DAL
Imports QLHS1DTO
Imports Utility

Public Class NamHocBus
    Private nhDAL As NamHocDAL
    Public Sub New()
        nhDAL = New NamHocDAL()
    End Sub
    Public Sub New(connectionString As String)
        nhDAL = New NamHocDAL(connectionString)
    End Sub
    Public Function isValidName(nh As NamHocDTO) As Boolean

        If (nh.NamHoc.Length < 1) Then
            Return False
        End If

        Return True

    End Function

    Public Function insert(nh As NamHocDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return nhDAL.insert(nh)
    End Function
    Public Function update(nh As NamHocDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return nhDAL.update(nh)
    End Function
    Public Function delete(maLoai As Integer) As Result
        '1. verify data here!!

        '2. insert to DB
        Return nhDAL.delete(maLoai)
    End Function
    Public Function selectAll(ByRef listNamHoc As List(Of NamHocDTO)) As Result
        '1. verify data here!!

        '2. insert to DB
        Return nhDAL.selectALL(listNamHoc)
    End Function
    Public Function getNextID(ByRef nextID As Integer) As Result
        Return nhDAL.getNextID(nextID)
    End Function

    Public Function getNextTTNamHoc(ByRef nextTTNamHoc As Integer) As Result
        Return nhDAL.getNextTTNamHoc(nextTTNamHoc)
    End Function
End Class
