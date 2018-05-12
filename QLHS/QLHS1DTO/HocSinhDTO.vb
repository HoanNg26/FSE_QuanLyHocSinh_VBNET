Public Class HocSinhDTO

    Private strMSHS As String
    Private iLoaiHS As Integer
    Private strHoten As String
    Private strDiaChi As String
    Private dateNgaySinh As DateTime
    Public Sub New()
    End Sub
    Public Sub New(strMSHS As Integer, iLoaiHS As Integer, strHoten As String, strDiaChi As String, dateNgaySinh As DateTime)
        Me.strMSHS = strMSHS
        Me.iLoaiHS = iLoaiHS
        Me.strHoten = strHoten
        Me.strDiaChi = strDiaChi
        Me.dateNgaySinh = dateNgaySinh
    End Sub
    Property MSHS() As String
        Get
            Return strMSHS
        End Get
        Set(ByVal Value As String)
            strMSHS = Value
        End Set
    End Property
    Property LoaiHS() As Integer
        Get
            Return iLoaiHS
        End Get
        Set(ByVal Value As Integer)
            iLoaiHS = Value
        End Set
    End Property
    Property HoTen() As String
        Get
            Return strHoten
        End Get
        Set(ByVal Value As String)
            strHoten = Value
        End Set
    End Property

    Property DiaChi() As String
        Get
            Return strDiaChi
        End Get
        Set(ByVal Value As String)
            strDiaChi = Value
        End Set
    End Property
    Property NgaySinh() As DateTime
        Get
            Return dateNgaySinh
        End Get
        Set(ByVal Value As DateTime)
            dateNgaySinh = Value
        End Set
    End Property
End Class
