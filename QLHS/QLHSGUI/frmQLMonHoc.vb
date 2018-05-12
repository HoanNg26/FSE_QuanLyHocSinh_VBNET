Imports QLHS1BUS
Imports QLHS1DTO
Imports Utility

Public Class frmQLMonHoc
    Private mhBus As MonHocBus
    Private Sub frmQLMonHoc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mhBus = New MonHocBus()

        'Load list Môn học
        loadListMonHoc()
    End Sub
    Private Sub loadListMonHoc()
        ' Load LoaiHocSinh list
        Dim listMonHoc = New List(Of MonHocDTO)
        Dim result As Result
        result = mhBus.selectAll(listMonHoc)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Môn học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        dgvDanhSachMônHoc.Columns.Clear()
        dgvDanhSachMônHoc.DataSource = Nothing

        dgvDanhSachMônHoc.AutoGenerateColumns = False
        dgvDanhSachMônHoc.AllowUserToAddRows = False
        dgvDanhSachMônHoc.DataSource = listMonHoc

        Dim clMaLoai = New DataGridViewTextBoxColumn()
        clMaLoai.Name = "MaMonHoc"
        clMaLoai.HeaderText = "Mã Môn Học"
        clMaLoai.DataPropertyName = "MaMonHoc"
        dgvDanhSachMônHoc.Columns.Add(clMaLoai)

        Dim clTenLoai = New DataGridViewTextBoxColumn()
        clTenLoai.Name = "MonHoc"
        clTenLoai.HeaderText = "Tên Môn Học"
        clTenLoai.DataPropertyName = "MonHoc"
        dgvDanhSachMônHoc.Columns.Add(clTenLoai)
        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(dgvDanhSachMônHoc.DataSource)
        myCurrencyManager.Refresh()
    End Sub

    Private Sub dgvDanhSachMônHoc_SELECTionChanged(sender As Object, e As EventArgs) Handles dgvDanhSachMônHoc.SELECTionChanged
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvDanhSachMônHoc.CurrentCellAddress.Y 'current row selected
        'Dim x As Integer = dgvDanhSachMônHoc.CurrentCellAddress.X 'curent column selected

        ' Write coordinates to console for debugging
        'Console.WriteLine(y.ToString + " " + x.ToString)

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDanhSachMônHoc.RowCount) Then
            Try
                Dim monhoc = CType(dgvDanhSachMônHoc.Rows(currentRowIndex).DataBoundItem, MonHocDTO)
                txtMaMonHoc.Text = monhoc.MaMonHoc
                txtTenMonHoc.Text = monhoc.MonHoc
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub
    Private Sub mapDataFROMTable()
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvDanhSachMônHoc.CurrentCellAddress.Y 'current row selected
        'Dim x As Integer = dgvDanhSachMônHoc.CurrentCellAddress.X 'curent column selected

        ' Write coordinates to console for debugging
        'Console.WriteLine(y.ToString + " " + x.ToString)

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDanhSachMônHoc.RowCount) Then
            Try
                Dim monhoc = CType(dgvDanhSachMônHoc.Rows(currentRowIndex).DataBoundItem, MonHocDTO)
                txtMaMonHoc.Text = monhoc.MaMonHoc
                txtTenMonHoc.Text = monhoc.MonHoc
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub

    Private Sub btnCapNhat_Click(sender As Object, e As EventArgs) Handles btnCapNhat.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvDanhSachMônHoc.CurrentCellAddress.Y 'current row selected


        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDanhSachMônHoc.RowCount) Then
            Try
                Dim monhoc As MonHocDTO
                monhoc = New MonHocDTO()

                '1. Mapping data from GUI control
                monhoc.MaMonHoc = Convert.ToInt32(txtMaMonHoc.Text)
                monhoc.MonHoc = txtTenMonHoc.Text

                '2. Business .....
                If (mhBus.isValidName(monhoc) = False) Then
                    MessageBox.Show("Tên Môn học không đúng. Vui lòng kiểm tra lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtTenMonHoc.Focus()
                    Return
                End If

                '3. Insert to DB

                Dim result As Result
                result = mhBus.update(monhoc)
                If (result.FlagResult = True) Then
                    ' Re-Load LoaiHocSinh list
                    loadListMonHoc()
                    ' Hightlight the row has been updated on table
                    dgvDanhSachMônHoc.Rows(currentRowIndex).SELECTed = True
                    Try
                        monhoc = CType(dgvDanhSachMônHoc.Rows(currentRowIndex).DataBoundItem, MonHocDTO)
                        txtMaMonHoc.Text = monhoc.MaMonHoc
                        txtTenMonHoc.Text = monhoc.MonHoc
                    Catch ex As Exception
                        Console.WriteLine(ex.StackTrace)
                    End Try

                    MessageBox.Show("Cập nhật Môn học thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Cập nhật Môn học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    System.Console.WriteLine(result.SystemMessage)
                End If
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvDanhSachMônHoc.CurrentCellAddress.Y 'current row selected


        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDanhSachMônHoc.RowCount) Then
            SELECT Case MsgBox("Bạn có thực sự muốn xóa Môn học có mã: " + txtMaMonHoc.Text, MsgBoxStyle.YesNo, "Information")
                Case MsgBoxResult.Yes
                    Try

                        '1. Delete from DB
                        Dim result As Result
                        result = mhBus.delete(Convert.ToInt32(txtMaMonHoc.Text))
                        If (result.FlagResult = True) Then

                            ' Re-Load LoaiHocSinh list
                            loadListMonHoc()

                            ' Hightlight the next row on table
                            If (currentRowIndex >= dgvDanhSachMônHoc.Rows.Count) Then
                                currentRowIndex = currentRowIndex - 1
                            End If
                            If (currentRowIndex >= 0) Then
                                dgvDanhSachMônHoc.Rows(currentRowIndex).SELECTed = True
                                Try
                                    Dim monhoc As MonHocDTO
                                    monhoc = New MonHocDTO()
                                    monhoc = CType(dgvDanhSachMônHoc.Rows(currentRowIndex).DataBoundItem, MonHocDTO)
                                    txtMaMonHoc.Text = monhoc.MaMonHoc
                                    txtTenMonHoc.Text = monhoc.MonHoc
                                Catch ex As Exception
                                    Console.WriteLine(ex.StackTrace)
                                End Try
                            End If
                            MessageBox.Show("Xóa Môn học thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Xóa Môn học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
End Class