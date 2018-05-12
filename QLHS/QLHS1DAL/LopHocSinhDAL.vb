Imports System.Configuration
Imports System.Data.SqlClient
Imports QLHS1DTO
Imports Utility

Public Class LopHocSinhDAL
    Private connectionString As String

    Public Sub New()
        ' Read ConnectionString value from App.config file
        connectionString = ConfigurationManager.AppSettings("ConnectionString")
    End Sub
    Public Sub New(ConnectionString As String)
        Me.connectionString = ConnectionString
    End Sub

    Public Function insert(nh As LopHocSinhDTO) As Result

        Dim query As String = String.Empty
        'query &= "INSERT INTO [tbllophocsinh] ([mahocsinh], [malop], [mahocky])"
        query &= "INSERT INTO [tbllophocsinh] ([mahocsinh], [malop])"
        'query &= "VALUES (@mahocsinh,@malop,@mahocky)"
        query &= "VALUES (@mahocsinh,@malop)"

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mahocsinh", nh.MSHS)
                    .Parameters.AddWithValue("@malop", nh.MaLop)
                    '.Parameters.AddWithValue("@mahocky", nh.MaHocKy)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Thêm học sinh vào lớp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function update(nh As LopHocSinhDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tbllophocsinh] SET"
        query &= " [malop] = @malop "
        query &= " WHERE "
        query &= " [mahocsinh] = @mahocsinh "
        'query &= " AND [mahocky] = @mahocky "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mahocsinh", nh.MSHS)
                    .Parameters.AddWithValue("@malop", nh.MaLop)
                    '.Parameters.AddWithValue("@mahocky", nh.MaHocKy)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập nhật học sinh vào lớp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function selectALL(ByRef listLopHocSinh As List(Of LopHocSinhDTO)) As Result

        Dim query As String = String.Empty
        'query &= " SELECT [mahocsinh], [malop], [mahocky]"
        query &= " SELECT [mahocsinh], [malop]"
        query &= " FROM [tbllophocsinh]"


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
                        listLopHocSinh.Clear()
                        While reader.Read()
                            'listLopHocSinh.Add(New LopHocSinhDTO(reader("malop"), reader("mahocsinh"), reader("mahocky")))
                            listLopHocSinh.Add(New LopHocSinhDTO(reader("malop"), reader("mahocsinh")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả lớp học sinh không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function selectALL_ByMaLop(iMaLop As Integer, ByRef listLopHocSinh As List(Of LopHocSinhDTO)) As Result

        Dim query As String = String.Empty
        'query &= " SELECT [mahocsinh], [malop], [mahocky]"
        query &= " SELECT [mahocsinh], [malop]"
        query &= " FROM [tbllophocsinh]"
        query &= " WHERE "
        query &= " [malop] = @malop "

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
                        listLopHocSinh.Clear()
                        While reader.Read()
                            'listLopHocSinh.Add(New LopHocSinhDTO(reader("malop"), reader("mahocsinh"), reader("mahocky")))
                            listLopHocSinh.Add(New LopHocSinhDTO(reader("malop"), reader("mahocsinh")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả lớp học sinh không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function


    Public Function delete(lhs As LopHocSinhDTO) As Result

        Dim query As String = String.Empty
        query &= " DELETE FROM [tbllophocsinh] "
        query &= " WHERE "
        query &= " [mahocsinh] = @mahocsinh "
        query &= " AND [malop] = @malop "
        'query &= " AND [mahocky] = @mahocky "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mahocsinh", lhs.MSHS)
                    .Parameters.AddWithValue("@malop", lhs.MaLop)
                    '.Parameters.AddWithValue("@mahocky", lhs.MaHocKy)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Xóa học sinh của lớp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
End Class
