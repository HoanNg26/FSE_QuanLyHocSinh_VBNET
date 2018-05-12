Imports System.Configuration
Imports System.Data.SqlClient
Imports QLHS1DTO
Imports Utility

Public Class NamHocDAL
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
        query &= "SELECT TOP 1 [manamhoc] "
        query &= "FROM [tblnamhoc] "
        query &= "ORDER BY [manamhoc] DESC "

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
                            idOnDB = reader("manamhoc")
                        End While
                    End If
                    ' new ID = current ID + 1
                    nextID = idOnDB + 1
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    nextID = 1
                    Return New Result(False, "Lấy ID kế tiếp của Loại năm học không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function getNextTTNamHoc(ByRef nextTTNamHoc As Integer) As Result

        Dim query As String = String.Empty
        query &= "SELECT TOP 1 [thutunamhoc] "
        query &= "FROM [tblnamhoc] "
        query &= "ORDER BY [thutunamhoc] DESC "

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
                            ttOnDB = reader("thutunamhoc")
                        End While
                    End If
                    ' new ID = current ID + 1
                    nextTTNamHoc = ttOnDB + 1
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    nextTTNamHoc = 1
                    Return New Result(False, "Lấy ID kế tiếp của Loại năm học không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function insert(nh As NamHocDTO) As Result

        Dim query As String = String.Empty
        query &= "INSERT INTO [tblnamhoc] ([manamhoc], [tennamhoc], [thutunamhoc])"
        query &= "VALUES (@manamhoc,@tennamhoc,@thutunamhoc)"

        Dim nextID = 0
        Dim result As Result
        result = getNextID(nextID)
        If (result.FlagResult = False) Then
            Return result
        End If
        nh.MaNamHoc = nextID

        Dim nextTTNamHoc = 0
        result = getNextTTNamHoc(nextTTNamHoc)
        If (result.FlagResult = False) Then
            Return result
        End If
        nh.TTNamHoc = nextTTNamHoc

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@manamhoc", nh.MaNamHoc)
                    .Parameters.AddWithValue("@thutunamhoc", nh.TTNamHoc)
                    .Parameters.AddWithValue("@tennamhoc", nh.NamHoc)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Thêm năm học không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function update(nh As NamHocDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tblnamhoc] SET"
        query &= " [tennamhoc] = @tennamhoc "
        query &= "WHERE "
        query &= " [manamhoc] = @manamhoc "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@manamhoc", nh.MaNamHoc)
                    .Parameters.AddWithValue("@tennamhoc", nh.NamHoc)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập nhật năm học không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
    Public Function selectALL(ByRef listLoaiHS As List(Of NamHocDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [manamhoc], [tennamhoc], [thutunamhoc]"
        query &= " FROM [tblnamhoc]"


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
                        listLoaiHS.Clear()
                        While reader.Read()
                            listLoaiHS.Add(New NamHocDTO(reader("manamhoc"), reader("tennamhoc"), reader("thutunamhoc")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả loại năm học không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function delete(iMaNamHoc As Integer) As Result

        Dim query As String = String.Empty
        query &= " DELETE FROM [tblnamhoc] "
        query &= " WHERE "
        query &= " [manamhoc] = @manamhoc "

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
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Xóa năm học không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
End Class
