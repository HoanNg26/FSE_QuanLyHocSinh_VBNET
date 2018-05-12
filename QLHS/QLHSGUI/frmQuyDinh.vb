Imports QLHS1BUS
Imports QLHS1DTO

Public Class frmQuyDinh
    Dim qdBus As QuyDinhBus
    Dim quydinh As QuyDinhDTO
    Private Sub frmQuyDinh_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        qdBus = New QuyDinhBus()
        Dim listQuyDinh = New List(Of QuyDinhDTO)
        Dim result = qdBus.selectALL(listQuyDinh)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy thông tin Quy Định không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
        End If
        quydinh = listQuyDinh(0)
        txtSoKhoiToiDa.Text = quydinh.SoKhoiToiDa
        txtSoHKToiDa.Text = quydinh.SoHocKyToiDa
    End Sub

    Private Sub btnCapNhat_Click(sender As Object, e As EventArgs) Handles btnCapNhat.Click
        Try
            quydinh.SoKhoiToiDa = Integer.Parse(txtSoKhoiToiDa.Text)
            quydinh.SoHocKyToiDa = Integer.Parse(txtSoHKToiDa.Text)
            Dim result = qdBus.update(quydinh)
            If (result.FlagResult = False) Then
                MessageBox.Show("Cập nhật Quy Định không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Console.WriteLine(result.SystemMessage)
                Return
            End If
            MessageBox.Show("Cập nhật Quy Định thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
        End Try

    End Sub
End Class