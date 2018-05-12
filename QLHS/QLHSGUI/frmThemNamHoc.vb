Imports QLHS1BUS
Imports QLHS1DTO

Imports Utility

Public Class frmThemNamHoc

    Private nhBus As NamHocBus
    Dim currrentYear As Integer
    Private Sub btnNhap_Click(sender As Object, e As EventArgs) Handles btnNhap.Click

        Dim nh As NamHocDTO
        nh = New NamHocDTO()

        '1. Mapping data from GUI control
        nh.MaNamHoc = Convert.ToInt32(txtMaNamHoc.Text)
        nh.NamHoc = txtNamHoc.Text

        '2. Business .....
        If (nhBus.isValidName(nh) = False) Then
            MessageBox.Show("Tên Năm học không đúng. Vui lòng kiểm tra lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtNamHoc.Focus()
            Return
        End If
        '3. Insert to DB
        Dim result As Result
        result = nhBus.insert(nh)
        If (result.FlagResult = True) Then
            MessageBox.Show("Thêm Năm học thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNamHoc.Text = String.Empty

            ' Get Next ID
            Dim nextID As Integer
            result = nhBus.getNextID(nextID)
            If (result.FlagResult = True) Then
                txtMaNamHoc.Text = nextID.ToString()
            Else
                MessageBox.Show("Lấy ID kế tiếp của Năm học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Console.WriteLine(result.SystemMessage)
            End If

            ' Get next 'Khóa Thứ mấy'
            Dim nextTTNamhoc As Integer
            result = nhBus.getNextTTNamHoc(nextTTNamhoc)
            If (result.FlagResult = True) Then
                txtKhoaThu.Text = nextTTNamhoc.ToString()
            Else
                MessageBox.Show("Lấy Thứ Tự Khóa  kế tiếp của Năm học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Console.WriteLine(result.SystemMessage)
            End If

            'Auto set for Ten Nam Hoc
            txtNamHoc.Text = currrentYear.ToString() + "-" + (currrentYear + 1).ToString()
            currrentYear = currrentYear + 1
        Else
            MessageBox.Show("Thêm Năm học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If
    End Sub

    Private Sub frmThemNamHoc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nhBus = New NamHocBus()

        ' Get Next ID
        Dim nextID As Integer
        Dim result As Result
        result = nhBus.getNextID(nextID)
        If (result.FlagResult = True) Then
            txtMaNamHoc.Text = nextID.ToString()
        Else
            MessageBox.Show("Lấy ID kế tiếp của Năm học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If

        ' Get next 'Khóa Thứ mấy'
        Dim nextTTNamhoc As Integer
        result = nhBus.getNextTTNamHoc(nextTTNamhoc)
        If (result.FlagResult = True) Then
            txtKhoaThu.Text = nextTTNamhoc.ToString()
        Else
            MessageBox.Show("Lấy Thứ Tự Khóa  kế tiếp của Năm học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If

        'Auto set for Ten Nam Hoc
        currrentYear = DateTime.Now.Year
        txtNamHoc.Text = currrentYear.ToString() + "-" + (currrentYear + 1).ToString()
        currrentYear = currrentYear + 1
    End Sub

    Private Sub btnNhapVanDong_Click(sender As Object, e As EventArgs) Handles btnNhapVanDong.Click
        Dim nh As NamHocDTO
        nh = New NamHocDTO()

        '1. Mapping data from GUI control
        nh.MaNamHoc = Convert.ToInt32(txtMaNamHoc.Text)
        nh.NamHoc = txtNamHoc.Text

        '2. Business .....
        If (nhBus.isValidName(nh) = False) Then
            MessageBox.Show("Tên Năm học không đúng. Vui lòng kiểm tra lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtNamHoc.Focus()
            Return
        End If
        '3. Insert to DB
        Dim result As Result
        result = nhBus.insert(nh)
        If (result.FlagResult = True) Then
            MessageBox.Show("Thêm Năm học thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNamHoc.Text = String.Empty
            Me.Close()
        Else
            MessageBox.Show("Thêm Năm học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If
    End Sub
End Class