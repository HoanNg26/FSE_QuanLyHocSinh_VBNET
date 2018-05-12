Imports QLHS1BUS
Imports QLHS1DTO
Imports Utility

Public Class frmQLLoaiDiem
    Private loaiDiemBus As LoaiDiemBus

    Private Sub frmQLLoaiDiem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaiDiemBus = New LoaiDiemBus()
        ' Load LoaiHocSinh list
        loadListLoaiDiem()
    End Sub
    Private Sub loadListLoaiDiem()
        ' Load LoaiHocSinh list
        Dim listLoaiHocSinh = New List(Of LoaiDiemDTO)
        Dim result As Result
        result = loaiDiemBus.selectAll(listLoaiHocSinh)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Loại điểm không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        dgvDanhSachLoaiDiem.Columns.Clear()
        dgvDanhSachLoaiDiem.DataSource = Nothing

        dgvDanhSachLoaiDiem.AutoGenerateColumns = False
        dgvDanhSachLoaiDiem.AllowUserToAddRows = False
        dgvDanhSachLoaiDiem.DataSource = listLoaiHocSinh

        Dim clMaLoai = New DataGridViewTextBoxColumn()
        clMaLoai.Name = "MaLoaiDiem"
        clMaLoai.HeaderText = "Mã Loại Điểm"
        clMaLoai.DataPropertyName = "MaLoaiDiem"
        dgvDanhSachLoaiDiem.Columns.Add(clMaLoai)

        Dim clLoaiDiem = New DataGridViewTextBoxColumn()
        clLoaiDiem.Name = "LoaiDiem"
        clLoaiDiem.HeaderText = "Tên Loại Điểm"
        clLoaiDiem.DataPropertyName = "LoaiDiem"
        dgvDanhSachLoaiDiem.Columns.Add(clLoaiDiem)

        Dim clHeSoMacDinh = New DataGridViewTextBoxColumn()
        clHeSoMacDinh.Name = "HeSoMacDinh"
        clHeSoMacDinh.HeaderText = "Hệ Số Mặc Định"
        clHeSoMacDinh.DataPropertyName = "HeSoMacDinh"
        dgvDanhSachLoaiDiem.Columns.Add(clHeSoMacDinh)

        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(dgvDanhSachLoaiDiem.DataSource)
        myCurrencyManager.Refresh()

    End Sub
    Private Sub btnCapNhat_Click(sender As Object, e As EventArgs) Handles btnCapNhat.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvDanhSachLoaiDiem.CurrentCellAddress.Y 'current row selected


        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDanhSachLoaiDiem.RowCount) Then
            Try
                Dim loaidiem As LoaiDiemDTO
                loaidiem = New LoaiDiemDTO()

                '1. Mapping data from GUI control
                loaidiem.MaLoaiDiem = Convert.ToInt32(txtMaLoai.Text)
                loaidiem.LoaiDiem = txtTenLoai.Text
                loaidiem.HeSoMacDinh = Convert.ToInt32(txtHeSoMacDinh.Text)

                '2. Business .....
                If (loaiDiemBus.isValidName(loaidiem) = False) Then
                    MessageBox.Show("Tên Loại điểm không đúng. Vui lòng kiểm tra lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtTenLoai.Focus()
                    Return
                End If

                '3. Insert to DB

                Dim result As Result
                result = loaiDiemBus.update(loaidiem)
                If (result.FlagResult = True) Then
                    ' Re-Load LoaiHocSinh list
                    loadListLoaiDiem()
                    ' Hightlight the row has been updated on table
                    dgvDanhSachLoaiDiem.Rows(currentRowIndex).SELECTed = True
                    Try
                        loaidiem = CType(dgvDanhSachLoaiDiem.Rows(currentRowIndex).DataBoundItem, LoaiDiemDTO)
                        txtMaLoai.Text = loaidiem.MaLoaiDiem
                        txtTenLoai.Text = loaidiem.LoaiDiem
                    Catch ex As Exception
                        Console.WriteLine(ex.StackTrace)
                    End Try
                    MessageBox.Show("Cập nhật Loại điểm thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Cập nhật Loại điểm không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    System.Console.WriteLine(result.SystemMessage)
                End If
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvDanhSachLoaiDiem.CurrentCellAddress.Y 'current row selected


        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDanhSachLoaiDiem.RowCount) Then
            SELECT Case MsgBox("Bạn có thực sự muốn xóa Loại điểm có mã: " + txtMaLoai.Text, MsgBoxStyle.YesNo, "Information")
                Case MsgBoxResult.Yes
                    Try

                        '1. Delete from DB
                        Dim result As Result
                        result = loaiDiemBus.delete(Convert.ToInt32(txtMaLoai.Text))
                        If (result.FlagResult = True) Then

                            ' Re-Load LoaiHocSinh list
                            loadListLoaiDiem()

                            ' Hightlight the next row on table
                            If (currentRowIndex >= dgvDanhSachLoaiDiem.Rows.Count) Then
                                currentRowIndex = currentRowIndex - 1
                            End If
                            If (currentRowIndex >= 0) Then
                                dgvDanhSachLoaiDiem.Rows(currentRowIndex).SELECTed = True
                                Try
                                    Dim loaidiem = CType(dgvDanhSachLoaiDiem.Rows(currentRowIndex).DataBoundItem, LoaiDiemDTO)
                                    txtMaLoai.Text = loaidiem.MaLoaiDiem
                                    txtTenLoai.Text = loaidiem.LoaiDiem
                                Catch ex As Exception
                                    Console.WriteLine(ex.StackTrace)
                                End Try
                            End If
                            MessageBox.Show("Xóa Loại điểm thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Xóa Loại điểm không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub dgvDanhSachLoaiDiem_SELECTionChanged(sender As Object, e As EventArgs) Handles dgvDanhSachLoaiDiem.SELECTionChanged
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvDanhSachLoaiDiem.CurrentCellAddress.Y 'current row selected
        'Dim x As Integer = dgvDanhSachLoaiDiem.CurrentCellAddress.X 'curent column selected

        ' Write coordinates to console for debugging
        'Console.WriteLine(y.ToString + " " + x.ToString)

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDanhSachLoaiDiem.RowCount) Then
            Try
                Dim loaidiem = CType(dgvDanhSachLoaiDiem.Rows(currentRowIndex).DataBoundItem, LoaiDiemDTO)
                txtMaLoai.Text = loaidiem.MaLoaiDiem
                txtTenLoai.Text = loaidiem.LoaiDiem
                txtHeSoMacDinh.Text = loaidiem.HeSoMacDinh
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub
End Class