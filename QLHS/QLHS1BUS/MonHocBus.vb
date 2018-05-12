Imports QLHS1DAL
Imports QLHS1DTO
Imports Utility

Public Class MonHocBus
    Private mhDAL As MonHocDAL
    Public Sub New()
        mhDAL = New MonHocDAL()
    End Sub
    Public Sub New(connectionString As String)
        mhDAL = New MonHocDAL(connectionString)
    End Sub
    Public Function isValidName(mh As MonHocDTO) As Boolean

        If (mh.MonHoc.Length < 1) Then
            Return False
        End If

        Return True

    End Function

    Public Function insert(mh As MonHocDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return mhDAL.insert(mh)
    End Function
    Public Function update(mh As MonHocDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return mhDAL.update(mh)
    End Function
    Public Function delete(maMonHoc As Integer) As Result
        '1. verify data here!!

        '2. insert to DB
        Return mhDAL.delete(maMonHoc)
    End Function
    Public Function selectAll(ByRef listMonHoc As List(Of MonHocDTO)) As Result
        '1. verify data here!!

        '2. insert to DB
        Return mhDAL.selectALL(listMonHoc)
    End Function
    Public Function getNextID(ByRef nextID As Integer) As Result
        Return mhDAL.getNextID(nextID)
    End Function
End Class
