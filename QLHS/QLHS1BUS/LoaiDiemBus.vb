Imports QLHS1DAL
Imports QLHS1DTO
Imports Utility

Public Class LoaiDiemBus
    Private ldDAL As LoaiDiemDAL
    Public Sub New()
        ldDAL = New LoaiDiemDAL()
    End Sub
    Public Sub New(connectionString As String)
        ldDAL = New LoaiDiemDAL(connectionString)
    End Sub
    Public Function isValidName(nh As LoaiDiemDTO) As Boolean

        If (nh.LoaiDiem.Length < 1) Then
            Return False
        End If

        Return True

    End Function

    Public Function insert(nh As LoaiDiemDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return ldDAL.insert(nh)
    End Function
    Public Function update(nh As LoaiDiemDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return ldDAL.update(nh)
    End Function
    Public Function delete(maLoai As Integer) As Result
        '1. verify data here!!

        '2. insert to DB
        Return ldDAL.delete(maLoai)
    End Function
    Public Function selectAll(ByRef listNamHoc As List(Of LoaiDiemDTO)) As Result
        '1. verify data here!!

        '2. insert to DB
        Return ldDAL.selectALL(listNamHoc)
    End Function
    Public Function getNextID(ByRef nextID As Integer) As Result
        Return ldDAL.getNextID(nextID)
    End Function
End Class
