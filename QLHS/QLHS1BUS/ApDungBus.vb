Imports QLHS1DAL
Imports QLHS1DTO
Imports Utility

Public Class ApDungBus
    Private apdungDAL As ApDungDAL
    Public Sub New()
        apdungDAL = New ApDungDAL()
    End Sub
    Public Sub New(connectionString As String)
        apdungDAL = New ApDungDAL(connectionString)
    End Sub

    Public Function insert(apdung As ApDungDTO) As Result
        Return apdungDAL.insert(apdung)
    End Function

    Public Function insertForce(apdung As ApDungDTO) As Result
        Return apdungDAL.insertForce(apdung)
    End Function


    Public Function selectALL(ByRef listApDung As List(Of ApDungDTO)) As Result
        Return apdungDAL.selectALL(listApDung)
    End Function

    Public Function selectALL_ByMaLop(iMaLop As Integer, ByRef listApDung As List(Of ApDungDTO)) As Result
        Return apdungDAL.selectALL_ByMaLop(iMaLop, listApDung)
    End Function

    Public Function selectALL_ByMaCT(iMaCT As Integer, ByRef listApDung As List(Of ApDungDTO)) As Result
        Return apdungDAL.selectALL_ByMaCT(iMaCT, listApDung)
    End Function


    Public Function delete(apdung As ApDungDTO) As Result
        Return apdungDAL.delete(apdung)
    End Function


    Public Function selectALL_LeftJoin(iMaHocKy As Integer, iMaKhoi As Integer, ByRef listApDung As List(Of ApDungDTO)) As Result
        Return apdungDAL.selectALL_LeftJoin(iMaHocKy, iMaKhoi, listApDung)
    End Function
End Class
