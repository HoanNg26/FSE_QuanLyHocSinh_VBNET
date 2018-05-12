Imports QLHS1BUS
Imports QLHS1DTO
Imports Utility

Public Class frmThemChuongTrinhHoc


    Private lopBus As LopBus
    Private hsBus As HocSinhBUS
    Private monhocBus As MonHocBus
    Private loaidiemBus As LoaiDiemBus
    Private ctBus As ChuongTrinhBus
    Private listMonHoc As List(Of MonHocDTO)
    Private listMonHocChuongTrinh As List(Of ChiTietChuongTrinhDTO)
    Private listHTDG As List(Of HinhThucDanhGiaDTO)

    Private Sub frmThemChuongTrinhHoc_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lopBus = New LopBus()
        hsBus = New HocSinhBUS()
        monhocBus = New MonHocBus()
        loaidiemBus = New LoaiDiemBus()
        ctBus = New ChuongTrinhBus()


        listMonHoc = New List(Of MonHocDTO)
        listMonHocChuongTrinh = New List(Of ChiTietChuongTrinhDTO)
        listHTDG = New List(Of HinhThucDanhGiaDTO)

        loadListMonHoc()

        buildDGVMonHoc()
        buildDGVMonHocChuongTrinh()
        buildDGVHTDG()

        loadLoaiDiem()
    End Sub



    Private Sub loadLoaiDiem()
        'Load Loai Diem list to combobox
        Dim listLoaiDiem = New List(Of LoaiDiemDTO)
        Dim result = loaidiemBus.selectAll(listLoaiDiem)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Loại Điểm không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If
        cbLoaiDiem.DataSource = New BindingSource(listLoaiDiem, String.Empty)
        cbLoaiDiem.DisplayMember = "LoaiDiem"
        cbLoaiDiem.ValueMember = "MaLoaiDiem"
        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(cbLoaiDiem.DataSource)
        myCurrencyManager.Refresh()
    End Sub
    Private Sub loadListMonHoc()
        listMonHoc = New List(Of MonHocDTO)
        listMonHocChuongTrinh = New List(Of ChiTietChuongTrinhDTO)
        listHTDG = New List(Of HinhThucDanhGiaDTO)

        ' Load LoaiHocSinh list
        Dim result As Result
        result = monhocBus.selectAll(listMonHoc)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Môn học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If
    End Sub

    Private Sub buildDGVMonHoc()
        dgvMonHoc.DataSource = Nothing
        dgvMonHoc.Columns.Clear()

        dgvMonHoc.AutoGenerateColumns = False
        dgvMonHoc.AllowUserToAddRows = False
        dgvMonHoc.DataSource = listMonHoc

        Dim clMaMon = New DataGridViewTextBoxColumn()
        clMaMon.Name = "MaMonHoc"
        clMaMon.HeaderText = "Mã Môn Học"
        clMaMon.DataPropertyName = "MaMonHoc"
        dgvMonHoc.Columns.Add(clMaMon)

        Dim clTenMon = New DataGridViewTextBoxColumn()
        clTenMon.Name = "MonHoc"
        clTenMon.HeaderText = "Tên Môn Học"
        clTenMon.DataPropertyName = "MonHoc"
        dgvMonHoc.Columns.Add(clTenMon)
        'clTenMon.ReadOnly = True

        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(dgvMonHoc.DataSource)
        myCurrencyManager.Refresh()
    End Sub

    Private Sub buildDGVMonHocChuongTrinh()
        dgvMonHocChuongTrinh.DataSource = Nothing
        dgvMonHocChuongTrinh.Columns.Clear()

        dgvMonHocChuongTrinh.AutoGenerateColumns = False
        dgvMonHocChuongTrinh.AllowUserToAddRows = False
        dgvMonHocChuongTrinh.DataSource = listMonHocChuongTrinh

        Dim clMaMon = New DataGridViewTextBoxColumn()
        clMaMon.Name = "MaMonHoc"
        clMaMon.HeaderText = "Mã Môn Học"
        clMaMon.DataPropertyName = "MaMonHoc"
        dgvMonHocChuongTrinh.Columns.Add(clMaMon)
        clMaMon.ReadOnly = True

        Dim clTenMon = New DataGridViewTextBoxColumn()
        clTenMon.Name = "TenMonHoc"
        clTenMon.HeaderText = "Tên Môn Học"
        clTenMon.DataPropertyName = "TenMonHoc"
        dgvMonHocChuongTrinh.Columns.Add(clTenMon)
        clTenMon.ReadOnly = True

        Dim clHeSoMon = New DataGridViewTextBoxColumn()
        clHeSoMon.Name = "HeSoMon"
        clHeSoMon.HeaderText = "Hệ Số Môn"
        clHeSoMon.DataPropertyName = "HeSoMon"
        dgvMonHocChuongTrinh.Columns.Add(clHeSoMon)
        clHeSoMon.ReadOnly = False

        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(dgvMonHocChuongTrinh.DataSource)
        myCurrencyManager.Refresh()
    End Sub

    Private Sub buildDGVHTDG()
        dgvHTDG.DataSource = Nothing
        dgvHTDG.Columns.Clear()

        dgvHTDG.AutoGenerateColumns = False
        dgvHTDG.AllowUserToAddRows = False
        dgvHTDG.DataSource = listHTDG

        Dim clMaLoaiDiem = New DataGridViewTextBoxColumn()
        clMaLoaiDiem.Name = "TenLoaiDiem"
        clMaLoaiDiem.HeaderText = "Tên Loại Điểm"
        clMaLoaiDiem.DataPropertyName = "TenLoaiDiem"
        dgvHTDG.Columns.Add(clMaLoaiDiem)
        clMaLoaiDiem.ReadOnly = True

        Dim clHeSoDiem = New DataGridViewTextBoxColumn()
        clHeSoDiem.Name = "HeSoDiem"
        clHeSoDiem.HeaderText = "Hệ Số Điểm"
        clHeSoDiem.DataPropertyName = "HeSoDiem"
        dgvHTDG.Columns.Add(clHeSoDiem)
        clHeSoDiem.ReadOnly = False

        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(dgvHTDG.DataSource)
        myCurrencyManager.Refresh()
    End Sub
    Private Sub btnCapNhat_Click(sender As Object, e As EventArgs) Handles btnCapNhat.Click
        Dim ct = New ChuongTrinhDTO()

        '1. Mapping data from GUI control
        ct.TenCT = txtTenCT.Text
        ct.NgayTao = dtpNgayTao.Value
        ct.MaCT = 1
        ct.ListCTTT = Me.listMonHocChuongTrinh
        '2. Business .....
        If (ctBus.isValidName(ct) = False) Then
            MessageBox.Show("Tên Chương Trình không đúng. Vui lòng kiểm tra lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTenCT.Focus()
            Return
        End If
        '3. Insert to DB
        Dim result As Result
        result = ctBus.insertCT(ct)
        If (result.FlagResult = True) Then
            MessageBox.Show("Thêm Chương Trình thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtTenCT.Text = String.Empty

            loadListMonHoc()

            buildDGVMonHoc()
            listMonHocChuongTrinh = New List(Of ChiTietChuongTrinhDTO)
            buildDGVMonHocChuongTrinh()
            listHTDG = New List(Of HinhThucDanhGiaDTO)
            buildDGVHTDG()
        Else
            MessageBox.Show("Thêm Chương Trình không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If
    End Sub

    Private Sub btnFROMTo_Click(sender As Object, e As EventArgs) Handles btnFROMTo.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvMonHoc.CurrentCellAddress.Y 'current row selected
        'Dim x As Integer = dgvListHS.CurrentCellAddress.X 'curent column selected

        ' Write coordinates to console for debugging
        'Console.WriteLine(y.ToString + " " + x.ToString)

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvMonHoc.RowCount) Then
            Try
                Dim monhoc = CType(dgvMonHoc.Rows(currentRowIndex).DataBoundItem, MonHocDTO)
                listMonHoc.Remove(monhoc)
                listMonHocChuongTrinh.Add(New ChiTietChuongTrinhDTO(monhoc.MaMonHoc, monhoc.MonHoc, 1, 1, 1, New List(Of HinhThucDanhGiaDTO)))
                listHTDG = listMonHocChuongTrinh(listMonHocChuongTrinh.Count - 1).ListHTDG
                buildDGVMonHoc()
                buildDGVMonHocChuongTrinh()
                buildDGVHTDG()
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub btnToFROM_Click(sender As Object, e As EventArgs) Handles btnToFROM.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvMonHocChuongTrinh.CurrentCellAddress.Y 'current row selected
        'Dim x As Integer = dgvListHS.CurrentCellAddress.X 'curent column selected

        ' Write coordinates to console for debugging
        'Console.WriteLine(y.ToString + " " + x.ToString)

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvMonHocChuongTrinh.RowCount) Then
            Try
                Dim ctct = CType(dgvMonHocChuongTrinh.Rows(currentRowIndex).DataBoundItem, ChiTietChuongTrinhDTO)
                listMonHocChuongTrinh.Remove(ctct)
                listMonHoc.Add(New MonHocDTO(ctct.MaMonHoc, ctct.TenMonHoc))
                listHTDG = New List(Of HinhThucDanhGiaDTO)
                buildDGVMonHoc()
                buildDGVMonHocChuongTrinh()
                buildDGVHTDG()
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub dgvMonHocChuongTrinh_SELECTionChanged(sender As Object, e As EventArgs) Handles dgvMonHocChuongTrinh.SELECTionChanged
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvMonHocChuongTrinh.CurrentCellAddress.Y 'current row selected
        'Dim x As Integer = dgvListHS.CurrentCellAddress.X 'curent column selected

        ' Write coordinates to console for debugging
        'Console.WriteLine(y.ToString + " " + x.ToString)

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvMonHocChuongTrinh.RowCount) Then
            Try
                Dim ctct = CType(dgvMonHocChuongTrinh.Rows(currentRowIndex).DataBoundItem, ChiTietChuongTrinhDTO)
                listHTDG = ctct.ListHTDG
                buildDGVHTDG()
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub dgvHTDG_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvHTDG.KeyDown
        If (e.KeyCode = Keys.Delete) Then
            ' Get the current cell location.
            Dim currentRowIndex As Integer = dgvHTDG.CurrentCellAddress.Y 'current row selected
            'Verify that indexing OK
            If (-1 < currentRowIndex And currentRowIndex < dgvHTDG.RowCount) Then
                Try
                    Dim htdg = CType(dgvHTDG.Rows(currentRowIndex).DataBoundItem, HinhThucDanhGiaDTO)
                    listHTDG.Remove(htdg)
                    buildDGVHTDG()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                End Try
            End If
        End If
    End Sub

    Private Sub dgvMonHocChuongTrinh_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvMonHocChuongTrinh.DataError
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvMonHocChuongTrinh.CurrentCellAddress.Y 'current row selected
        'Dim x As Integer = dgvListHS.CurrentCellAddress.X 'curent column selected

        ' Write coordinates to console for debugging
        'Console.WriteLine(y.ToString + " " + x.ToString)

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvMonHocChuongTrinh.RowCount) Then
            Try
                'Dim hs = CType(dgvMonHocChuongTrinh.Rows(currentRowIndex).DataBoundItem, ChiTietChuongTrinhDTO)

                MessageBox.Show("Hệ Số Môn không đúng.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dgvMonHocChuongTrinh.CancelEdit()
                'storeValue = hs.NgaySinh
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub

    Private Sub dgvHTDG_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvHTDG.DataError
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvHTDG.CurrentCellAddress.Y 'current row selected
        'Dim x As Integer = dgvListHS.CurrentCellAddress.X 'curent column selected

        ' Write coordinates to console for debugging
        'Console.WriteLine(y.ToString + " " + x.ToString)

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvHTDG.RowCount) Then
            Try
                'Dim hs = CType(dgvHTDG.Rows(currentRowIndex).DataBoundItem, HocSinhDTO)

                MessageBox.Show("Hệ Số Điểm không đúng.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dgvHTDG.CancelEdit()
                'storeValue = hs.NgaySinh
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub

    Private Sub btnThemLoaiDiem_Click(sender As Object, e As EventArgs) Handles btnThemLoaiDiem.Click
        Try
            Dim loaidiem = CType(cbLoaiDiem.SelectedItem, LoaiDiemDTO)
            Dim htdg = New HinhThucDanhGiaDTO(1, 1, loaidiem.MaLoaiDiem, loaidiem.HeSoMacDinh, loaidiem.LoaiDiem)
            listHTDG.Add(htdg)
            buildDGVHTDG()
        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
        End Try
    End Sub
End Class