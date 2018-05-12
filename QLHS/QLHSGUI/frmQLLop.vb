Imports QLHS1BUS
Imports QLHS1DTO
Imports Utility

Public Class frmQLLop
    Private lopBus As LopBus
    Private khoiBus As KhoiBus

    Private namhocBus As NamHocBus
    Private hockyBus As HocKyBus
    Private Sub cbKhoiFilter_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cbKhoiFilter.SELECTedIndexChanged
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
    Private Sub loadListLop(maKhoi As Integer, maHocKy As Integer)
        Dim listLop = New List(Of LopDTO)
        Dim result As Result
        result = lopBus.selectALL_ByMaKhoiAndMyHocKy(maKhoi, maHocKy, listLop)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Lớp theo Khối không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        'dgvListLop.SuspendLayout()
        dgvListLop.Columns.Clear()
        dgvListLop.DataSource = Nothing

        dgvListLop.AutoGenerateColumns = False
        dgvListLop.AllowUserToAddRows = False
        dgvListLop.DataSource = listLop

        Dim clMa = New DataGridViewTextBoxColumn()
        clMa.Name = "MaLop"
        clMa.HeaderText = "Mã Lớp"
        clMa.DataPropertyName = "MaLop"
        dgvListLop.Columns.Add(clMa)

        Dim clTenHocKy = New DataGridViewTextBoxColumn()
        clTenHocKy.Name = "TenLop"
        clTenHocKy.HeaderText = "Tên Lớp"
        clTenHocKy.DataPropertyName = "TenLop"
        dgvListLop.Columns.Add(clTenHocKy)

        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(dgvListLop.DataSource)
        myCurrencyManager.Refresh()
    End Sub
    Private Sub frmQLLop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lopBus = New LopBus()
        khoiBus = New KhoiBus()
        namhocBus = New NamHocBus()
        hockyBus = New HocKyBus()

        ' Load Khoi list
        Dim listKhoi = New List(Of KhoiDTO)
        Dim result = khoiBus.selectAll(listKhoi)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Khối không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        cbKhoiFilter.DataSource = New BindingSource(listKhoi, String.Empty)
        cbKhoiFilter.DisplayMember = "Khoi"
        cbKhoiFilter.ValueMember = "MaKhoi"
        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(cbKhoiFilter.DataSource)
        myCurrencyManager.Refresh()
        If (listKhoi.Count > 0) Then
            cbKhoiFilter.SELECTedIndex = 0
        End If

    End Sub

    Private Sub btnCapNhat_Click(sender As Object, e As EventArgs) Handles btnCapNhat.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvListLop.CurrentCellAddress.Y 'current row selected


        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvListLop.RowCount) Then
            Try
                '1. Map data from GUI
                Dim lop = CType(dgvListLop.Rows(currentRowIndex).DataBoundItem, LopDTO)
                lop.TenLop = txtTenLop.Text
                '2. Business .....
                If (lopBus.isValidName(lop) = False) Then
                    MessageBox.Show("Tên Lớp không đúng.")
                    txtTenLop.Focus()
                    Return
                End If
                '3. Insert to DB
                Dim result As Result
                result = lopBus.update(lop)
                If (result.FlagResult = True) Then
                    ' Re-Load khoi list
                    Dim hocky = CType(cbTuHocKy.SELECTedItem, HocKyDTO)
                    Dim khoi = CType(cbKhoiFilter.SELECTedItem, KhoiDTO)
                    loadListLop(khoi.MaKhoi, hocky.MaHocKy)
                    ' Hightlight the row has been updated on table
                    dgvListLop.Rows(currentRowIndex).SELECTed = True

                    MessageBox.Show("Cập nhật Lớp thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Cập nhật Lớp không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    System.Console.WriteLine(result.SystemMessage)
                End If
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvListLop.CurrentCellAddress.Y 'current row selected

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvListLop.RowCount) Then
            SELECT Case MsgBox("Bạn có thực sự muốn xóa Lớp có mã số: " + txtMaLop.Text, MsgBoxStyle.YesNo, "Information")
                Case MsgBoxResult.Yes
                    Try
                        Dim lop = CType(dgvListLop.Rows(currentRowIndex).DataBoundItem, LopDTO)
                        '1. Delete from DB
                        Dim result As Result
                        result = lopBus.delete(lop.MaLop)
                        If (result.FlagResult = True) Then

                            ' Re-Load Loaikhoi list
                            Dim hocky = CType(cbTuHocKy.SELECTedItem, HocKyDTO)
                            Dim khoi = CType(cbKhoiFilter.SELECTedItem, KhoiDTO)
                            loadListLop(khoi.MaKhoi, hocky.MaHocKy)

                            ' Hightlight the next row on table
                            If (currentRowIndex >= dgvListLop.Rows.Count) Then
                                currentRowIndex = currentRowIndex - 1
                            End If
                            If (currentRowIndex >= 0) Then
                                dgvListLop.Rows(currentRowIndex).SELECTed = True
                            End If

                            MessageBox.Show("Xóa Lớp thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Xóa Lớp không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            System.Console.WriteLine(result.SystemMessage)
                        End If
                    Catch ex As Exception
                        Console.WriteLine(ex.StackTrace)
                    End Try
                Case MsgBoxResult.No
                    Return
            End SELECT


        End If
    End Sub

    Private Sub dgvListLop_SELECTionChanged(sender As Object, e As EventArgs) Handles dgvListLop.SELECTionChanged
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvListLop.CurrentCellAddress.Y 'current row selected
        'Dim x As Integer = dgvListLop.CurrentCellAddress.X 'curent column selected

        ' Write coordinates to console for debugging
        'Console.WriteLine(y.ToString + " " + x.ToString)

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvListLop.RowCount) Then
            Try
                Dim lop = CType(dgvListLop.Rows(currentRowIndex).DataBoundItem, LopDTO)
                txtMaLop.Text = lop.MaLop
                txtTenLop.Text = lop.TenLop

            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
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
        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
        End Try
    End Sub

    Private Sub cbTuHocKy_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cbTuHocKy.SELECTedIndexChanged
        Try
            Dim hocky = CType(cbTuHocKy.SELECTedItem, HocKyDTO)
            Dim khoi = CType(cbKhoiFilter.SELECTedItem, KhoiDTO)
            loadListLop(khoi.MaKhoi, hocky.MaHocKy)
        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
        End Try
    End Sub
End Class