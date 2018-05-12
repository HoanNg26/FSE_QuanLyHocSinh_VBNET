Imports QLHS1DTO

Public Class ChuongTrinhDTO

    Private iMaCT As Integer
    Private strTenCT As String
    Private dtNgayTao As DateTime

    Private lsCTTT As List(Of ChiTietChuongTrinhDTO)

    Public Sub New()
        iMaCT = 0
        strTenCT = String.Empty
        dtNgayTao = DateTime.Now
        lsCTTT = New List(Of ChiTietChuongTrinhDTO)

    End Sub
    Public Sub New(iMaCT As Integer, strTenCT As String, dtNgayTao As DateTime, lsCTTT As List(Of ChiTietChuongTrinhDTO))
        Me.iMaCT = iMaCT
        Me.strTenCT = strTenCT
        Me.dtNgayTao = dtNgayTao
        Me.lsCTTT = lsCTTT
    End Sub
    Public Property MaCT As Integer
        Get
            Return iMaCT
        End Get
        Set(value As Integer)
            iMaCT = value
        End Set
    End Property

    Public Property TenCT As String
        Get
            Return strTenCT
        End Get
        Set(value As String)
            strTenCT = value
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

    Public Property ListCTTT As List(Of ChiTietChuongTrinhDTO)
        Get
            Return lsCTTT
        End Get
        Set(value As List(Of ChiTietChuongTrinhDTO))
            lsCTTT = value
        End Set
    End Property
End Class
