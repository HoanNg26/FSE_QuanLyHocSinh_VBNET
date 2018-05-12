Imports QLHS1DTO

Public Class ChuongTrinhHocDTO
    Private iMaChuongTrinh As Integer
    Private strTenChuongTrinh As String
    Private dtNgayTao As DateTime
    Private lsMonHoc As List(Of MonHocDTO)

    Public Property MaChuonTrinh As Integer
        Get
            Return iMaChuongTrinh
        End Get
        Set(value As Integer)
            iMaChuongTrinh = value
        End Set
    End Property

    Public Property TenChuongTrinh As String
        Get
            Return strTenChuongTrinh
        End Get
        Set(value As String)
            strTenChuongTrinh = value
        End Set
    End Property

    Public Property NgayTao As DateTime
        Get
            Return dtNgayTao
        End Get
        Set(value As Date)
            dtNgayTao = value
        End Set
    End Property

    Public Property ListMonHoc As List(Of MonHocDTO)
        Get
            Return lsMonHoc
        End Get
        Set(value As List(Of MonHocDTO))
            lsMonHoc = value
        End Set
    End Property

    Public Sub New()
        Me.iMaChuongTrinh = 0
        Me.strTenChuongTrinh = String.Empty
        Me.dtNgayTao = DateTime.Now
        Me.lsMonHoc = New List(Of MonHocDTO)
    End Sub
    Public Sub New(iMaChuongTrinh As Integer, strTenChuongTrinh As String, dtNgayTao As DateTime, listMonHoc As List(Of MonHocDTO))
        Me.iMaChuongTrinh = iMaChuongTrinh
        Me.strTenChuongTrinh = strTenChuongTrinh
        Me.dtNgayTao = dtNgayTao
        Me.lsMonHoc = listMonHoc
    End Sub
End Class
