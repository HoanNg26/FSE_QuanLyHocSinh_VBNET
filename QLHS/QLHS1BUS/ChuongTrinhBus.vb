Imports QLHS1DAL
Imports QLHS1DTO
Imports Utility

Public Class ChuongTrinhBus
    Private ctDAL As ChuongTrinhDAL
    Public Sub New()
        ctDAL = New ChuongTrinhDAL()
    End Sub
    Public Sub New(connectionString As String)
        ctDAL = New ChuongTrinhDAL(connectionString)
    End Sub
    Public Function isValidName(ct As ChuongTrinhDTO) As Boolean

        If (ct.TenCT.Length < 1) Then
            Return False
        End If

        Return True

    End Function

    Public Function insertCT(ct As ChuongTrinhDTO) As Result

        Return ctDAL.insertCT(ct)

    End Function

    Public Function insertCTCT(ctct As ChiTietChuongTrinhDTO) As Result
        Return ctDAL.insertCTCT(ctct)
    End Function

    Public Function insertHTDG(htdg As HinhThucDanhGiaDTO) As Result
        Return ctDAL.insertHTDG(htdg)
    End Function

    Public Function deleteHTDG(htdg As HinhThucDanhGiaDTO) As Result
        Return ctDAL.deleteHTDG(htdg)
    End Function

    Public Function deleteCTCT(ctct As ChiTietChuongTrinhDTO) As Result
        Return ctDAL.deleteCTCT(ctct)
    End Function

    Public Function deleteCT(ct As ChuongTrinhDTO) As Result

        Return ctDAL.deleteCT(ct)
    End Function

    Public Function select_byMaCT(iMaCT As Integer, listCT As List(Of ChuongTrinhDTO)) As Result
        Return ctDAL.select_byMaCT(iMaCT, listCT)
    End Function

    Public Function selectALL(listCT As List(Of ChuongTrinhDTO)) As Result

        Return ctDAL.selectALL(listCT)
    End Function

    Public Function selectALLCTCT_ByMaCT(iMaCT As Integer, listCTCT As List(Of ChiTietChuongTrinhDTO)) As Result

        Return ctDAL.selectALLCTCT_ByMaCT(iMaCT, listCTCT)
    End Function

    Public Function selectALLHTDG_ByMaCTCT(iMaCTCT As Integer, listHTDG As List(Of HinhThucDanhGiaDTO)) As Result

        Return ctDAL.selectALLHTDG_ByMaCTCT(iMaCTCT, listHTDG)
    End Function

    Public Function updateCT_MasterPart(ct As ChuongTrinhDTO) As Result
        Return ctDAL.updateCT_MasterPart(ct)

    End Function

    Public Function updateCT_Cascade(ct As ChuongTrinhDTO) As Result

        Return ctDAL.updateCT_Cascade(ct)
    End Function

    Public Function updateCTCT(ctct As ChiTietChuongTrinhDTO) As Result

        Return ctDAL.updateCTCT(ctct)
    End Function

    Public Function updateCTCT_Cascade(ctct As ChiTietChuongTrinhDTO) As Result

        Return ctDAL.updateCTCT_Cascade(ctct)
    End Function

    Public Function updateHTDG(htdg As HinhThucDanhGiaDTO) As Result
        Return ctDAL.updateHTDG(htdg)

    End Function
End Class
