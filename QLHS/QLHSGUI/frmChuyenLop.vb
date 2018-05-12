Imports QLHS1BUS
Imports QLHS1DTO
Imports Utility

Public Class frmChuyenLop

    Private namhocBus As NamHocBus
    Private hockyBus As HocKyBus
    Private khoiBus As KhoiBus
    Private lopBus As LopBus
    Private hsBus As HocSinhBUS
    Private lophocsinhBus As LopHocSinhBus

    Private listHS As List(Of HocSinhDTO)
    Private listHS_Deleted As List(Of HocSinhDTO)
    Private listHS_Addded As List(Of HocSinhDTO)
    Private listLopFROM As List(Of LopDTO)

    Private Sub frmChuyenLop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        namhocBus = New NamHocBus()
        hockyBus = New HocKyBus()
        khoiBus = New KhoiBus()
        lopBus = New LopBus()
        hsBus = New HocSinhBUS()
        lophocsinhBus = New LopHocSinhBus()

        listHS = New List(Of HocSinhDTO)
        listHS_Deleted = New List(Of HocSinhDTO)
        listHS_Addded = New List(Of HocSinhDTO)

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
        dgvListHS_FROM.DataSource = Nothing
        dgvListHS_To.DataSource = Nothing

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
        cbNamHoc.SELECTedIndex = 0
        If (listNamHoc.Count > 0) Then
            cbNamHoc.SELECTedIndex = 0
        End If
    End Sub

    Private Sub btnChuyenHS_Click(sender As Object, e As EventArgs) Handles btnChuyenHS.Click
        Try
            Dim lopFROM = CType(cbLop_FROM.SELECTedItem, LopDTO)
            Dim lopTo = CType(cbLop_To.SELECTedItem, LopDTO)
            For Each hs As HocSinhDTO In listHS_Deleted
                Dim lop_hs_deleted = New LopHocSinhDTO(lopFROM.MaLop, hs.MSHS)
                Dim lop_hs_added = New LopHocSinhDTO(lopTo.MaLop, hs.MSHS)

                Dim result = lophocsinhBus.delete(lop_hs_deleted)
                If (result.FlagResult = False) Then
                    MessageBox.Show("Xoá Học Sinh khỏi lóp cũ không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    System.Console.WriteLine(result.SystemMessage)
                    Return
                End If
                result = lophocsinhBus.insert(lop_hs_added)
                If (result.FlagResult = False) Then
                    MessageBox.Show("Thêm Học Sinh khỏi lóp mới không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    System.Console.WriteLine(result.SystemMessage)
                    Return
                End If
            Next
            loadListHocSinhFROM(lopFROM.MaLop)
            MessageBox.Show("Chuyển Lớp cho học sinh thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
            Return
        End Try
    End Sub

    Private Sub cbNamHoc_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cbNamHoc.SELECTedIndexChanged
        dgvListHS_FROM.DataSource = Nothing
        dgvListHS_To.DataSource = Nothing
        Try
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
        dgvListHS_FROM.DataSource = Nothing
        dgvListHS_To.DataSource = Nothing

        listLopFROM = New List(Of LopDTO)
        Try
            Dim khoi = CType(cbKhoi.SELECTedItem, KhoiDTO)
            Dim hocky = CType(cbHocKy.SELECTedItem, HocKyDTO)
            Dim result = lopBus.selectALL_ByMaKhoiAndMyHocKy(khoi.MaKhoi, hocky.MaHocKy, listLopFROM)
            If (result.FlagResult = False) Then
                MessageBox.Show("Lấy danh sách Lớp không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Console.WriteLine(result.SystemMessage)
                Me.Close()
                Return
            End If

            ' Load Lop list
            cbLop_FROM.DataSource = New BindingSource(listLopFROM, String.Empty)
            cbLop_FROM.DisplayMember = "TenLop"
            cbLop_FROM.ValueMember = "MaLop"
            Dim myCurrencyManager As CurrencyManager = Me.BindingContext(cbLop_FROM.DataSource)
            myCurrencyManager.Refresh()
            If (listLopFROM.Count > 0) Then
                cbLop_FROM.SELECTedIndex = 0
            End If

            Dim listLopTo = buildListLopTo(listLopFROM)
            cbLop_To.DataSource = New BindingSource(listLopTo, String.Empty)
            cbLop_To.DisplayMember = "TenLop"
            cbLop_To.ValueMember = "MaLop"
            Dim myCurrencyManager1 As CurrencyManager = Me.BindingContext(cbLop_To.DataSource)
            myCurrencyManager1.Refresh()
            If (listLopTo.Count > 0) Then
                cbLop_To.SELECTedIndex = 0
            End If

        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
            Return
        End Try
    End Sub
    Private Function buildListLopTo(listLopFROM As List(Of LopDTO)) As List(Of LopDTO)
        Dim listLopTo = New List(Of LopDTO)
        If (listLopFROM.Count < 1) Then
            Return listLopTo
        End If
        For n = 0 To listLopFROM.Count - 1
            If (n <> cbLop_FROM.SELECTedIndex) Then
                listLopTo.Add(listLopFROM(n))
            End If
        Next n
        Return listLopTo
    End Function


    Private Sub cbLop_FROM_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cbLop_FROM.SELECTedIndexChanged
        Try
            Dim lopFROM = CType(cbLop_FROM.SELECTedItem, LopDTO)
            loadListHocSinhFROM(lopFROM.MaLop)

            Dim listLopTo = buildListLopTo(listLopFROM)
            cbLop_To.DataSource = New BindingSource(listLopTo, String.Empty)
            cbLop_To.DisplayMember = "TenLop"
            cbLop_To.ValueMember = "MaLop"
            Dim myCurrencyManager1 As CurrencyManager = Me.BindingContext(cbLop_To.DataSource)
            myCurrencyManager1.Refresh()
            If (listLopTo.Count > 0) Then
                cbLop_To.SELECTedIndex = 0
            End If
        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
            Return
        End Try

        buildGridFROM()
        buildGridTo()
    End Sub

    Private Sub loadListHocSinhFROM(maHocKy As Integer)

        Dim result As Result
        result = hsBus.selectALL_ByMaLop(maHocKy, listHS)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách học sinh theo loại không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        listHS_Addded.Clear()
        listHS_Deleted.Clear()
    End Sub

    Private Sub buildGridFROM()

        dgvListHS_FROM.Columns.Clear()
        dgvListHS_FROM.DataSource = Nothing

        dgvListHS_FROM.AutoGenerateColumns = False
        dgvListHS_FROM.AllowUserToAddRows = False
        dgvListHS_FROM.DataSource = listHS

        Dim clMa = New DataGridViewTextBoxColumn()
        clMa.Name = "MSHS"
        clMa.HeaderText = "Mã Học Sinh"
        clMa.DataPropertyName = "MSHS"
        dgvListHS_FROM.Columns.Add(clMa)
        clMa.ReadOnly = True

        Dim clLoaiHS = New DataGridView()
        'clLoaiHS.Name = "LoaiHS"
        'clLoaiHS.HeaderText = "Tên Loại"
        'clLoaiHS.DataPropertyName = "LoaiHS"
        'dgvListHS_FROM.Columns.Add(clLoaiHS)

        Dim clHoTen = New DataGridViewTextBoxColumn()
        clHoTen.Name = "HoTen"
        clHoTen.HeaderText = "Họ Tên"
        clHoTen.DataPropertyName = "HoTen"
        dgvListHS_FROM.Columns.Add(clHoTen)
        clHoTen.ReadOnly = True


        'Dim clDiaChi = New DataGridViewTextBoxColumn()
        'clDiaChi.Name = "DiaChi"
        'clDiaChi.HeaderText = "Địa Chỉ"
        'clDiaChi.DataPropertyName = "DiaChi"
        'dgvListHS_FROM.Columns.Add(clDiaChi)

        Dim clNgaySinh = New DataGridViewTextBoxColumn()
        clNgaySinh.Name = "NgaySinh"
        clNgaySinh.HeaderText = "Ngày Sinh"
        clNgaySinh.DataPropertyName = "NgaySinh"
        dgvListHS_FROM.Columns.Add(clNgaySinh)
        clNgaySinh.ReadOnly = False

        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(dgvListHS_FROM.DataSource)
        myCurrencyManager.Refresh()
    End Sub

    Private Sub buildGridTo()

        dgvListHS_To.Columns.Clear()
        dgvListHS_To.DataSource = Nothing

        dgvListHS_To.AutoGenerateColumns = False
        dgvListHS_To.AllowUserToAddRows = False
        dgvListHS_To.DataSource = listHS_Addded

        Dim clMa = New DataGridViewTextBoxColumn()
        clMa.Name = "MSHS"
        clMa.HeaderText = "Mã Học Sinh"
        clMa.DataPropertyName = "MSHS"
        dgvListHS_To.Columns.Add(clMa)

        Dim clLoaiHS = New DataGridView()
        'clLoaiHS.Name = "LoaiHS"
        'clLoaiHS.HeaderText = "Tên Loại"
        'clLoaiHS.DataPropertyName = "LoaiHS"
        'dgvListHS_To.Columns.Add(clLoaiHS)

        Dim clHoTen = New DataGridViewTextBoxColumn()
        clHoTen.Name = "HoTen"
        clHoTen.HeaderText = "Họ Tên"
        clHoTen.DataPropertyName = "HoTen"
        dgvListHS_To.Columns.Add(clHoTen)

        'Dim clDiaChi = New DataGridViewTextBoxColumn()
        'clDiaChi.Name = "DiaChi"
        'clDiaChi.HeaderText = "Địa Chỉ"
        'clDiaChi.DataPropertyName = "DiaChi"
        'dgvListHS_To.Columns.Add(clDiaChi)

        Dim clNgaySinh = New DataGridViewTextBoxColumn()
        clNgaySinh.Name = "NgaySinh"
        clNgaySinh.HeaderText = "Ngày Sinh"
        clNgaySinh.DataPropertyName = "NgaySinh"
        dgvListHS_To.Columns.Add(clNgaySinh)

        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(dgvListHS_To.DataSource)
        myCurrencyManager.Refresh()
    End Sub

    Private Sub cbLop_To_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cbLop_To.SELECTedIndexChanged

    End Sub

    Private Sub btnFROMTo_Click(sender As Object, e As EventArgs) Handles btnFROMTo.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvListHS_FROM.CurrentCellAddress.Y 'current row selected
        'Dim x As Integer = dgvListHS.CurrentCellAddress.X 'curent column selected

        ' Write coordinates to console for debugging
        'Console.WriteLine(y.ToString + " " + x.ToString)

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvListHS_FROM.RowCount) Then
            Try
                Dim hs = CType(dgvListHS_FROM.Rows(currentRowIndex).DataBoundItem, HocSinhDTO)

                listHS.Remove(hs)
                listHS_Deleted.Add(hs)
                listHS_Addded.Add(hs)

                buildGridFROM()
                buildGridTo()

            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub

    Private Sub btnToFROM_Click(sender As Object, e As EventArgs) Handles btnToFROM.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvListHS_To.CurrentCellAddress.Y 'current row selected
        'Dim x As Integer = dgvListHS.CurrentCellAddress.X 'curent column selected

        ' Write coordinates to console for debugging
        'Console.WriteLine(y.ToString + " " + x.ToString)

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvListHS_To.RowCount) Then
            Try
                Dim hs = CType(dgvListHS_To.Rows(currentRowIndex).DataBoundItem, HocSinhDTO)

                listHS_Addded.Remove(hs)
                listHS_Deleted.Remove(hs)
                listHS.Add(hs)

                buildGridFROM()
                buildGridTo()

            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub

    Private Sub dgvListHS_FROM_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListHS_FROM.CellValueChanged
        '' Get the current cell location.
        'Dim currentRowIndex As Integer = dgvListHS_FROM.CurrentCellAddress.Y 'current row selected
        ''Dim x As Integer = dgvListHS.CurrentCellAddress.X 'curent column selected

        '' Write coordinates to console for debugging
        ''Console.WriteLine(y.ToString + " " + x.ToString)

        ''Verify that indexing OK
        'If (-1 < currentRowIndex And currentRowIndex < dgvListHS_FROM.RowCount) Then
        '    Try
        '        Dim hs = CType(dgvListHS_FROM.Rows(currentRowIndex).DataBoundItem, HocSinhDTO)

        '        MessageBox.Show("Test CellValueChanged:" + hs.HoTen, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        dgvListHS_FROM.CancelEdit()
        '    Catch ex As Exception
        '        Console.WriteLine(ex.StackTrace)
        '    End Try

        'End If
    End Sub

    'Private Sub dgvListHS_FROM_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListHS_FROM.CellEndEdit
    '    ' Get the current cell location.
    '    Dim currentRowIndex As Integer = dgvListHS_FROM.CurrentCellAddress.Y 'current row selected
    '    'Dim x As Integer = dgvListHS.CurrentCellAddress.X 'curent column selected

    '    ' Write coordinates to console for debugging
    '    'Console.WriteLine(y.ToString + " " + x.ToString)

    '    'Verify that indexing OK
    '    If (-1 < currentRowIndex And currentRowIndex < dgvListHS_FROM.RowCount) Then
    '        Try
    '            Dim hs = CType(dgvListHS_FROM.Rows(currentRowIndex).DataBoundItem, HocSinhDTO)

    '            MessageBox.Show("Test CellEndEdit:" + hs.NgaySinh, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            hs.NgaySinh = storeValue.AddDays(1)
    '        Catch ex As Exception
    '            Console.WriteLine(ex.StackTrace)
    '        End Try

    '    End If
    'End Sub
    'Dim storeValue As DateTime
    'Private Sub dgvListHS_FROM_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvListHS_FROM.CellBeginEdit
    '    ' Get the current cell location.
    '    Dim currentRowIndex As Integer = dgvListHS_FROM.CurrentCellAddress.Y 'current row selected
    '    'Dim x As Integer = dgvListHS.CurrentCellAddress.X 'curent column selected

    '    ' Write coordinates to console for debugging
    '    'Console.WriteLine(y.ToString + " " + x.ToString)

    '    'Verify that indexing OK
    '    If (-1 < currentRowIndex And currentRowIndex < dgvListHS_FROM.RowCount) Then
    '        Try
    '            Dim hs = CType(dgvListHS_FROM.Rows(currentRowIndex).DataBoundItem, HocSinhDTO)

    '            MessageBox.Show("Test CellBeginEdit:" + hs.NgaySinh, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            storeValue = hs.NgaySinh
    '        Catch ex As Exception
    '            Console.WriteLine(ex.StackTrace)
    '        End Try

    '    End If
    'End Sub

    Private Sub dgvListHS_FROM_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvListHS_FROM.DataError
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvListHS_FROM.CurrentCellAddress.Y 'current row selected
        'Dim x As Integer = dgvListHS.CurrentCellAddress.X 'curent column selected

        ' Write coordinates to console for debugging
        'Console.WriteLine(y.ToString + " " + x.ToString)

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvListHS_FROM.RowCount) Then
            Try
                Dim hs = CType(dgvListHS_FROM.Rows(currentRowIndex).DataBoundItem, HocSinhDTO)

                MessageBox.Show("Test DataError:" + dgvListHS_FROM.CurrentCell.Value, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dgvListHS_FROM.CancelEdit()
                'storeValue = hs.NgaySinh
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub
End Class