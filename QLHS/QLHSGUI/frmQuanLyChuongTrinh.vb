Imports QLHS1BUS
Imports QLHS1DTO
Imports Utility

Public Class frmQuanLyChuongTrinh

    Private lopBus As LopBus
    Private hsBus As HocSinhBUS
    Private monhocBus As MonHocBus
    Private loaidiemBus As LoaiDiemBus
    Private ctBus As ChuongTrinhBus
    Private listMonHoc As List(Of MonHocDTO)
    Private listMonHocOnDB As List(Of MonHocDTO)


    Private listCT As List(Of ChuongTrinhDTO)

    Private Sub frmQuanLyChuongTrinh_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lopBus = New LopBus()
        hsBus = New HocSinhBUS()
        monhocBus = New MonHocBus()
        loaidiemBus = New LoaiDiemBus()
        ctBus = New ChuongTrinhBus()

        listCT = New List(Of ChuongTrinhDTO)
        listMonHocOnDB = New List(Of MonHocDTO)
        listMonHoc = New List(Of MonHocDTO)

        loadLoaiDiem()
        loadListMonHoc()
        loadChuongTrinh()
    End Sub

    Private Sub cbChuongTrinh_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cbChuongTrinh.SELECTedIndexChanged
        Try
            Dim ct = CType(cbChuongTrinh.SELECTedItem, ChuongTrinhDTO)
            txtTenCT.Text = ct.TenCT
            dtpNgayTao.Value = ct.NgayTao
            dgvMonHocChuongTrinh.DataSource = Nothing
            dgvMonHocChuongTrinh.Columns.Clear()

            dgvMonHocChuongTrinh.AutoGenerateColumns = False
            dgvMonHocChuongTrinh.AllowUserToAddRows = False
            dgvMonHocChuongTrinh.DataSource = ct.ListCTTT

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
            If (ct.ListCTTT.Count > 0) Then
                dgvMonHocChuongTrinh.Rows(0).Selected = True
                dgvHTDG.DataSource = Nothing
                dgvHTDG.DataSource = ct.ListCTTT(0).ListHTDG
                Dim myCurrencyManager11 As CurrencyManager = Me.BindingContext(dgvHTDG.DataSource)
                myCurrencyManager11.Refresh()
            End If

            Me.listMonHoc.Clear()
            For Each mh In listMonHocOnDB
                Dim f = True
                For Each ctct In ct.ListCTTT
                    If (mh.MaMonHoc = ctct.MaMonHoc) Then
                        f = False
                        Exit For
                    End If
                Next
                If (f = True) Then
                    Me.listMonHoc.Add(mh)
                End If
            Next
            buildDGVMonHoc()

        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
        End Try
    End Sub

    Private Sub btnFROMTo_Click(sender As Object, e As EventArgs) Handles btnFROMTo.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvMonHoc.CurrentCellAddress.Y 'current row selected
        'Dim x As Integer = dgvListHS.CurrentCellAddress.X 'curent column selected

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvMonHoc.RowCount) Then
            Try

                Dim monhoc = CType(dgvMonHoc.Rows(currentRowIndex).DataBoundItem, MonHocDTO)
                Dim ct = CType(cbChuongTrinh.SelectedItem, ChuongTrinhDTO)
                listMonHoc.Remove(monhoc)
                buildDGVMonHoc()

                ct.ListCTTT.Add(New ChiTietChuongTrinhDTO(monhoc.MaMonHoc, monhoc.MonHoc, 1, -1, ct.MaCT, New List(Of HinhThucDanhGiaDTO)))
                dgvMonHocChuongTrinh.DataSource = Nothing
                dgvMonHocChuongTrinh.DataSource = ct.ListCTTT
                Dim myCurrencyManager As CurrencyManager = Me.BindingContext(dgvMonHocChuongTrinh.DataSource)
                myCurrencyManager.Refresh()
                dgvMonHocChuongTrinh.Rows(ct.ListCTTT.Count - 1).Selected = True

                dgvHTDG.DataSource = Nothing
                dgvHTDG.DataSource = ct.ListCTTT(ct.ListCTTT.Count - 1).ListHTDG
                Dim myCurrencyManager11 As CurrencyManager = Me.BindingContext(dgvHTDG.DataSource)
                myCurrencyManager11.Refresh()

            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub btnToFROM_Click(sender As Object, e As EventArgs) Handles btnToFROM.Click
        Try
            Dim ct = CType(cbChuongTrinh.SelectedItem, ChuongTrinhDTO)
            Dim ctct = CType(dgvMonHocChuongTrinh.SelectedRows(0).DataBoundItem, ChiTietChuongTrinhDTO)
            Dim currentRowIndex = dgvMonHocChuongTrinh.SelectedRows(0).Index
            ct.ListCTTT.Remove(ctct)
            dgvHTDG.DataSource = Nothing
            listMonHoc.Add(New MonHocDTO(ctct.MaMonHoc, ctct.TenMonHoc))
            buildDGVMonHoc()

            dgvMonHocChuongTrinh.DataSource = Nothing
            dgvMonHocChuongTrinh.DataSource = ct.ListCTTT
            Dim myCurrencyManager As CurrencyManager = Me.BindingContext(dgvMonHocChuongTrinh.DataSource)
            myCurrencyManager.Refresh()
            If (ct.ListCTTT.Count > 0) Then
                If (currentRowIndex > 0) Then
                    currentRowIndex = currentRowIndex - 1
                End If
                dgvMonHocChuongTrinh.Rows(currentRowIndex).Selected = True
                ctct = CType(dgvMonHocChuongTrinh.Rows(currentRowIndex).DataBoundItem, ChiTietChuongTrinhDTO)
                dgvHTDG.DataSource = Nothing
                dgvHTDG.DataSource = ctct.ListHTDG
                Dim myCurrencyManager11 As CurrencyManager = Me.BindingContext(dgvHTDG.DataSource)
                myCurrencyManager11.Refresh()
            End If
        Catch ex As Exception
            Console.WriteLine(ex.StackTrace)
        End Try
    End Sub



    Private Sub dgvMonHocChuongTrinh_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvMonHocChuongTrinh.DataError
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvMonHocChuongTrinh.CurrentCellAddress.Y 'current row selected
        'Dim x As Integer = dgvListHS.CurrentCellAddress.X 'curent column selected

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

    Private Sub dgvHTDG_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvHTDG.KeyDown
        If (e.KeyCode = Keys.Delete) Then
            ' Get the current cell location.
            Dim currentRowIndex As Integer = dgvHTDG.CurrentCellAddress.Y 'current row selected
            'Verify that indexing OK
            If (-1 < currentRowIndex And currentRowIndex < dgvHTDG.RowCount) Then
                Try
                    Dim htdg = CType(dgvHTDG.Rows(currentRowIndex).DataBoundItem, HinhThucDanhGiaDTO)
                    Dim currentRowIndex01 As Integer = dgvMonHocChuongTrinh.CurrentCellAddress.Y 'current row selected
                    'Verify that indexing OK
                    If (-1 < currentRowIndex01 And currentRowIndex01 < dgvMonHocChuongTrinh.RowCount) Then
                        Dim ctct = CType(dgvMonHocChuongTrinh.Rows(currentRowIndex01).DataBoundItem, ChiTietChuongTrinhDTO)
                        ctct.ListHTDG.Remove(htdg)
                        dgvHTDG.DataSource = Nothing
                        dgvHTDG.DataSource = ctct.ListHTDG
                        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(dgvHTDG.DataSource)
                        myCurrencyManager.Refresh()
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                End Try
            End If
        End If
    End Sub

    Private Sub loadChuongTrinh()
        'Load Chuong Trinh list to combobox

        Dim result = ctBus.selectALL(Me.listCT)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Chương Trình không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If
        cbChuongTrinh.DataSource = New BindingSource(listCT, String.Empty)
        cbChuongTrinh.DisplayMember = "TenCT"
        cbChuongTrinh.ValueMember = "MaCT"
        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(cbChuongTrinh.DataSource)
        myCurrencyManager.Refresh()
        If (listCT.Count > 0) Then
            cbChuongTrinh.SelectedIndex = 0
        End If

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
        If (listLoaiDiem.Count > 0) Then
            cbLoaiDiem.SELECTedIndex = 0
        End If

    End Sub
    Private Sub loadListMonHoc()
        ' Load LoaiHocSinh list
        Dim result As Result
        result = monhocBus.selectAll(Me.listMonHocOnDB)
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

    Private Sub btnThemLoaiDiem_Click(sender As Object, e As EventArgs) Handles btnThemLoaiDiem.Click
        Try
            Dim ctct = CType(dgvMonHocChuongTrinh.SelectedRows(0).DataBoundItem, ChiTietChuongTrinhDTO)
            Dim loaidiem = CType(cbLoaiDiem.SelectedItem, LoaiDiemDTO)
            Dim htdg = New HinhThucDanhGiaDTO(-1, ctct.MaCTTT, loaidiem.MaLoaiDiem, loaidiem.HeSoMacDinh, loaidiem.LoaiDiem)
            ctct.ListHTDG.Add(htdg)
            dgvHTDG.DataSource = Nothing
            dgvHTDG.DataSource = ctct.ListHTDG
            Dim myCurrencyManager As CurrencyManager = Me.BindingContext(dgvHTDG.DataSource)
            myCurrencyManager.Refresh()
        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
        End Try
    End Sub

    Private Sub btnCapNhat_Click(sender As Object, e As EventArgs) Handles btnCapNhat.Click
        Dim ctUpdated = New ChuongTrinhDTO()
        Dim ct = CType(cbChuongTrinh.SELECTedItem, ChuongTrinhDTO)
        '1. Mapping data from GUI control
        ctUpdated.TenCT = txtTenCT.Text
        ctUpdated.NgayTao = dtpNgayTao.Value
        ctUpdated.MaCT = ct.MaCT
        ctUpdated.ListCTTT = ct.ListCTTT
        '2. Business .....
        If (ctBus.isValidName(ctUpdated) = False) Then
            MessageBox.Show("Tên Chương Trình không đúng. Vui lòng kiểm tra lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTenCT.Focus()
            Return
        End If
        '3. Insert to DB
        Dim result As Result
        result = ctBus.updateCT_Cascade(ctUpdated)
        If (result.FlagResult = True) Then
            MessageBox.Show("Cập Nhật Chương Trình thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            loadChuongTrinh()
        Else
            MessageBox.Show("Cập Nhật Chương Trình không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If
    End Sub

    Private Sub dgvMonHocChuongTrinh_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMonHocChuongTrinh.RowEnter
        If (e.RowIndex < 0 Or dgvMonHocChuongTrinh.SelectedRows.Count < 1) Then
            Return
        End If
        Try
            Dim ctct = CType(dgvMonHocChuongTrinh.SelectedRows(0).DataBoundItem, ChiTietChuongTrinhDTO)
            dgvHTDG.DataSource = Nothing
            dgvHTDG.Columns.Clear()

            dgvHTDG.AutoGenerateColumns = False
            dgvHTDG.AllowUserToAddRows = False
            dgvHTDG.DataSource = ctct.ListHTDG

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
            'If (ctct.ListHTDG.Count > 0) Then
            '    dgvHTDG.Rows(ctct.ListHTDG.Count - 1).Selected = True
            'End If
        Catch ex As Exception
            Console.WriteLine(ex.StackTrace)
        End Try
    End Sub
End Class