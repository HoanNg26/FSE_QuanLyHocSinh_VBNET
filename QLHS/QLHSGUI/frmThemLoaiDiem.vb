Imports QLHS1BUS
Imports QLHS1DTO
Imports Utility

Public Class frmThemLoaiDiem
    Private loaiDiemBus As LoaiDiemBus
    Private Sub frmThemLoaiDiem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaiDiemBus = New LoaiDiemBus()

        ' Get Next ID
        Dim nextID As Integer
        Dim result As Result
        result = loaiDiemBus.getNextID(nextID)
        If (result.FlagResult = True) Then
            txtMaLoai.Text = nextID.ToString()
        Else
            MessageBox.Show("Lấy ID kế tiếp của Loại điểm không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If
    End Sub

    Private Sub btnNhap_Click(sender As Object, e As EventArgs) Handles btnNhap.Click
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
        result = loaiDiemBus.insert(loaidiem)
        If (result.FlagResult = True) Then
            MessageBox.Show("Thêm Loại điểm thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtTenLoai.Text = String.Empty

            ' Get Next ID
            Dim nextID As Integer
            result = loaiDiemBus.getNextID(nextID)
            If (result.FlagResult = True) Then
                txtMaLoai.Text = nextID.ToString()
            Else
                MessageBox.Show("Lấy ID kế tiếp của Loại điểm không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Console.WriteLine(result.SystemMessage)
            End If

        Else
            MessageBox.Show("Thêm Loại điểm không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If
    End Sub

    Private Sub btnNhapVanDong_Click(sender As Object, e As EventArgs) Handles btnNhapVanDong.Click
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
        result = loaiDiemBus.insert(loaidiem)
        If (result.FlagResult = True) Then
            MessageBox.Show("Thêm Loại điểm thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBox.Show("Thêm Loại điểm không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If
    End Sub
End Class