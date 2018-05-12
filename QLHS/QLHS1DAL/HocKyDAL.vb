Imports System.Configuration
Imports System.Data.SqlClient
Imports QLHS1DTO
Imports Utility

Public Class HocKyDAL
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
        query &= "SELECT TOP 1 [mahocky] "
        query &= "FROM [tblhocky] "
        query &= "ORDER BY [mahocky] DESC "

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
                            idOnDB = reader("mahocky")
                        End While
                    End If
                    ' new ID = current ID + 1
                    nextID = idOnDB + 1
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    nextID = 1
                    Return New Result(False, "Lấy ID kế tiếp của Học Kỳ không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function getNextTTHocKy(iMaNamHoc As Integer, ByRef nextTTHocKy As Integer) As Result

        Dim query As String = String.Empty
        query &= " SELECT TOP 1 [thutuhocky] "
        query &= " FROM [tblhocky] "
        query &= " WHERE "
        query &= " [manamhoc] = @manamhoc "
        query &= " ORDER BY "
        query &= " [thutuhocky] DESC "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@manamhoc", iMaNamHoc)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    Dim ttOnDB As Integer
                    ttOnDB = 0
                    If reader.HasRows = True Then
                        While reader.Read()
                            ttOnDB = reader("thutuhocky")
                        End While
                    End If
                    ' new ID = current ID + 1
                    nextTTHocKy = ttOnDB + 1
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    nextTTHocKy = 1
                    Return New Result(False, "Lấy Thứ Tự Học Kỳ kế tiếp của Học Kỳ không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function insert(hk As HocKyDTO) As Result

        Dim query As String = String.Empty
        query &= "INSERT INTO [tblhocky] ([mahocky], [tenhocky], [thutuhocky], [manamhoc])"
        query &= "VALUES (@mahocky,@tenhocky,@thutuhocky,@manamhoc)"

        Dim nextID = 0
        Dim result As Result
        result = getNextID(nextID)
        If (result.FlagResult = False) Then
            Return result
        End If
        hk.MaHocKy = nextID

        Dim nextTTHocKy = 0
        result = getNextTTHocKy(hk.MaNamHoc, nextTTHocKy)
        If (result.FlagResult = False) Then
            Return result
        End If
        hk.TTHocKy = nextTTHocKy

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mahocky", hk.MaHocKy)
                    .Parameters.AddWithValue("@tenhocky", hk.HocKy)
                    .Parameters.AddWithValue("@thutuhocky", hk.TTHocKy)
                    .Parameters.AddWithValue("@manamhoc", hk.MaNamHoc)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Thêm Học Kỳ không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function update(hk As HocKyDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tblhocky] SET"
        query &= " [tenhocky] = @tenhocky "
        query &= " WHERE "
        query &= " [mahocky] = @mahocky "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mahocky", hk.MaHocKy)
                    .Parameters.AddWithValue("@tenhocky", hk.HocKy)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập nhật Học Kỳ không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function selectALL(ByRef listHocKy As List(Of HocKyDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [mahocky], [tenhocky], [thutuhocky], [manamhoc]"
        query &= " FROM [tblhocky]"


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
                        listHocKy.Clear()
                        While reader.Read()
                            listHocKy.Add(New HocKyDTO(reader("mahocky"), reader("tenhocky"), reader("thutuhocky"), reader("manamhoc")))
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
        Return New Result(True) ' thanh cong
    End Function
    Public Function selectALL_ByMaNamHoc(iMaNamHoc As Integer, ByRef listHocKy As List(Of HocKyDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [mahocky], [tenhocky], [thutuhocky], [manamhoc]"
        query &= " FROM [tblhocky]"
        query &= " WHERE "
        query &= " [manamhoc] = @manamhoc "
        query &= " ORDER BY "
        query &= " [thutuhocky] ASC "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@manamhoc", iMaNamHoc)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listHocKy.Clear()
                        While reader.Read()
                            listHocKy.Add(New HocKyDTO(reader("mahocky"), reader("tenhocky"), reader("thutuhocky"), reader("manamhoc")))
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
        Return New Result(True) ' thanh cong
    End Function

    Public Function delete(maLoai As Integer) As Result

        Dim query As String = String.Empty
        query &= " DELETE FROM [tblhocky] "
        query &= " WHERE "
        query &= " [mahocky] = @mahocky "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mahocky", maLoai)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Xóa Học Kỳ không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
End Class
