Imports QLHS1BUS
Imports QLHS1DTO
Imports Utility

Public Class frmQLNamHoc

    Private nhBus As NamHocBus
    Private Sub frmQLNamHoc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nhBus = New NamHocBus()

        'Load list Năm học
        loadListNamHoc()
    End Sub
    Private Sub loadListNamHoc()
        ' Load LoaiHocSinh list
        Dim listNamHoc = New List(Of NamHocDTO)
        Dim result As Result
        result = nhBus.selectAll(listNamHoc)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách năm học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        dgvDanhSachNamHoc.Columns.Clear()
        dgvDanhSachNamHoc.DataSource = Nothing

        dgvDanhSachNamHoc.AutoGenerateColumns = False
        dgvDanhSachNamHoc.AllowUserToAddRows = False
        dgvDanhSachNamHoc.DataSource = listNamHoc

        Dim clMaLoai = New DataGridViewTextBoxColumn()
        clMaLoai.Name = "MaNamHoc"
        clMaLoai.HeaderText = "Mã Năm Học"
        clMaLoai.DataPropertyName = "MaNamHoc"
        dgvDanhSachNamHoc.Columns.Add(clMaLoai)

        Dim clTenLoai = New DataGridViewTextBoxColumn()
        clTenLoai.Name = "NamHoc"
        clTenLoai.HeaderText = "Năm Học"
        clTenLoai.DataPropertyName = "NamHoc"
        dgvDanhSachNamHoc.Columns.Add(clTenLoai)

        Dim clTTNamHoc = New DataGridViewTextBoxColumn()
        clTTNamHoc.Name = "TTNamHoc"
        clTTNamHoc.HeaderText = "Khóa Thứ"
        clTTNamHoc.DataPropertyName = "TTNamHoc"
        dgvDanhSachNamHoc.Columns.Add(clTTNamHoc)

        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(dgvDanhSachNamHoc.DataSource)
        myCurrencyManager.Refresh()
    End Sub
    Private Sub btnCapNhat_Click(sender As Object, e As EventArgs) Handles btnCapNhat.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvDanhSachNamHoc.CurrentCellAddress.Y 'current row selected


        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDanhSachNamHoc.RowCount) Then
            Try
                Dim nh As NamHocDTO
                nh = New NamHocDTO()

                '1. Mapping data from GUI control
                nh.MaNamHoc = Convert.ToInt32(txtMaNamHoc.Text)
                nh.NamHoc = txtTenNamHoc.Text

                '2. Business .....
                If (nhBus.isValidName(nh) = False) Then
                    MessageBox.Show("Tên Năm học không đúng. Vui lòng kiểm tra lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtTenNamHoc.Focus()
                    Return
                End If

                '3. Insert to DB

                Dim result As Result
                result = nhBus.update(nh)
                If (result.FlagResult = True) Then
                    ' Re-Load LoaiHocSinh list
                    loadListNamHoc()
                    ' Hightlight the row has been updated on table
                    dgvDanhSachNamHoc.Rows(currentRowIndex).SELECTed = True
                    Try
                        nh = CType(dgvDanhSachNamHoc.Rows(currentRowIndex).DataBoundItem, NamHocDTO)
                        txtMaNamHoc.Text = nh.MaNamHoc
                        txtTenNamHoc.Text = nh.NamHoc
                    Catch ex As Exception
                        Console.WriteLine(ex.StackTrace)
                    End Try
                    MessageBox.Show("Cập nhật Năm học thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Cập nhật Năm học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    System.Console.WriteLine(result.SystemMessage)
                End If
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvDanhSachNamHoc.CurrentCellAddress.Y 'current row selected


        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDanhSachNamHoc.RowCount) Then
            SELECT Case MsgBox("Bạn có thực sự muốn xóa Năm học có mã: " + txtMaNamHoc.Text, MsgBoxStyle.YesNo, "Information")
                Case MsgBoxResult.Yes
                    Try

                        '1. Delete from DB
                        Dim result As Result
                        result = nhBus.delete(Convert.ToInt32(txtMaNamHoc.Text))
                        If (result.FlagResult = True) Then

                            ' Re-Load LoaiHocSinh list
                            loadListNamHoc()

                            ' Hightlight the next row on table
                            If (currentRowIndex >= dgvDanhSachNamHoc.Rows.Count) Then
                                currentRowIndex = currentRowIndex - 1
                            End If
                            If (currentRowIndex >= 0) Then
                                dgvDanhSachNamHoc.Rows(currentRowIndex).SELECTed = True
                                Try
                                    Dim nh = CType(dgvDanhSachNamHoc.Rows(currentRowIndex).DataBoundItem, NamHocDTO)
                                    txtMaNamHoc.Text = nh.MaNamHoc
                                    txtTenNamHoc.Text = nh.NamHoc
                                Catch ex As Exception
                                    Console.WriteLine(ex.StackTrace)
                                End Try
                            End If
                            MessageBox.Show("Xóa Năm học thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Xóa Năm học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub dgvDanhSachNamHoc_SELECTionChanged(sender As Object, e As EventArgs) Handles dgvDanhSachNamHoc.SELECTionChanged
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvDanhSachNamHoc.CurrentCellAddress.Y 'current row selected
        'Dim x As Integer = dgvDanhSachNamHoc.CurrentCellAddress.X 'curent column selected

        ' Write coordinates to console for debugging
        'Console.WriteLine(y.ToString + " " + x.ToString)

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDanhSachNamHoc.RowCount) Then
            Try
                Dim nh = CType(dgvDanhSachNamHoc.Rows(currentRowIndex).DataBoundItem, NamHocDTO)
                txtMaNamHoc.Text = nh.MaNamHoc
                txtTenNamHoc.Text = nh.NamHoc
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub
End Class