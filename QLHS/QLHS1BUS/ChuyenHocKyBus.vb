Imports QLHS1DAL
Imports QLHS1DTO
Imports Utility
Public Class ChuyenHocKyBus
    Private diemDAL As ChuyenHocKyDAL
    Private lopDAL As LopDAL
    Private lopHS As LopHocSinhDAL
    Public Sub New()
        diemDAL = New ChuyenHocKyDAL()
        lopDAL = New LopDAL()
        lopHS = New LopHocSinhDAL()
    End Sub
    Public Sub New(connectionString As String)
        diemDAL = New ChuyenHocKyDAL(connectionString)
        lopDAL = New LopDAL(connectionString)
        lopHS = New LopHocSinhDAL(connectionString)
    End Sub
    Public Function chuyenHocKy(chk As ChuyenHocKyDTO) As Result
        '1. get list lop of current Hoc Ky
        Dim listLopCurrrent = New List(Of LopDTO)
        Dim result = lopDAL.selectALL_ByMaKhoiAndMaHocKy(chk.MaKhoi, chk.MaHocKy_FROM, listLopCurrrent)
        If (result.FlagResult = False) Then
            Return result
        End If

        '2. Create list: new Lop with the same 'Ten lop' for the next Hoc Ky
        Dim listLopNext = New List(Of LopDTO)
        For Each lp As LopDTO In listLopCurrrent
            Dim newLp = New LopDTO(0, lp.TenLop, lp.MaKhoi, chk.MaHocKy_To)
            result = lopDAL.insert(newLp)
            If (result.FlagResult = False) Then
                Return result
            End If
            listLopNext.Add(newLp)
        Next
        '3. Get student of current Lop and movement
        Dim listLop_HS = New List(Of LopHocSinhDTO)
        Dim n = listLopCurrrent.Count - 1
        For i = 0 To n
            result = lopHS.selectALL_ByMaLop(listLopCurrrent(i).MaLop, listLop_HS)
            If (result.FlagResult = False) Then
                Return result
            End If
            For Each llhs As LopHocSinhDTO In listLop_HS
                Dim newlop_HS = New LopHocSinhDTO(listLopNext(i).MaLop, llhs.MSHS)
                result = lopHS.insert(newlop_HS)
                If (result.FlagResult = False) Then
                    Return result
                End If
            Next
        Next i

        Return New Result(True)
    End Function



End Class
