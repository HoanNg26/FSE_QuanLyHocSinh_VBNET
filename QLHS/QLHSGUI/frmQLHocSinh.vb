Imports System.Configuration
Imports QLHS1BUS
Imports QLHS1DTO
Imports Utility

Public Class frmQLHocSinh

    Private hsBus As HocSinhBUS
    Private lhsBus As LoaiHocSinhBUS
    Private Sub btnCapNhat_Click(sender As Object, e As EventArgs) Handles btnCapNhat.Click

        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvListHS.CurrentCellAddress.Y 'current row selected


        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvListHS.RowCount) Then
            Try
                Dim hocsinh As HocSinhDTO
                hocsinh = New HocSinhDTO()

                '1. Mapping data from GUI control
                hocsinh.MSHS = txtMaSo.Text
                hocsinh.HoTen = txtHoTen.Text
                hocsinh.DiaChi = txtDiaChi.Text
                hocsinh.NgaySinh = dtpNgaySinh.Value
                hocsinh.LoaiHS = Convert.ToInt32(cbLoaiHSCapNhat.SELECTedValue)
                '2. Business .....
                If (hsBus.isValidName(hocsinh) = False) Then
                    MessageBox.Show("Họ tên Học sinh không đúng.")
                    txtHoTen.Focus()
                    Return
                End If
                '3. Insert to DB
                Dim result As Result
                result = hsBus.update(hocsinh)
                If (result.FlagResult = True) Then
                    ' Re-Load HocSinh list
                    loadListHocSinh(cbLoaiHS.SELECTedValue)
                    ' Hightlight the row has been updated on table
                    dgvListHS.Rows(currentRowIndex).SELECTed = True

                    MessageBox.Show("Cập nhật Học sinh thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Cập nhật Học sinh không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    System.Console.WriteLine(result.SystemMessage)
                End If
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvListHS.CurrentCellAddress.Y 'current row selected


        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvListHS.RowCount) Then
            SELECT Case MsgBox("Bạn có thực sự muốn xóa học sinh có mã số: " + txtMaSo.Text, MsgBoxStyle.YesNo, "Information")
                Case MsgBoxResult.Yes
                    Try
                        '1. Delete from DB
                        Dim result As Result
                        result = hsBus.delete(txtMaSo.Text)
                        If (result.FlagResult = True) Then

                            ' Re-Load LoaiHocSinh list
                            loadListHocSinh(cbLoaiHS.SELECTedValue)

                            ' Hightlight the next row on table
                            If (currentRowIndex >= dgvListHS.Rows.Count) Then
                                currentRowIndex = currentRowIndex - 1
                            End If
                            If (currentRowIndex >= 0) Then
                                dgvListHS.Rows(currentRowIndex).SELECTed = True
                            End If

                            MessageBox.Show("Xóa Học sinh thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Xóa Học sinh không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub frmQuanLyHocSinh_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        hsBus = New HocSinhBUS()
        lhsBus = New LoaiHocSinhBUS()

        ' Load LoaiHocSinh list
        Dim listLoaiHocSinh = New List(Of LoaiHocSinhDTO)
        Dim result As Result
        result = lhsBus.selectAll(listLoaiHocSinh)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách loại học sinh không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        cbLoaiHS.DataSource = New BindingSource(listLoaiHocSinh, String.Empty)
        cbLoaiHS.DisplayMember = "TenLoai"
        cbLoaiHS.ValueMember = "MaLoaiHS"

        cbLoaiHSCapNhat.DataSource = New BindingSource(listLoaiHocSinh, String.Empty)
        cbLoaiHSCapNhat.DisplayMember = "TenLoai"
        cbLoaiHSCapNhat.ValueMember = "MaLoaiHS"

    End Sub
    Private Sub loadListHocSinh()
        Dim listHocSinh = New List(Of HocSinhDTO)
        Dim result As Result
        result = hsBus.selectAll(listHocSinh)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách học sinh không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        'dgvListHS.SuspendLayout()
        dgvListHS.Columns.Clear()
        dgvListHS.DataSource = Nothing

        dgvListHS.AutoGenerateColumns = False
        dgvListHS.AllowUserToAddRows = False
        dgvListHS.DataSource = listHocSinh

        Dim clMa = New DataGridViewTextBoxColumn()
        clMa.Name = "MSHS"
        clMa.HeaderText = "Mã Học Sinh"
        clMa.DataPropertyName = "MSHS"
        dgvListHS.Columns.Add(clMa)

        Dim clLoaiHS = New DataGridView()
        'clLoaiHS.Name = "LoaiHS"
        'clLoaiHS.HeaderText = "Tên Loại"
        'clLoaiHS.DataPropertyName = "LoaiHS"
        'dgvListHS.Columns.Add(clLoaiHS)

        Dim clHoTen = New DataGridViewTextBoxColumn()
        clHoTen.Name = "HoTen"
        clHoTen.HeaderText = "Họ Tên"
        clHoTen.DataPropertyName = "HoTen"
        dgvListHS.Columns.Add(clHoTen)

        Dim clDiaChi = New DataGridViewTextBoxColumn()
        clDiaChi.Name = "DiaChi"
        clDiaChi.HeaderText = "Địa Chỉ"
        clDiaChi.DataPropertyName = "DiaChi"
        dgvListHS.Columns.Add(clDiaChi)

        Dim clNgaySinh = New DataGridViewTextBoxColumn()
        clNgaySinh.Name = "NgaySinh"
        clNgaySinh.HeaderText = "Ngày Sinh"
        clNgaySinh.DataPropertyName = "NgaySinh"
        dgvListHS.Columns.Add(clNgaySinh)
        'dgvListHS.ResumeLayout()
    End Sub

    Private Sub loadListHocSinh(maLoai As String)
        Dim listHocSinh = New List(Of HocSinhDTO)
        Dim result As Result
        result = hsBus.selectALL_ByType(maLoai, listHocSinh)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách học sinh theo loại không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        'dgvListHS.SuspendLayout()
        dgvListHS.Columns.Clear()
        dgvListHS.DataSource = Nothing

        dgvListHS.AutoGenerateColumns = False
        dgvListHS.AllowUserToAddRows = False
        dgvListHS.DataSource = listHocSinh

        Dim clMa = New DataGridViewTextBoxColumn()
        clMa.Name = "MSHS"
        clMa.HeaderText = "Mã Học Sinh"
        clMa.DataPropertyName = "MSHS"
        dgvListHS.Columns.Add(clMa)

        Dim clLoaiHS = New DataGridView()
        'clLoaiHS.Name = "LoaiHS"
        'clLoaiHS.HeaderText = "Tên Loại"
        'clLoaiHS.DataPropertyName = "LoaiHS"
        'dgvListHS.Columns.Add(clLoaiHS)

        Dim clHoTen = New DataGridViewTextBoxColumn()
        clHoTen.Name = "HoTen"
        clHoTen.HeaderText = "Họ Tên"
        clHoTen.DataPropertyName = "HoTen"
        dgvListHS.Columns.Add(clHoTen)

        Dim clDiaChi = New DataGridViewTextBoxColumn()
        clDiaChi.Name = "DiaChi"
        clDiaChi.HeaderText = "Địa Chỉ"
        clDiaChi.DataPropertyName = "DiaChi"
        dgvListHS.Columns.Add(clDiaChi)

        Dim clNgaySinh = New DataGridViewTextBoxColumn()
        clNgaySinh.Name = "NgaySinh"
        clNgaySinh.HeaderText = "Ngày Sinh"
        clNgaySinh.DataPropertyName = "NgaySinh"
        dgvListHS.Columns.Add(clNgaySinh)
        'dgvListHS.ResumeLayout()
    End Sub

    Private Sub cbLoaiHS_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cbLoaiHS.SELECTedIndexChanged
        Try
            Dim maLoai = Convert.ToInt32(cbLoaiHS.SELECTedValue)
            loadListHocSinh(maLoai)

        Catch ex As Exception

        End Try


    End Sub

    Private Sub dgvListHS_SELECTionChanged(sender As Object, e As EventArgs) Handles dgvListHS.SELECTionChanged
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvListHS.CurrentCellAddress.Y 'current row selected
        'Dim x As Integer = dgvListHS.CurrentCellAddress.X 'curent column selected

        ' Write coordinates to console for debugging
        'Console.WriteLine(y.ToString + " " + x.ToString)

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvListHS.RowCount) Then
            Try
                Dim hs = CType(dgvListHS.Rows(currentRowIndex).DataBoundItem, HocSinhDTO)
                txtMaSo.Text = hs.MSHS
                txtHoTen.Text = hs.HoTen
                txtDiaChi.Text = hs.DiaChi
                dtpNgaySinh.Value = hs.NgaySinh
                cbLoaiHSCapNhat.SELECTedIndex = cbLoaiHS.SELECTedIndex
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub
End Class