Imports QLHS1BUS
Imports QLHS1DTO
Imports Utility

Public Class frmThemLoaiHocSinhGUI

    Private lhsBus As LoaiHocSinhBUS

    Private Sub btnNhap_Click(sender As Object, e As EventArgs) Handles btnNhap.Click

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
        result = lhsBus.insert(lhs)
        If (result.FlagResult = True) Then
            MessageBox.Show("Thêm loại học sinh thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtTenLoai.Text = String.Empty

            ' Get Next ID
            Dim nextID As Integer
            result = lhsBus.getNextID(nextID)
            If (result.FlagResult = True) Then
                txtMaLoai.Text = nextID.ToString()
            Else
                MessageBox.Show("Lấy ID kế tiếp của Loại học sinh không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Console.WriteLine(result.SystemMessage)
            End If

        Else
            MessageBox.Show("Thêm loại học sinh không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If
    End Sub

    Private Sub frmLoaiHocSinhGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lhsBus = New LoaiHocSinhBUS()

        ' Get Next ID
        Dim nextID As Integer
        Dim result As Result
        result = lhsBus.getNextID(nextID)
        If (result.FlagResult = True) Then
            txtMaLoai.Text = nextID.ToString()
        Else
            MessageBox.Show("Lấy ID kế tiếp của Loại học sinh không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If

    End Sub

    Private Sub btnNhapVanDong_Click(sender As Object, e As EventArgs) Handles btnNhapVanDong.Click
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
        result = lhsBus.insert(lhs)
        If (result.FlagResult = True) Then
            MessageBox.Show("Thêm loại học sinh thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBox.Show("Thêm loại học sinh không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If
    End Sub
End Class