Imports QLHS1BUS
Imports QLHS1DTO
Imports Utility

Public Class frmThemMonHoc
    Private mhBus As MonHocBus
    Private Sub frmThemMonHoc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mhBus = New MonHocBus()

        ' Get Next ID
        Dim nextID As Integer
        Dim result As Result
        result = mhBus.getNextID(nextID)
        If (result.FlagResult = True) Then
            txtMaMonHoc.Text = nextID.ToString()
        Else
            MessageBox.Show("Lấy ID kế tiếp của Môn học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If
    End Sub

    Private Sub btnNhap_Click(sender As Object, e As EventArgs) Handles btnNhap.Click
        Dim monhoc As MonHocDTO
        monhoc = New MonHocDTO()

        '1. Mapping data from GUI control
        monhoc.MaMonHoc = Convert.ToInt32(txtMaMonHoc.Text)
        monhoc.MonHoc = txtMonHoc.Text

        '2. Business .....
        If (mhBus.isValidName(monhoc) = False) Then
            MessageBox.Show("Tên Môn học không đúng. Vui lòng kiểm tra lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtMonHoc.Focus()
            Return
        End If
        '3. Insert to DB
        Dim result As Result
        result = mhBus.insert(monhoc)
        If (result.FlagResult = True) Then
            MessageBox.Show("Thêm Môn học thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtMonHoc.Text = String.Empty

            ' Get Next ID
            Dim nextID As Integer
            result = mhBus.getNextID(nextID)
            If (result.FlagResult = True) Then
                txtMaMonHoc.Text = nextID.ToString()
            Else
                MessageBox.Show("Lấy ID kế tiếp của Môn học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Console.WriteLine(result.SystemMessage)
            End If

        Else
            MessageBox.Show("Thêm Môn học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If
    End Sub

    Private Sub btnNhapVanDong_Click(sender As Object, e As EventArgs) Handles btnNhapVanDong.Click
        Dim monhoc As MonHocDTO
        monhoc = New MonHocDTO()

        '1. Mapping data from GUI control
        monhoc.MaMonHoc = Convert.ToInt32(txtMaMonHoc.Text)
        monhoc.MonHoc = txtMonHoc.Text

        '2. Business .....
        If (mhBus.isValidName(monhoc) = False) Then
            MessageBox.Show("Tên Môn học không đúng. Vui lòng kiểm tra lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtMonHoc.Focus()
            Return
        End If
        '3. Insert to DB
        Dim result As Result
        result = mhBus.insert(monhoc)
        If (result.FlagResult = True) Then
            MessageBox.Show("Thêm Môn học thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtMonHoc.Text = String.Empty
            Me.Close()
        Else
            MessageBox.Show("Thêm Môn học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If
    End Sub
End Class