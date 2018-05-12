Imports System.Configuration
Imports System.Data.SqlClient
Imports QLHS1DTO
Imports Utility

Public Class DiemDAL
    Private connectionString As String

    Public Sub New()
        ' Read ConnectionString value from App.config file
        connectionString = ConfigurationManager.AppSettings("ConnectionString")
    End Sub
    Public Sub New(ConnectionString As String)
        Me.connectionString = ConnectionString
    End Sub

    Public Function insert(diem As DiemDTO) As Result

        Dim f = False
        Dim result = select_Check(diem, f)
        If (result.FlagResult = False) Then
            Return result
        End If
        If (f = True) Then 'Diem existed on DB
            Return Me.update(diem)
        End If

        Dim query As String = String.Empty
        query &= "INSERT INTO [tbldiem] ([mahinhthucdanhgia], [mahocsinh], [diemso], [ngaynhap], [ngaycapnhat], [useridnhap], [useridcapnhat])"
        query &= "VALUES (@mahinhthucdanhgia,@mahocsinh,@diemso,@ngaynhap,@ngaycapnhat,@useridnhap,@useridcapnhat)"

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mahinhthucdanhgia", diem.MaHTDG)
                    .Parameters.AddWithValue("@mahocsinh", diem.MSHS)
                    .Parameters.AddWithValue("@diemso", diem.Diem)
                    .Parameters.AddWithValue("@ngaynhap", diem.NgayNhap)
                    .Parameters.AddWithValue("@ngaycapnhat", diem.NgayCapNhat)
                    .Parameters.AddWithValue("@useridnhap", diem.UserIdNhap)
                    .Parameters.AddWithValue("@useridcapnhat", diem.UserIdCapNhat)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Thêm điểm không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function update(diem As DiemDTO) As Result

        Dim f = True
        Dim result = select_Check(diem, f)
        If (result.FlagResult = False) Then
            Return result
        End If
        If (f = False) Then 'Diem NOT existed on DB
            Return Me.insert(diem)
        End If

        Dim query As String = String.Empty
        query &= " UPDATE [tbldiem] SET"
        query &= " [diemso] = @diemso "
        query &= " ,[ngaycapnhat] = @ngaycapnhat "
        query &= " ,[useridcapnhat] = @useridcapnhat "
        query &= "WHERE "
        query &= " [mahocsinh] = @mahocsinh "
        query &= " AND [mahinhthucdanhgia] = @mahinhthucdanhgia "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@diemso", diem.Diem)
                    .Parameters.AddWithValue("@ngaycapnhat", diem.NgayCapNhat)
                    .Parameters.AddWithValue("@useridcapnhat", diem.UserIdCapNhat)
                    .Parameters.AddWithValue("@mahinhthucdanhgia", diem.MaHTDG)
                    .Parameters.AddWithValue("@mahocsinh", diem.MSHS)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập nhật điểm không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function delete(diem As DiemDTO) As Result

        Dim query As String = String.Empty
        query &= " DELETE FROM [tbldiem] "
        query &= " WHERE "
        query &= " [mahocsinh] = @mahocsinh "
        query &= " AND [mahinhthucdanhgia] = @mahinhthucdanhgia "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mahinhthucdanhgia", diem.MaHTDG)
                    .Parameters.AddWithValue("@mahocsinh", diem.MSHS)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Xóa điểm không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Private Function select_Check(diem As DiemDTO, ByRef f As Boolean) As Result ' f = true --> existed on DB, = false on otherwise

        Dim query As String = String.Empty
        query &= " SELECT [mahinhthucdanhgia] "
        query &= "       ,[mahocsinh] "
        query &= "       ,[diemso] "
        query &= "       ,[ngaynhap] "
        query &= "       ,[ngaycapnhat] "
        query &= "       ,[useridnhap] "
        query &= "       ,[useridcapnhat] "
        query &= "   FROM [dbo].[tbldiem] "
        query &= "   WHERE "
        query &= " 	        [mahinhthucdanhgia] =  @mahinhthucdanhgia"
        query &= " 	 AND    [mahocsinh]= @mahocsinh"

        f = False
        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mahinhthucdanhgia", diem.MaHTDG)
                    .Parameters.AddWithValue("@mahocsinh", diem.MSHS)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        f = True ' Diem existed on DB
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy danh sách các môn học của chương trình mà học sinh đang theo học không thành công", ex.StackTrace)
                End Try
            End Using
        End Using

        Return New Result(True) ' thanh cong
    End Function

    Public Function selectMonHoc_ByMaLop(maLop As Integer, listMonHoc As List(Of MonHocDTO)) As Result
        Dim query As String = String.Empty
        query &= " select [tblmonhoc].[mamonhoc], [tblmonhoc].[tenmonhoc] "
        query &= " from "
        query &= " [tblapdung] "
        query &= " ,[tblchuongtrinh] "
        query &= " ,[tblchitietchuongtrinh] "
        query &= " ,[tblmonhoc] "
        query &= " where "
        query &= " [tblapdung].[malop] = @malop "
        query &= " and  [tblapdung].[machuongtrinh] = [tblchuongtrinh].[machuongtrinh]   "
        query &= " and  [tblchuongtrinh].[machuongtrinh]  = [tblchitietchuongtrinh].[machuongtrinh] "
        query &= " and  [tblchitietchuongtrinh].[mamonhoc] =  [tblmonhoc].[mamonhoc]  "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@malop", maLop)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listMonHoc.Clear()
                        While reader.Read()
                            listMonHoc.Add(New MonHocDTO(reader("mamonhoc"), reader("tenmonhoc")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy danh sách các môn học của chương trình mà học sinh đang theo học không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function selectDiem_LeftJoinByMaHSMaLopMaMonHoc(maHocSinh As String, maLop As Integer, maMonHoc As Integer, listDiemView As List(Of DiemViewDTO)) As Result
        Dim query As String = String.Empty
        query &= " select [infoloaidiem].[mahocsinh], [infoloaidiem].[mamonhoc], [infoloaidiem].[tenmonhoc],  [infoloaidiem].[mahinhthucdanhgia], [infoloaidiem].[tenloaidiem], [infoloaidiem].[maloaidiem], [infoloaidiem].[hesodiem] ,[filterdiem].[diemso] "
        query &= " from "
        query &= " ( "
        query &= " Select [tbllophocsinh].[mahocsinh],[tblmonhoc].[tenmonhoc], [tblmonhoc].[mamonhoc] , [tblloaidiem].[tenloaidiem], [tblloaidiem].[maloaidiem], [tblhinhthucdanhgia].[hesodiem], [tblhinhthucdanhgia].[mahinhthucdanhgia] "
        query &= " from  "
        query &= " 	[tblhinhthucdanhgia] "
        query &= " 	,[tblloaidiem] "
        query &= " 	,[tblapdung] "
        query &= " 	,[tblchuongtrinh] "
        query &= " 	,[tblchitietchuongtrinh] "
        query &= " 	,[tblmonhoc] "
        query &= " 	,[tbllophocsinh] "
        query &= " where "
        query &= " 	[tblapdung].[malop] = @malop "
        query &= " 	And  [tblmonhoc].[mamonhoc] = @mamonhoc "
        query &= " 	And  [tbllophocsinh].[mahocsinh] = @mahocsinh "
        query &= " 	and  [tblapdung].[machuongtrinh] = [tblchuongtrinh].[machuongtrinh]   "
        query &= " 	and  [tblchuongtrinh].[machuongtrinh]  = [tblchitietchuongtrinh].[machuongtrinh] "
        query &= " 	and  [tblchitietchuongtrinh].[machitietchuongtrinh] = [tblhinhthucdanhgia].[machitietchuongtrinh]   "
        query &= " 	and  [tblchitietchuongtrinh].[mamonhoc] =  [tblmonhoc].[mamonhoc] "
        query &= " 	AND  [tblhinhthucdanhgia].maloaidiem = [tblloaidiem].[maloaidiem] "
        query &= " 	and  [tbllophocsinh].[malop] =  [tblapdung].[malop]  "
        query &= " ) as [infoloaidiem] "
        query &= " left join  "
        query &= " ( "
        query &= " 	select * "
        query &= " 	from [tbldiem] "
        query &= " 	where  "
        query &= " 	[tbldiem].[mahocsinh] =  N'16000001' "
        query &= " ) as [filterdiem] "
        query &= " on [infoloaidiem].[mahinhthucdanhgia]=  [filterdiem].[mahinhthucdanhgia] "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@malop", maLop)
                    .Parameters.AddWithValue("@mamonhoc", maMonHoc)
                    .Parameters.AddWithValue("@mahocsinh", maHocSinh)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listDiemView.Clear()
                        While reader.Read()
                            Dim diemview = New DiemViewDTO()
                            diemview.MSHS = reader("mahocsinh")
                            diemview.MaMonHoc = reader("mamonhoc")
                            diemview.MonHoc = reader("tenmonhoc")
                            diemview.MaHTDG = reader("mahinhthucdanhgia")
                            diemview.TenLoaiDiem = reader("tenloaidiem")
                            diemview.MaLoaiDiem = reader("maloaidiem")
                            diemview.HeSoDiem = reader("hesodiem")
                            If (reader("diemso") Is DBNull.Value) Then
                                diemview.Diem = -1
                            Else
                                diemview.Diem = reader("diemso")
                            End If
                            listDiemView.Add(diemview)
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy danh sách điểm của môn học của học sinh đang theo học không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function selectALLHTDG_ByMaLopAndMaMonHoc(iMaLop As Integer, iMaMonHoc As Integer, listHTDG As List(Of HinhThucDanhGiaDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [tblhinhthucdanhgia].[mahinhthucdanhgia], [tblhinhthucdanhgia].[machitietchuongtrinh], [tblhinhthucdanhgia].[maloaidiem], [tblhinhthucdanhgia].[hesodiem], [tblloaidiem].[tenloaidiem] "
        query &= " from "
        query &= " [tblapdung] "
        query &= " ,[tblchuongtrinh] "
        query &= " ,[tblchitietchuongtrinh] "
        query &= " 		,[tblhinhthucdanhgia] "
        query &= " ,[tblmonhoc] "
        query &= " 		,[tblloaidiem] "
        query &= " where "
        query &= " [tblapdung].[malop] = @malop "
        query &= " 		and [tblchitietchuongtrinh].[mamonhoc] = @mamonhoc "
        query &= " and  [tblapdung].[machuongtrinh] = [tblchuongtrinh].[machuongtrinh]   "
        query &= " and  [tblchuongtrinh].[machuongtrinh]  = [tblchitietchuongtrinh].[machuongtrinh] "
        query &= " 		and [tblchitietchuongtrinh].[machitietchuongtrinh] = [tblhinhthucdanhgia].[machitietchuongtrinh] "
        query &= " and  [tblchitietchuongtrinh].[mamonhoc] =  [tblmonhoc].[mamonhoc] "
        query &= " 		and [tblloaidiem].[maloaidiem] = [tblhinhthucdanhgia].[maloaidiem]  "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@malop", iMaLop)
                    .Parameters.AddWithValue("@mamonhoc", iMaMonHoc)
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
                    Return New Result(False, "Lấy tất cả HTDG theo MaLop Va MaMonHoc không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function selectDiem_LeftJoinByMaLopMaMonHocMaHTDG(maLop As Integer, maMonHoc As Integer, maHTDG As Integer, listDiemView As List(Of DiemViewDTO)) As Result
        Dim query As String = String.Empty
        query &= " select [infoloaidiem].[mahocsinh], [infoloaidiem].[mamonhoc], [infoloaidiem].[tenmonhoc],  [infoloaidiem].[mahinhthucdanhgia], [infoloaidiem].[tenloaidiem], [infoloaidiem].[maloaidiem], [infoloaidiem].[hesodiem] ,[filterdiem].[diemso] "
        query &= " from "
        query &= " ( "
        query &= " Select [tbllophocsinh].[mahocsinh],[tblmonhoc].[tenmonhoc], [tblmonhoc].[mamonhoc] , [tblloaidiem].[tenloaidiem], [tblloaidiem].[maloaidiem], [tblhinhthucdanhgia].[hesodiem], [tblhinhthucdanhgia].[mahinhthucdanhgia] "
        query &= " from  "
        query &= " 	[tblhinhthucdanhgia] "
        query &= " 	,[tblloaidiem] "
        query &= " 	,[tblapdung] "
        query &= " 	,[tblchuongtrinh] "
        query &= " 	,[tblchitietchuongtrinh] "
        query &= " 	,[tblmonhoc] "
        query &= " 	,[tbllophocsinh] "
        query &= " where "
        query &= " 	[tblapdung].[malop] = @malop "
        query &= " 	And  [tblmonhoc].[mamonhoc] = @mamonhoc "
        query &= " 	And  [tblhinhthucdanhgia].[mahinhthucdanhgia]  = @mahinhthucdanhgia "
        query &= " 	and  [tblapdung].[machuongtrinh] = [tblchuongtrinh].[machuongtrinh]   "
        query &= " 	and  [tblchuongtrinh].[machuongtrinh]  = [tblchitietchuongtrinh].[machuongtrinh] "
        query &= " 	and  [tblchitietchuongtrinh].[machitietchuongtrinh] = [tblhinhthucdanhgia].[machitietchuongtrinh]   "
        query &= " 	and  [tblchitietchuongtrinh].[mamonhoc] =  [tblmonhoc].[mamonhoc] "
        query &= " 	AND  [tblhinhthucdanhgia].maloaidiem = [tblloaidiem].[maloaidiem] "
        query &= " 	and  [tbllophocsinh].[malop] =  [tblapdung].[malop]  "
        query &= " ) as [infoloaidiem] "
        query &= " left join  "
        query &= " ( "
        query &= " 	select * "
        query &= " 	from [tbldiem] "
        query &= " 	where  "
        query &= " 	[tbldiem].[mahinhthucdanhgia]  = @mahinhthucdanhgia "
        query &= " ) as [filterdiem] "
        query &= " on [infoloaidiem].[mahinhthucdanhgia]=  [filterdiem].[mahinhthucdanhgia]  "
        query &= " 	and [infoloaidiem].[mahocsinh] = [filterdiem].[mahocsinh]  "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@malop", maLop)
                    .Parameters.AddWithValue("@mamonhoc", maMonHoc)
                    .Parameters.AddWithValue("@mahinhthucdanhgia", maHTDG)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listDiemView.Clear()
                        While reader.Read()
                            Dim diemview = New DiemViewDTO()
                            diemview.MSHS = reader("mahocsinh")
                            diemview.MaMonHoc = reader("mamonhoc")
                            diemview.MonHoc = reader("tenmonhoc")
                            diemview.MaHTDG = reader("mahinhthucdanhgia")
                            diemview.TenLoaiDiem = reader("tenloaidiem")
                            diemview.MaLoaiDiem = reader("maloaidiem")
                            diemview.HeSoDiem = reader("hesodiem")
                            If (reader("diemso") Is DBNull.Value) Then
                                diemview.Diem = -1
                            Else
                                diemview.Diem = reader("diemso")
                            End If
                            listDiemView.Add(diemview)
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy danh sách điểm của môn học của học sinh đang theo học không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
End Class
