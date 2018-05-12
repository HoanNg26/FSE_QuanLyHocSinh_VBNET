Imports QLHS1BUS
Imports QLHS1DTO
Imports Utility

Public Class frmQLHocKy
    Private hockyBus As HocKyBus
    Private namhocBus As NamHocBus
    Private Sub cbNamHocFilter_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cbNamHocFilter.SELECTedIndexChanged
        Try
            Dim namhoc = CType(cbNamHocFilter.SELECTedItem, NamHocDTO)
            loadListHocKy(namhoc.MaNamHoc)
        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
        End Try
    End Sub
    Private Sub loadListHocKy(maNamHoc As String)
        Dim listHocKy = New List(Of HocKyDTO)
        Dim result As Result
        result = hockyBus.selectALL_ByMaNamHoc(maNamHoc, listHocKy)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Học Kỳ theo Năm Học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        'dgvListHocKy.SuspendLayout()
        dgvListHocKy.Columns.Clear()
        dgvListHocKy.DataSource = Nothing

        dgvListHocKy.AutoGenerateColumns = False
        dgvListHocKy.AllowUserToAddRows = False
        dgvListHocKy.DataSource = listHocKy

        Dim clMa = New DataGridViewTextBoxColumn()
        clMa.Name = "MaHocKy"
        clMa.HeaderText = "Mã Học Kỳ"
        clMa.DataPropertyName = "MaHocKy"
        dgvListHocKy.Columns.Add(clMa)

        Dim clTenHocKy = New DataGridViewTextBoxColumn()
        clTenHocKy.Name = "HocKy"
        clTenHocKy.HeaderText = "Tên Học Kỳ"
        clTenHocKy.DataPropertyName = "HocKy"
        dgvListHocKy.Columns.Add(clTenHocKy)

        Dim clTTHocKy = New DataGridViewTextBoxColumn()
        clTTHocKy.Name = "TTHocKy"
        clTTHocKy.HeaderText = "Thứ Tự Học Kỳ"
        clTTHocKy.DataPropertyName = "TTHocKy"
        dgvListHocKy.Columns.Add(clTTHocKy)

        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(dgvListHocKy.DataSource)
        myCurrencyManager.Refresh()
    End Sub
    Private Sub btnCapNhat_Click(sender As Object, e As EventArgs) Handles btnCapNhat.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvListHocKy.CurrentCellAddress.Y 'current row selected


        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvListHocKy.RowCount) Then
            Try
                Dim hocky As HocKyDTO
                hocky = New HocKyDTO()

                '1. Mapping data from GUI control
                hocky.MaHocKy = Convert.ToInt32(txtMaHocKy.Text)
                hocky.HocKy = txtTenHocKy.Text
                hocky.MaNamHoc = Convert.ToInt32(cbNamHocFilter.SELECTedValue)
                Dim namhoc = CType(cbNamHocFilter.SELECTedItem, NamHocDTO)
                hocky.MaNamHoc = namhoc.MaNamHoc
                '2. Business .....
                If (hockyBus.isValidName(hocky) = False) Then
                    MessageBox.Show("Tên Học Kỳ không đúng.")
                    txtTenHocKy.Focus()
                    Return
                End If
                '3. Insert to DB
                Dim result As Result
                result = hockyBus.update(hocky)
                If (result.FlagResult = True) Then
                    ' Re-Load hocky list
                    loadListHocKy(cbNamHocFilter.SELECTedValue)
                    ' Hightlight the row has been updated on table
                    dgvListHocKy.Rows(currentRowIndex).SELECTed = True

                    MessageBox.Show("Cập nhật Học Kỳ thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Cập nhật Học Kỳ không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    System.Console.WriteLine(result.SystemMessage)
                End If
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvListHocKy.CurrentCellAddress.Y 'current row selected

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvListHocKy.RowCount) Then
            SELECT Case MsgBox("Bạn có thực sự muốn xóa Học Kỳ có mã số: " + txtMaHocKy.Text, MsgBoxStyle.YesNo, "Information")
                Case MsgBoxResult.Yes
                    Try
                        '1. Delete from DB
                        Dim result As Result
                        result = hockyBus.delete(txtMaHocKy.Text)
                        If (result.FlagResult = True) Then

                            ' Re-Load Loaihocky list
                            loadListHocKy(cbNamHocFilter.SELECTedValue)

                            ' Hightlight the next row on table
                            If (currentRowIndex >= dgvListHocKy.Rows.Count) Then
                                currentRowIndex = currentRowIndex - 1
                            End If
                            If (currentRowIndex >= 0) Then
                                dgvListHocKy.Rows(currentRowIndex).SELECTed = True
                            End If

                            MessageBox.Show("Xóa Học Kỳ thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Xóa Học Kỳ không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub frmQLHocKy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        hockyBus = New HocKyBus()
        namhocBus = New NamHocBus()

        ' Load Nam Hoc list
        Dim listNamHoc = New List(Of NamHocDTO)
        Dim result As Result
        result = namhocBus.selectAll(listNamHoc)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Học Kỳ không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        cbNamHocFilter.DataSource = New BindingSource(listNamHoc, String.Empty)
        cbNamHocFilter.DisplayMember = "NamHoc"
        cbNamHocFilter.ValueMember = "MaNamHoc"
        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(cbNamHocFilter.DataSource)
        myCurrencyManager.Refresh()
        If (listNamHoc.Count > 0) Then
            cbNamHocFilter.SELECTedIndex = 0
        End If
    End Sub

    Private Sub dgvListHocKy_SELECTionChanged(sender As Object, e As EventArgs) Handles dgvListHocKy.SELECTionChanged
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvListHocKy.CurrentCellAddress.Y 'current row selected
        'Dim x As Integer = dgvListHocKy.CurrentCellAddress.X 'curent column selected

        ' Write coordinates to console for debugging
        'Console.WriteLine(y.ToString + " " + x.ToString)

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvListHocKy.RowCount) Then
            Try
                Dim hk = CType(dgvListHocKy.Rows(currentRowIndex).DataBoundItem, HocKyDTO)
                txtMaHocKy.Text = hk.MaHocKy
                txtTenHocKy.Text = hk.HocKy
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub
End Class