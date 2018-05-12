Public Class LoaiHocSinhDTO

    Private iMaLoaiHS As Integer
    Private strTenLoai As String

    Public Sub New()
    End Sub
    Public Sub New(ml As Integer, tl As String)
        iMaLoaiHS = ml
        strTenLoai = tl
    End Sub
    Property MaLoaiHS() As Integer
        Get
            Return iMaLoaiHS
        End Get
        Set(ByVal Value As Integer)
            iMaLoaiHS = Value
        End Set
    End Property
    Property TenLoai() As String
        Get
            Return strTenLoai
        End Get
        Set(ByVal Value As String)
            strTenLoai = Value
        End Set
    End Property

End Class
