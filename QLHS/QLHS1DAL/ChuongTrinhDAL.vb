Imports System.Configuration
Imports System.Data.SqlClient
Imports QLHS1DTO
Imports Utility

Public Class ChuongTrinhDAL
    Private connectionString As String

    Public Sub New()
        ' Read ConnectionString value from App.config file
        connectionString = ConfigurationManager.AppSettings("ConnectionString")
    End Sub
    Public Sub New(ConnectionString As String)
        Me.connectionString = ConnectionString
    End Sub

    Public Function getNextIDCT(ByRef nextIDCT As Integer) As Result

        Dim query As String = String.Empty
        query &= "SELECT TOP 1 [machuongtrinh] "
        query &= "FROM [tblchuongtrinh] "
        query &= "ORDER BY [machuongtrinh] DESC "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    Dim idOnDB As Integer
                    idOnDB = Nothing
                    If reader.HasRows = True Then
                        While reader.Read()
                            idOnDB = reader("machuongtrinh")
                        End While
                    End If
                    ' new ID = current ID + 1
                    nextIDCT = idOnDB + 1
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    nextIDCT = 1
                    Return New Result(False, "Lấy ID kế tiếp của Chương Trình không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
	
    Public Function getNextIDCTCT(ByRef nextIDCTCT As Integer) As Result

        Dim query As String = String.Empty
        query &= "SELECT TOP 1 [machitietchuongtrinh] "
        query &= "FROM [tblchitietchuongtrinh] "
        query &= "ORDER BY [machitietchuongtrinh] DESC "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    Dim idOnDB As Integer
                    idOnDB = Nothing
                    If reader.HasRows = True Then
                        While reader.Read()
                            idOnDB = reader("machitietchuongtrinh")
                        End While
                    End If
                    ' new ID = current ID + 1
                    nextIDCTCT = idOnDB + 1
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    nextIDCTCT = 1
                    Return New Result(False, "Lấy ID kế tiếp của Chi Tiết Chương Trình không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function getNextIDHTDG(ByRef nextIDHTDG As Integer) As Result

        Dim query As String = String.Empty
        query &= "SELECT TOP 1 [mahinhthucdanhgia] "
        query &= "FROM [tblhinhthucdanhgia] "
        query &= "ORDER BY [mahinhthucdanhgia] DESC "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    Dim idOnDB As Integer
                    idOnDB = Nothing
                    If reader.HasRows = True Then
                        While reader.Read()
                            idOnDB = reader("mahinhthucdanhgia")
                        End While
                    End If
                    ' new ID = current ID + 1
                    nextIDHTDG = idOnDB + 1
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    nextIDHTDG = 1
                    Return New Result(False, "Lấy ID kế tiếp của Hình Thức Đánh Giá không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
	
    Public Function insertCT(ct As ChuongTrinhDTO) As Result

        Dim query As String = String.Empty
        query &= "INSERT INTO [dbo].[tblchuongtrinh] "
        query &= "(  [machuongtrinh] "
        query &= "  ,[tenchuongtrinh] "
        query &= "  ,[ngaytao]) "
        query &= "VALUES "
        query &= "(   @machuongtrinh"
        query &= "   ,@tenchuongtrinh"
        query &= "   ,@ngaytao)"


        Dim nextIDCT = 0
        Dim result As Result
        result = getNextIDCT(nextIDCT)
        If (result.FlagResult = False) Then
            Return result
        End If
        ct.MaCT = nextIDCT

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@machuongtrinh", ct.MaCT)
                    .Parameters.AddWithValue("@tenchuongtrinh", ct.TenCT)
                    .Parameters.AddWithValue("@ngaytao", ct.NgayTao)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Thêm Chương Trình không thành công", ex.StackTrace)
                End Try
            End Using
        End Using

        'Them Chi tiet chuong trinh
        If (ct.ListCTTT IsNot Nothing And ct.ListCTTT.Count > 0) Then
            For Each ctct In ct.ListCTTT
                ctct.MaCT = ct.MaCT
                result = insertCTCT(ctct)
                If (result.FlagResult = False) Then
                    Return result
                End If
            Next
        End If
        Return New Result(True) ' thanh cong
    End Function

    Public Function insertCTCT(ctct As ChiTietChuongTrinhDTO) As Result

        Dim query As String = String.Empty
        query &= "  INSERT INTO [dbo].[tblchitietchuongtrinh] "
        query &= "             ([machitietchuongtrinh] "
        query &= "             ,[mamonhoc] "
        query &= "             ,[hesomon] "
        query &= "             ,[machuongtrinh]) "
        query &= "       VALUES "
        query &= "             (@machitietchuongtrinh "
        query &= "             ,@mamonhoc "
        query &= "             ,@hesomon "
        query &= "             ,@machuongtrinh) "


        Dim nextIDCTCT = 0
        Dim result As Result
        result = getNextIDCTCT(nextIDCTCT)
        If (result.FlagResult = False) Then
            Return result
        End If
        ctct.MaCTTT = nextIDCTCT

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@machitietchuongtrinh", ctct.MaCTTT)
                    .Parameters.AddWithValue("@mamonhoc", ctct.MaMonHoc)
                    .Parameters.AddWithValue("@hesomon", ctct.HeSoMon)
                    .Parameters.AddWithValue("@machuongtrinh", ctct.MaCT)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Thêm Chi Tiết Chương Trình không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        'Them Hinh Thuc Danh gia cho tung Chi Tiet Chuong Trinh
        If (ctct.ListHTDG IsNot Nothing And ctct.ListHTDG.Count > 0) Then
            For Each htdg In ctct.ListHTDG
                htdg.MaCTTT = ctct.MaCTTT
                result = insertHTDG(htdg)
                If (result.FlagResult = False) Then
                    Return result
                End If
            Next
        End If
        Return New Result(True) ' thanh cong
    End Function

    Public Function insertHTDG(htdg As HinhThucDanhGiaDTO) As Result

        Dim query As String = String.Empty
        query &= "  INSERT INTO [dbo].[tblhinhthucdanhgia] "
        query &= "             ([mahinhthucdanhgia] "
        query &= "             ,[machitietchuongtrinh] "
        query &= "             ,[maloaidiem] "
        query &= "             ,[hesodiem]) "
        query &= "       VALUES "
        query &= "             (@mahinhthucdanhgia "
        query &= "             ,@machitietchuongtrinh "
        query &= "             ,@maloaidiem "
        query &= "             ,@hesodiem ) "

        Dim nextIDHTDG = 0
        Dim result As Result
        result = getNextIDHTDG(nextIDHTDG)
        If (result.FlagResult = False) Then
            Return result
        End If
        htdg.MaHTDG = nextIDHTDG

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mahinhthucdanhgia", htdg.MaHTDG)
                    .Parameters.AddWithValue("@machitietchuongtrinh", htdg.MaCTTT)
                    .Parameters.AddWithValue("@maloaidiem", htdg.MaLoaiDiem)
                    .Parameters.AddWithValue("@hesodiem", htdg.HeSoDiem)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Thêm Hình Thức Đánh Giá không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
	
    Public Function deleteHTDG(htdg As HinhThucDanhGiaDTO) As Result
        Dim query As String = String.Empty
        query &= " DELETE FROM [dbo].[tblhinhthucdanhgia] "
        query &= " WHERE "
        query &= " [mahinhthucdanhgia] = @mahinhthucdanhgia "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mahinhthucdanhgia", htdg.MaHTDG)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Xóa Hình Thức Đánh Giá không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function deleteCTCT(ctct As ChiTietChuongTrinhDTO) As Result

        'Xóa Hinh Thuc Danh gia cho tung Chi Tiet Chuong Trinh
        If (ctct.ListHTDG IsNot Nothing And ctct.ListHTDG.Count > 0) Then
            For Each htdg In ctct.ListHTDG
                Dim result = deleteHTDG(htdg)
                If (result.FlagResult = False) Then
                    Return result
                End If
            Next
        End If

        Dim query As String = String.Empty
        query &= " DELETE FROM [dbo].[tblchitietchuongtrinh] "
        query &= " WHERE "
        query &= " [machitietchuongtrinh] = @machitietchuongtrinh "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@machitietchuongtrinh", ctct.MaCTTT)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Xóa Chi Tiết Chương Trình không thành công", ex.StackTrace)
                End Try
            End Using
        End Using

        Return New Result(True) ' thanh cong
    End Function
	
    Public Function deleteCT(ct As ChuongTrinhDTO) As Result

        'Xóa Chi Tiet Chuong Trinh
        If (ct.ListCTTT IsNot Nothing And ct.ListCTTT.Count > 0) Then
            For Each ctct In ct.ListCTTT
                Dim result = deleteCTCT(ctct)
                If (result.FlagResult = False) Then
                    Return result
                End If
            Next
        End If

        Dim query As String = String.Empty
        query &= " DELETE FROM [dbo].[tblchuongtrinh] "
        query &= " WHERE "
        query &= " [machuongtrinh] = @machuongtrinh "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@machuongtrinh", ct.MaCT)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Xóa Chi Tiết Chương Trình không thành công", ex.StackTrace)
                End Try
            End Using
        End Using

        Return New Result(True) ' thanh cong
    End Function

    Public Function select_byMaCT(iMaCT As Integer, listCT As List(Of ChuongTrinhDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [machuongtrinh], [tenchuongtrinh], [ngaytao]"
        query &= " FROM [tblchuongtrinh]"
        query &= " WHERE "
        query &= " [machuongtrinh]=@machuongtrinh"


        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@machuongtrinh", iMaCT)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listCT.Clear()
                        While reader.Read()
                            listCT.Add(New ChuongTrinhDTO(reader("machuongtrinh"), reader("tenchuongtrinh"), reader("ngaytao"), New List(Of ChiTietChuongTrinhDTO)))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Học Kỳ không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        ' select Chi Tiet Chuong Trinh
        For Each ct In listCT
            Dim result = selectALLCTCT_ByMaCT(ct.MaCT, ct.ListCTTT)
            If (result.FlagResult = False) Then
                Return result
            End If
        Next
        Return New Result(True) ' thanh cong
    End Function

    Public Function selectALL(listCT As List(Of ChuongTrinhDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [machuongtrinh], [tenchuongtrinh], [ngaytao]"
        query &= " FROM [tblchuongtrinh]"


        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listCT.Clear()
                        While reader.Read()
                            listCT.Add(New ChuongTrinhDTO(reader("machuongtrinh"), reader("tenchuongtrinh"), reader("ngaytao"), New List(Of ChiTietChuongTrinhDTO)))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Học Kỳ không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        ' select Chi Tiet Chuong Trinh
        For Each ct In listCT
            Dim result = selectALLCTCT_ByMaCT(ct.MaCT, ct.ListCTTT)
            If (result.FlagResult = False) Then
                Return result
            End If
        Next
        Return New Result(True) ' thanh cong
    End Function
	
    Public Function selectALLCTCT_ByMaCT(iMaCT As Integer, listCTCT As List(Of ChiTietChuongTrinhDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [tblchitietchuongtrinh].[machitietchuongtrinh], [tblmonhoc].[mamonhoc], [tblchitietchuongtrinh].[hesomon], [tblchitietchuongtrinh].[machuongtrinh], [tblmonhoc].[tenmonhoc]"
        query &= " FROM [tblchitietchuongtrinh], [tblmonhoc]"
        query &= " WHERE "
        query &= " [tblchitietchuongtrinh].[mamonhoc] = [tblmonhoc].[mamonhoc]"
        query &= " AND [tblchitietchuongtrinh].[machuongtrinh]= @machuongtrinh"

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@machuongtrinh", iMaCT)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listCTCT.Clear()
                        While reader.Read()
                            listCTCT.Add(New ChiTietChuongTrinhDTO(reader("mamonhoc"), reader("tenmonhoc"), reader("hesomon"), reader("machitietchuongtrinh"), reader("machuongtrinh"), New List(Of HinhThucDanhGiaDTO)))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Học Kỳ không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        ' select Hinh Thuc Danh Gia
        For Each ctct In listCTCT
            Dim result = selectALLHTDG_ByMaCTCT(ctct.MaCTTT, ctct.ListHTDG)
            If (result.FlagResult = False) Then
                Return result
            End If
        Next
        Return New Result(True) ' thanh cong
    End Function
	
    Public Function selectALLHTDG_ByMaCTCT(iMaCTCT As Integer, listHTDG As List(Of HinhThucDanhGiaDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [tblhinhthucdanhgia].[mahinhthucdanhgia], [tblhinhthucdanhgia].[machitietchuongtrinh], [tblhinhthucdanhgia].[maloaidiem], [tblhinhthucdanhgia].[hesodiem], [tblloaidiem].[tenloaidiem]"
        query &= " FROM [tblhinhthucdanhgia], [tblloaidiem]"
        query &= " WHERE "
        query &= " [tblhinhthucdanhgia].[maloaidiem]=[tblloaidiem].[maloaidiem]"
        query &= " AND [machitietchuongtrinh]= @machitietchuongtrinh"

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@machitietchuongtrinh", iMaCTCT)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listHTDG.Clear()
                        While reader.Read()
                            listHTDG.Add(New HinhThucDanhGiaDTO(reader("mahinhthucdanhgia"), reader("machitietchuongtrinh"), reader("maloaidiem"), reader("hesodiem"), reader("tenloaidiem")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Học Kỳ không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        ' select Hinh Thuc Danh Gia

        Return New Result(True) ' thanh cong
    End Function

    Public Function updateCT_MasterPart(ct As ChuongTrinhDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tblchuongtrinh] SET"
        query &= " [tenchuongtrinh] = @tenchuongtrinh "
        query &= "WHERE "
        query &= " [machuongtrinh] = @machuongtrinh "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@tenchuongtrinh", ct.TenCT)
                    .Parameters.AddWithValue("@machuongtrinh", ct.MaCT)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập nhật phần Master của Chương Trình không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
	
    Public Function updateCT_Cascade(ct As ChuongTrinhDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tblchuongtrinh] SET"
        query &= " [tenchuongtrinh] = @tenchuongtrinh "
        query &= " WHERE "
        query &= " [machuongtrinh] = @machuongtrinh "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@tenchuongtrinh", ct.TenCT)
                    .Parameters.AddWithValue("@machuongtrinh", ct.MaCT)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập nhật phần Master của Chương Trình không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        'Update cascade for Chi Tiết Chương Trình
        Dim listCTCTonDB = New List(Of ChiTietChuongTrinhDTO)
        Dim result = selectALLCTCT_ByMaCT(ct.MaCT, listCTCTonDB)
        If (result.FlagResult = False) Then
            Return result
        End If
        Dim f = False
        For Each ctctOnDB In listCTCTonDB
			f = False
            For Each ctct In ct.ListCTTT
                If (ctctOnDB.MaCTTT = ctct.MaCTTT) Then
                    f = True
                    Exit For
                End If
            Next
            If (f = False) Then ' record on DB is NOT found on GUI  -> Delete
                result = deleteCTCT(ctctOnDB)
                If (result.FlagResult = False) Then
                    Return result
                End If
            End If
        Next
        f = False
        For Each ctct In ct.ListCTTT
			f = False
            For Each ctctOnDB In listCTCTonDB
                If (ctct.MaCTTT = ctctOnDB.MaCTTT) Then
                    f = True
                    Exit For
                End If
            Next
            If (f = False) Then ' record on GUI is NOT found on DB  -> Insert new
                ctct.MaCT = ct.MaCT
                insertCTCT(ctct)
                If (result.FlagResult = False) Then
                    Return result
                End If
            Else ' Updated
                updateCTCT_Cascade(ctct)
                If (result.FlagResult = False) Then
                    Return result
                End If
            End If
        Next
        Return New Result(True) ' thanh cong
    End Function

    Public Function updateCTCT(ctct As ChiTietChuongTrinhDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tblchitietchuongtrinh] SET"
        query &= " [hesomon] = @hesomon "
        query &= " WHERE "
        query &= " [machitietchuongtrinh] = @machitietchuongtrinh "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@hesomon", ctct.HeSoMon)
                    .Parameters.AddWithValue("@machitietchuongtrinh", ctct.MaCTTT)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập nhật Chi Tiết Chương Trình không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
	
    Public Function updateCTCT_Cascade(ctct As ChiTietChuongTrinhDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tblchitietchuongtrinh] SET"
        query &= " [hesomon] = @hesomon "
        query &= " WHERE "
        query &= " [machitietchuongtrinh] = @machitietchuongtrinh "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@hesomon", ctct.HeSoMon)
                    .Parameters.AddWithValue("@machitietchuongtrinh", ctct.MaCTTT)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập nhật Chi Tiết Chương Trình không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        'Update cascade for Hình thức đánh giá
        Dim listHTDGonDB = New List(Of HinhThucDanhGiaDTO)
        Dim result = selectALLHTDG_ByMaCTCT(ctct.MaCTTT, listHTDGonDB)
        If (result.FlagResult = False) Then
            Return result
        End If
        Dim f = False
        For Each htdgOnDB In listHTDGonDB
            f = False
            For Each htdg In ctct.ListHTDG
                If (htdgOnDB.MaHTDG = htdg.MaHTDG) Then
                    f = True
                    Exit For
                End If
            Next
            If (f = False) Then ' record on DB is NOT found on GUI  -> Delete
                result = deleteHTDG(htdgOnDB)
                If (result.FlagResult = False) Then
                    Return result
                End If
            End If
        Next

        For Each htdg In ctct.ListHTDG
            f = False
            For Each htdgOnDB In listHTDGonDB
                If (htdg.MaHTDG = htdgOnDB.MaHTDG) Then
                    f = True
                    Exit For
                End If
            Next
            If (f = False) Then ' record on GUI is NOT found on DB  -> Insert new
                htdg.MaCTTT = ctct.MaCTTT
                insertHTDG(htdg)
                If (result.FlagResult = False) Then
                    Return result
                End If
            Else ' Updated
                updateHTDG(htdg)
                If (result.FlagResult = False) Then
                    Return result
                End If
            End If
        Next
        Return New Result(True) ' thanh cong
    End Function
	
    Public Function updateHTDG(htdg As HinhThucDanhGiaDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tblhinhthucdanhgia] SET"
        query &= " [hesodiem] = @hesodiem "
        query &= " WHERE "
        query &= " [mahinhthucdanhgia] = @mahinhthucdanhgia "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@hesodiem", htdg.HeSoDiem)
                    .Parameters.AddWithValue("@mahinhthucdanhgia", htdg.MaHTDG)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập nhật Hình Thức Đánh Giá không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
End Class
