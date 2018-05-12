Imports System.Configuration
Imports QLHS1BUS
Imports QLHS1DTO
Imports Utility

Public Class frmQLLoaiHocSinh

    Private lhsBus As LoaiHocSinhBUS
    Private Sub frmDanhSachLoaiHocSinh_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lhsBus = New LoaiHocSinhBUS()
        ' Load LoaiHocSinh list
        loadListLoaiHocSinh()

    End Sub

    Private Sub loadListLoaiHocSinh()
        ' Load LoaiHocSinh list
        Dim listLoaiHocSinh = New List(Of LoaiHocSinhDTO)
        Dim result As Result
        result = lhsBus.selectAll(listLoaiHocSinh)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách loại học sinh không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        dgvDanhSachLoaiHS.Columns.Clear()
        dgvDanhSachLoaiHS.DataSource = Nothing

        dgvDanhSachLoaiHS.AutoGenerateColumns = False
        dgvDanhSachLoaiHS.AllowUserToAddRows = False
        dgvDanhSachLoaiHS.DataSource = listLoaiHocSinh

        Dim clMaLoai = New DataGridViewTextBoxColumn()
        clMaLoai.Name = "MaLoaiHS"
        clMaLoai.HeaderText = "Mã Loại"
        clMaLoai.DataPropertyName = "MaLoaiHS"
        dgvDanhSachLoaiHS.Columns.Add(clMaLoai)

        Dim clTenLoai = New DataGridViewTextBoxColumn()
        clTenLoai.Name = "TenLoai"
        clTenLoai.HeaderText = "Tên Loại"
        clTenLoai.DataPropertyName = "TenLoai"
        dgvDanhSachLoaiHS.Columns.Add(clTenLoai)

    End Sub
    Private Sub btnCapNhat_Click(sender As Object, e As EventArgs) Handles btnCapNhat.Click

        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvDanhSachLoaiHS.CurrentCellAddress.Y 'current row selected


        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDanhSachLoaiHS.RowCount) Then
            Try
                Dim lhs As LoaiHocSinhDTO
                lhs = New LoaiHocSinhDTO()

                '1. Mapping data from GUI control
                lhs.MaLoaiHS = Convert.ToInt32(txtMaLoai.Text)
                lhs.TenLoai = txtTenLoai.Text

                '2. Business .....
                If (lhsBus.isValidName(lhs) = False) Then
                    MessageBox.Show("Tên Loại học sinh không đúng. Vui lòng kiểm tra lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtTenLoai.Focus()
                    Return
                End If

                '3. Insert to DB

                Dim result As Result
                result = lhsBus.update(lhs)
                If (result.FlagResult = True) Then
                    ' Re-Load LoaiHocSinh list
                    loadListLoaiHocSinh()
                    ' Hightlight the row has been updated on table
                    dgvDanhSachLoaiHS.Rows(currentRowIndex).SELECTed = True
                    Try
                        lhs = CType(dgvDanhSachLoaiHS.Rows(currentRowIndex).DataBoundItem, LoaiHocSinhDTO)
                        txtMaLoai.Text = lhs.MaLoaiHS
                        txtTenLoai.Text = lhs.TenLoai
                    Catch ex As Exception
                        Console.WriteLine(ex.StackTrace)
                    End Try
                    MessageBox.Show("Cập nhật Loại học sinh thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Cập nhật loại học sinh không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    System.Console.WriteLine(result.SystemMessage)
                End If
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If

    End Sub



    Private Sub dgvDanhSachLoaiHS_SELECTionChanged(sender As Object, e As EventArgs) Handles dgvDanhSachLoaiHS.SELECTionChanged

        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvDanhSachLoaiHS.CurrentCellAddress.Y 'current row selected
        'Dim x As Integer = dgvDanhSachLoaiHS.CurrentCellAddress.X 'curent column selected

        ' Write coordinates to console for debugging
        'Console.WriteLine(y.ToString + " " + x.ToString)

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDanhSachLoaiHS.RowCount) Then
            Try
                Dim lhs = CType(dgvDanhSachLoaiHS.Rows(currentRowIndex).DataBoundItem, LoaiHocSinhDTO)
                txtMaLoai.Text = lhs.MaLoaiHS
                txtTenLoai.Text = lhs.TenLoai
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If

    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvDanhSachLoaiHS.CurrentCellAddress.Y 'current row selected


        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDanhSachLoaiHS.RowCount) Then
            SELECT Case MsgBox("Bạn có thực sự muốn xóa loại học sinh có mã: " + txtMaLoai.Text, MsgBoxStyle.YesNo, "Information")
                Case MsgBoxResult.Yes
                    Try

                        '1. Delete from DB
                        Dim result As Result
                        result = lhsBus.delete(Convert.ToInt32(txtMaLoai.Text))
                        If (result.FlagResult = True) Then

                            ' Re-Load LoaiHocSinh list
                            loadListLoaiHocSinh()

                            ' Hightlight the next row on table
                            If (currentRowIndex >= dgvDanhSachLoaiHS.Rows.Count) Then
                                currentRowIndex = currentRowIndex - 1
                            End If
                            If (currentRowIndex >= 0) Then
                                dgvDanhSachLoaiHS.Rows(currentRowIndex).SELECTed = True
                                Try
                                    Dim lhs = CType(dgvDanhSachLoaiHS.Rows(currentRowIndex).DataBoundItem, LoaiHocSinhDTO)
                                    txtMaLoai.Text = lhs.MaLoaiHS
                                    txtTenLoai.Text = lhs.TenLoai
                                Catch ex As Exception
                                    Console.WriteLine(ex.StackTrace)
                                End Try
                            End If
                            MessageBox.Show("Xóa Loại học sinh thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Xóa Loại học sinh không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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