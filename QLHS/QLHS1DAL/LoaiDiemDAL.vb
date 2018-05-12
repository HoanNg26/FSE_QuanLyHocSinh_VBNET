Imports System.Configuration
Imports System.Data.SqlClient
Imports QLHS1DTO
Imports Utility

Public Class LoaiDiemDAL
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
        query &= "SELECT TOP 1 [maloaidiem] "
        query &= "FROM [tblloaidiem] "
        query &= "ORDER BY [maloaidiem] DESC "

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
                            idOnDB = reader("maloaidiem")
                        End While
                    End If
                    ' new ID = current ID + 1
                    nextID = idOnDB + 1
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    nextID = 1
                    Return New Result(False, "Lấy ID kế tiếp của Loại loại điểm không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thald cong
    End Function

    Public Function insert(ld As LoaiDiemDTO) As Result

        Dim query As String = String.Empty
        query &= "INSERT INTO [tblloaidiem] ([maloaidiem], [tenloaidiem], [hesomacdinh])"
        query &= "VALUES (@maloaidiem,@tenloaidiem,@hesomacdinh)"

        Dim nextID = 0
        Dim result As Result
        result = getNextID(nextID)
        If (result.FlagResult = False) Then
            Return result
        End If
        ld.MaLoaiDiem = nextID

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@maloaidiem", ld.MaLoaiDiem)
                    .Parameters.AddWithValue("@tenloaidiem", ld.LoaiDiem)
                    .Parameters.AddWithValue("@hesomacdinh", ld.HeSoMacDinh)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Thêm loại điểm không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thald cong
    End Function

    Public Function update(ld As LoaiDiemDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tblloaidiem] SET"
        query &= " [tenloaidiem] = @tenloaidiem "
        query &= " ,[hesomacdinh] = @hesomacdinh "
        query &= "WHERE "
        query &= " [maloaidiem] = @maloaidiem "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@maloaidiem", ld.MaLoaiDiem)
                    .Parameters.AddWithValue("@tenloaidiem", ld.LoaiDiem)
                    .Parameters.AddWithValue("@hesomacdinh", ld.HeSoMacDinh)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập ldật loại điểm không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thald cong
    End Function
    Public Function selectALL(ByRef listLoaiDiem As List(Of LoaiDiemDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [maloaidiem], [tenloaidiem], [hesomacdinh]"
        query &= " FROM [tblloaidiem]"


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
                        listLoaiDiem.Clear()
                        While reader.Read()
                            listLoaiDiem.Add(New LoaiDiemDTO(reader("maloaidiem"), reader("tenloaidiem"), reader("hesomacdinh")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả loại loại điểm không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thald cong
    End Function

    Public Function delete(maLoai As Integer) As Result

        Dim query As String = String.Empty
        query &= " DELETE FROM [tblloaidiem] "
        query &= " WHERE "
        query &= " [maloaidiem] = @maloaidiem "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@maloaidiem", maLoai)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Xóa loại điểm không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thald cong
    End Function
End Class
