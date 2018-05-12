Imports QLHS1BUS
Imports QLHS1DTO
Imports Utility

Public Class frmQLKhoi
    Private khoiBus As KhoiBus
    Private Sub frmQLKhoi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        khoiBus = New KhoiBus()

        'Load list Khối
        loadlistKhoi()
    End Sub
    Private Sub loadlistKhoi()
        ' Load LoaiHocSinh list
        Dim listKhoi = New List(Of KhoiDTO)
        Dim result As Result
        result = khoiBus.selectAll(listKhoi)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Khối không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        dgvDanhSachKhoi.Columns.Clear()
        dgvDanhSachKhoi.DataSource = Nothing

        dgvDanhSachKhoi.AutoGenerateColumns = False
        dgvDanhSachKhoi.AllowUserToAddRows = False
        dgvDanhSachKhoi.DataSource = listKhoi

        Dim clMaKhoi = New DataGridViewTextBoxColumn()
        clMaKhoi.Name = "MaKhoi"
        clMaKhoi.HeaderText = "Mã Khối"
        clMaKhoi.DataPropertyName = "MaKhoi"
        dgvDanhSachKhoi.Columns.Add(clMaKhoi)

        Dim clTenKhoi = New DataGridViewTextBoxColumn()
        clTenKhoi.Name = "Khoi"
        clTenKhoi.HeaderText = "Tên Khối"
        clTenKhoi.DataPropertyName = "Khoi"
        dgvDanhSachKhoi.Columns.Add(clTenKhoi)

        Dim clTTKhoi = New DataGridViewTextBoxColumn()
        clTTKhoi.Name = "TTKhoi"
        clTTKhoi.HeaderText = "Thứ Tự Khối"
        clTTKhoi.DataPropertyName = "TTKhoi"
        dgvDanhSachKhoi.Columns.Add(clTTKhoi)

        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(dgvDanhSachKhoi.DataSource)
        myCurrencyManager.Refresh()
    End Sub

    Private Sub btnCapNhat_Click(sender As Object, e As EventArgs) Handles btnCapNhat.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvDanhSachKhoi.CurrentCellAddress.Y 'current row selected

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDanhSachKhoi.RowCount) Then
            Try
                Dim khoi As KhoiDTO
                khoi = New KhoiDTO()

                '1. Mapping data from GUI control
                khoi.MaKhoi = Convert.ToInt32(txtMaKhoi.Text)
                khoi.Khoi = txtTenKhoi.Text

                '2. Business .....
                If (khoiBus.isValidName(khoi) = False) Then
                    MessageBox.Show("Tên Khối không đúng. Vui lòng kiểm tra lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtTenKhoi.Focus()
                    Return
                End If

                '3. Insert to DB

                Dim result As Result
                result = khoiBus.update(khoi)
                If (result.FlagResult = True) Then
                    ' Re-Load LoaiHocSinh list
                    loadlistKhoi()
                    ' Hightlight the row has been updated on table
                    dgvDanhSachKhoi.Rows(currentRowIndex).SELECTed = True
                    Try
                        khoi = CType(dgvDanhSachKhoi.Rows(currentRowIndex).DataBoundItem, KhoiDTO)
                        txtMaKhoi.Text = khoi.MaKhoi
                        txtTenKhoi.Text = khoi.Khoi
                    Catch ex As Exception
                        Console.WriteLine(ex.StackTrace)
                    End Try
                    MessageBox.Show("Cập nhật Khối thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Cập nhật Khối không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    System.Console.WriteLine(result.SystemMessage)
                End If
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvDanhSachKhoi.CurrentCellAddress.Y 'current row selected


        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDanhSachKhoi.RowCount) Then
            SELECT Case MsgBox("Bạn có thực sự muốn xóa Khối có mã: " + txtMaKhoi.Text, MsgBoxStyle.YesNo, "Information")
                Case MsgBoxResult.Yes
                    Try

                        '1. Delete from DB
                        Dim result As Result
                        result = khoiBus.delete(Convert.ToInt32(txtMaKhoi.Text))
                        If (result.FlagResult = True) Then

                            ' Re-Load LoaiHocSinh list
                            loadlistKhoi()

                            ' Hightlight the next row on table
                            If (currentRowIndex >= dgvDanhSachKhoi.Rows.Count) Then
                                currentRowIndex = currentRowIndex - 1
                            End If
                            If (currentRowIndex >= 0) Then
                                dgvDanhSachKhoi.Rows(currentRowIndex).SELECTed = True
                                Try
                                    Dim khoi = CType(dgvDanhSachKhoi.Rows(currentRowIndex).DataBoundItem, KhoiDTO)
                                    txtMaKhoi.Text = khoi.MaKhoi
                                    txtTenKhoi.Text = khoi.Khoi
                                Catch ex As Exception
                                    Console.WriteLine(ex.StackTrace)
                                End Try
                            End If
                            MessageBox.Show("Xóa Khối thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Xóa Khối không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub dgvDanhSachNamHoc_SELECTionChanged(sender As Object, e As EventArgs) Handles dgvDanhSachKhoi.SELECTionChanged
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvDanhSachKhoi.CurrentCellAddress.Y 'current row selected
        'Dim x As Integer = dgvDanhSachNamHoc.CurrentCellAddress.X 'curent column selected

        ' Write coordinates to console for debugging
        'Console.WriteLine(y.ToString + " " + x.ToString)

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDanhSachKhoi.RowCount) Then
            Try
                Dim khoi = CType(dgvDanhSachKhoi.Rows(currentRowIndex).DataBoundItem, KhoiDTO)
                txtMaKhoi.Text = khoi.MaKhoi
                txtTenKhoi.Text = khoi.Khoi
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub
End Class