Imports System.Configuration
Imports System.Data.SqlClient
Imports QLHS1DTO
Imports Utility

Public Class LopDAL
    Private connectionString As String

    Public Sub New()
        ' Read ConnectionString value from App.config file
        connectionString = ConfigurationManager.AppSettings("ConnectionString")
    End Sub
    Public Sub New(ConnectionString As String)
        Me.connectionString = ConnectionString
    End Sub

    Public Function getNextID(ByRef nextID As Integer) As Result

        Dim query As String = String.Empty
        query &= "SELECT TOP 1 [malop] "
        query &= "FROM [tbllop] "
        query &= "ORDER BY [malop] DESC "

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
                            idOnDB = reader("malop")
                        End While
                    End If
                    ' new ID = current ID + 1
                    nextID = idOnDB + 1
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    nextID = 1
                    Return New Result(False, "Lấy ID kế tiếp của lớp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function insert(lop As LopDTO) As Result

        Dim query As String = String.Empty
        query &= "INSERT INTO [tbllop] ([malop], [tenlop],[makhoi],[mahocky])"
        query &= "VALUES (@malop,@tenlop,@makhoi,@mahocky)"

        Dim nextID = 0
        Dim result As Result
        result = getNextID(nextID)
        If (result.FlagResult = False) Then
            Return result
        End If
        lop.MaLop = nextID

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@malop", lop.MaLop)
                    .Parameters.AddWithValue("@tenlop", lop.TenLop)
                    .Parameters.AddWithValue("@makhoi", lop.MaKhoi)
                    .Parameters.AddWithValue("@mahocky", lop.MaHocKy)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Thêm lớp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function update(lop As LopDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tbllop] SET"
        query &= " [tenlop] = @tenlop "
        query &= " ,[makhoi] = @makhoi "
        query &= " ,[mahocky] = @mahocky "
        query &= "WHERE "
        query &= " [malop] = @malop "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@malop", lop.MaLop)
                    .Parameters.AddWithValue("@tenlop", lop.TenLop)
                    .Parameters.AddWithValue("@makhoi", lop.MaKhoi)
                    .Parameters.AddWithValue("@mahocky", lop.MaHocKy)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập nhật lớp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function selectALL(ByRef listLop As List(Of LopDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [malop], [tenlop], [makhoi], [mahocky]"
        query &= " FROM [tbllop]"


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
                        listLop.Clear()
                        While reader.Read()
                            listLop.Add(New LopDTO(reader("malop"), reader("tenlop"), reader("makhoi"), reader("mahocky")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả lớp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function selectALL_ByMaKhoi(iMaKhoi As Integer, ByRef listLop As List(Of LopDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [malop], [tenlop], [makhoi], [mahocky]"
        query &= " FROM [tbllop]"
        query &= " WHERE "
        query &= " [makhoi] = @makhoi "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@makhoi", iMaKhoi)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listLop.Clear()
                        While reader.Read()
                            listLop.Add(New LopDTO(reader("malop"), reader("tenlop"), reader("makhoi"), reader("mahocky")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả lớp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function selectALL_ByMaKhoiAndMaHocKy(iMaKhoi As Integer, iMaHocKy As Integer, ByRef listLop As List(Of LopDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [malop], [tenlop], [makhoi], [mahocky]"
        query &= " FROM [tbllop]"
        query &= " WHERE "
        query &= " [makhoi] = @makhoi "
        query &= " AND [mahocky] = @mahocky "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@makhoi", iMaKhoi)
                    .Parameters.AddWithValue("@mahocky", iMaHocKy)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listLop.Clear()
                        While reader.Read()
                            listLop.Add(New LopDTO(reader("malop"), reader("tenlop"), reader("makhoi"), reader("mahocky")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả lớp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function delete(maLop As Integer) As Result

        Dim query As String = String.Empty
        query &= " DELETE FROM [tbllop] "
        query &= " WHERE "
        query &= " [malop] = @malop "

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
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Xóa lớp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
End Class
