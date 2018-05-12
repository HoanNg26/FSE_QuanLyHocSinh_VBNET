Imports QLHS1BUS
Imports QLHS1DTO
Imports Utility

Public Class frmChuyenHocKy

    Private namhocBus As NamHocBus
    Private hockyBus As HocKyBus
    Private khoiBus As KhoiBus
    Private chuyenHocKyBus As ChuyenHocKyBus
    Private Sub btnThemLopVaChuyenHS_Click(sender As Object, e As EventArgs) Handles btnThemLopVaChuyenHS.Click
        Try
            Dim chkDTO = New ChuyenHocKyDTO()
            Dim tuHocKy = CType(cbTuHocKy.SELECTedItem, HocKyDTO)
            chkDTO.MaHocKy_FROM = tuHocKy.MaHocKy
            Dim sangHocKy = CType(cbSangHocKy.SELECTedItem, HocKyDTO)
            chkDTO.MaHocKy_To = sangHocKy.MaHocKy
            Dim khoi = CType(cbKhoi.SELECTedItem, KhoiDTO)
            chkDTO.MaKhoi = khoi.MaKhoi

            Dim result = chuyenHocKyBus.chuyenHocKy(chkDTO)
            If (result.FlagResult = False) Then
                MessageBox.Show("Chuyển Danh Sách Học Sinh Sang Học Kỳ mới không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Console.WriteLine(result.SystemMessage)
                Return
            Else
                MessageBox.Show("Chuyển Danh Sách Học Sinh Sang Học Kỳ mới thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnThemLopVaChuyenHS.Enabled = False
            End If
        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
        End Try
    End Sub

    Private Sub cbNamHoc_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cbNamHoc.SELECTedIndexChanged
        Try
            Dim namhoc = CType(cbNamHoc.SELECTedItem, NamHocDTO)
            Dim listHocKy = New List(Of HocKyDTO)
            Dim Result = hockyBus.selectALL_ByMaNamHoc(namhoc.MaNamHoc, listHocKy)
            If (Result.FlagResult = False) Then
                MessageBox.Show("Lấy danh sách Học Kỳ theo Năm Học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Console.WriteLine(Result.SystemMessage)
                Return
            End If

            cbTuHocKy.DataSource = New BindingSource(listHocKy, String.Empty)
            cbTuHocKy.DisplayMember = "HocKy"
            cbTuHocKy.ValueMember = "MaHocKy"
            Dim myCurrencyManager As CurrencyManager = Me.BindingContext(cbTuHocKy.DataSource)
            myCurrencyManager.Refresh()
            If (listHocKy.Count > 0) Then
                cbTuHocKy.SELECTedIndex = 0
            End If

            cbSangHocKy.DataSource = New BindingSource(listHocKy, String.Empty)
            cbSangHocKy.DisplayMember = "HocKy"
            cbSangHocKy.ValueMember = "MaHocKy"
            myCurrencyManager = Me.BindingContext(cbSangHocKy.DataSource)
            myCurrencyManager.Refresh()
            If (listHocKy.Count > 0) Then
                cbSangHocKy.SELECTedIndex = 0
            End If
        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
        End Try

    End Sub

    Private Sub frmChuyenHocKy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        namhocBus = New NamHocBus()
        hockyBus = New HocKyBus()
        khoiBus = New KhoiBus()
        chuyenHocKyBus = New ChuyenHocKyBus()

        ' Load Khoi list
        Dim listKhoi = New List(Of KhoiDTO)
        Dim result = khoiBus.selectAll(listKhoi)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Khối không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If
        cbKhoi.DataSource = New BindingSource(listKhoi, String.Empty)
        cbKhoi.DisplayMember = "Khoi"
        cbKhoi.ValueMember = "MaKhoi"
        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(cbKhoi.DataSource)
        myCurrencyManager.Refresh()
        If (listKhoi.Count > 0) Then
            cbKhoi.SELECTedIndex = 0
        End If
    End Sub

    Private Sub cbKhoi_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cbKhoi.SELECTedIndexChanged
        ' Load Nam Hoc list
        Dim listNamHoc = New List(Of NamHocDTO)
        Dim result As Result
        result = namhocBus.selectAll(listNamHoc)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Năm Học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        cbNamHoc.DataSource = New BindingSource(listNamHoc, String.Empty)
        cbNamHoc.DisplayMember = "NamHoc"
        cbNamHoc.ValueMember = "MaNamHoc"
        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(cbNamHoc.DataSource)
        myCurrencyManager.Refresh()
        If (listNamHoc.Count > 0) Then
            cbNamHoc.SELECTedIndex = 0
        End If
    End Sub
End Class