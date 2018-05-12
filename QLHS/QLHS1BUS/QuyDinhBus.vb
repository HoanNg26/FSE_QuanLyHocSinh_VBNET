Imports QLHS1DTO
Imports Utility

Public Class QuyDinhBus
    Private qdDAL As QuyDinhDAL
    Public Sub New()
        qdDAL = New QuyDinhDAL()
    End Sub
    Public Sub New(connectionString As String)
        qdDAL = New QuyDinhDAL(connectionString)
    End Sub
    Public Function update(qd As QuyDinhDTO) As Result
        Return qdDAL.update(qd)
    End Function

    Public Function selectALL(ByRef quydinh As List(Of QuyDinhDTO)) As Result
        Return qdDAL.selectALL(quydinh)
    End Function
End Class
