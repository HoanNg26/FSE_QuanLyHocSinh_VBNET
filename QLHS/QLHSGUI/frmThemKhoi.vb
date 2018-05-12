Imports QLHS1BUS
Imports QLHS1DTO
Imports Utility

Public Class frmThemKhoi
    Private khoiBus As KhoiBus

    Private Sub btnNhap_Click(sender As Object, e As EventArgs) Handles btnNhap.Click
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
        result = khoiBus.insert(khoi)
        If (result.FlagResult = True) Then
            MessageBox.Show("Thêm Khối thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtTenKhoi.Text = String.Empty

            ' Get Next ID
            Dim nextID As Integer
            result = khoiBus.getNextID(nextID)
            If (result.FlagResult = True) Then
                txtTenKhoi.Text = nextID.ToString()
            Else
                MessageBox.Show("Lấy ID kế tiếp của Khối không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Console.WriteLine(result.SystemMessage)
            End If
            ' Get Next Thu Tu Khoi
            Dim nextTTKhoi As Integer
            result = khoiBus.getNextTTKhoi(nextTTKhoi)
            If (result.FlagResult = True) Then
                txtTTKhoi.Text = nextTTKhoi.ToString()
            Else
                MessageBox.Show("Lấy Thứ tự của Khối không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Console.WriteLine(result.SystemMessage)
            End If
        Else
            MessageBox.Show("Thêm Khối không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If
    End Sub

    Private Sub btnNhapVanDong_Click(sender As Object, e As EventArgs) Handles btnNhapVanDong.Click
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
        result = khoiBus.insert(khoi)
        If (result.FlagResult = True) Then
            MessageBox.Show("Thêm Khối thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtTenKhoi.Text = String.Empty
            Me.Close()
        Else
            MessageBox.Show("Thêm Khối không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If
    End Sub

    Private Sub frmThemKhoi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        khoiBus = New KhoiBus()

        ' Get Next ID
        Dim nextID As Integer
        Dim result As Result
        result = khoiBus.getNextID(nextID)
        If (result.FlagResult = True) Then
            txtMaKhoi.Text = nextID.ToString()
        Else
            MessageBox.Show("Lấy ID kế tiếp của Khối không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If

        ' Get Next Thu Tu Khoi
        Dim nextTTKhoi As Integer
        result = khoiBus.getNextTTKhoi(nextTTKhoi)
        If (result.FlagResult = True) Then
            txtTTKhoi.Text = nextTTKhoi.ToString()
        Else
            MessageBox.Show("Lấy Thứ tự của Khối không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If
    End Sub
End Class