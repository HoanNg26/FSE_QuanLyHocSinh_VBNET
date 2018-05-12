Public Class DiemDTO
    Private strMSHS As String
    Private iMaHTDG As Integer
    Private fDiem As Single
    Private dtNgayNhap As DateTime
    Private dtNgayCapNhat As DateTime
    Private strUserIdNhap As String
    Private strUserIdCapNhat As String

    Property MSHS() As String
        Get
            Return strMSHS
        End Get
        Set(ByVal Value As String)
            strMSHS = Value
        End Set
    End Property
    Public Property MaHTDG As Integer
        Get
            Return iMaHTDG
        End Get
        Set(value As Integer)
            iMaHTDG = value
        End Set
    End Property

    Public Property Diem As Single
        Get
            Return fDiem
        End Get
        Set(value As Single)
            fDiem = value
        End Set
    End Property
    Public Property NgayNhap As DateTime
        Get
            Return dtNgayNhap
        End Get
        Set(value As Date)
            dtNgayNhap = value
        End Set
    End Property
    Public Property NgayCapNhat As DateTime
        Get
            Return dtNgayCapNhat
        End Get
        Set(value As Date)
            dtNgayCapNhat = value
        End Set
    End Property

    Public Property UserIdNhap As String
        Get
            Return strUserIdNhap
        End Get
        Set(value As String)
            strUserIdNhap = value
        End Set
    End Property

    Public Property UserIdCapNhat As String
        Get
            Return strUserIdCapNhat
        End Get
        Set(value As String)
            strUserIdCapNhat = value
        End Set
    End Property
End Class
