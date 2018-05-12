Imports QLHS1BUS
Imports QLHS1DTO
Imports Utility

Public Class frmThemHocKy
    Private hockyBus As HocKyBus
    Private namhocBus As NamHocBus

    Private Sub frmThemHocKy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        hockyBus = New HocKyBus()
        namhocBus = New NamHocBus()

        ' Load Nam Hoc list
        Dim listNamHoc = New List(Of NamHocDTO)
        Dim result As Result
        result = namhocBus.selectAll(listNamHoc)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Năm Học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If
        cbNamHoc.DataSource = New BindingSource(listNamHoc, String.Empty)
        cbNamHoc.DisplayMember = "NamHoc"
        cbNamHoc.ValueMember = "MaNamHoc"
        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(cbNamHoc.DataSource)
        myCurrencyManager.Refresh()
        If (listNamHoc.Count > 0) Then
            cbNamHoc.SELECTedIndex = 0
        End If
        'set Mã HK auto
        Dim nextID = 0
        result = hockyBus.getNextID(nextID)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh tự động mã Học Kỳ không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If
        txtMaHocKy.Text = nextID

        'set Thứ Tự HK auto
        Dim nextTTHocKy = 0
        Dim namhoc = CType(cbNamHoc.SELECTedItem, NamHocDTO)
        result = hockyBus.getNextTTHocKy(namhoc.MaNamHoc, nextTTHocKy)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh tự động Thứ Tự Học Kỳ không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If
        txtTTHocKy.Text = nextTTHocKy

        ' Support to generate auto 'Ten Hoc ky'
        txtTenHocKy.Text = "Học Kỳ " + nextTTHocKy.ToString()
    End Sub

    Private Sub btnNhap_Click(sender As Object, e As EventArgs) Handles btnNhap.Click
        Try
            Dim hocky As HocKyDTO
            hocky = New HocKyDTO()

            '1. Mapping data from GUI control
            hocky.MaHocKy = Convert.ToInt32(txtMaHocKy.Text)
            hocky.HocKy = txtTenHocKy.Text
            Dim namhoc = CType(cbNamHoc.SELECTedItem, NamHocDTO)
            hocky.MaNamHoc = namhoc.MaNamHoc

            '2. Business .....
            If (hockyBus.isValidName(hocky) = False) Then
                MessageBox.Show("Tên Học Kỳ không đúng")
                txtTenHocKy.Focus()
                Return
            End If
            '3. Insert to DB
            Dim result As Result
            result = hockyBus.insert(hocky)
            If (result.FlagResult = True) Then
                MessageBox.Show("Thêm Học Kỳ thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'set Mã HK auto
                Dim nextID = 0
                result = hockyBus.getNextID(nextID)
                If (result.FlagResult = False) Then
                    MessageBox.Show("Lấy danh tự động mã Học Kỳ không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    System.Console.WriteLine(result.SystemMessage)
                    Me.Close()
                    Return
                End If
                txtMaHocKy.Text = nextID
                'set Thứ Tự HK auto
                Dim nextTTHocKy = 0
                result = hockyBus.getNextTTHocKy(namhoc.MaNamHoc, nextTTHocKy)
                If (result.FlagResult = False) Then
                    MessageBox.Show("Lấy danh tự động Thứ Tự Học Kỳ không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    System.Console.WriteLine(result.SystemMessage)
                    Me.Close()
                    Return
                End If
                txtTTHocKy.Text = nextTTHocKy

                txtTenHocKy.Text = "Học Kỳ " + nextTTHocKy.ToString()
            Else
                MessageBox.Show("Thêm Học Kỳ không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Console.WriteLine(result.SystemMessage)
            End If
        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
        End Try

    End Sub

    Private Sub btnNhapVaDong_Click(sender As Object, e As EventArgs) Handles btnNhapVaDong.Click
        Try
            Dim hocky As HocKyDTO
            hocky = New HocKyDTO()

            '1. Mapping data from GUI control
            hocky.MaHocKy = Convert.ToInt32(txtMaHocKy.Text)
            hocky.HocKy = txtTenHocKy.Text
            Dim namhoc = CType(cbNamHoc.SELECTedItem, NamHocDTO)
            hocky.MaNamHoc = namhoc.MaNamHoc

            '2. Business .....
            If (hockyBus.isValidName(hocky) = False) Then
                MessageBox.Show("Tên Học Kỳ không đúng")
                txtTenHocKy.Focus()
                Return
            End If
            '3. Insert to DB
            Dim result As Result
            result = hockyBus.insert(hocky)
            If (result.FlagResult = True) Then
                MessageBox.Show("Thêm Học Kỳ thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                MessageBox.Show("Thêm Học Kỳ không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Console.WriteLine(result.SystemMessage)
            End If
        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
        End Try
    End Sub

    Private Sub cbNamHoc_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cbNamHoc.SELECTedIndexChanged
        'set Thứ Tự HK auto
        Dim nextTTHocKy = 0
        Dim namhoc = CType(cbNamHoc.SELECTedItem, NamHocDTO)
        Dim Result = hockyBus.getNextTTHocKy(namhoc.MaNamHoc, nextTTHocKy)
        If (Result.FlagResult = False) Then
            MessageBox.Show("Lấy danh tự động Thứ Tự Học Kỳ không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(Result.SystemMessage)
            Me.Close()
            Return
        End If
        txtTTHocKy.Text = nextTTHocKy

        ' Support to generate auto 'Ten Hoc ky'
        txtTenHocKy.Text = "Học Kỳ " + nextTTHocKy.ToString()
    End Sub
End Class