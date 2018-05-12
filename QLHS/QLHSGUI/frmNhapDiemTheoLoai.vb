Imports QLHS1BUS
Imports QLHS1DTO
Imports Utility

Public Class frmNhapDiemTheoLoai

    Private namhocBus As NamHocBus
    Private hockyBus As HocKyBus
    Private khoiBus As KhoiBus
    Private lopBus As LopBus
    Private diemBus As DiemBus
    Private Sub frmNhapDiemTheoLoai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        namhocBus = New NamHocBus()
        hockyBus = New HocKyBus()
        khoiBus = New KhoiBus()
        lopBus = New LopBus()
        diemBus = New DiemBus()

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
            cbKhoi.SelectedIndex = 0
        End If
    End Sub

    Private Sub cbKhoi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbKhoi.SelectedIndexChanged
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
            cbNamHoc.SelectedIndex = 0
        End If
    End Sub

    Private Sub cbNamHoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbNamHoc.SelectedIndexChanged
        Try
            Dim namhoc = CType(cbNamHoc.SelectedItem, NamHocDTO)
            Dim listHocKy = New List(Of HocKyDTO)
            Dim Result = hockyBus.selectALL_ByMaNamHoc(namhoc.MaNamHoc, listHocKy)
            If (Result.FlagResult = False) Then
                MessageBox.Show("Lấy danh sách Học Kỳ theo Năm Học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Console.WriteLine(Result.SystemMessage)
                Return
            End If

            cbHocKy.DataSource = New BindingSource(listHocKy, String.Empty)
            cbHocKy.DisplayMember = "HocKy"
            cbHocKy.ValueMember = "MaHocKy"
            Dim myCurrencyManager As CurrencyManager = Me.BindingContext(cbHocKy.DataSource)
            myCurrencyManager.Refresh()
            If (listHocKy.Count > 0) Then
                cbHocKy.SelectedIndex = 0
            End If
        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
        End Try
    End Sub

    Private Sub cbHocKy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbHocKy.SelectedIndexChanged
        Try
            Dim listLop = New List(Of LopDTO)
            Dim khoi = CType(cbKhoi.SelectedItem, KhoiDTO)
            Dim hocky = CType(cbHocKy.SelectedItem, HocKyDTO)
            Dim result = lopBus.selectALL_ByMaKhoiAndMyHocKy(khoi.MaKhoi, hocky.MaHocKy, listLop)
            If (result.FlagResult = False) Then
                MessageBox.Show("Lấy danh sách Lớp không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Console.WriteLine(result.SystemMessage)
                Me.Close()
                Return
            End If

            ' Load Lop list
            cbLop.DataSource = New BindingSource(listLop, String.Empty)
            cbLop.DisplayMember = "TenLop"
            cbLop.ValueMember = "MaLop"
            Dim myCurrencyManager As CurrencyManager = Me.BindingContext(cbLop.DataSource)
            myCurrencyManager.Refresh()
            If (listLop.Count > 0) Then
                cbLop.SelectedIndex = 0
            End If

        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
            Return
        End Try
    End Sub

    Private Sub cbLop_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLop.SelectedIndexChanged
        Try
            'Dim hs = CType(dgvListHS.Rows(currentRowIndex).DataBoundItem, HocSinhDTO)
            Dim lop = CType(cbLop.SelectedItem, LopDTO)
            ' Load Mon Hoc list cua Chunog trinh
            Dim listMonHoc = New List(Of MonHocDTO)
            Dim result As Result
            result = diemBus.selectMonHoc_ByMaLop(lop.MaLop, listMonHoc)
            If (result.FlagResult = False) Then
                MessageBox.Show("Lấy danh sách Môn Học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Console.WriteLine(result.SystemMessage)
                Return
            End If

            cbMonHoc.DataSource = New BindingSource(listMonHoc, String.Empty)
            cbMonHoc.DisplayMember = "MonHoc"
            cbMonHoc.ValueMember = "MaMonHoc"
            Dim myCurrencyManager As CurrencyManager = Me.BindingContext(cbMonHoc.DataSource)
            myCurrencyManager.Refresh()
            If (listMonHoc.Count > 0) Then
                cbMonHoc.SelectedIndex = 0
            End If
        Catch ex As Exception
            Console.WriteLine(ex.StackTrace)
        End Try
    End Sub

    Private Sub cbMonHoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMonHoc.SelectedIndexChanged
        ' select all of HTDG of LOP, MonHoc
        Try
            Dim lop = CType(cbLop.SelectedItem, LopDTO)
            Dim monhoc = CType(cbMonHoc.SelectedItem, MonHocDTO)
            Dim result As Result
            Dim listHTDG = New List(Of HinhThucDanhGiaDTO)
            result = diemBus.selectALLHTDG_ByMaLopAndMaMonHoc(lop.MaLop, monhoc.MaMonHoc, listHTDG)
            If (result.FlagResult = False) Then
                MessageBox.Show("Lấy danh sách HTDG theo MaLop va MaMonHoc không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Console.WriteLine(result.SystemMessage)
                Return
            End If

            cbHTDG.DataSource = New BindingSource(listHTDG, String.Empty)
            cbHTDG.DisplayMember = "TenLoaiDiem"
            cbHTDG.ValueMember = "MaHTDG"
            Dim myCurrencyManager As CurrencyManager = Me.BindingContext(cbHTDG.DataSource)
            myCurrencyManager.Refresh()
            If (listHTDG.Count > 0) Then
                cbHTDG.SelectedIndex = 0
            End If
        Catch ex As Exception
            Console.WriteLine(ex.StackTrace)
        End Try
    End Sub

    Private Sub cbHTDG_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbHTDG.SelectedIndexChanged
        Try
            Dim lop = CType(cbLop.SelectedItem, LopDTO)
            Dim monhoc = CType(cbMonHoc.SelectedItem, MonHocDTO)
            Dim htdg = CType(cbHTDG.SelectedItem, HinhThucDanhGiaDTO)
            Dim result As Result
            Dim listDiemView = New List(Of DiemViewDTO)
            result = diemBus.selectDiem_LeftJoinByMaLopMaMonHocMaHTDG(lop.MaLop, monhoc.MaMonHoc, htdg.MaHTDG, listDiemView)
            If (result.FlagResult = False) Then
                MessageBox.Show("Lấy danh sách Diem theo MaLop, Mon Hoc va HTDG không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Console.WriteLine(result.SystemMessage)
                Return
            End If

            dgvDiemHS.Columns.Clear()
            dgvDiemHS.DataSource = Nothing

            dgvDiemHS.AutoGenerateColumns = False
            dgvDiemHS.AllowUserToAddRows = False
            dgvDiemHS.DataSource = listDiemView

            Dim clMa = New DataGridViewTextBoxColumn()
            clMa.Name = "MSHS"
            clMa.HeaderText = "Mã Học Sinh"
            clMa.DataPropertyName = "MSHS"
            dgvDiemHS.Columns.Add(clMa)
            clMa.ReadOnly = True

            Dim clHoTen = New DataGridViewTextBoxColumn()
            clHoTen.Name = "MonHoc"
            clHoTen.HeaderText = "Môn Học"
            clHoTen.DataPropertyName = "MonHoc"
            dgvDiemHS.Columns.Add(clHoTen)
            clHoTen.ReadOnly = True

            Dim clTenLoaiDiem = New DataGridViewTextBoxColumn()
            clTenLoaiDiem.Name = "TenLoaiDiem"
            clTenLoaiDiem.HeaderText = "Loại Điểm"
            clTenLoaiDiem.DataPropertyName = "TenLoaiDiem"
            dgvDiemHS.Columns.Add(clTenLoaiDiem)
            clTenLoaiDiem.ReadOnly = True

            Dim clHeSoDiem = New DataGridViewTextBoxColumn()
            clHeSoDiem.Name = "HeSoDiem"
            clHeSoDiem.HeaderText = "Hệ Số"
            clHeSoDiem.DataPropertyName = "HeSoDiem"
            dgvDiemHS.Columns.Add(clHeSoDiem)
            clHeSoDiem.ReadOnly = True

            Dim clDiem = New DataGridViewTextBoxColumn()
            clDiem.Name = "Diem"
            clDiem.HeaderText = "Điểm Số"
            clDiem.DataPropertyName = "Diem"
            dgvDiemHS.Columns.Add(clDiem)
            clDiem.ReadOnly = False

            Dim myCurrencyManager As CurrencyManager = Me.BindingContext(dgvDiemHS.DataSource)
            myCurrencyManager.Refresh()
        Catch ex As Exception
            Console.WriteLine(ex.StackTrace)
        End Try
    End Sub

    Private Sub btnNhapDiem_Click(sender As Object, e As EventArgs) Handles btnNhapDiem.Click
        Try
            Dim listDiemView = CType(dgvDiemHS.DataSource, List(Of DiemViewDTO))
            Dim s = 0
            For Each dv In listDiemView
                If (dv.Diem > -1) Then ' co nhap diem
                    Dim result = diemBus.update(dv.createDiemDTO)
                    If (result.FlagResult = False) Then
                        MessageBox.Show("Cập nhật điểm không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        System.Console.WriteLine(result.SystemMessage)
                        Exit For
                    Else
                        s = s + 1
                    End If
                End If
            Next
            If (s > 0) Then
                MessageBox.Show("Cập nhật " + s.ToString() + "cột Điểm thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            Console.WriteLine(ex.StackTrace)
        End Try
    End Sub
End Class