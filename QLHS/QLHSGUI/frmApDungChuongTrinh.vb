Imports QLHS1BUS
Imports QLHS1DTO
Imports Utility

Public Class frmApDungChuongTrinh

    Private namhocBus As NamHocBus
    Private hockyBus As HocKyBus
    Private khoiBus As KhoiBus
    Private lopBus As LopBus
    Private ctBus As ChuongTrinhBus
    Private adbus As ApDungBus

    Private listApDung As List(Of ApDungDTO)
    Private listCT As List(Of ChuongTrinhDTO)

    Private Sub frmApDungChuongTrinh_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        namhocBus = New NamHocBus()
        hockyBus = New HocKyBus()
        khoiBus = New KhoiBus()
        lopBus = New LopBus()
        adbus = New ApDungBus()
        ctBus = New ChuongTrinhBus()

        listApDung = New List(Of ApDungDTO)
        listCT = New List(Of ChuongTrinhDTO)

        ' Load Khoi list
        Dim listKhoi = New List(Of KhoiDTO)
        Dim result = khoiBus.selectAll(listKhoi)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Khối không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If
        cbKhoi.DataSource = New BindingSource(listKhoi, String.Empty)
        cbKhoi.DisplayMember = "Khoi"
        cbKhoi.ValueMember = "MaKhoi"
        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(cbKhoi.DataSource)
        myCurrencyManager.Refresh()
        If (listKhoi.Count > 0) Then
            cbKhoi.SelectedIndex = 0
        End If

        cbChuongTrinh.Hide()
        Me.Controls.Remove(cbChuongTrinh)

    End Sub
    Private Sub btnXacNhan_Click(sender As Object, e As EventArgs) Handles btnXacNhan.Click
        For Each ad In listApDung
            If (ad.MaCT <> -1) Then ' have set Chuong Trinh
                Dim result = adbus.insertForce(ad)
                If (result.FlagResult = False) Then
                    MessageBox.Show("Áp dụng Chương Trình cho các lớp không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    System.Console.WriteLine(result.SystemMessage)
                    Return
                End If
            End If
        Next
        MessageBox.Show("Áp dụng Chương Trình cho các lớp thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub cbKhoi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbKhoi.SelectedIndexChanged

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
        cbNamHoc.SelectedIndex = 0
        If (listNamHoc.Count > 0) Then
            cbNamHoc.SelectedIndex = 0
        End If
    End Sub

    Private Sub cbNamHoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbNamHoc.SelectedIndexChanged
        Try
            Dim namhoc = CType(cbNamHoc.SelectedItem, NamHocDTO)
            Dim listHocKy = New List(Of HocKyDTO)
            Dim Result = hockyBus.selectALL_ByMaNamHoc(namhoc.MaNamHoc, listHocKy)
            If (Result.FlagResult = False) Then
                MessageBox.Show("Lấy danh sách Học Kỳ theo Năm Học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Console.WriteLine(Result.SystemMessage)
                Return
            End If

            cbHocKy.DataSource = New BindingSource(listHocKy, String.Empty)
            cbHocKy.DisplayMember = "HocKy"
            cbHocKy.ValueMember = "MaHocKy"
            Dim myCurrencyManager As CurrencyManager = Me.BindingContext(cbHocKy.DataSource)
            myCurrencyManager.Refresh()
            If (listHocKy.Count > 0) Then
                cbHocKy.SelectedIndex = 0
            End If
        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
        End Try
    End Sub

    Private Sub cbHocKy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbHocKy.SelectedIndexChanged

        Try
            Dim khoi = CType(cbKhoi.SelectedItem, KhoiDTO)
            Dim hocky = CType(cbHocKy.SelectedItem, HocKyDTO)
            Dim result = adbus.selectALL_LeftJoin(hocky.MaHocKy, khoi.MaKhoi, listApDung)
            If (result.FlagResult = False) Then
                MessageBox.Show("Lấy danh sách Áp Dụng không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Console.WriteLine(result.SystemMessage)
                Me.Close()
                Return
            End If

            ' Build Grid ap dung - lớp
            buildGridApDung()

        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
            Return
        End Try
    End Sub
    Private Sub buildGridApDung()

        dgvListApDung.Columns.Clear()
        dgvListApDung.DataSource = Nothing

        dgvListApDung.AutoGenerateColumns = False
        dgvListApDung.AllowUserToAddRows = False
        dgvListApDung.DataSource = listApDung

        Dim clMaLop = New DataGridViewTextBoxColumn()
        clMaLop.Name = "MaLop"
        clMaLop.HeaderText = "Mã Lớp"
        clMaLop.DataPropertyName = "MaLop"
        dgvListApDung.Columns.Add(clMaLop)
        clMaLop.ReadOnly = True

        Dim clTenLop = New DataGridViewTextBoxColumn()
        clTenLop.Name = "TenLop"
        clTenLop.HeaderText = "Tên Lớp"
        clTenLop.DataPropertyName = "TenLop"
        dgvListApDung.Columns.Add(clTenLop)
        clTenLop.ReadOnly = True

        Dim clTenCT = New DataGridViewTextBoxColumn()
        clTenCT.Name = "TenCT"
        clTenCT.HeaderText = "Tên Chương Trình"
        clTenCT.DataPropertyName = "TenCT"
        dgvListApDung.Columns.Add(clTenCT)
        clTenCT.ReadOnly = True

        Dim clNgayApDung = New DataGridViewTextBoxColumn()
        clNgayApDung.Name = "NgayApDung"
        clNgayApDung.HeaderText = "Ngày Áp Dụng"
        clNgayApDung.DataPropertyName = "NgayApDung"
        dgvListApDung.Columns.Add(clNgayApDung)
        clNgayApDung.ReadOnly = True

        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(dgvListApDung.DataSource)
        myCurrencyManager.Refresh()
    End Sub


    Private Sub dgvListApDung_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvListApDung.CellMouseClick

        If (Me.dgvListApDung.Controls.Contains(cbChuongTrinh)) Then
            cbChuongTrinh.Hide()
            Me.dgvListApDung.Controls.Remove(cbChuongTrinh)
        End If
        If (e.ColumnIndex = 2) Then ' Column Ten chuong trinh
            Me.cbChuongTrinh.Location = Me.dgvListApDung.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Location
            'Me.cbChuongTrinh.SelectedIndex = 1
            'Me.cbChuongTrinh.SelectedValue = Me.dgvListApDung.CurrentCell.Value
            Me.dgvListApDung.Controls.Add(cbChuongTrinh)

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

            Me.cbChuongTrinh.Width = Me.dgvListApDung.Columns(e.ColumnIndex).Width
            Me.cbChuongTrinh.Height = Me.dgvListApDung.Rows(e.RowIndex).Height
            Me.cbChuongTrinh.Show()
        Else

        End If
    End Sub


    Private Sub cbChuongTrinh_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbChuongTrinh.SelectedIndexChanged
        Try
            Dim ct = CType(cbChuongTrinh.SelectedItem, ChuongTrinhDTO)
            ' Get the current cell location.
            Dim currentRowIndex As Integer = dgvListApDung.CurrentCellAddress.Y 'current row selected
            'Verify that indexing OK
            If (-1 < currentRowIndex And currentRowIndex < dgvListApDung.RowCount) Then
                Try
                    Dim ad = CType(dgvListApDung.Rows(currentRowIndex).DataBoundItem, ApDungDTO)
                    ad.TenCT = ct.TenCT
                    ad.MaCT = ct.MaCT
                    ad.NgayApDung = DateTime.Now

                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                End Try
            End If
        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
        End Try
    End Sub

    Private Sub dgvListApDung_ColumnWidthChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles dgvListApDung.ColumnWidthChanged
        If (e.Column.Index = 2) Then ' Column Ten chuong trinh
            If (Me.dgvListApDung.Controls.Contains(cbChuongTrinh)) Then
                cbChuongTrinh.Width = e.Column.Width
            End If
        End If
    End Sub

    Private Sub dgvListApDung_RowHeightChanged(sender As Object, e As DataGridViewRowEventArgs) Handles dgvListApDung.RowHeightChanged
        If (Me.dgvListApDung.Controls.Contains(cbChuongTrinh)) Then
            e.Row.Height = cbChuongTrinh.Height
        End If
    End Sub
End Class