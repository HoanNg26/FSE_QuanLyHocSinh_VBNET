Imports System.Configuration
Imports System.Data.SqlClient
Imports QLHS1DTO
Imports Utility

Public Class KhoiDAL
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
        query &= "SELECT TOP 1 [makhoi] "
        query &= "FROM [tblkhoi] "
        query &= "ORDER BY [makhoi] DESC "

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
                            idOnDB = reader("makhoi")
                        End While
                    End If
                    ' new ID = current ID + 1
                    nextID = idOnDB + 1
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    nextID = 1
                    Return New Result(False, "Lấy ID kế tiếp của Loại khối không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function getNextTTKhoi(ByRef nextTTKhoi As Integer) As Result

        Dim query As String = String.Empty
        query &= "SELECT TOP 1 [thutukhoi] "
        query &= "FROM [tblkhoi] "
        query &= "ORDER BY [thutukhoi] DESC "

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
                    Dim ttOnDB As Integer
                    ttOnDB = 0
                    If reader.HasRows = True Then
                        While reader.Read()
                            ttOnDB = reader("thutukhoi")
                        End While
                    End If
                    ' new ID = current ID + 1
                    nextTTKhoi = ttOnDB + 1
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    nextTTKhoi = 1
                    Return New Result(False, "Lấy ID kế tiếp của Loại khối không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function insert(nh As KhoiDTO) As Result

        Dim query As String = String.Empty
        query &= "INSERT INTO [tblkhoi] ([makhoi], [tenkhoi], [thutukhoi])"
        query &= "VALUES (@makhoi,@tenkhoi,@thutukhoi)"

        Dim nextID = 0
        Dim result As Result
        result = getNextID(nextID)
        If (result.FlagResult = False) Then
            Return result
        End If
        nh.MaKhoi = nextID

        Dim nextTTKhoi = 0
        result = getNextTTKhoi(nextTTKhoi)
        If (result.FlagResult = False) Then
            Return result
        End If
        nh.TTKhoi = nextTTKhoi

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@makhoi", nh.MaKhoi)
                    .Parameters.AddWithValue("@tenkhoi", nh.Khoi)
                    .Parameters.AddWithValue("@thutukhoi", nh.TTKhoi)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Thêm khối không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function update(nh As KhoiDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tblkhoi] SET"
        query &= " [tenkhoi] = @tenkhoi "
        query &= "WHERE "
        query &= " [makhoi] = @makhoi "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@makhoi", nh.MaKhoi)
                    .Parameters.AddWithValue("@tenkhoi", nh.Khoi)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập nhật khối không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function selectALL(ByRef listKhoi As List(Of KhoiDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [makhoi], [tenkhoi], [thutukhoi]"
        query &= " FROM [tblkhoi]"


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
                        listKhoi.Clear()
                        While reader.Read()
                            listKhoi.Add(New KhoiDTO(reader("makhoi"), reader("tenkhoi"), reader("thutukhoi")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Khối không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function delete(maLoai As Integer) As Result

        Dim query As String = String.Empty
        query &= " DELETE FROM [tblkhoi] "
        query &= " WHERE "
        query &= " [makhoi] = @makhoi "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@makhoi", maLoai)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Xóa khối không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
End Class
