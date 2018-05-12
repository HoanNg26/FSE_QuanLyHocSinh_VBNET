Imports QLHS1BUS
Imports QLHS1DTO
Imports Utility

Public Class frmThemHocSinh

    Private hsBus As HocSinhBUS
    Private lhsBus As LoaiHocSinhBUS

    Private Sub btnNhap_Click(sender As Object, e As EventArgs) Handles btnNhap.Click

        Dim hocsinh As HocSinhDTO
        hocsinh = New HocSinhDTO()

        '1. Mapping data from GUI control
        hocsinh.MSHS = txtMaSo.Text
        hocsinh.HoTen = txtHoTen.Text
        hocsinh.DiaChi = txtDiaChi.Text
        hocsinh.NgaySinh = dtpNgaySinh.Value
        hocsinh.LoaiHS = Convert.ToInt32(cbLoaiHS.SELECTedValue)

        '2. Business .....
        If (hsBus.isValidName(hocsinh) = False) Then
            MessageBox.Show("Họ tên học sinh không đúng")
            txtHoTen.Focus()
            Return
        End If
        '3. Insert to DB
        Dim result As Result
        result = hsBus.insert(hocsinh)
        If (result.FlagResult = True) Then
            MessageBox.Show("Thêm Học sinh thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'set MSSH auto
            Dim nextMshs = "1"
            result = hsBus.buildMSHS(nextMshs)
            If (result.FlagResult = False) Then
                MessageBox.Show("Lấy danh tự động mã Học sinh không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Return
            End If
            txtMaSo.Text = nextMshs
            txtDiaChi.Text = String.Empty
            txtHoTen.Text = String.Empty

        Else
            MessageBox.Show("Thêm Học sinh không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If

    End Sub

    Private Sub frmHocSinhGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        hsBus = New HocSinhBUS()
        lhsBus = New LoaiHocSinhBUS()

        ' Load LoaiHocSinh list
        Dim listLoaiHocSinh = New List(Of LoaiHocSinhDTO)
        Dim result As Result
        result = lhsBus.selectAll(listLoaiHocSinh)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách loại học sinh không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If
        cbLoaiHS.DataSource = New BindingSource(listLoaiHocSinh, String.Empty)
        cbLoaiHS.DisplayMember = "TenLoai"
        cbLoaiHS.ValueMember = "MaLoaiHS"

        'set MSSH auto
        Dim nextMshs = "1"
        result = hsBus.buildMSHS(nextMshs)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh tự động mã Học sinh không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If
        txtMaSo.Text = nextMshs

    End Sub
    Private Sub btnNhapVaDong_Click(sender As Object, e As EventArgs) Handles btnNhapVaDong.Click
        Dim hocsinh As HocSinhDTO
        hocsinh = New HocSinhDTO()

        '1. Mapping data from GUI control
        hocsinh.MSHS = txtMaSo.Text
        hocsinh.HoTen = txtHoTen.Text
        hocsinh.DiaChi = txtDiaChi.Text
        hocsinh.NgaySinh = dtpNgaySinh.Value
        hocsinh.LoaiHS = Convert.ToInt32(cbLoaiHS.SELECTedValue)

        '2. Business .....
        If (hsBus.isValidName(hocsinh) = False) Then
            MessageBox.Show("Họ tên học sinh không đúng")
            txtHoTen.Focus()
            Return
        End If
        '3. Insert to DB
        Dim result As Result
        result = hsBus.insert(hocsinh)
        If (result.FlagResult = True) Then
            MessageBox.Show("Thêm Học sinh thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBox.Show("Thêm Học sinh không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If
    End Sub
End Class