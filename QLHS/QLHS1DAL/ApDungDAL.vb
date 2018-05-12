Imports System.Configuration
Imports System.Data.SqlClient
Imports QLHS1DTO
Imports Utility

Public Class ApDungDAL
    Private connectionString As String

    Public Sub New()
        ' Read ConnectionString value from App.config file
        connectionString = ConfigurationManager.AppSettings("ConnectionString")
    End Sub
    Public Sub New(ConnectionString As String)
        Me.connectionString = ConnectionString
    End Sub

    Public Function insert(apdung As ApDungDTO) As Result

        Dim query As String = String.Empty
        query &= "INSERT INTO [tblapdung] ([malop], [machuongtrinh], [ngayapdung])"
        query &= "VALUES (@malop,@machuongtrinh,@ngayapdung)"

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@malop", apdung.MaLop)
                    .Parameters.AddWithValue("@machuongtrinh", apdung.MaCT)
                    .Parameters.AddWithValue("@ngayapdung", apdung.NgayApDung)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Thêm áp dụng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function insertForce(apdung As ApDungDTO) As Result

        Dim query As String = String.Empty
        query &= "INSERT INTO [tblapdung] ([malop], [machuongtrinh], [ngayapdung])"
        query &= "VALUES (@malop,@machuongtrinh,@ngayapdung)"

        'Select  all of ApDung on DB with the same MaLop
        Dim listApDungOnDB = New List(Of ApDungDTO)
        Dim result = selectALL_ByMaLop(apdung.MaLop, listApDungOnDB)
        If (result.FlagResult = False) Then
            Return result
        End If
        'if ApDung existed on DB then Skip
        For Each ad In listApDungOnDB
            If (ad.MaCT = apdung.MaCT And ad.MaLop = apdung.MaLop) Then '' Existed on DB
                Return New Result(True)
            End If
            If (ad.MaLop = apdung.MaLop) Then '' Existed on DB
                result = delete(ad)
                If (result.FlagResult = False) Then
                    Return result
                End If
            End If
        Next
        'Insert new one
        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@malop", apdung.MaLop)
                    .Parameters.AddWithValue("@machuongtrinh", apdung.MaCT)
                    .Parameters.AddWithValue("@ngayapdung", apdung.NgayApDung)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Thêm áp dụng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function selectALL(ByRef listApDung As List(Of ApDungDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [tblapdung].[malop], [tblapdung].[machuongtrinh], [tblapdung].[ngayapdung], [tbllop].[tenlop], [tblchuongtrinh].[tenchuongtrinh]"
        query &= " FROM [tblapdung], [tbllop], [tblchuongtrinh]"
        query &= " WHERE "
        query &= " [tblapdung].[malop] = [tbllop].[malop] "
        query &= " AND [tblapdung].[machuongtrinh] = [tblchuongtrinh].[machuongtrinh] "


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
                        listApDung.Clear()
                        While reader.Read()
                            listApDung.Add(New ApDungDTO(reader("malop"), reader("tenlop"), reader("machuongtrinh"), reader("tenchuongtrinh"), reader("ngayapdung")))
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
    Public Function selectALL_ByMaLop(iMaLop As Integer, ByRef listApDung As List(Of ApDungDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [tblapdung].[malop], [tblapdung].[machuongtrinh], [tblapdung].[ngayapdung], [tbllop].[tenlop], [tblchuongtrinh].[tenchuongtrinh]"
        query &= " FROM [tblapdung], [tbllop], [tblchuongtrinh]"
        query &= " WHERE "
        query &= " [tblapdung].[malop] = [tbllop].[malop] "
        query &= " AND [tblapdung].[machuongtrinh] = [tblchuongtrinh].[machuongtrinh] "
        query &= " AND [tblapdung].[malop] = @malop"

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
                        listApDung.Clear()
                        While reader.Read()
                            listApDung.Add(New ApDungDTO(reader("malop"), reader("tenlop"), reader("machuongtrinh"), reader("tenchuongtrinh"), reader("ngayapdung")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Áp dụng theo mã lớp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function selectALL_ByMaCT(iMaCT As Integer, ByRef listApDung As List(Of ApDungDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [tblapdung].[malop], [tblapdung].[machuongtrinh], [tblapdung].[ngayapdung], [tbllop].[tenlop], [tblchuongtrinh].[tenchuongtrinh]"
        query &= " FROM [tblapdung], [tbllop], [tblchuongtrinh]"
        query &= " WHERE "
        query &= " [tblapdung].[malop] = [tbllop].[malop] "
        query &= " AND [tblapdung].[machuongtrinh] = [tblchuongtrinh].[machuongtrinh] "
        query &= " AND [tblchuongtrinh].[machuongtrinh] = @machuongtrinh"

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
                        listApDung.Clear()
                        While reader.Read()
                            listApDung.Add(New ApDungDTO(reader("malop"), reader("tenlop"), reader("machuongtrinh"), reader("tenchuongtrinh"), reader("ngayapdung")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Áp Dụng theo mã chương trình không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function selectALL_LeftJoin(iMaHocKy As Integer, iMaKhoi As Integer, ByRef listApDung As List(Of ApDungDTO)) As Result

        Dim query As String = String.Empty
        query &= " select [tbllop].[malop], [tbllop].[tenlop], [tblchuongtrinh].[tenchuongtrinh], [tblapdung].[machuongtrinh], [tblapdung].[ngayapdung] "
        query &= " from ([tbllop]  left join [tblapdung] on [tbllop].[malop]  = [tblapdung].[malop] ) "
        query &= " 	     left join [tblchuongtrinh]  on [tblchuongtrinh].[machuongtrinh] = [tblapdung].[machuongtrinh]   "
        query &= " where "
        query &= " 	     [tbllop].[mahocky] = @mahocky "
        query &= "   and [tbllop].[makhoi] = @makhoi "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mahocky", iMaHocKy)
                    .Parameters.AddWithValue("@makhoi", iMaKhoi)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listApDung.Clear()
                        While reader.Read()
                            'listApDung.Add(New ApDungDTO(reader("malop"), reader("tenlop"), reader("machuongtrinh"), reader("tenchuongtrinh"), reader("ngayapdung")))
                            Dim ad = New ApDungDTO()
                            ad.MaLop = reader("malop")
                            ad.TenLop = reader("tenlop")
                            If (reader("machuongtrinh") Is DBNull.Value) Then
                                ad.MaCT = -1
                            Else
                                ad.MaCT = reader("machuongtrinh")
                            End If
                            If (reader("tenchuongtrinh") Is DBNull.Value) Then
                                ad.TenCT = String.Empty
                            Else
                                ad.TenCT = reader("tenchuongtrinh")
                            End If
                            If (reader("ngayapdung") Is DBNull.Value) Then
                                ad.NgayApDung = DateTime.Now
                            Else
                                ad.NgayApDung = reader("ngayapdung")
                            End If
                            listApDung.Add(ad)
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Lớp left join với Áp Dụng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function delete(apdung As ApDungDTO) As Result

        Dim query As String = String.Empty
        query &= " DELETE FROM [tblapdung] "
        query &= " WHERE "
        query &= " [machuongtrinh] = @machuongtrinh "
        query &= " AND [malop] = @malop "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@machuongtrinh", apdung.MaCT)
                    .Parameters.AddWithValue("@malop", apdung.MaLop)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Xóa Áp Dụng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
End Class
