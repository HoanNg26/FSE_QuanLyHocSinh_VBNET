Imports QLHS1DAL
Imports QLHS1DTO
Imports Utility

Public Class LoaiHocSinhBUS
    Private lhsDAL As LoaiHocSinhDAL
    Public Sub New()
        lhsDAL = New LoaiHocSinhDAL()
    End Sub
    Public Sub New(connectionString As String)
        lhsDAL = New LoaiHocSinhDAL(connectionString)
    End Sub
    Public Function isValidName(lhs As LoaiHocSinhDTO) As Boolean

        If (lhs.TenLoai.Length < 1) Then
            Return False
        End If

        Return True

    End Function

    Public Function insert(lhs As LoaiHocSinhDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return lhsDAL.insert(lhs)
    End Function
    Public Function update(lhs As LoaiHocSinhDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return lhsDAL.update(lhs)
    End Function
    Public Function delete(maLoai As Integer) As Result
        '1. verify data here!!

        '2. insert to DB
        Return lhsDAL.delete(maLoai)
    End Function
    Public Function selectAll(ByRef listLoaiHS As List(Of LoaiHocSinhDTO)) As Result
        '1. verify data here!!

        '2. insert to DB
        Return lhsDAL.selectALL(listLoaiHS)
    End Function
    Public Function getNextID(ByRef nextID As Integer) As Result
        Return lhsDAL.getNextID(nextID)
    End Function
End Class
