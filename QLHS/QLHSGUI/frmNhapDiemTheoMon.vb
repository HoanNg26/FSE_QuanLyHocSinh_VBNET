Imports QLHS1BUS
Imports QLHS1DTO
Imports Utility

Public Class frmNhapDiemTheoMon

    Private namhocBus As NamHocBus
    Private hockyBus As HocKyBus
    Private khoiBus As KhoiBus
    Private lopBus As LopBus
    Private hsBus As HocSinhBUS
    Private diemBus As DiemBus
    Private lophocsinhBus As LopHocSinhBus

    Private Sub frmNhapDiem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        namhocBus = New NamHocBus()
        hockyBus = New HocKyBus()
        khoiBus = New KhoiBus()
        lopBus = New LopBus()
        hsBus = New HocSinhBUS()
        diemBus = New DiemBus()
        lophocsinhBus = New LopHocSinhBus()

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
        dgvListHS.DataSource = Nothing

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

    Private Sub cbNamHoc_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cbNamHoc.SELECTedIndexChanged
        Try
            dgvListHS.DataSource = Nothing
            Dim namhoc = CType(cbNamHoc.SELECTedItem, NamHocDTO)
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
                cbHocKy.SELECTedIndex = 0
            End If
        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
        End Try
    End Sub

    Private Sub cbHocKy_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cbHocKy.SELECTedIndexChanged
        Try
            dgvListHS.DataSource = Nothing
            Dim listLop = New List(Of LopDTO)
            Dim khoi = CType(cbKhoi.SELECTedItem, KhoiDTO)
            Dim hocky = CType(cbHocKy.SELECTedItem, HocKyDTO)
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
                cbLop.SELECTedIndex = 0
            End If

        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
            Return
        End Try
    End Sub
    Private Sub loadListHocSinh(maLop As Integer)

        dgvDiemHS.DataSource = Nothing

        Dim listHS = New List(Of HocSinhDTO)
        Dim result As Result
        result = hsBus.selectALL_ByMaLop(maLop, listHS)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách học sinh theo loại không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If
        dgvListHS.Columns.Clear()
        dgvListHS.DataSource = Nothing

        dgvListHS.AutoGenerateColumns = False
        dgvListHS.AllowUserToAddRows = False
        dgvListHS.DataSource = listHS

        Dim clMa = New DataGridViewTextBoxColumn()
        clMa.Name = "MSHS"
        clMa.HeaderText = "Mã Học Sinh"
        clMa.DataPropertyName = "MSHS"
        dgvListHS.Columns.Add(clMa)

        Dim clLoaiHS = New DataGridView()
        'clLoaiHS.Name = "LoaiHS"
        'clLoaiHS.HeaderText = "Tên Loại"
        'clLoaiHS.DataPropertyName = "LoaiHS"
        'dgvListHS.Columns.Add(clLoaiHS)

        Dim clHoTen = New DataGridViewTextBoxColumn()
        clHoTen.Name = "HoTen"
        clHoTen.HeaderText = "Họ Tên"
        clHoTen.DataPropertyName = "HoTen"
        dgvListHS.Columns.Add(clHoTen)

        'Dim clDiaChi = New DataGridViewTextBoxColumn()
        'clDiaChi.Name = "DiaChi"
        'clDiaChi.HeaderText = "Địa Chỉ"
        'clDiaChi.DataPropertyName = "DiaChi"
        'dgvListHS.Columns.Add(clDiaChi)

        Dim clNgaySinh = New DataGridViewTextBoxColumn()
        clNgaySinh.Name = "NgaySinh"
        clNgaySinh.HeaderText = "Ngày Sinh"
        clNgaySinh.DataPropertyName = "NgaySinh"
        dgvListHS.Columns.Add(clNgaySinh)

        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(dgvListHS.DataSource)
        myCurrencyManager.Refresh()
    End Sub
    Private Sub cbLop_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cbLop.SelectedIndexChanged
        Try
            Dim lop = CType(cbLop.SelectedItem, LopDTO)
            loadListHocSinh(lop.MaLop)
        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
            Return
        End Try
    End Sub
    Private Sub loadListDiemView(maHocSinh As String, maLop As Integer, maMonHoc As Integer)
        ' Load danh sach diem theo MaLop, MaMonHoc, MaHocSinh
        Dim listDiemView = New List(Of DiemViewDTO)
        Dim result As Result
        result = diemBus.selectDiem_LeftJoinByMaHSMaLopMaMonHoc(maHocSinh, maLop, maMonHoc, listDiemView)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Điểm của học sinh không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    End Sub
    Private Sub cbMonHoc_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cbMonHoc.SelectedIndexChanged
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvListHS.CurrentCellAddress.Y 'current row selected
        'Dim x As Integer = dgvListHS.CurrentCellAddress.X 'curent column selected

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvListHS.RowCount) Then
            Try
                'Dim hs = CType(dgvListHS.Rows(currentRowIndex).DataBoundItem, HocSinhDTO)
                Dim lop = CType(cbLop.SelectedItem, LopDTO)
                Dim monhoc = CType(cbMonHoc.SelectedItem, MonHocDTO)
                Dim hs = CType(dgvListHS.Rows(currentRowIndex).DataBoundItem, HocSinhDTO)

                loadListDiemView(hs.MSHS, lop.MaLop, monhoc.MaMonHoc)

            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
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

    Private Sub dgvListHS_SelectionChanged(sender As Object, e As EventArgs) Handles dgvListHS.SelectionChanged
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvListHS.CurrentCellAddress.Y 'current row selected
        'Dim x As Integer = dgvListHS.CurrentCellAddress.X 'curent column selected

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvListHS.RowCount) Then
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

        End If
    End Sub

    Private Sub dgvDiemHS_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvDiemHS.DataError
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvDiemHS.CurrentCellAddress.Y 'current row selected
        'Dim x As Integer = dgvListHS.CurrentCellAddress.X 'curent column selected

        ' Write coordinates to console for debugging
        'Console.WriteLine(y.ToString + " " + x.ToString)

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDiemHS.RowCount) Then
            Try
                'Dim hs = CType(dgvHTDG.Rows(currentRowIndex).DataBoundItem, HocSinhDTO)

                MessageBox.Show("Điểm nhập không đúng.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dgvDiemHS.CancelEdit()
                'storeValue = hs.NgaySinh
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub
End Class