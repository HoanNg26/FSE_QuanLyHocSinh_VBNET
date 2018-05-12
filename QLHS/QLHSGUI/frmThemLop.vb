Imports QLHS1BUS
Imports QLHS1DTO
Imports Utility

Public Class frmThemLop
    Private lopBus As LopBus
    Private khoiBus As KhoiBus
    Private namhocBus As NamHocBus
    Private hockyBus As HocKyBus
    Private Sub frmThemLop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lopBus = New LopBus()
        khoiBus = New KhoiBus()
        namhocBus = New NamHocBus()
        hockyBus = New HocKyBus()

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
        If (listNamHoc.Count > 0) Then
            cbNamHoc.SELECTedIndex = 0
        End If

        ' Load Khoi list
        Dim listKhoi = New List(Of KhoiDTO)
        result = khoiBus.selectAll(listKhoi)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Khối không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If
        cbKhoi.DataSource = New BindingSource(listKhoi, String.Empty)
        cbKhoi.DisplayMember = "Khoi"
        cbKhoi.ValueMember = "MaKhoi"
        myCurrencyManager = Me.BindingContext(cbKhoi.DataSource)
        myCurrencyManager.Refresh()
        If (listKhoi.Count > 0) Then
            cbKhoi.SELECTedIndex = 0
        End If
        'set Mã HK auto
        Dim nextID = 0
        result = lopBus.getNextID(nextID)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh tự động mã Lớp không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If
        txtMaLop.Text = nextID
    End Sub

    Private Sub btnNhapVaDong_Click(sender As Object, e As EventArgs) Handles btnNhapVaDong.Click
        Dim lopDTO As LopDTO
        lopDTO = New LopDTO()
        '1. Mapping data from GUI control
        lopDTO.MaLop = Convert.ToInt32(txtMaLop.Text)
        lopDTO.TenLop = txtTenLop.Text
        Dim hocky = CType(cbTuHocKy.SELECTedItem, HocKyDTO)
        lopDTO.MaHocKy = hocky.MaHocKy
        Dim khoi = CType(cbKhoi.SELECTedItem, KhoiDTO)
        lopDTO.MaKhoi = khoi.MaKhoi

        '2. Business .....
        If (lopBus.isValidName(lopDTO) = False) Then
            MessageBox.Show("Tên Lớp không đúng")
            txtTenLop.Focus()
            Return
        End If
        '3. Insert to DB
        Dim result As Result
        result = lopBus.insert(lopDTO)
        If (result.FlagResult = True) Then
            MessageBox.Show("Thêm Lớp thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtTenLop.Text = String.Empty
            Me.Close()
        Else
            MessageBox.Show("Thêm Lớp không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If
    End Sub

    Private Sub btnNhap_Click(sender As Object, e As EventArgs) Handles btnNhap.Click
        Dim lopDTO As LopDTO
        lopDTO = New LopDTO()

        '1. Mapping data from GUI control
        lopDTO.MaLop = Convert.ToInt32(txtMaLop.Text)
        lopDTO.TenLop = txtTenLop.Text
        Dim hocky = CType(cbTuHocKy.SELECTedItem, HocKyDTO)
        lopDTO.MaHocKy = hocky.MaHocKy
        Dim khoi = CType(cbKhoi.SELECTedItem, KhoiDTO)
        lopDTO.MaKhoi = khoi.MaKhoi

        '2. Business .....
        If (lopBus.isValidName(lopDTO) = False) Then
            MessageBox.Show("Tên Lớp không đúng")
            txtTenLop.Focus()
            Return
        End If
        '3. Insert to DB
        Dim result As Result
        result = lopBus.insert(lopDTO)
        If (result.FlagResult = True) Then
            MessageBox.Show("Thêm Lớp thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'set Mã HK auto
            Dim nextID = 0
            result = lopBus.getNextID(nextID)
            If (result.FlagResult = False) Then
                MessageBox.Show("Lấy danh tự động mã Lớp không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Console.WriteLine(result.SystemMessage)
                Me.Close()
                Return
            End If
            txtMaLop.Text = nextID
            txtTenLop.Text = String.Empty

        Else
            MessageBox.Show("Thêm Lớp không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If
    End Sub

    Private Sub cbNamHoc_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cbNamHoc.SELECTedIndexChanged
        Try
            Dim namhoc = CType(cbNamHoc.SELECTedItem, NamHocDTO)

            Dim listHocKy = New List(Of HocKyDTO)
            Dim Result = hockyBus.selectALL_ByMaNamHoc(namhoc.MaNamHoc, listHocKy)
            If (Result.FlagResult = False) Then
                MessageBox.Show("Lấy danh sách Học Kỳ theo Năm Học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Console.WriteLine(Result.SystemMessage)
                Return
            End If

            cbTuHocKy.DataSource = New BindingSource(listHocKy, String.Empty)
            cbTuHocKy.DisplayMember = "HocKy"
            cbTuHocKy.ValueMember = "MaHocKy"
            Dim myCurrencyManager As CurrencyManager = Me.BindingContext(cbTuHocKy.DataSource)
            myCurrencyManager.Refresh()
            If (listHocKy.Count > 0) Then
                cbTuHocKy.SELECTedIndex = 0
            End If
        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
        End Try
    End Sub
End Class