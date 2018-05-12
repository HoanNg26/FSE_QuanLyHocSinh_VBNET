Imports System.Configuration
Imports System.Data.SqlClient
Imports QLHS1DTO
Imports Utility

Public Class HocSinhDAL
    Private connectionString As String

    Public Sub New()
        ' Read ConnectionString value from App.config file
        connectionString = ConfigurationManager.AppSettings("ConnectionString")
    End Sub
    Public Sub New(ConnectionString As String)
        Me.connectionString = ConnectionString
    End Sub


    Public Function buildMSHS(ByRef nextMshs As String) As Result 'ex: 18222229

        nextMshs = String.Empty
        Dim y = DateTime.Now.Year
        Dim x = y.ToString().Substring(2)
        nextMshs = x + "000000"

        Dim query As String = String.Empty
        query &= "SELECT TOP 1 [mshs] "
        query &= "FROM [tblHocSinh] "
        query &= "ORDER BY [mshs] DESC "

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
                    Dim msOnDB As String
                    msOnDB = Nothing
                    If reader.HasRows = True Then
                        While reader.Read()
                            msOnDB = reader("mshs")
                        End While
                    End If
                    If (msOnDB <> Nothing And msOnDB.Length >= 8) Then
                        Dim currentYear = DateTime.Now.Year.ToString().Substring(2)
                        Dim iCurrentYear = Integer.Parse(currentYear)
                        Dim currentYearOnDB = msOnDB.Substring(0, 2)
                        Dim icurrentYearOnDB = Integer.Parse(currentYearOnDB)
                        Dim year = iCurrentYear
                        If (year < icurrentYearOnDB) Then
                            year = icurrentYearOnDB
                        End If
                        nextMshs = year.ToString()
                        Dim v = msOnDB.Substring(2)
                        Dim convertDecimal = Convert.ToDecimal(v)
                        convertDecimal = convertDecimal + 1
                        Dim tmp = convertDecimal.ToString()
                        tmp = tmp.PadLeft(msOnDB.Length - 2, "0")
                        nextMshs = nextMshs + tmp
                        System.Console.WriteLine(nextMshs)
                    End If

                Catch ex As Exception
                    conn.Close() ' that bai!!!
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy tự động Mã số Học sinh kế tiếp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function insert(hs As HocSinhDTO) As Result

        Dim query As String = String.Empty
        query &= "INSERT INTO [tblHocSinh] ([mshs], [maloaihocsinh], [hoten], [diachi], [ngaysinh])"
        query &= "VALUES (@mshs,@maloaihocsinh,@hoten,@diachi,@ngaysinh)"

        'get MSHS
        Dim nextMshs = "1"
        buildMSHS(nextMshs)
        hs.MSHS = nextMshs

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mshs", hs.MSHS)
                    .Parameters.AddWithValue("@maloaihocsinh", hs.LoaiHS)
                    .Parameters.AddWithValue("@hoten", hs.HoTen)
                    .Parameters.AddWithValue("@diachi", hs.DiaChi)
                    .Parameters.AddWithValue("@ngaysinh", hs.NgaySinh)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Thêm Học sinh không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function selectALL(ByRef listHocSinh As List(Of HocSinhDTO)) As Result

        Dim query As String = String.Empty
        query &= "SELECT [mshs], [maloaihocsinh], [hoten], [diachi], [ngaysinh]"
        query &= "FROM [tblHocSinh]"


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
                        listHocSinh.Clear()
                        While reader.Read()
                            listHocSinh.Add(New HocSinhDTO(reader("mshs"), reader("maloaihocsinh"), reader("hoten"), reader("diachi"), reader("ngaysinh")))
                        End While
                    End If

                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy tất cả Học sinh không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function selectALL_ByMaLop(iMaLop As Integer, ByRef listHocSinh As List(Of HocSinhDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [mshs], [maloaihocsinh], [hoten], [diachi], [ngaysinh] "
        query &= " FROM [tblHocSinh] "
        query &= "     ,[tbllophocsinh] "
        query &= " WHERE "
        query &= "     [tblHocSinh].[mshs] = [tbllophocsinh].[mahocsinh]"
        query &= "     AND [tbllophocsinh].[malop] = @malop"



        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@malop", iMaLop)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listHocSinh.Clear()
                        While reader.Read()
                            listHocSinh.Add(New HocSinhDTO(reader("mshs"), reader("maloaihocsinh"), reader("hoten"), reader("diachi"), reader("ngaysinh")))
                        End While
                    End If

                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy tất cả Học sinh theo Lớp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function selectALL_ByType(maLoai As Integer, ByRef listHocSinh As List(Of HocSinhDTO)) As Result

        Dim query As String = String.Empty
        query &= "SELECT [mshs], [maloaihocsinh], [hoten], [diachi], [ngaysinh] "
        query &= "FROM [tblHocSinh] "
        query &= "WHERE [maloaihocsinh] = @maloaihocsinh "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@maloaihocsinh", maLoai)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listHocSinh.Clear()
                        While reader.Read()
                            listHocSinh.Add(New HocSinhDTO(reader("mshs"), reader("maloaihocsinh"), reader("hoten"), reader("diachi"), reader("ngaysinh")))
                        End While
                    End If

                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy tất cả Học sinh theo Loại không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function


    Public Function update(hs As HocSinhDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tblHocSinh] SET"
        query &= " [maloaihocsinh] = @maloaihocsinh "
        query &= " ,[hoten] = @hoten "
        query &= " ,[diachi] = @diachi "
        query &= " ,[ngaysinh] = @ngaysinh "
        query &= " WHERE "
        query &= " [mshs] = @mshs "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@maloaihocsinh", hs.LoaiHS)
                    .Parameters.AddWithValue("@hoten", hs.HoTen)
                    .Parameters.AddWithValue("@diachi", hs.DiaChi)
                    .Parameters.AddWithValue("@ngaysinh", hs.NgaySinh)
                    .Parameters.AddWithValue("@mshs", hs.MSHS)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Cập nhật Học sinh không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function


    Public Function delete(maHocSinh As String) As Result

        Dim query As String = String.Empty
        query &= " DELETE FROM [tblHocSinh] "
        query &= " WHERE "
        query &= " [mshs] = @mshs "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mshs", maHocSinh)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Xóa Học sinh không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)  ' thanh cong
    End Function
End Class
